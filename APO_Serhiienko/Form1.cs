using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace APO_Serhiienko
{
    public partial class Form1 : Form
    {
        delegate void twoPointOperation();
        twoPointOperation TwoPointOperation;
        MainImage mainImage;
        int startThLevel;
        int endThLevel;
        uint kDiv = 9;
        int userPixel = 0;
        List<TextBox> txtMaskMatrixList = new List<TextBox>();
        List<int[,]> intMaskList = new List<int[,]>();
        int maskSizeX = 3, maskSizeY = 3;
        masksAplied mask;
        public Form1()
        {
            InitializeComponent();
            initMasks();
            initControls();
        }
        //General functions:
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = OpenImage();
                if (fileName == "fail")
                    return;
                Bitmap mainBitMap = new Bitmap(fileName, true);
                mainImage = new MainImage(fileName, mainBitMap);
                picBoxMain.Image = mainImage.imageBitMap;
                mainImage.GetHistogram();
                DrawHistogram();
                mainHistogram.Visible = true;
                tabCtrlLab.Visible = true;
                cbAlreadyChosen.Enabled = false;
                TwoPointOperation = TwoPointOpWithDialog;
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Exception");
            }


        }
        private string OpenImage()
        {
            openFileDialog1.Filter = "";

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;
            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                openFileDialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog1.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }
            openFileDialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog1.Filter, sep, "All Files", "*.*");
            openFileDialog1.DefaultExt = ".png";

            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            return "fail";
        }
        private void DrawHistogram()
        {
            long[] histogram = mainImage.histMain;
            mainHistogram.Series["Gray"].Points.DataBindXY(Enumerable.Range(0, 256).ToList(), histogram.ToList());
            Axis ax = mainHistogram.ChartAreas[0].AxisX;
            ax.Minimum = 0;
            ax.Maximum = 255;
        }
        private void initControls()
        {
            string[] onePointOperation = new string[] { "Invert", "Threshold", "ThreshHoldGraySave", "Reduction", "StretchGrayLevel" };
            string[] twoPointOperation = new string[] { "Add", "Sub", "Diff", "OR", "AND", "XOR" };
            string[] medians = new string[] { "3", "5", "7" };
            string[] edgeMethods = new string[] { "First", "Second", "Third", "Mine" };
            string[] scaleMethods = new string[] { "First", "Second", "Third" };
            string[] morphOperations = new string[] { "Erosion", "Dilatation", "Opening", "Closing" };
            string[] structElements = new string[] { "Rhomb", "Square" };
            string[] edgeMethodsMorph = new string[] { "Second", "Mine" };
            string[] compressionBlocksSize = new string[] { "4x4", "8x8", "16x16", "32x32" };
            string[] masks = new string[] { "Wygladzanie 1/9", "Wygladzanie 1/10", "Wygladzanie 1/16", "Wyostrzanie cyfroweLaplasa", "LaplasA", "LaplasB", "LaplasC", "LaplasD", "edgeOne", "edgeTwo", "edgeThree", "firstUniq", "secondUniq", "firstSobel", "secondSobel", "firstPrewitt", "secondPrewitt" };
            foreach (var item in onePointOperation) { cbOnePointOp.Items.Add(item); }
            foreach (var item in twoPointOperation) { cbTwoPointOp.Items.Add(item); }
            foreach (var item in edgeMethods) { cbEdgeMethods.Items.Add(item); }
            foreach (var item in scaleMethods) { cbScaleMethods.Items.Add(item); }
            foreach (var item in morphOperations) { cbMorphOperations.Items.Add(item); }
            foreach (var item in structElements) { cbStructElementsMorph.Items.Add(item); }
            foreach (var item in edgeMethodsMorph) { cbEdgeMethodsMorph.Items.Add(item); cbEdgeMethodsSkel.Items.Add(item); }
            foreach (var item in compressionBlocksSize) { cbComBlocksSize.Items.Add(item); }
            foreach (var item in masks) { cbMasks.Items.Add(item); }
            foreach (var item in medians) { cbMedianX.Items.Add(item); cbMedianY.Items.Add(item); }
            var query = tabCtrlLab.TabPages[2].Controls.Cast<Control>().OrderBy((ctrl) => ctrl.Location.Y).ThenBy((ctrl) => ctrl.Location.X).Where((ctrl) => ctrl is TextBox && ctrl.Name.Substring(0, 7) == "txtMask").Select((ctrl) => ctrl as TextBox);
            foreach (var item in query)
            {
                txtMaskMatrixList.Add(item);
            }
            cbOnePointOp.SelectedIndex = 0;
            cbEdgeMethods.SelectedIndex = 0;
            cbScaleMethods.SelectedIndex = 0;
            cbMedianX.SelectedIndex = 0;
            cbMedianY.SelectedIndex = 0;
            cbMasks.SelectedIndex = 0;
            cbStructElementsMorph.SelectedIndex = 0;
            cbMorphOperations.SelectedIndex = 0;
            cbComBlocksSize.SelectedIndex = 0;


        }
        private void initMasks()
        {
            intMaskList.Add(new int[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } }); //onNine 
            intMaskList.Add(new int[3, 3] { { 1, 1, 1 }, { 1, 2, 1 }, { 1, 1, 1 } });//onTen
            intMaskList.Add(new int[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } });//onSixteen
            intMaskList.Add(new int[3, 3] { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } });//cyfrowaLaplas
            intMaskList.Add(new int[3, 3] { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } });//laplasA
            intMaskList.Add(new int[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } });//laplasB
            intMaskList.Add(new int[3, 3] { { 1, -2, 1 }, { -2, 4, -2 }, { 1, -2, 1 } });//laplasC
            intMaskList.Add(new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } });//laplasD
            intMaskList.Add(new int[3, 3] { { 1, -2, 1 }, { -2, 5, -2 }, { 1, -2, 1 } });//edgeOne
            intMaskList.Add(new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } });//edgeTwo
            intMaskList.Add(new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } });//edgeThree
            intMaskList.Add(new int[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } });//firstUniq
            intMaskList.Add(new int[3, 3] { { -2, 0, 2 }, { -2, 0, 2 }, { -2, 0, 2 } });//secondUniq
            intMaskList.Add(new int[3, 3] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } });//firstSobel
            intMaskList.Add(new int[3, 3] { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } });//secondSobel
            intMaskList.Add(new int[3, 3] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } });//firstPrewitt
            intMaskList.Add(new int[3, 3] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } });//secondPrewitt
        }
        private void InvalidateImage()
        {
            mainImage.GetHistogram();
            this.Invoke(new Action(() => DrawHistogram()));
            picBoxMain.Image = mainImage.imageBitMap;
        }
        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplikacja zbiorcza z ćwiczeń laboratoryjnych\nAutor:      Anton Serhiienko\nProwadzący:    dr inż. Marek Doros \nAlgorytmy Przetwarzania Obrazów 2019 \nInżynieria oprogramowania grupa ID06IO1 \n", "Algorytmy Przetwarzania Obrazów 2019");
        }

        //Lab1 functions:
        private void btnLab1Clck(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Stretch") { new Thread(() => StartStretch()).Start(); return; }
            if (btn.Text == "EqualizationFirst") { new Thread(() => StartEqualizationThread(equalizationMethods.first)).Start(); return; }
            if (btn.Text == "EqualizationSecond") { new Thread(() => StartEqualizationThread(equalizationMethods.second)).Start(); return; }
            if (btn.Text == "EqualizationThird") { new Thread(() => StartEqualizationThread(equalizationMethods.third)).Start(); return; }
            if (btn.Text == "EqualizationMine") { new Thread(() => StartEqualizationThread(equalizationMethods.mine)).Start(); return; }
        }
        private void StartEqualizationThread(equalizationMethods method)
        {
            mainImage.EqualizationHistogram(method);
            InvalidateImage();


        }
        private void StartStretch()
        {
            mainImage.StretchHistogram();
            InvalidateImage();
        }

        //Lab2 functions:
        private void btnLab2_Click(object sender, EventArgs e)
        {
            string operation = cbOnePointOp.SelectedItem.ToString();
            new Thread(() => OnePointOperation(operation)).Start();
        }
        private void TwoPointOpWithDialog()
        {
            string fileName = OpenImage();
            if (fileName == "fail")
                return;
            try
            {
                Bitmap overlayBitmap = new Bitmap(fileName, true);
                mainImage.overlayBitMap = mainImage.ConvertTo8bpp(new Bitmap(overlayBitmap, mainImage.imageBitMap.Size));
                mainImage.OperationArithmeticLogical((operationName)cbTwoPointOp.SelectedIndex);
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Exception");
            }

        }
        private void twoPointOpSame()
        {
            Bitmap overlayBitmap = new Bitmap(mainImage.imageBitMap);
            mainImage.overlayBitMap = mainImage.ConvertTo8bpp(overlayBitmap);
            mainImage.OperationArithmeticLogical((operationName)cbTwoPointOp.SelectedIndex);
        }
        private void twoPointOpAlreadyChosen()
        {
            mainImage.OperationArithmeticLogical((operationName)cbTwoPointOp.SelectedIndex);
        }
        private void btnTwoPointOp_Click(object sender, EventArgs e)
        {
            TwoPointOperation();
            InvalidateImage();
            cbAlreadyChosen.Enabled = mainImage.overlayBitMap != null;
        }
        private void OnePointOperation(string operation)
        {
            if (operation == "ThreshHoldGraySave")
            {
                mainImage.ThresholdLevelSave(startThLevel, endThLevel);
                InvalidateImage();
            }
            else if (operation == "StretchGrayLevel")
            {
                mainImage.StretchGrayLevel(startThLevel, endThLevel);
                InvalidateImage();
            }
            else
            {
                mainImage.OnePointOperation(operation);
                InvalidateImage();
            }
        }
        private void cbOnePointOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOnePointOp.SelectedItem.ToString() == "ThreshHoldGraySave" || cbOnePointOp.SelectedItem.ToString() == "StretchGrayLevel")
            {
                txtThEnd.Visible = txtThStart.Visible = lbThEnd.Visible = lbThStart.Visible = true;
                int start;
                int end;
                btnOnePointOp.Enabled = Int32.TryParse(txtThStart.Text, out start) && start >= 0 && start <= 255 && Int32.TryParse(txtThEnd.Text, out end) && end >= start && end <= 255;
            }
            else
            {
                txtThEnd.Visible = txtThStart.Visible = lbThEnd.Visible = lbThStart.Visible = false;
                btnOnePointOp.Enabled = true;
            }
        }
        private void txtThLevel_changing(object sender, EventArgs e)
        {
            if (cbOnePointOp.SelectedItem.ToString() == "ThreshHoldGraySave" || cbOnePointOp.SelectedItem.ToString() == "StretchGrayLevel")
            {
                btnOnePointOp.Enabled = Int32.TryParse(txtThStart.Text, out startThLevel) && startThLevel >= 0 && startThLevel <= 255 && Int32.TryParse(txtThEnd.Text, out endThLevel) && endThLevel >= startThLevel && endThLevel <= 255;
            }
        }
        private void cbSameImage_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSameImage.Checked)
            {
                cbAlreadyChosen.Checked = false;
                TwoPointOperation = twoPointOpSame;
            }
            if (!cbSameImage.Checked && !cbAlreadyChosen.Checked)
            {
                TwoPointOperation = TwoPointOpWithDialog;
            }


        }
        private void cbAlreadyChosen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAlreadyChosen.Checked)
            {
                cbSameImage.Checked = false;
                TwoPointOperation = twoPointOpAlreadyChosen;
            }
            if (!cbSameImage.Checked && !cbAlreadyChosen.Checked)
            {
                TwoPointOperation = TwoPointOpWithDialog;
            }
        }
        private void tabCtrlLab_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtThEnd.Visible = txtThStart.Visible = lbThEnd.Visible = lbThStart.Visible = cbOnePointOp.SelectedIndex == 2 || cbOnePointOp.SelectedIndex == 4;
        }


        //Lab3 functions:
        private void btnApplyMask_Click(object sender, EventArgs e)
        {
            if (cbOwnMask.Checked)
            {
                try
                {
                    int k = 0;
                    int[,] ownMask = new int[maskSizeX, maskSizeY];
                    for (int i = 0; i < maskSizeX; i++)
                    {
                        for (int j = 0; j < maskSizeY; j++)
                        {
                            ownMask[i, j] = Convert.ToInt32(txtMaskMatrixList[k].Text);
                            k++;
                        }
                    }
                    mainImage.MaskOnImage(ownMask);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Exception");
                }
            }
            else if (mask <= masksAplied.onSixteen) { mainImage.MaskOnImage(intMaskList[(int)mask], kDiv); }
            else if (mask <= masksAplied.edgeThree) { mainImage.MaskOnImage(intMaskList[(int)mask]); }
            else
            {
                int tempPixel = 0;
                bool tryParseUserPixel = Int32.TryParse(txtUserPixel.Text, out tempPixel);
                if (!tryParseUserPixel)
                {
                    MessageBox.Show("Enter valid number in userPixel text box!");
                    return;
                }
                if (tempPixel < 0 || tempPixel > 255)
                {
                    MessageBox.Show("User pixel must be >= 0 and <= 255!");
                    return;

                }
                userPixel = tempPixel;
                mainImage.MaskOnImage(intMaskList[(int)mask], (edgeMethods)cbEdgeMethods.SelectedIndex, (scaleMethods)cbScaleMethods.SelectedIndex, userPixel);
            }
            InvalidateImage();

        }
        private void btnApplyMedian_Click(object sender, EventArgs e)
        {
            int maskSizeXInt, maskSizeYInt;
            maskSize maskSizeX = (maskSize)cbMedianX.SelectedIndex;
            maskSize maskSizeY = (maskSize)cbMedianY.SelectedIndex;
            edgeMethods edgeMethod = (edgeMethods)cbEdgeMethods.SelectedIndex;
            Int32.TryParse(cbMedianX.SelectedItem.ToString(), out maskSizeXInt);
            Int32.TryParse(cbMedianY.SelectedItem.ToString(), out maskSizeYInt);
            mainImage.MedianOnImage(maskSizeX, maskSizeY, maskSizeXInt, maskSizeYInt, edgeMethod, (int)userPixel);
            InvalidateImage();
        }
        private void cbOwnMask_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in txtMaskMatrixList)
            {
                item.ReadOnly = !cbOwnMask.Checked;
            }
        }
        private void txtMask_TextChanged(object sender, EventArgs e)
        {
            int temp;
            btnApplyMask.Enabled = Int32.TryParse((sender as TextBox).Text, out temp);
        }
        private void cbMasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMasks.SelectedItem.ToString() == "Wygladzanie 1/9") { kDiv = 9; lbKDiv.Text = "K = " + Convert.ToString(kDiv); lbKDiv.Visible = true; }
            else if (cbMasks.SelectedItem.ToString() == "Wygladzanie 1/10") { kDiv = 10; lbKDiv.Text = "K = " + Convert.ToString(kDiv); lbKDiv.Visible = true; }
            else if (cbMasks.SelectedItem.ToString() == "Wygladzanie 1/16") { kDiv = 16; lbKDiv.Text = "K = " + Convert.ToString(kDiv); lbKDiv.Visible = true; }
            else
            {
                lbKDiv.Visible = false;
            }
            mask = (masksAplied)cbMasks.SelectedIndex;
            int k = 0;
            for (int i = 0; i < maskSizeX; i++)
            {
                for (int j = 0; j < maskSizeY; j++)
                {
                    txtMaskMatrixList[k].Text = "";
                }
            }
            for (int i = 0; i < intMaskList[(int)mask].GetLength(0); i++)
            {
                for (int j = 0; j < intMaskList[(int)mask].GetLength(1); j++)
                {
                    txtMaskMatrixList[k].Text = Convert.ToString(intMaskList[(int)mask].GetValue(i, j));
                    k++;
                }
            }
        }

        //Lab4 functions:
        private void btnApplyMorph_Click(object sender, EventArgs e)
        {
            try
            {
                morfOperation morfOperation = (morfOperation)cbMorphOperations.SelectedIndex;
                structElement structElement = (structElement)cbStructElementsMorph.SelectedIndex;
                edgeMethods edgeMethod;
                if (cbEdgeMethodsMorph.SelectedIndex == 0) { edgeMethod = edgeMethods.second; }
                else { edgeMethod = edgeMethods.mine; };
                mainImage.MorgologicOperation(morfOperation, structElement, edgeMethod);
                InvalidateImage();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Apply morph operation");
            }

        }
        private void btnApplySkel_Click(object sender, EventArgs e)
        {
            try
            {
                edgeMethods edgeMethod;
                if (cbEdgeMethodsMorph.SelectedIndex == 0) { edgeMethod = edgeMethods.second; }
                else { edgeMethod = edgeMethods.mine; }
                mainImage.SkeletonizationImage(edgeMethod);
                InvalidateImage();

            }
            catch (Exception)
            {

                throw;
            }

        }


        //Lab5 functions:
        private void btnCompressionRle_Click(object sender, EventArgs e)
        {
            mainImage.CompressionRLE();
        }

        private void btnCompressionRead_Click(object sender, EventArgs e)
        {
            mainImage.CompressionREAD();
        }

        private void btnCompressionHuffmans_Click(object sender, EventArgs e)
        {
            mainImage.CompressionHuffmans();
        }

        private void btnCompressionBlocks_Click(object sender, EventArgs e)
        {
            mainImage.CompressionBlocks((int)Math.Pow(2, cbComBlocksSize.SelectedIndex + 2));
        }




        //Lab6 functions:
        private void btnTurtle_Click(object sender, EventArgs e)
        {
            mainImage.turtle();
            InvalidateImage();
        }
    }
}
