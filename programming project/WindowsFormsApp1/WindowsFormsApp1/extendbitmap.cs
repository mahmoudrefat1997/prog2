using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;


namespace WindowsFormsApp1
{
  

        public static class ExtBitmap
        {
            public static Bitmap CopyToSquareCanvas(this Bitmap sourceBitmap, int canvasWidthLenght)
            {
                float ratio = 1.0f;
                int maxSide = sourceBitmap.Width > sourceBitmap.Height ?
                              sourceBitmap.Width : sourceBitmap.Height;

                ratio = (float)maxSide / (float)canvasWidthLenght;

                Bitmap bitmapResult = (sourceBitmap.Width > sourceBitmap.Height ?
                                        new Bitmap(canvasWidthLenght, (int)(sourceBitmap.Height / ratio))
                                        : new Bitmap((int)(sourceBitmap.Width / ratio), canvasWidthLenght));

                using (Graphics graphicsResult = Graphics.FromImage(bitmapResult))
                {
                    graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                    graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    graphicsResult.DrawImage(sourceBitmap,
                                            new Rectangle(0, 0,
                                                bitmapResult.Width, bitmapResult.Height),
                                            new Rectangle(0, 0,
                                                sourceBitmap.Width, sourceBitmap.Height),
                                                GraphicsUnit.Pixel);
                    graphicsResult.Flush();
                }

                return bitmapResult;
            }

            public static Bitmap ConvolutionFilter<T>(this Bitmap sourceBitmap, T filter)
                                             where T : ConvolutionFilterBase
            {
                BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                         sourceBitmap.Width, sourceBitmap.Height),
                                         ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
                byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

                Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                sourceBitmap.UnlockBits(sourceData);

                double blue = 0.0;
                double green = 0.0;
                double red = 0.0;

                int filterWidth = filter.FilterMatrix.GetLength(1);
                int filterHeight = filter.FilterMatrix.GetLength(0);

                int filterOffset = (filterWidth - 1) / 2;
                int calcOffset = 0;

                int byteOffset = 0;

                for (int offsetY = filterOffset; offsetY <
                    sourceBitmap.Height - filterOffset; offsetY++)
                {
                    for (int offsetX = filterOffset; offsetX <
                        sourceBitmap.Width - filterOffset; offsetX++)
                    {
                        blue = 0;
                        green = 0;
                        red = 0;

                        byteOffset = offsetY *
                                     sourceData.Stride +
                                     offsetX * 4;

                        for (int filterY = -filterOffset;
                            filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset;
                                filterX <= filterOffset; filterX++)
                            {

                                calcOffset = byteOffset +
                                             (filterX * 4) +
                                             (filterY * sourceData.Stride);

                                blue += (double)(pixelBuffer[calcOffset]) *
                                        filter.FilterMatrix[filterY + filterOffset,
                                                            filterX + filterOffset];

                                green += (double)(pixelBuffer[calcOffset + 1]) *
                                         filter.FilterMatrix[filterY + filterOffset,
                                                            filterX + filterOffset];

                                red += (double)(pixelBuffer[calcOffset + 2]) *
                                       filter.FilterMatrix[filterY + filterOffset,
                                                          filterX + filterOffset];
                            }
                        }

                        blue = filter.Factor * blue + filter.Bias;
                        green = filter.Factor * green + filter.Bias;
                        red = filter.Factor * red + filter.Bias;

                        if (blue > 255)
                        { blue = 255; }
                        else if (blue < 0)
                        { blue = 0; }

                        if (green > 255)
                        { green = 255; }
                        else if (green < 0)
                        { green = 0; }

                        if (red > 255)
                        { red = 255; }
                        else if (red < 0)
                        { red = 0; }

                        resultBuffer[byteOffset] = (byte)(blue);
                        resultBuffer[byteOffset + 1] = (byte)(green);
                        resultBuffer[byteOffset + 2] = (byte)(red);
                        resultBuffer[byteOffset + 3] = 255;
                    }
                }

                Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

                BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                         resultBitmap.Width, resultBitmap.Height),
                                         ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
                resultBitmap.UnlockBits(resultData);

                return resultBitmap;
            }


        public static string ASCIIFilter(this Bitmap sourceBitmap, int pixelBlockSize,
                                                                   int colorCount = 0)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                    sourceBitmap.Width, sourceBitmap.Height),
                                                      ImageLockMode.ReadOnly,
                                                PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            StringBuilder asciiArt = new StringBuilder();

            int avgBlue = 0;
            int avgGreen = 0;
            int avgRed = 0;
            int offset = 0;

            int rows = sourceBitmap.Height / pixelBlockSize;
            int columns = sourceBitmap.Width / pixelBlockSize;

            colorCharacters = "*+|-.'   ";

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    avgBlue = 0;
                    avgGreen = 0;
                    avgRed = 0;

                    for (int pY = 0; pY < pixelBlockSize; pY++)
                    {
                        for (int pX = 0; pX < pixelBlockSize; pX++)
                        {
                            offset = y * pixelBlockSize * sourceData.Stride +
                                     x * pixelBlockSize * 4;

                            offset += pY * sourceData.Stride;
                            offset += pX * 4;

                            avgBlue += pixelBuffer[offset];
                            avgGreen += pixelBuffer[offset + 1];
                            avgRed += pixelBuffer[offset + 2];
                        }
                    }

                    avgBlue = avgBlue / (pixelBlockSize * pixelBlockSize);
                    avgGreen = avgGreen / (pixelBlockSize * pixelBlockSize);
                    avgRed = avgRed / (pixelBlockSize * pixelBlockSize);

                    asciiArt.Append(GetColorCharacter(avgBlue, avgGreen,  avgRed));
                }

                asciiArt.Append("\r\n");
            }
            
            return asciiArt.ToString();
        }

        private static string GenerateRandomString(int maxSize)
        {
            StringBuilder stringBuilder = new StringBuilder(maxSize);
            Random randomChar = new Random();

            char charValue;

            for (int k = 0; k < maxSize; k++)
            {
                charValue = (char)(Math.Floor(255 * randomChar.NextDouble() * 4));

                if (stringBuilder.ToString().IndexOf(charValue) != -1)
                {
                    charValue = (char)(Math.Floor((byte)charValue *
                                            randomChar.NextDouble()));
                }

                if (Char.IsControl(charValue) == false &&
                    Char.IsPunctuation(charValue) == false &&
                    stringBuilder.ToString().IndexOf(charValue) == -1)
                {
                    stringBuilder.Append(charValue);

                    randomChar = new Random((int)((byte)charValue *
                                     (k + 1) + DateTime.Now.Ticks));
                }
                else
                {
                    randomChar = new Random((int)((byte)charValue *
                                     (k + 1) + DateTime.UtcNow.Ticks));
                    k -= 1;
                }
            }

            return stringBuilder.ToString().RandomStringSort();
        }

        public static string RandomStringSort(this string stringValue)
        {
            char[] charArray = stringValue.ToCharArray();

            Random randomIndex = new Random((byte)charArray[0]);
            int iterator = charArray.Length;

            while (iterator > 1)
            {
                iterator -= 1;

                int nextIndex = randomIndex.Next(iterator + 1);

                char nextValue = charArray[nextIndex];
                charArray[nextIndex] = charArray[iterator];
                charArray[iterator] = nextValue;
            }

            return new string(charArray);
        }

        private static string colorCharacters ;

        private static string GetColorCharacter(int blue, int green, int red)
        {
            string colorChar = String.Empty;
            int intensity =((blue + green + red) / 3)
                * (colorCharacters.Length - 1) / 255;

            colorChar = colorCharacters.Substring(intensity, 1).ToUpper();
            colorChar += colorChar.ToLower();

            return colorChar;
        }

        public static Bitmap TextToImage(this string text, Font font,
                                                        float factor)
        {
            Bitmap textBitmap = new Bitmap(1, 1);

            Graphics graphics = Graphics.FromImage(textBitmap);

            int width = (int)Math.Ceiling(
                        graphics.MeasureString(text, font).Width *
                        factor);

            int height = (int)Math.Ceiling(
                         graphics.MeasureString(text, font).Height *
                         factor);

            graphics.Dispose();

            textBitmap = new Bitmap(width, height,
                                    PixelFormat.Format32bppArgb);

            graphics = Graphics.FromImage(textBitmap);
            graphics.Clear(Color.Black);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            graphics.ScaleTransform(factor, factor);
            graphics.DrawString(text, font, Brushes.White, new PointF(0, 0));

            graphics.Flush();
            graphics.Dispose();

            return textBitmap;
        }

        public static Bitmap ScaleBitmap(this Bitmap sourceBitmap, float factor)
        {
            Bitmap resultBitmap = new Bitmap((int)(sourceBitmap.Width * factor),
                                             (int)(sourceBitmap.Height * factor),
                                             PixelFormat.Format32bppArgb);

            Graphics graphics = Graphics.FromImage(resultBitmap);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            graphics.DrawImage(sourceBitmap,
                new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height),
                new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                                                         GraphicsUnit.Pixel);

            return resultBitmap;
        }
    


}
        }
