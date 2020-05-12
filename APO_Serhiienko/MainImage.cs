using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO_Serhiienko
{
    class MinMaxPixel
    {
        public int min, max;
        public MinMaxPixel()
        {
            min = 255;
            max = 0;
        }
    }
    enum equalizationMethods
    {
        first, second, third, mine
    }
    enum operationName
    {
        add, sub, diff, or, and, xor
    }
    enum masksAplied
    {
        onNine, onTen, onSixteen, cyfrowaLaplas, laplasA, laplasB, laplasC, laplasD, edgeOne, edgeTwo, edgeThree, firstUniq, secondUniq, firstSobel, secondSobel, firstPrewitt, secondPrewitt
    }
    enum maskSize
    {
        three = 0, five = 1, seven = 2
    }
    enum edgeMethods
    {
        first, second, third, mine
    }
    enum scaleMethods
    {
        first, second, third
    }
    enum morfOperation
    {
        Erosion, Dilatation, Opening, Closing
    }
    enum structElement
    {
        rhomb, square
    }
    class MainImage
    {
        static readonly int levels = 256;
        public string imageLocation { get; }
        public Bitmap imageBitMap { get; set; }
        public Bitmap overlayBitMap { get; set; }

        public long[] histMain;
        short[,] rhombElement = new short[3, 3] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
        short[,] squareELement = new short[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

        Form1 mainForm { get; }

        public MainImage(string imgLoc, Bitmap imgBitMap)
        {
            imageLocation = imgLoc;
            imageBitMap = ConvertTo8bpp(imgBitMap);
        }
        public Bitmap ConvertTo8bpp(Bitmap bmpToConvert)
        {
            if (bmpToConvert.PixelFormat == PixelFormat.Format8bppIndexed) { return bmpToConvert; }
            Bitmap bmp8bpp = Grayscale.CommonAlgorithms.BT709.Apply(bmpToConvert);
            return bmp8bpp;
        }
        private byte GetPixelXY(int x, int y, BitmapData bmData)
        {
            unsafe
            {
                byte* ptr = (byte*)((byte*)bmData.Scan0 + (y * bmData.Stride) + x);
                return *ptr;
            }
        }
        private void SetPixelXY(int x, int y, BitmapData bmData, byte value)
        {
            unsafe
            {
                byte* ptr = (byte*)((byte*)bmData.Scan0 + (y * bmData.Stride) + x);
                *ptr = value;
            }
        }
        private void LockImage(Bitmap bmp, out BitmapData bmData, out int bytesPerPixel, out int heightInPixels, out int widthInPixels)
        {
            bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
            bytesPerPixel = Bitmap.GetPixelFormatSize(imageBitMap.PixelFormat) / 8;
            heightInPixels = imageBitMap.Height;
            widthInPixels = imageBitMap.Width * bytesPerPixel;
        }
        private void LockImage(Bitmap bmp, out BitmapData bmData)
        {
            bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
        }
        public void GetHistogram()
        {
            long[] histogram = new long[levels];
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;

            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                unsafe
                {
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            histogram[GetPixelXY(x,y,bmData)]++;
                        }
                    }
                }
                imageBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imageBitMap.UnlockBits(bmData);
                }
                catch
                {
                }
            }
            histMain = histogram;
        }
        public void StretchHistogram()
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            try
            {
                MinMaxPixel minMax = MaxMinPixelsMeth();
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                int multiplier = minMax.max != 0 ? 255 / (minMax.max - minMax.min) : 0;
                int newPixel;
                unsafe
                {
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            int oldPixel = GetPixelXY(x, y, bmData);
                            if (oldPixel <= minMax.min || oldPixel > minMax.max) newPixel = 0;
                            else newPixel = (oldPixel - minMax.min) * multiplier;
                            SetPixelXY(x, y, bmData, (byte)newPixel);
                        }
                    }
                }
                imageBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imageBitMap.UnlockBits(bmData);
                    throw new Exception("Error in stretch histogram function");

                }
                catch
                {
                    throw new Exception("Error in stretch histogram function");

                }
            }
        }
        public void EqualizationHistogram(equalizationMethods eqMeth)
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            long[] histogram = this.histMain;
            long histAvg = (int)Math.Round(histogram.Average());
            long R = 0, histCalk = 0;
            long[] left = new long[levels];
            long[] right = new long[levels];
            long[] _new = new long[levels];
            byte newPixel = 0;
            Random rnd = new Random();
            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                Point[] neighbourPoints = new Point[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1), new Point(1, 1), new Point(-1, -1), new Point(-1, 1), new Point(1, -1) };
                for (int i = 0; i < neighbourPoints.Length; i++)
                {
                    neighbourPoints[i].X = neighbourPoints[i].X * bytesPerPixel;
                }
                for (int z = 0; z < levels; z++)
                {
                    left[z] = R;
                    histCalk += histogram[z];
                    while (histCalk > histAvg)
                    {
                        histCalk -= histAvg;
                        R++;
                    }
                    right[z] = R;
                    switch (eqMeth)
                    {
                        case equalizationMethods.first:
                            _new[z] = (left[z] + right[z]) / 2;
                            break;
                        case equalizationMethods.second:
                            _new[z] = right[z] - left[z];
                            break;
                        case equalizationMethods.mine:
                            _new[z] = right[z] - left[z] / 2;
                            break;
                        default:
                            break;
                    }
                }
                unsafe
                {
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            if (left[GetPixelXY(x,y,bmData)] == right[GetPixelXY(x, y, bmData)])
                            {
                                SetPixelXY(x, y, bmData, (byte)left[GetPixelXY(x, y, bmData)]);
                            }
                            else
                            {
                                switch (eqMeth)
                                {
                                    case equalizationMethods.first:
                                        SetPixelXY(x, y, bmData, (byte)_new[GetPixelXY(x, y, bmData)]);
                                        break;
                                    case equalizationMethods.second:
                                        newPixel = (byte)(left[GetPixelXY(x, y, bmData)] + rnd.Next(0, (int)_new[GetPixelXY(x, y, bmData)]));
                                        SetPixelXY(x, y, bmData, newPixel);
                                        break;
                                    case equalizationMethods.third:
                                        int avg = 0, count = 0;
                                        foreach (var Point in neighbourPoints)
                                        {
                                            if (x + Point.X >= 0 && x + Point.X < widthInPixels && y + Point.Y >= 0 && y + Point.Y < heightInPixels)
                                            {
                                                avg += GetPixelXY(x + Point.X, y + Point.Y, bmData);
                                                ++count;
                                            }
                                        }
                                        avg /= count;
                                        if (avg > right[GetPixelXY(x, y, bmData)]) newPixel = (byte)right[GetPixelXY(x, y, bmData)];
                                        else if (avg < left[GetPixelXY(x, y, bmData)]) newPixel = (byte)left[GetPixelXY(x, y, bmData)];
                                        else newPixel = (byte)avg;
                                        SetPixelXY(x, y, bmData, newPixel);
                                        break;
                                    case equalizationMethods.mine:
                                        newPixel = (byte)(left[GetPixelXY(x, y, bmData)] + (int)_new[GetPixelXY(x, y, bmData)]);
                                        SetPixelXY(x, y, bmData, newPixel);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
                imageBitMap.UnlockBits(bmData);
            }
            catch
            {
                throw new Exception("Error in stretch histogram function");
            }
        }
        public MinMaxPixel MaxMinPixelsMeth()
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            MinMaxPixel minMax = new MinMaxPixel();
            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                unsafe
                {
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            minMax.max = Math.Max(minMax.max, GetPixelXY(x, y, bmData));
                            minMax.min = Math.Min(minMax.min, GetPixelXY(x, y, bmData));
                        }
                    }
                }
                imageBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imageBitMap.UnlockBits(bmData);
                    throw new Exception("Some problem in minMax func");

                }
                catch
                {
                    throw new Exception("Some problem in minMax func");
                }
            }
            return minMax;
        }

        public void OnePointOperation(string operation)
        {
            switch (operation)
            {
                case "Invert":
                    Invert invert = new Invert();
                    invert.ApplyInPlace(imageBitMap);
                    break;
                case "Threshold":
                    Threshold threshold = new Threshold();
                    threshold.ApplyInPlace(imageBitMap);
                    break;
                case "Reduction":
                    ReductionImage();
                    break;
                default:
                    break;
            }
        }
        public void ReductionImage()
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            int p0 = 50;
            int p1 = 100;
            int p2 = 150;
            int p3 = 200;
            int p4 = levels - 1;
            int q0 = 0;
            int q1 = 75;
            int q2 = 125;
            int q3 = 175;
            int q4 = levels - 1;
            int[] pArray = new int[5] { p0, p1, p2, p3, p4 };
            int[] qArray = new int[5] { q0, q1, q2, q3, q4 };
            int PQArraySize = 5;
            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                unsafe
                {
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            for (int i = 0; i < PQArraySize; i++)
                            {
                                if (GetPixelXY(x, y, bmData) <= pArray[i])
                                {
                                    SetPixelXY(x, y, bmData, (byte)qArray[i]);
                                    break;
                                }
                            }
                        }
                    }
                }
                imageBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imageBitMap.UnlockBits(bmData);
                }
                catch
                {
                }
            }
        }
        public void ThresholdLevelSave(int start, int end)
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;

            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                unsafe
                {
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            if (GetPixelXY(x, y, bmData) < start || GetPixelXY(x, y, bmData) > end)
                            {
                                SetPixelXY(x, y, bmData, 0);
                            }
                        }
                    }
                }
                imageBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imageBitMap.UnlockBits(bmData);
                }
                catch
                {
                }
            }
        }

        public void StretchGrayLevel(int start, int end)
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            byte newPixel = 0;

            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                unsafe
                {
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            if (GetPixelXY(x, y, bmData) < start || GetPixelXY(x, y, bmData) > end)
                            {
                                SetPixelXY(x, y, bmData, 0);
                            }
                            else
                            {
                                newPixel = (byte)((GetPixelXY(x, y, bmData) - start) * (levels - 1) / (end - start));
                                SetPixelXY(x, y, bmData, newPixel);
                            }
                        }
                    }
                }
                imageBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imageBitMap.UnlockBits(bmData);
                }
                catch
                {
                }
            }
        }
        public void OperationArithmeticLogical(operationName operation)
        {

            switch (operation)
            {
                case operationName.add:
                    Add filterAdd = new Add(overlayBitMap);
                    filterAdd.ApplyInPlace(imageBitMap);
                    break;
                case operationName.sub:
                    Subtract filterSub = new Subtract(overlayBitMap);
                    filterSub.ApplyInPlace(imageBitMap);
                    break;
                case operationName.diff:
                    Difference filterDiff = new Difference(overlayBitMap);
                    filterDiff.ApplyInPlace(imageBitMap);
                    break;
                case operationName.or:
                    LogicalOpImage(operation);
                    break;
                case operationName.and:
                    LogicalOpImage(operation);
                    break;
                case operationName.xor:
                    LogicalOpImage(operation);
                    break;
                default:
                    break;
            }
        }

        public void LogicalOpImage(operationName operation)
        {
            BitmapData bmData1 = null;
            BitmapData bmData2 = null;
            BitmapData bmDataResult = null;
            Bitmap bit1 = null;
            Bitmap bit2 = null;
            byte newPixel = 0;

            try
            {
                bmData1 = imageBitMap.LockBits(new Rectangle(0, 0, imageBitMap.Width, imageBitMap.Height), ImageLockMode.ReadOnly, imageBitMap.PixelFormat);
                bmData2 = overlayBitMap.LockBits(new Rectangle(0, 0, overlayBitMap.Width, overlayBitMap.Height), ImageLockMode.ReadOnly, overlayBitMap.PixelFormat);
                int bytesPerPixel = Bitmap.GetPixelFormatSize(imageBitMap.PixelFormat) / 8;
                int heightInPixels = overlayBitMap.Height > imageBitMap.Height ? overlayBitMap.Height : imageBitMap.Height;
                int widthInPixels = overlayBitMap.Width > imageBitMap.Width ? overlayBitMap.Width * bytesPerPixel : imageBitMap.Width * bytesPerPixel;
                imageBitMap.UnlockBits(bmData1);
                overlayBitMap.UnlockBits(bmData2);
                bit1 = new Bitmap(imageBitMap, widthInPixels, heightInPixels);
                bit2 = new Bitmap(overlayBitMap, widthInPixels, heightInPixels);
                bmData1 = bit1.LockBits(new Rectangle(0, 0, bit1.Width, bit1.Height), ImageLockMode.ReadOnly, bit1.PixelFormat);
                bmData2 = bit2.LockBits(new Rectangle(0, 0, bit2.Width, bit2.Height), ImageLockMode.ReadOnly, bit2.PixelFormat);
                bmDataResult = imageBitMap.LockBits(new Rectangle(0, 0, imageBitMap.Width, imageBitMap.Height), ImageLockMode.ReadOnly, imageBitMap.PixelFormat);
                unsafe
                {
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            switch (operation)
                            {
                                case operationName.or:
                                    newPixel = (byte)(GetPixelXY(x, y, bmData1) | GetPixelXY(x, y, bmData2));
                                    SetPixelXY(x, y, bmDataResult, newPixel);
                                    break;
                                case operationName.and:
                                    newPixel = (byte)(GetPixelXY(x, y, bmData1) & GetPixelXY(x, y, bmData2));
                                    SetPixelXY(x, y, bmDataResult, newPixel);
                                    break;
                                case operationName.xor:
                                    newPixel = (byte)(GetPixelXY(x, y, bmData1) ^ GetPixelXY(x, y, bmData2));
                                    SetPixelXY(x, y, bmDataResult, newPixel);
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                }
                bit1.UnlockBits(bmData1);
                bit2.UnlockBits(bmData2);
                imageBitMap.UnlockBits(bmDataResult);
            }
            catch
            {
                try
                {
                    bit1.UnlockBits(bmData1);
                    bit2.UnlockBits(bmData2);
                    imageBitMap.UnlockBits(bmDataResult);
                }
                catch
                {
                }
            }
        }

        public void MaskOnImage(int[,] maskArray, uint K)
        {
            Convolution applyMask = new Convolution(maskArray,(int)K);
            applyMask.ApplyInPlace(imageBitMap);
        }
        public void MaskOnImage(int[,] maskArray)
        {
            Convolution applyMask = new Convolution(maskArray);
            applyMask.ApplyInPlace(imageBitMap);
        }
        public void MaskOnImage(int[,] maskArray, edgeMethods edgeMethod, scaleMethods scaleMethod, int userPixel)
        {
            Convolution applyMask = new Convolution(maskArray);
            applyMask.ApplyInPlace(imageBitMap);
            OnEdgeOperation(edgeMethod, userPixel);
            ScaleImage(scaleMethod);
        }
        public void MedianOnImage(maskSize xSize, maskSize ySize, int xSizeInt, int ySizeInt, edgeMethods method, int userPixel)
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            Random rnd = new Random();
            Point[] points = new Point[xSizeInt * ySizeInt];
            byte newPixel = 0;
            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                unsafe
                {
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            if (!((y >= heightInPixels - 1 - (int)ySize) || (y <= (int)ySize) || (x >= widthInPixels - 1 - (int)xSize) || (x <= (int)xSize)))
                            {

                                int[] neighbours = new int[xSizeInt * ySizeInt];
                                int a = 0;
                                for (int k = -xSizeInt / 2; k <= xSizeInt / 2; ++k)
                                    for (int l = -ySizeInt / 2; l <= ySizeInt / 2; ++l)
                                    {
                                        neighbours[a++] = GetPixelXY(x + k, y + l, bmData);
                                    }

                                Array.Sort(neighbours);
                                if (neighbours.Length % 2 == 1)
                                    newPixel = (byte)neighbours[neighbours.Length / 2];
                                else
                                    newPixel = (byte)Math.Min((neighbours[neighbours.Length / 2] + neighbours[(neighbours.Length / 2) + 1]) / 2, levels - 1);
                                SetPixelXY(x, y, bmData, newPixel);
                            }
                            else
                            {
                                OnEdgeOperation(x,y,bmData,method,userPixel);
                            }
                        }
                    }
                }
                imageBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imageBitMap.UnlockBits(bmData);
                }
                catch
                {
                }
            }
        }

        public unsafe void OnEdgeOperation(int x, int y, BitmapData bmData, edgeMethods method, int userPixel)
        {
            Random rnd = new Random();
            byte newPixel = 0;
                unsafe
                {
                switch (method)
                {
                    case edgeMethods.first:
                        return;
                        break;
                    case edgeMethods.second:
                        newPixel = (byte)rnd.Next(0, 255);
                        break;
                    case edgeMethods.third:
                        newPixel = (byte)userPixel;
                        break;
                    case edgeMethods.mine:
                        newPixel = 0;
                        break;
                    default:
                        return;
                        break;
                }
                SetPixelXY(x, y, bmData, newPixel);
            }
        }
        public void OnEdgeOperation(edgeMethods method, int userPixel)
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            Random rnd = new Random();
            byte newPixel = 0;
            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                unsafe
                {
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            if ((y == heightInPixels - 1 || y == 0 || x == widthInPixels - 1 || x == 0))
                            {
                                switch (method)
                                {
                                    case edgeMethods.first:
                                        imageBitMap.UnlockBits(bmData);
                                        return;
                                        break;
                                    case edgeMethods.second:
                                        newPixel = (byte)rnd.Next(0, 255);
                                        break;
                                    case edgeMethods.third:
                                        newPixel = (byte)userPixel;
                                        break;
                                    case edgeMethods.mine:
                                        newPixel = 0;
                                        break;
                                    default:
                                        return;
                                        break;
                                }
                                SetPixelXY(x, y, bmData, newPixel);
                            }
                        }
                    }
                    imageBitMap.UnlockBits(bmData);
                }
            }
            catch
            {
                try
                {
                    imageBitMap.UnlockBits(bmData);
                }
                catch
                {
                }
            }
        }
        public void ScaleImage(scaleMethods method)
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            MinMaxPixel minMax = MaxMinPixelsMeth();
            int scalePixel = 0;
            byte newPixel = 0;
            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                unsafe
                {
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            switch (method)
                            {
                                case scaleMethods.first:
                                    scalePixel = ((GetPixelXY(x,y,bmData) - minMax.min) * (levels - 1) / (minMax.max - minMax.min));
                                    if (scalePixel < 0) { newPixel = 0; }
                                    else if (scalePixel > levels - 1) { newPixel = (byte)(levels - 1); }
                                    else { newPixel = (byte)scalePixel; }
                                    break;
                                case scaleMethods.second:
                                    if (GetPixelXY(x, y, bmData) < 0) { newPixel = 0; }
                                    else if (GetPixelXY(x, y, bmData) > 0) { newPixel = (byte)(levels - 1); }
                                    else { newPixel = (byte)((levels - 1) / 2); }
                                    break;
                                case scaleMethods.third:
                                    if (GetPixelXY(x, y, bmData) < 0) { newPixel = 0; }
                                    else if (GetPixelXY(x, y, bmData) > (levels - 1)) { newPixel = (byte)(levels - 1); }
                                    break;
                                default:
                                    return;
                                    break;
                            }
                            SetPixelXY(x, y, bmData, newPixel);
                            
                        }
                    }
                }
                imageBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imageBitMap.UnlockBits(bmData);
                    throw new Exception("Some problem in Scale func");

                }
                catch
                {
                    throw new Exception("Some problem in Scale func");
                }
            }
        }
        public void MorgologicOperation(morfOperation operation, structElement element, edgeMethods edgeMethod)
        {
            short[,] elementArray;
            if (element == structElement.rhomb) { elementArray = rhombElement; }
            else { elementArray = squareELement; }
            switch (operation)
            {
                case morfOperation.Erosion:
                    Erosion erosion = new Erosion(elementArray);
                    erosion.ApplyInPlace(imageBitMap);
                    break;
                case morfOperation.Dilatation:
                    Dilatation dilatation = new Dilatation(elementArray);
                    dilatation.ApplyInPlace(imageBitMap);
                    break;
                case morfOperation.Opening:
                    Opening opening = new Opening(elementArray);
                    opening.ApplyInPlace(imageBitMap);
                    break;
                case morfOperation.Closing:
                    Closing closing = new Closing(elementArray);
                    closing.ApplyInPlace(imageBitMap);
                    break;
                default:
                    break;
            }
            OnEdgeOperation(edgeMethod, 0);
        }

        public void SkeletonizationImage(edgeMethods method)
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            bool remain = true;
            bool skel = false;
            int[] example1 = new int[9] { 1, 1, 1, 0, 0, 0, 1, 1, 1 };
            int[] example2 = new int[9] { 1, 1, 1, 1, 0, 0, 1, 0, 2 };
            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                Point[] neighbourPoints = new Point[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1), new Point(1, 1), new Point(-1, -1), new Point(-1, 1), new Point(1, -1) };
                for (int i = 0; i < neighbourPoints.Length; i++)
                {
                    neighbourPoints[i].X = neighbourPoints[i].X * bytesPerPixel;
                }
                while (remain)
                {
                    remain = false;
                    for (int j = 0; j < 7; j += 2)
                    {
                        
                            for (int y = 0; y < heightInPixels; y++)
                            {
                                for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                                {

                                    int[] neighbours = new int[9];
                                    int a = 0;
                                    for (int k = -1; k < 2; ++k)
                                        for (int l = -1; l < 2; ++l)
                                        {
                                            neighbours[a++] = GetPixelXY(x + k, y + k, bmData);
                                        }
                                    if (GetPixelXY(x, y, bmData) == 1 && neighbours[j] == 0)
                                    {
                                        skel = false;
                                        bool A = false;
                                        bool B = false;
                                        for (int i = 0; i < neighbours.Length; i++)
                                        {
                                            if (i < 3)
                                            {
                                                if (example1[i] == neighbours[i]) { A = true; i = 2; }
                                            }
                                            else if (i < 6)
                                            {
                                                if (example1[i] != neighbours[i] && i != 4)
                                                {
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (example1[i] == neighbours[i]) { B = true; skel = true; break; }
                                            }

                                        }
                                        for (int i = 0; i < neighbours.Length; i++)
                                        {
                                            if (i < 4 || i == 6)
                                            {
                                                if (example1[i] == neighbours[i]) { A = true; }
                                            }
                                            else if (i == 5 || i == 7 || i == 8)
                                            {
                                                if (example1[i] != neighbours[i])
                                                {
                                                    break;
                                                }
                                                if (i == 8) { skel = true; break; }
                                            }

                                        }
                                        if (skel == true) { SetPixelXY(x, y, bmData, 2); }
                                        else { SetPixelXY(x, y, bmData, 3); remain = true; }
                                    }

                                }
                            }
                            for (int y = 0; y < heightInPixels; y++)
                            {
                                for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                                {
                                    if (GetPixelXY(x, y, bmData) == 3) { SetPixelXY(x, y, bmData, 0); }
                                }
                            }
                        
                    }
                    

                }
                OnEdgeOperation(method, 0);
                imageBitMap.UnlockBits(bmData);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void CompressionRLE()
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            int counter = 0;
            int after;
            int before = 0;
            float comLevel;

            int pam;
            int pam2 = -128; // ?

            after = imageBitMap.Width * imageBitMap.Height;
            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                for (int y = 0; y < heightInPixels; y++)
                {
                    for (int x = 0; x < widthInPixels; x += bytesPerPixel) 
                    {
                        if (y >= imageBitMap.Height) break;

                        pam = GetPixelXY(x,y,bmData);

                        if (pam == pam2)
                        {
                            counter = 0;

                            while (((pam = GetPixelXY(x, y, bmData)) == pam2) && (counter < 127))
                            {
                                counter++;
                                x++;

                                if (x >= widthInPixels - 1)
                                {
                                    x = 0;
                                    y++;
                                    if (y >= heightInPixels) break;
                                }

                                pam2 = pam;
                            }

                            before += 2;
                        }
                        else
                        {
                            counter = 0;
                            while (((pam = GetPixelXY(x,y,bmData)) == pam2) && (counter < 127))
                            {
                                counter++;
                                x++;

                                if (x >= widthInPixels - 1)
                                {
                                    x = 0;
                                    y++;
                                    if (y >= heightInPixels) break;
                                }

                                pam2 = pam;
                            }
                            before = before + counter + 1;
                        }

                        pam2 = pam;
                    }
                }
                comLevel = (float)after / (float)before;

                int bits = 0;
                for (int i = 1; i <= 8; i++)
                {
                    int levels = (int)Math.Pow(2, i);
                    if (levels < MainImage.levels) continue;
                    bits = i;
                    break;
                }
                float div = bits / 8.0f;

                MessageBox.Show("\nSize before compression: " + after * div
                    + "\n\nSize after compression: " + before * div
                    + "\n\nCompression level: " + comLevel, "Compression RLE");
                imageBitMap.UnlockBits(bmData);

            }
            catch (Exception)
            {
                imageBitMap.UnlockBits(bmData);
                throw;
            }
        }
        public void CompressionREAD()
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            const int PIXELLEN = 1;
            const int WORDLEN = 1;

            int newColor = 255, lastColor = 0;
            int repeatCount = 0;
            int total = 0;

            int width = imageBitMap.Width;
            int height = imageBitMap.Height;
            int fld = width * height;
            int before, after;
            float comLevel;

            before = fld * PIXELLEN;
            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                //Rows
                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                    {
                        newColor = GetPixelXY(x, y, bmData);

                        if (newColor == lastColor)
                        {
                            repeatCount++;
                        }
                        else
                        {

                            if (repeatCount > 0)
                            {
                                total += WORDLEN + PIXELLEN;
                                repeatCount = 0;
                            }

                            total += WORDLEN + PIXELLEN;
                        }

                        lastColor = GetPixelXY(x, y, bmData);
                    }
                if (repeatCount > 0)
                {
                    total += WORDLEN + PIXELLEN;
                    repeatCount = 0;
                }
                //Columns
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        newColor = GetPixelXY(x, y, bmData);

                        if (newColor == lastColor)
                        {
                            repeatCount++;
                        }
                        else
                        {
                            if (repeatCount > 0)
                            {
                                total += WORDLEN + PIXELLEN;
                                repeatCount = 0;
                            }
                            total += WORDLEN + PIXELLEN;
                        }
                        lastColor = GetPixelXY(x, y, bmData);
                    }
                if (repeatCount > 0)
                {
                    total += WORDLEN + PIXELLEN;
                    repeatCount = 0;
                }
                after = total / 2;
                comLevel = (float)(float)before / (float)after;

                int bits = 0;
                for (int i = 1; i <= 8; i++)
                {
                    int levels = (int)Math.Pow(2, i);
                    if (levels < MainImage.levels) continue;
                    bits = i;
                    break;
                }
                float div = bits / 8.0f;
                imageBitMap.UnlockBits(bmData);
                MessageBox.Show("\nSize before compression: " + before * div
                                + "\n\nSize after compression: " + after * div
                                + "\n\nCompression level: " + comLevel, "READ Compression");
            }
            catch (Exception)
            {
                imageBitMap.UnlockBits(bmData);
                throw;
            }
        }
        public void CompressionHuffmans()
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            int x = 2;
            int counter = 0;
            int before;
            int after = 0;
            float ComLevel;
            int pow = 2;
            int quantity = 0;

            int[] phist = new int[MainImage.levels];
            before = imageBitMap.Width * imageBitMap.Height;
            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                for (int j = 0; j < heightInPixels; j++)
                    for (int i = 0; i < widthInPixels; i++)
                        phist[GetPixelXY(i,j,bmData)] += 1;
                for (int i = 0; i < MainImage.levels; i++)
                {
                    if (phist[i] != 0)
                    {
                        counter++;
                        after += (counter * phist[i]);

                        if (counter >= Math.Pow((double)x, (double)pow))
                        {
                            counter = 0;
                            pow++;
                        }
                        quantity++;
                    }

                    if (counter == 1)
                    {
                        after = before + 1;
                    }
                }
                after /= 8;
                after += (quantity * 2);

                ComLevel = (float)(float)before / (float)after;

                int bits = 0;
                for (int i = 1; i <= 8; i++)
                {
                    int levels = (int)Math.Pow(2, i);
                    if (levels < MainImage.levels) continue;
                    bits = i;
                    break;
                }
                float div = bits / 8.0f;
                imageBitMap.UnlockBits(bmData);
                MessageBox.Show("\nSize before compression: " + before * div
                    + "\n\nSize after compression: " + after * div
                    + "\n\nCompression level: " + ComLevel, "Huffmans COmpression");
            }
            catch (Exception)
            {
                imageBitMap.UnlockBits(bmData);

                throw;
            }
        }
        public void CompressionBlocks(int size)
        {
            BitmapData bmData = null;
            BitmapData bmDataNew = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            int color = 0;
            float avg, avgUP, avgDOWN;
            int countUP, countDOWN, countAVG;
            int sizeAfter = 0;
            try
            {
                LockImage(imageBitMap, out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                for (int y = 0; y < heightInPixels; y += size)
                    for (int x = 0; x < widthInPixels; x += size)
                    {
                        avg = 0;
                        countAVG = 0;
                        for (int yy = 0; yy < size; ++yy)
                        {
                            for (int xx = 0; xx < size; ++xx)
                            {
                                if (x + xx < widthInPixels && y + yy < heightInPixels)
                                {
                                    color = GetPixelXY(x + xx, y + yy, bmData);
                                    avg += color;
                                    ++countAVG;
                                }
                            }
                        }
                        avg /= countAVG;
                        avg = (int)avg;

                        avgUP = 0;
                        avgDOWN = 0;
                        countDOWN = 0;
                        countUP = 0;
                        for (int yy = 0; yy < size; ++yy)
                        {
                            for (int xx = 0; xx < size; ++xx)
                            {
                                if (x + xx < widthInPixels && y + yy < heightInPixels)
                                {
                                    color = GetPixelXY(x + xx, y + yy, bmData);
                                    if (color >= avg) { avgUP += color; ++countUP; }
                                    else { avgDOWN += color; ++countDOWN; }
                                }
                            }
                        }
                        avgUP /= countUP;
                        avgDOWN /= countDOWN;
                        avgUP = (int)avgUP;
                        avgDOWN = (int)avgDOWN;

                        for (int yy = 0; yy < size; ++yy)
                            for (int xx = 0; xx < size; ++xx)
                                if (x + xx < widthInPixels && y + yy < heightInPixels)
                                    if (GetPixelXY(x + xx, y + yy, bmData) >= avg) SetPixelXY(x, y, bmDataNew, (byte)avgUP);
                                    else SetPixelXY(x, y, bmDataNew, (byte)avgDOWN);

                        sizeAfter += countAVG + 16;
                    }
                int sizeBefore = widthInPixels * heightInPixels * 8;

                int bits = 0;
                for (int i = 1; i <= 8; i++)
                {
                    int levels = (int)Math.Pow(2, i);
                    if (levels < MainImage.levels) continue;
                    bits = i;
                    break;
                }
                float div = bits / 8.0f;
                float ComLevel = (float)sizeBefore / (float)sizeAfter;
                imageBitMap.UnlockBits(bmData);
                MessageBox.Show("\nSize before Compression: " + sizeBefore * div
                                + "\n\nSize after Compression: " + sizeAfter * div
                                + "\n\nCompression level: " + ComLevel, "BLOCK Compression");

            }
            catch (Exception)
            {
                imageBitMap.UnlockBits(bmData);
                throw;
            }
            

            
        }
        public void turtle()
        {
            BitmapData bmData = null;
            Bitmap bmp = (Bitmap)imageBitMap.Clone();
            try
            {
                LockImage(bmp, out bmData);
                int[,] grayTab = new int[bmp.Width, bmp.Height];

                int i, j;
                for (i = 1; i < bmp.Width - 1; i++)
                {
                    for (j = 1; j < bmp.Height - 1; j++)
                    {
                        grayTab[i, j] = GetPixelXY(i, j, bmData);
                    }
                }
                int d = 0;
                int pami = 0, pamj = 0, ja = 0, ia = 0;
                int x, y;
                int[] wynik = new int[bmp.Width * bmp.Height];
                int[] droga = new int[bmp.Width * bmp.Height];
                for (i = 1; i < bmp.Height - 1; i++)
                {
                    for (j = 1; j < bmp.Width - 1; j++)
                    {
                        if (grayTab[j, i] != 0)
                        {
                            ja = j;
                            ia = i;
                            pamj = j;
                            pami = i;
                            wynik[bmp.Width * i + j] = MainImage.levels - 1;
                            goto cont;
                        }
                    }
                }
                cont:
                j = pamj;
                i = pami - 1;
                wynik[bmp.Width * i + j] = MainImage.levels - 1;
                droga[d] = 1;
                do
                {
                    x = j - pamj;
                    y = i - pami;
                    pamj = j;
                    pami = i;
                    d++;
                    if (grayTab[j, i] != 0)
                    {
                        if (x == 0 && y == (-1))
                        {
                            j--;
                            droga[d] = 2;
                        }
                        if (x == 1 && y == 0)
                        {
                            i--;
                            droga[d] = 1;
                        }
                        if (x == 0 && y == 1)
                        {
                            j++;
                            droga[d] = 0;
                        }
                        if (x == (-1) && y == 0)
                        {
                            i++;
                            droga[d] = 3;
                        }
                    }
                    else
                    {
                        if (x == 0 && y == (-1))
                        {
                            j++;
                            droga[d] = 0;
                        }
                        if (x == 1 && y == 0)
                        {
                            i++;
                            droga[d] = 3;
                        }
                        if (x == 0 && y == 1)
                        {
                            j--;
                            droga[d] = 2;
                        }
                        if (x == (-1) && y == 0)
                        {
                            i--;
                            droga[d] = 1;
                        }
                    }
                    wynik[bmp.Width * i + j] = MainImage.levels - 1;
                }
                while (j != ja || i != ia);
                for (i = 0; i < bmp.Height; i++)
                {
                    for (j = 0; j < bmp.Width; j++)
                    {
                        if (wynik[bmp.Width * i + j] == MainImage.levels - 1)
                        {
                            grayTab[j, i] = MainImage.levels / 2;
                        }
                    }
                }

                for (i = 0; i < bmp.Width; i++)
                {
                    for (j = 0; j < bmp.Height; j++)
                    {
                        SetPixelXY(i, j, bmData, (byte)grayTab[i, j]);
                    }
                }
                bmp.UnlockBits(bmData);
                imageBitMap = bmp;
            }
            catch (Exception)
            {
                bmp.UnlockBits(bmData);
                throw;
            }
            
        }
    }

}
