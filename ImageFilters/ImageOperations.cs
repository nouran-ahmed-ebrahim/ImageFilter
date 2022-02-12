using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageFilters
{
    public class ImageOperations
    {
        /// <summary>
        /// Open an image, convert it to gray scale and load it into 2D array of size (Height x Width)
        /// </summary>
        /// <param name="ImagePath">Image file path</param>
        /// <returns>2D array of gray values</returns>
        public static byte[,] OpenImage(string ImagePath)
        {
            Bitmap original_bm = new Bitmap(ImagePath);
            int Height = original_bm.Height;
            int Width = original_bm.Width;

            byte[,] Buffer = new byte[Height, Width];

            unsafe
            {
                BitmapData bmd = original_bm.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, original_bm.PixelFormat);
                int x, y;
                int nWidth = 0;
                bool Format32 = false;
                bool Format24 = false;
                bool Format8 = false;

                if (original_bm.PixelFormat == PixelFormat.Format24bppRgb)
                {
                    Format24 = true;
                    nWidth = Width * 3;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format32bppArgb || original_bm.PixelFormat == PixelFormat.Format32bppRgb || original_bm.PixelFormat == PixelFormat.Format32bppPArgb)
                {
                    Format32 = true;
                    nWidth = Width * 4;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    Format8 = true;
                    nWidth = Width;
                }
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (y = 0; y < Height; y++)
                {
                    for (x = 0; x < Width; x++)
                    {
                        if (Format8)
                        {
                            Buffer[y, x] = p[0];
                            p++;
                        }
                        else
                        {
                            Buffer[y, x] = (byte)((int)(p[0] + p[1] + p[2]) / 3);
                            if (Format24) p += 3;
                            else if (Format32) p += 4;
                        }
                    }
                    p += nOffset;
                }
                original_bm.UnlockBits(bmd);
            }

            return Buffer;
        }

        /// <summary>
        /// Get the height of the image 
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <returns>Image Height</returns>
        public static int GetHeight(byte[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(0);
        }

        /// <summary>
        /// Get the width of the image 
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <returns>Image Width</returns>
        public static int GetWidth(byte[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(1);
        }

        /// <summary>
        /// Display the given image on the given PictureBox object
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <param name="PicBox">PictureBox object to display the image on it</param>
        public static void DisplayImage(byte[,] ImageMatrix, PictureBox PicBox)
        {
            // Create Image:
            //==============
            int Height = ImageMatrix.GetLength(0);
            int Width = ImageMatrix.GetLength(1);

            Bitmap ImageBMP = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            unsafe
            {
                BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);
                int nWidth = 0;
                nWidth = Width * 3;
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        p[0] = p[1] = p[2] = ImageMatrix[i, j];
                        p += 3;
                    }

                    p += nOffset;
                }
                ImageBMP.UnlockBits(bmd);
            }
            PicBox.Image = ImageBMP;
        }


        public static byte[,] AlphaTrim(byte[,] arr, int T, int windowSize, char trimAlgorthim)
        // trimAlgorthim : c stands to trim using counting sort
        //               : K stands to trim using  randomize selection
        {
            int paddingSize = windowSize / 2;
            int realImageHigh = ImageOperations.GetHeight(arr);
            int reaImageWidth = ImageOperations.GetWidth(arr);
            byte[,] newImage = new byte[realImageHigh, reaImageWidth];
            byte[] windowValues = new byte[windowSize * windowSize];
            byte[,] imageWithPadding = AddPadding(arr, paddingSize, realImageHigh, reaImageWidth);
            for (int i = paddingSize ,k =0; i < realImageHigh + paddingSize; i++, k++)
            {
                for (int j = paddingSize, l = 0; j < reaImageWidth + paddingSize; j++ , l++)
                {
                    windowValues = ExtractWindow(imageWithPadding, i, j, windowSize);
                    if (trimAlgorthim == 'c')
                    {
                        newImage[k, l] = TrimUsingCountingSort(windowValues, T);
                    }
                    else
                    {
                        newImage[k, l] = TrimUsingSelectingKth(windowValues, T);
                    }
                }
            }
            return newImage;
           
        }

        public static byte[,] AdaptiveMedian(byte[,] arr, int maxWindowSize, char sortingAlgorthim)
        {
            int paddingSize = maxWindowSize / 2;
            int realImageHigh = ImageOperations.GetHeight(arr);
            int reaImageWidth = ImageOperations.GetWidth(arr);
            byte[,] newImage = new byte[realImageHigh, reaImageWidth];
            byte[,]  imageWithPadding = AddPadding(arr, paddingSize, realImageHigh, reaImageWidth);
            for (int i = paddingSize; i < realImageHigh + paddingSize; i++)
            {
                for (int j = paddingSize; j < reaImageWidth + paddingSize; j++)
                {
                    HandleCell(imageWithPadding,newImage, j, i, 3, maxWindowSize,paddingSize, sortingAlgorthim);
                }
            }
            return newImage;
        }

        private static void HandleCell(byte[,] oldImage,byte[,] newImage, int col, int row, int currentWindowSize, 
                                                         int maxWindowSize, int paddingSize, char sortingAlgorithm)
        {
            byte[] windowValues = new byte[currentWindowSize * currentWindowSize];
            windowValues = ExtractWindow(oldImage, row, col, currentWindowSize);

            if (sortingAlgorithm == 'c')
            {
                windowValues = CountingSort(windowValues);
            }
            else
            {
                windowValues = QuickSort(windowValues,0,windowValues.Length-1);
            }
            int max = (int)windowValues[windowValues.Length - 1];
            int median = (int)windowValues[windowValues.Length / 2];
            int A1 = median - (int)windowValues[0];
            int A2 = max - median;
            
            if(A1>0 && A2>0)
            {
                ReplaceCell(oldImage,newImage, row , col, paddingSize , median, (int)windowValues[0], max);
            }
            else
            {
                if (currentWindowSize < maxWindowSize)
                    HandleCell(oldImage, newImage, col, row, currentWindowSize + 2, maxWindowSize,paddingSize, sortingAlgorithm);
                else
                    newImage[row - paddingSize, col - paddingSize] = (byte)median;

            }

        }
        private static void ReplaceCell(byte[,] oldImage, byte[,] newImage, int row, int col, int padding, int median ,int min, int max)
        {
            int B1 = max - (int)oldImage[row, col];
            int B2 = (int)oldImage[row, col] - min;

            if(B1>0 && B2>0)
            {
                newImage[row - padding, col - padding] = oldImage[row, col];
            }
            else 
            {
                newImage[row - padding, col- padding] = (byte)median;
            }

        }
        private static byte TrimUsingCountingSort(byte[] windowValues, int T)
        {
            int avg = 0;
            windowValues = CountingSort(windowValues);
            for (int i = T; i < windowValues.Length - T; i++)
            {
                avg += (int)windowValues[i];
            }
            avg /= (windowValues.Length - (T * 2));
            return (byte)avg;
        }
        public static byte[] CountingSort(byte[] arr)
        {
            int[] comulative = new int[256];
            byte[] sorted = new byte[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                comulative[(int)arr[i]]++;
            }

            for (int i = 1; i < 256; i++)
            {
                comulative[i] += comulative[i - 1];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                sorted[--comulative[(int)arr[i]]] = arr[i];
            }

            return sorted;
        }

        private static byte TrimUsingSelectingKth(byte[] windowValues, int T)
        {
            int tMax = T;
            int tMin = T;
            int sum = 0;
            int tLargest = windowValues.Length - T + 1;
            int numOfElements = 0;
            int tMinValue = (int)RandomSelection(windowValues, 0, windowValues.Length - 1, T);
            int tMaxValue = (int)RandomSelection(windowValues, 0, windowValues.Length - 1, tLargest);

            for (int i = 0 ; i < windowValues.Length ; i++)
            {
                if(windowValues[i] < tMinValue)
                {
                    tMin--;
                }
                else if(windowValues[i] > tMaxValue)
                {
                    tMax--;
                }
                else
                {
                    sum += (int)windowValues[i];
                    numOfElements++;
                }
            }
            numOfElements -= (tMax + tMin);
            sum -= (tMinValue * tMin + tMaxValue * tMax);
            return (byte)(sum/numOfElements);
        }
        private static byte[] ExtractWindow(byte[,] arr, int row, int col, int windowSize)
        {
            int padding = (windowSize / 2);
            byte[] windowValues = new byte[windowSize * windowSize];

            for (int i = row - padding, arrIdx = 0; i <= row + padding; i++)
            {
                for (int j = col - padding; j <= col + padding; j++, arrIdx++)
                {
                    windowValues[arrIdx] = arr[i, j];
                }
            }
            return windowValues;
        }
        private static byte[,] AddPadding(byte[,] image, int paddingSize, int imageHigh, int imageWidth)
        {
            int newImageHigh = imageHigh + 2 * paddingSize;
            int newImageWidth = imageWidth + 2 * paddingSize;
            byte[,] imageWithPadding = new byte[newImageHigh, newImageWidth];

            //copy original image into bigger matrix 
            for (int i = paddingSize; i < imageHigh + paddingSize; i++)
            {
                for (int j = paddingSize; j < imageWidth + paddingSize; j++)
                {
                    imageWithPadding[i, j] = image[i - paddingSize, j - paddingSize];
                }
            }

            for (int i = paddingSize; i < paddingSize +imageHigh; i++)
            {
                for (int j = 0; j < paddingSize; j++)
                {
                    imageWithPadding[i, j] = image[i - paddingSize, 0];
                    imageWithPadding[i, newImageWidth - j -1] = image[i - paddingSize, imageWidth-1];
                }
            }

            for (int i = 0; i < paddingSize ; i++)
            {
                for (int j = paddingSize; j < paddingSize + imageWidth; j++)
                {
                    imageWithPadding[i, j] = image[0, j - paddingSize];
                    imageWithPadding[i + imageHigh + paddingSize, j] = image[imageHigh - 1, j - paddingSize];
                }
            }

            for (int i = 0; i < paddingSize; i++)
            {
                for (int j = 0; j < paddingSize; j++)
                {
                    imageWithPadding[i, j] = image[0, 0];
                    imageWithPadding[newImageHigh -1 - i, j] = image[imageHigh-1,0];
                }
            }
            
            for (int i = 0; i < paddingSize; i++)
            {
                for (int j = imageWidth; j < newImageWidth; j++)
                {
                    imageWithPadding[i, j] = image[0, imageWidth-1];
                    imageWithPadding[newImageHigh -1 - i,  j] = image[imageHigh - 1, 0];
                }
            }
            return imageWithPadding;
        }
        private static int QuickPartion(byte[] arr, int low, int high)
        {

            int i = low; byte pivot = arr[high];

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    Swap(arr, i++, j);
                }
            }

            Swap(arr, i, high);
            return i;
        }
        private static void Swap(byte[] arr, int num1Idx, int num2Idx)
        {
            byte temp = arr[num1Idx];
            arr[num1Idx] = arr[num2Idx];
            arr[num2Idx] = temp;

        }
        private static byte[] QuickSort(byte[] arr, int low, int high)
        {
            if (high > low) // not (high == low || high < 0)
            {
                int pivot = QuickPartion(arr, low, high);

                QuickSort(arr, low, pivot - 1);
                QuickSort(arr, pivot + 1, high);
            }
            return arr;
        }
        private static byte RandomSelection(byte[] arr, int start, int end, int T)
        {
            if (start == end)
            {
                return arr[start];
            }

            int pivotIndex = RandomPartion(arr, start, end);
            int pivotOrder = pivotIndex - start + 1; // pivotOrder in the new array

            if (T == pivotOrder)
            {
                return arr[pivotIndex];
            }
            else if (T < pivotOrder)
            {
                return RandomSelection(arr, start, pivotIndex - 1, T);
            }
            else
            {
                return RandomSelection(arr, pivotIndex + 1, end, T - pivotOrder);
            }
        }
        private static int RandomPartion(byte[] arr, int start, int end)
        {
            int arrLength = end - start + 1;
            Random randomNum = new Random();
            int pivotIndex = randomNum.Next(arrLength);
            Swap(arr, (start + pivotIndex), end);
            return QuickPartion(arr, start, end);
        }
       
    }
}