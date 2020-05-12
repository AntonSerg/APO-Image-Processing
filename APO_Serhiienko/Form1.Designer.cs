namespace APO_Serhiienko
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.picBoxMain = new System.Windows.Forms.PictureBox();
            this.mainHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnStretch = new System.Windows.Forms.Button();
            this.btnEqFirst = new System.Windows.Forms.Button();
            this.btnEqSecond = new System.Windows.Forms.Button();
            this.btnEqThird = new System.Windows.Forms.Button();
            this.btnEqMine = new System.Windows.Forms.Button();
            this.cbOnePointOp = new System.Windows.Forms.ComboBox();
            this.btnOnePointOp = new System.Windows.Forms.Button();
            this.txtThStart = new System.Windows.Forms.TextBox();
            this.txtThEnd = new System.Windows.Forms.TextBox();
            this.lbThStart = new System.Windows.Forms.Label();
            this.lbThEnd = new System.Windows.Forms.Label();
            this.cbTwoPointOp = new System.Windows.Forms.ComboBox();
            this.btnTwoPointOp = new System.Windows.Forms.Button();
            this.cbSameImage = new System.Windows.Forms.CheckBox();
            this.cbAlreadyChosen = new System.Windows.Forms.CheckBox();
            this.tabCtrlLab = new System.Windows.Forms.TabControl();
            this.tpLab1 = new System.Windows.Forms.TabPage();
            this.tpLab2 = new System.Windows.Forms.TabPage();
            this.tpLab3 = new System.Windows.Forms.TabPage();
            this.lbMedianMulti = new System.Windows.Forms.Label();
            this.cbMedianY = new System.Windows.Forms.ComboBox();
            this.cbMedianX = new System.Windows.Forms.ComboBox();
            this.lbScale = new System.Windows.Forms.Label();
            this.lbEdge = new System.Windows.Forms.Label();
            this.cbScaleMethods = new System.Windows.Forms.ComboBox();
            this.cbEdgeMethods = new System.Windows.Forms.ComboBox();
            this.btnApplyMedian = new System.Windows.Forms.Button();
            this.lbMedian = new System.Windows.Forms.Label();
            this.cbOwnMask = new System.Windows.Forms.CheckBox();
            this.lbKDiv = new System.Windows.Forms.Label();
            this.txtMask3_2 = new System.Windows.Forms.TextBox();
            this.txtMask3_3 = new System.Windows.Forms.TextBox();
            this.txtMask3_1 = new System.Windows.Forms.TextBox();
            this.txtMask2_2 = new System.Windows.Forms.TextBox();
            this.txtMask2_3 = new System.Windows.Forms.TextBox();
            this.txtMask2_1 = new System.Windows.Forms.TextBox();
            this.txtMask1_2 = new System.Windows.Forms.TextBox();
            this.txtMask1_3 = new System.Windows.Forms.TextBox();
            this.txtMask1_1 = new System.Windows.Forms.TextBox();
            this.btnApplyMask = new System.Windows.Forms.Button();
            this.lbMask = new System.Windows.Forms.Label();
            this.cbMasks = new System.Windows.Forms.ComboBox();
            this.tpLab4 = new System.Windows.Forms.TabPage();
            this.lbEdgeOpSkel = new System.Windows.Forms.Label();
            this.cbEdgeMethodsSkel = new System.Windows.Forms.ComboBox();
            this.btnApplySkel = new System.Windows.Forms.Button();
            this.lbEdgeOpMorph = new System.Windows.Forms.Label();
            this.cbEdgeMethodsMorph = new System.Windows.Forms.ComboBox();
            this.btnApplyMorph = new System.Windows.Forms.Button();
            this.cbStructElementsMorph = new System.Windows.Forms.ComboBox();
            this.lbElementMorph = new System.Windows.Forms.Label();
            this.lbMorph = new System.Windows.Forms.Label();
            this.cbMorphOperations = new System.Windows.Forms.ComboBox();
            this.tpLab5 = new System.Windows.Forms.TabPage();
            this.cbComBlocksSize = new System.Windows.Forms.ComboBox();
            this.btnCompressionBlocks = new System.Windows.Forms.Button();
            this.btnCompressionHuffmans = new System.Windows.Forms.Button();
            this.btnCompressionRead = new System.Windows.Forms.Button();
            this.btnCompressionRle = new System.Windows.Forms.Button();
            this.tpLab6 = new System.Windows.Forms.TabPage();
            this.btnTurtle = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oProgramieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUserPixel = new System.Windows.Forms.TextBox();
            this.lbUserPixel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainHistogram)).BeginInit();
            this.tabCtrlLab.SuspendLayout();
            this.tpLab1.SuspendLayout();
            this.tpLab2.SuspendLayout();
            this.tpLab3.SuspendLayout();
            this.tpLab4.SuspendLayout();
            this.tpLab5.SuspendLayout();
            this.tpLab6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Location = new System.Drawing.Point(814, 459);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(173, 37);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "OpenFile";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // picBoxMain
            // 
            this.picBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxMain.Location = new System.Drawing.Point(12, 27);
            this.picBoxMain.Name = "picBoxMain";
            this.picBoxMain.Size = new System.Drawing.Size(309, 310);
            this.picBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxMain.TabIndex = 1;
            this.picBoxMain.TabStop = false;
            // 
            // mainHistogram
            // 
            this.mainHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainHistogram.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.mainHistogram.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.mainHistogram.Legends.Add(legend1);
            this.mainHistogram.Location = new System.Drawing.Point(341, 27);
            this.mainHistogram.Name = "mainHistogram";
            series1.BorderColor = System.Drawing.Color.Gray;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Gray;
            series1.Legend = "Legend1";
            series1.Name = "Gray";
            this.mainHistogram.Series.Add(series1);
            this.mainHistogram.Size = new System.Drawing.Size(636, 325);
            this.mainHistogram.TabIndex = 2;
            this.mainHistogram.Text = "Histogram";
            this.mainHistogram.Visible = false;
            // 
            // btnStretch
            // 
            this.btnStretch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStretch.Location = new System.Drawing.Point(6, 6);
            this.btnStretch.Name = "btnStretch";
            this.btnStretch.Size = new System.Drawing.Size(115, 23);
            this.btnStretch.TabIndex = 10;
            this.btnStretch.Text = "Stretch";
            this.btnStretch.UseVisualStyleBackColor = true;
            this.btnStretch.Click += new System.EventHandler(this.btnLab1Clck);
            // 
            // btnEqFirst
            // 
            this.btnEqFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEqFirst.Location = new System.Drawing.Point(152, 35);
            this.btnEqFirst.Name = "btnEqFirst";
            this.btnEqFirst.Size = new System.Drawing.Size(114, 23);
            this.btnEqFirst.TabIndex = 11;
            this.btnEqFirst.Text = "EqualizationFirst";
            this.btnEqFirst.UseVisualStyleBackColor = true;
            this.btnEqFirst.Click += new System.EventHandler(this.btnLab1Clck);
            // 
            // btnEqSecond
            // 
            this.btnEqSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEqSecond.Location = new System.Drawing.Point(152, 64);
            this.btnEqSecond.Name = "btnEqSecond";
            this.btnEqSecond.Size = new System.Drawing.Size(114, 23);
            this.btnEqSecond.TabIndex = 12;
            this.btnEqSecond.Text = "EqualizationSecond";
            this.btnEqSecond.UseVisualStyleBackColor = true;
            this.btnEqSecond.Click += new System.EventHandler(this.btnLab1Clck);
            // 
            // btnEqThird
            // 
            this.btnEqThird.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEqThird.Location = new System.Drawing.Point(152, 93);
            this.btnEqThird.Name = "btnEqThird";
            this.btnEqThird.Size = new System.Drawing.Size(114, 23);
            this.btnEqThird.TabIndex = 13;
            this.btnEqThird.Text = "EqualizationThird";
            this.btnEqThird.UseVisualStyleBackColor = true;
            this.btnEqThird.Click += new System.EventHandler(this.btnLab1Clck);
            // 
            // btnEqMine
            // 
            this.btnEqMine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEqMine.Location = new System.Drawing.Point(152, 6);
            this.btnEqMine.Name = "btnEqMine";
            this.btnEqMine.Size = new System.Drawing.Size(114, 23);
            this.btnEqMine.TabIndex = 14;
            this.btnEqMine.Text = "EqualizationMine";
            this.btnEqMine.UseVisualStyleBackColor = true;
            this.btnEqMine.Click += new System.EventHandler(this.btnLab1Clck);
            // 
            // cbOnePointOp
            // 
            this.cbOnePointOp.FormattingEnabled = true;
            this.cbOnePointOp.Location = new System.Drawing.Point(14, 6);
            this.cbOnePointOp.Name = "cbOnePointOp";
            this.cbOnePointOp.Size = new System.Drawing.Size(115, 21);
            this.cbOnePointOp.TabIndex = 17;
            this.cbOnePointOp.SelectedIndexChanged += new System.EventHandler(this.cbOnePointOp_SelectedIndexChanged);
            // 
            // btnOnePointOp
            // 
            this.btnOnePointOp.Location = new System.Drawing.Point(14, 101);
            this.btnOnePointOp.Name = "btnOnePointOp";
            this.btnOnePointOp.Size = new System.Drawing.Size(115, 23);
            this.btnOnePointOp.TabIndex = 18;
            this.btnOnePointOp.Text = "Apply";
            this.btnOnePointOp.UseVisualStyleBackColor = true;
            this.btnOnePointOp.Click += new System.EventHandler(this.btnLab2_Click);
            // 
            // txtThStart
            // 
            this.txtThStart.Location = new System.Drawing.Point(14, 72);
            this.txtThStart.Name = "txtThStart";
            this.txtThStart.Size = new System.Drawing.Size(45, 20);
            this.txtThStart.TabIndex = 19;
            this.txtThStart.Visible = false;
            this.txtThStart.TextChanged += new System.EventHandler(this.txtThLevel_changing);
            // 
            // txtThEnd
            // 
            this.txtThEnd.Location = new System.Drawing.Point(84, 72);
            this.txtThEnd.Name = "txtThEnd";
            this.txtThEnd.Size = new System.Drawing.Size(45, 20);
            this.txtThEnd.TabIndex = 20;
            this.txtThEnd.Visible = false;
            this.txtThEnd.TextChanged += new System.EventHandler(this.txtThLevel_changing);
            // 
            // lbThStart
            // 
            this.lbThStart.AutoSize = true;
            this.lbThStart.Location = new System.Drawing.Point(11, 56);
            this.lbThStart.Name = "lbThStart";
            this.lbThStart.Size = new System.Drawing.Size(29, 13);
            this.lbThStart.TabIndex = 21;
            this.lbThStart.Text = "Start";
            this.lbThStart.Visible = false;
            // 
            // lbThEnd
            // 
            this.lbThEnd.AutoSize = true;
            this.lbThEnd.Location = new System.Drawing.Point(87, 56);
            this.lbThEnd.Name = "lbThEnd";
            this.lbThEnd.Size = new System.Drawing.Size(26, 13);
            this.lbThEnd.TabIndex = 22;
            this.lbThEnd.Text = "End";
            this.lbThEnd.Visible = false;
            // 
            // cbTwoPointOp
            // 
            this.cbTwoPointOp.FormattingEnabled = true;
            this.cbTwoPointOp.Location = new System.Drawing.Point(166, 6);
            this.cbTwoPointOp.Name = "cbTwoPointOp";
            this.cbTwoPointOp.Size = new System.Drawing.Size(115, 21);
            this.cbTwoPointOp.TabIndex = 23;
            // 
            // btnTwoPointOp
            // 
            this.btnTwoPointOp.Location = new System.Drawing.Point(166, 101);
            this.btnTwoPointOp.Name = "btnTwoPointOp";
            this.btnTwoPointOp.Size = new System.Drawing.Size(115, 23);
            this.btnTwoPointOp.TabIndex = 24;
            this.btnTwoPointOp.Text = "Apply";
            this.btnTwoPointOp.UseVisualStyleBackColor = true;
            this.btnTwoPointOp.Click += new System.EventHandler(this.btnTwoPointOp_Click);
            // 
            // cbSameImage
            // 
            this.cbSameImage.AutoSize = true;
            this.cbSameImage.Location = new System.Drawing.Point(166, 37);
            this.cbSameImage.Name = "cbSameImage";
            this.cbSameImage.Size = new System.Drawing.Size(84, 17);
            this.cbSameImage.TabIndex = 25;
            this.cbSameImage.Text = "Same image";
            this.cbSameImage.UseVisualStyleBackColor = true;
            this.cbSameImage.CheckedChanged += new System.EventHandler(this.cbSameImage_CheckedChanged);
            // 
            // cbAlreadyChosen
            // 
            this.cbAlreadyChosen.AutoSize = true;
            this.cbAlreadyChosen.Enabled = false;
            this.cbAlreadyChosen.Location = new System.Drawing.Point(166, 64);
            this.cbAlreadyChosen.Name = "cbAlreadyChosen";
            this.cbAlreadyChosen.Size = new System.Drawing.Size(130, 17);
            this.cbAlreadyChosen.TabIndex = 26;
            this.cbAlreadyChosen.Text = "Already chosen image";
            this.cbAlreadyChosen.UseVisualStyleBackColor = true;
            this.cbAlreadyChosen.CheckedChanged += new System.EventHandler(this.cbAlreadyChosen_CheckedChanged);
            // 
            // tabCtrlLab
            // 
            this.tabCtrlLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabCtrlLab.Controls.Add(this.tpLab1);
            this.tabCtrlLab.Controls.Add(this.tpLab2);
            this.tabCtrlLab.Controls.Add(this.tpLab3);
            this.tabCtrlLab.Controls.Add(this.tpLab4);
            this.tabCtrlLab.Controls.Add(this.tpLab5);
            this.tabCtrlLab.Controls.Add(this.tpLab6);
            this.tabCtrlLab.Location = new System.Drawing.Point(12, 343);
            this.tabCtrlLab.Name = "tabCtrlLab";
            this.tabCtrlLab.SelectedIndex = 0;
            this.tabCtrlLab.Size = new System.Drawing.Size(791, 162);
            this.tabCtrlLab.TabIndex = 28;
            this.tabCtrlLab.Visible = false;
            this.tabCtrlLab.SelectedIndexChanged += new System.EventHandler(this.tabCtrlLab_SelectedIndexChanged);
            // 
            // tpLab1
            // 
            this.tpLab1.Controls.Add(this.btnStretch);
            this.tpLab1.Controls.Add(this.btnEqFirst);
            this.tpLab1.Controls.Add(this.btnEqSecond);
            this.tpLab1.Controls.Add(this.btnEqThird);
            this.tpLab1.Controls.Add(this.btnEqMine);
            this.tpLab1.Location = new System.Drawing.Point(4, 22);
            this.tpLab1.Name = "tpLab1";
            this.tpLab1.Padding = new System.Windows.Forms.Padding(3);
            this.tpLab1.Size = new System.Drawing.Size(783, 136);
            this.tpLab1.TabIndex = 0;
            this.tpLab1.Text = "Lab1";
            this.tpLab1.UseVisualStyleBackColor = true;
            // 
            // tpLab2
            // 
            this.tpLab2.Controls.Add(this.cbOnePointOp);
            this.tpLab2.Controls.Add(this.txtThEnd);
            this.tpLab2.Controls.Add(this.btnTwoPointOp);
            this.tpLab2.Controls.Add(this.cbAlreadyChosen);
            this.tpLab2.Controls.Add(this.btnOnePointOp);
            this.tpLab2.Controls.Add(this.cbSameImage);
            this.tpLab2.Controls.Add(this.txtThStart);
            this.tpLab2.Controls.Add(this.lbThStart);
            this.tpLab2.Controls.Add(this.cbTwoPointOp);
            this.tpLab2.Controls.Add(this.lbThEnd);
            this.tpLab2.Location = new System.Drawing.Point(4, 22);
            this.tpLab2.Name = "tpLab2";
            this.tpLab2.Padding = new System.Windows.Forms.Padding(3);
            this.tpLab2.Size = new System.Drawing.Size(783, 136);
            this.tpLab2.TabIndex = 1;
            this.tpLab2.Text = "Lab2";
            this.tpLab2.UseVisualStyleBackColor = true;
            // 
            // tpLab3
            // 
            this.tpLab3.Controls.Add(this.lbUserPixel);
            this.tpLab3.Controls.Add(this.txtUserPixel);
            this.tpLab3.Controls.Add(this.lbMedianMulti);
            this.tpLab3.Controls.Add(this.cbMedianY);
            this.tpLab3.Controls.Add(this.cbMedianX);
            this.tpLab3.Controls.Add(this.lbScale);
            this.tpLab3.Controls.Add(this.lbEdge);
            this.tpLab3.Controls.Add(this.cbScaleMethods);
            this.tpLab3.Controls.Add(this.cbEdgeMethods);
            this.tpLab3.Controls.Add(this.btnApplyMedian);
            this.tpLab3.Controls.Add(this.lbMedian);
            this.tpLab3.Controls.Add(this.cbOwnMask);
            this.tpLab3.Controls.Add(this.lbKDiv);
            this.tpLab3.Controls.Add(this.txtMask3_2);
            this.tpLab3.Controls.Add(this.txtMask3_3);
            this.tpLab3.Controls.Add(this.txtMask3_1);
            this.tpLab3.Controls.Add(this.txtMask2_2);
            this.tpLab3.Controls.Add(this.txtMask2_3);
            this.tpLab3.Controls.Add(this.txtMask2_1);
            this.tpLab3.Controls.Add(this.txtMask1_2);
            this.tpLab3.Controls.Add(this.txtMask1_3);
            this.tpLab3.Controls.Add(this.txtMask1_1);
            this.tpLab3.Controls.Add(this.btnApplyMask);
            this.tpLab3.Controls.Add(this.lbMask);
            this.tpLab3.Controls.Add(this.cbMasks);
            this.tpLab3.Location = new System.Drawing.Point(4, 22);
            this.tpLab3.Name = "tpLab3";
            this.tpLab3.Padding = new System.Windows.Forms.Padding(3);
            this.tpLab3.Size = new System.Drawing.Size(783, 136);
            this.tpLab3.TabIndex = 2;
            this.tpLab3.Text = "Lab3";
            this.tpLab3.UseVisualStyleBackColor = true;
            // 
            // lbMedianMulti
            // 
            this.lbMedianMulti.AutoSize = true;
            this.lbMedianMulti.Location = new System.Drawing.Point(393, 22);
            this.lbMedianMulti.Name = "lbMedianMulti";
            this.lbMedianMulti.Size = new System.Drawing.Size(14, 13);
            this.lbMedianMulti.TabIndex = 23;
            this.lbMedianMulti.Text = "X";
            // 
            // cbMedianY
            // 
            this.cbMedianY.FormattingEnabled = true;
            this.cbMedianY.Location = new System.Drawing.Point(413, 19);
            this.cbMedianY.Name = "cbMedianY";
            this.cbMedianY.Size = new System.Drawing.Size(42, 21);
            this.cbMedianY.TabIndex = 22;
            // 
            // cbMedianX
            // 
            this.cbMedianX.FormattingEnabled = true;
            this.cbMedianX.Location = new System.Drawing.Point(345, 19);
            this.cbMedianX.Name = "cbMedianX";
            this.cbMedianX.Size = new System.Drawing.Size(42, 21);
            this.cbMedianX.TabIndex = 21;
            // 
            // lbScale
            // 
            this.lbScale.AutoSize = true;
            this.lbScale.Location = new System.Drawing.Point(6, 42);
            this.lbScale.Name = "lbScale";
            this.lbScale.Size = new System.Drawing.Size(37, 13);
            this.lbScale.TabIndex = 20;
            this.lbScale.Text = "Scale:";
            // 
            // lbEdge
            // 
            this.lbEdge.AutoSize = true;
            this.lbEdge.Location = new System.Drawing.Point(138, 3);
            this.lbEdge.Name = "lbEdge";
            this.lbEdge.Size = new System.Drawing.Size(49, 13);
            this.lbEdge.TabIndex = 19;
            this.lbEdge.Text = "EdgeOp:";
            // 
            // cbScaleMethods
            // 
            this.cbScaleMethods.FormattingEnabled = true;
            this.cbScaleMethods.Location = new System.Drawing.Point(9, 58);
            this.cbScaleMethods.Name = "cbScaleMethods";
            this.cbScaleMethods.Size = new System.Drawing.Size(58, 21);
            this.cbScaleMethods.TabIndex = 18;
            // 
            // cbEdgeMethods
            // 
            this.cbEdgeMethods.FormattingEnabled = true;
            this.cbEdgeMethods.Location = new System.Drawing.Point(141, 19);
            this.cbEdgeMethods.Name = "cbEdgeMethods";
            this.cbEdgeMethods.Size = new System.Drawing.Size(62, 21);
            this.cbEdgeMethods.TabIndex = 17;
            // 
            // btnApplyMedian
            // 
            this.btnApplyMedian.Location = new System.Drawing.Point(345, 107);
            this.btnApplyMedian.Name = "btnApplyMedian";
            this.btnApplyMedian.Size = new System.Drawing.Size(96, 23);
            this.btnApplyMedian.TabIndex = 16;
            this.btnApplyMedian.Text = "Apply median";
            this.btnApplyMedian.UseVisualStyleBackColor = true;
            this.btnApplyMedian.Click += new System.EventHandler(this.btnApplyMedian_Click);
            // 
            // lbMedian
            // 
            this.lbMedian.AutoSize = true;
            this.lbMedian.Location = new System.Drawing.Point(342, 3);
            this.lbMedian.Name = "lbMedian";
            this.lbMedian.Size = new System.Drawing.Size(45, 13);
            this.lbMedian.TabIndex = 14;
            this.lbMedian.Text = "Median:";
            // 
            // cbOwnMask
            // 
            this.cbOwnMask.AutoSize = true;
            this.cbOwnMask.Location = new System.Drawing.Point(9, 85);
            this.cbOwnMask.Name = "cbOwnMask";
            this.cbOwnMask.Size = new System.Drawing.Size(96, 17);
            this.cbOwnMask.TabIndex = 13;
            this.cbOwnMask.Text = "Use own mask";
            this.cbOwnMask.UseVisualStyleBackColor = true;
            this.cbOwnMask.CheckedChanged += new System.EventHandler(this.cbOwnMask_CheckedChanged);
            // 
            // lbKDiv
            // 
            this.lbKDiv.AutoSize = true;
            this.lbKDiv.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbKDiv.Location = new System.Drawing.Point(273, 105);
            this.lbKDiv.Name = "lbKDiv";
            this.lbKDiv.Size = new System.Drawing.Size(0, 13);
            this.lbKDiv.TabIndex = 12;
            // 
            // txtMask3_2
            // 
            this.txtMask3_2.Location = new System.Drawing.Point(185, 98);
            this.txtMask3_2.Name = "txtMask3_2";
            this.txtMask3_2.ReadOnly = true;
            this.txtMask3_2.Size = new System.Drawing.Size(38, 20);
            this.txtMask3_2.TabIndex = 11;
            this.txtMask3_2.TextChanged += new System.EventHandler(this.txtMask_TextChanged);
            // 
            // txtMask3_3
            // 
            this.txtMask3_3.Location = new System.Drawing.Point(229, 98);
            this.txtMask3_3.Name = "txtMask3_3";
            this.txtMask3_3.ReadOnly = true;
            this.txtMask3_3.Size = new System.Drawing.Size(38, 20);
            this.txtMask3_3.TabIndex = 10;
            this.txtMask3_3.TextChanged += new System.EventHandler(this.txtMask_TextChanged);
            // 
            // txtMask3_1
            // 
            this.txtMask3_1.Location = new System.Drawing.Point(141, 98);
            this.txtMask3_1.Name = "txtMask3_1";
            this.txtMask3_1.ReadOnly = true;
            this.txtMask3_1.Size = new System.Drawing.Size(38, 20);
            this.txtMask3_1.TabIndex = 9;
            this.txtMask3_1.TextChanged += new System.EventHandler(this.txtMask_TextChanged);
            // 
            // txtMask2_2
            // 
            this.txtMask2_2.Location = new System.Drawing.Point(185, 72);
            this.txtMask2_2.Name = "txtMask2_2";
            this.txtMask2_2.ReadOnly = true;
            this.txtMask2_2.Size = new System.Drawing.Size(38, 20);
            this.txtMask2_2.TabIndex = 8;
            this.txtMask2_2.TextChanged += new System.EventHandler(this.txtMask_TextChanged);
            // 
            // txtMask2_3
            // 
            this.txtMask2_3.Location = new System.Drawing.Point(229, 72);
            this.txtMask2_3.Name = "txtMask2_3";
            this.txtMask2_3.ReadOnly = true;
            this.txtMask2_3.Size = new System.Drawing.Size(38, 20);
            this.txtMask2_3.TabIndex = 7;
            this.txtMask2_3.TextChanged += new System.EventHandler(this.txtMask_TextChanged);
            // 
            // txtMask2_1
            // 
            this.txtMask2_1.Location = new System.Drawing.Point(141, 72);
            this.txtMask2_1.Name = "txtMask2_1";
            this.txtMask2_1.ReadOnly = true;
            this.txtMask2_1.Size = new System.Drawing.Size(38, 20);
            this.txtMask2_1.TabIndex = 6;
            this.txtMask2_1.TextChanged += new System.EventHandler(this.txtMask_TextChanged);
            // 
            // txtMask1_2
            // 
            this.txtMask1_2.Location = new System.Drawing.Point(185, 46);
            this.txtMask1_2.Name = "txtMask1_2";
            this.txtMask1_2.ReadOnly = true;
            this.txtMask1_2.Size = new System.Drawing.Size(38, 20);
            this.txtMask1_2.TabIndex = 5;
            this.txtMask1_2.TextChanged += new System.EventHandler(this.txtMask_TextChanged);
            // 
            // txtMask1_3
            // 
            this.txtMask1_3.Location = new System.Drawing.Point(229, 46);
            this.txtMask1_3.Name = "txtMask1_3";
            this.txtMask1_3.ReadOnly = true;
            this.txtMask1_3.Size = new System.Drawing.Size(38, 20);
            this.txtMask1_3.TabIndex = 4;
            this.txtMask1_3.TextChanged += new System.EventHandler(this.txtMask_TextChanged);
            // 
            // txtMask1_1
            // 
            this.txtMask1_1.Location = new System.Drawing.Point(141, 46);
            this.txtMask1_1.Name = "txtMask1_1";
            this.txtMask1_1.ReadOnly = true;
            this.txtMask1_1.Size = new System.Drawing.Size(38, 20);
            this.txtMask1_1.TabIndex = 3;
            this.txtMask1_1.TextChanged += new System.EventHandler(this.txtMask_TextChanged);
            // 
            // btnApplyMask
            // 
            this.btnApplyMask.Location = new System.Drawing.Point(6, 107);
            this.btnApplyMask.Name = "btnApplyMask";
            this.btnApplyMask.Size = new System.Drawing.Size(75, 23);
            this.btnApplyMask.TabIndex = 2;
            this.btnApplyMask.Text = "Apply mask";
            this.btnApplyMask.UseVisualStyleBackColor = true;
            this.btnApplyMask.Click += new System.EventHandler(this.btnApplyMask_Click);
            // 
            // lbMask
            // 
            this.lbMask.AutoSize = true;
            this.lbMask.Location = new System.Drawing.Point(6, 3);
            this.lbMask.Name = "lbMask";
            this.lbMask.Size = new System.Drawing.Size(41, 13);
            this.lbMask.TabIndex = 1;
            this.lbMask.Text = "Masks:";
            // 
            // cbMasks
            // 
            this.cbMasks.FormattingEnabled = true;
            this.cbMasks.Location = new System.Drawing.Point(9, 19);
            this.cbMasks.Name = "cbMasks";
            this.cbMasks.Size = new System.Drawing.Size(121, 21);
            this.cbMasks.TabIndex = 0;
            this.cbMasks.SelectedIndexChanged += new System.EventHandler(this.cbMasks_SelectedIndexChanged);
            // 
            // tpLab4
            // 
            this.tpLab4.Controls.Add(this.lbEdgeOpSkel);
            this.tpLab4.Controls.Add(this.cbEdgeMethodsSkel);
            this.tpLab4.Controls.Add(this.btnApplySkel);
            this.tpLab4.Controls.Add(this.lbEdgeOpMorph);
            this.tpLab4.Controls.Add(this.cbEdgeMethodsMorph);
            this.tpLab4.Controls.Add(this.btnApplyMorph);
            this.tpLab4.Controls.Add(this.cbStructElementsMorph);
            this.tpLab4.Controls.Add(this.lbElementMorph);
            this.tpLab4.Controls.Add(this.lbMorph);
            this.tpLab4.Controls.Add(this.cbMorphOperations);
            this.tpLab4.Location = new System.Drawing.Point(4, 22);
            this.tpLab4.Name = "tpLab4";
            this.tpLab4.Padding = new System.Windows.Forms.Padding(3);
            this.tpLab4.Size = new System.Drawing.Size(783, 136);
            this.tpLab4.TabIndex = 3;
            this.tpLab4.Text = "Lab4";
            this.tpLab4.UseVisualStyleBackColor = true;
            // 
            // lbEdgeOpSkel
            // 
            this.lbEdgeOpSkel.AutoSize = true;
            this.lbEdgeOpSkel.Location = new System.Drawing.Point(300, 62);
            this.lbEdgeOpSkel.Name = "lbEdgeOpSkel";
            this.lbEdgeOpSkel.Size = new System.Drawing.Size(82, 13);
            this.lbEdgeOpSkel.TabIndex = 9;
            this.lbEdgeOpSkel.Text = "Edge operation:";
            // 
            // cbEdgeMethodsSkel
            // 
            this.cbEdgeMethodsSkel.FormattingEnabled = true;
            this.cbEdgeMethodsSkel.Location = new System.Drawing.Point(388, 59);
            this.cbEdgeMethodsSkel.Name = "cbEdgeMethodsSkel";
            this.cbEdgeMethodsSkel.Size = new System.Drawing.Size(121, 21);
            this.cbEdgeMethodsSkel.TabIndex = 8;
            // 
            // btnApplySkel
            // 
            this.btnApplySkel.Location = new System.Drawing.Point(262, 112);
            this.btnApplySkel.Name = "btnApplySkel";
            this.btnApplySkel.Size = new System.Drawing.Size(247, 21);
            this.btnApplySkel.TabIndex = 7;
            this.btnApplySkel.Text = "Skeletonization";
            this.btnApplySkel.UseVisualStyleBackColor = true;
            this.btnApplySkel.Click += new System.EventHandler(this.btnApplySkel_Click);
            // 
            // lbEdgeOpMorph
            // 
            this.lbEdgeOpMorph.AutoSize = true;
            this.lbEdgeOpMorph.Location = new System.Drawing.Point(47, 62);
            this.lbEdgeOpMorph.Name = "lbEdgeOpMorph";
            this.lbEdgeOpMorph.Size = new System.Drawing.Size(82, 13);
            this.lbEdgeOpMorph.TabIndex = 6;
            this.lbEdgeOpMorph.Text = "Edge operation:";
            // 
            // cbEdgeMethodsMorph
            // 
            this.cbEdgeMethodsMorph.FormattingEnabled = true;
            this.cbEdgeMethodsMorph.Location = new System.Drawing.Point(135, 59);
            this.cbEdgeMethodsMorph.Name = "cbEdgeMethodsMorph";
            this.cbEdgeMethodsMorph.Size = new System.Drawing.Size(121, 21);
            this.cbEdgeMethodsMorph.TabIndex = 5;
            // 
            // btnApplyMorph
            // 
            this.btnApplyMorph.Location = new System.Drawing.Point(9, 112);
            this.btnApplyMorph.Name = "btnApplyMorph";
            this.btnApplyMorph.Size = new System.Drawing.Size(247, 21);
            this.btnApplyMorph.TabIndex = 4;
            this.btnApplyMorph.Text = "Apply operation";
            this.btnApplyMorph.UseVisualStyleBackColor = true;
            this.btnApplyMorph.Click += new System.EventHandler(this.btnApplyMorph_Click);
            // 
            // cbStructElementsMorph
            // 
            this.cbStructElementsMorph.FormattingEnabled = true;
            this.cbStructElementsMorph.Location = new System.Drawing.Point(135, 32);
            this.cbStructElementsMorph.Name = "cbStructElementsMorph";
            this.cbStructElementsMorph.Size = new System.Drawing.Size(121, 21);
            this.cbStructElementsMorph.TabIndex = 3;
            // 
            // lbElementMorph
            // 
            this.lbElementMorph.AutoSize = true;
            this.lbElementMorph.Location = new System.Drawing.Point(51, 35);
            this.lbElementMorph.Name = "lbElementMorph";
            this.lbElementMorph.Size = new System.Drawing.Size(78, 13);
            this.lbElementMorph.TabIndex = 2;
            this.lbElementMorph.Text = "Struct element:";
            // 
            // lbMorph
            // 
            this.lbMorph.AutoSize = true;
            this.lbMorph.Location = new System.Drawing.Point(6, 9);
            this.lbMorph.Name = "lbMorph";
            this.lbMorph.Size = new System.Drawing.Size(123, 13);
            this.lbMorph.TabIndex = 1;
            this.lbMorph.Text = "Morphological operation:";
            // 
            // cbMorphOperations
            // 
            this.cbMorphOperations.FormattingEnabled = true;
            this.cbMorphOperations.Location = new System.Drawing.Point(135, 6);
            this.cbMorphOperations.Name = "cbMorphOperations";
            this.cbMorphOperations.Size = new System.Drawing.Size(121, 21);
            this.cbMorphOperations.TabIndex = 0;
            // 
            // tpLab5
            // 
            this.tpLab5.Controls.Add(this.cbComBlocksSize);
            this.tpLab5.Controls.Add(this.btnCompressionBlocks);
            this.tpLab5.Controls.Add(this.btnCompressionHuffmans);
            this.tpLab5.Controls.Add(this.btnCompressionRead);
            this.tpLab5.Controls.Add(this.btnCompressionRle);
            this.tpLab5.Location = new System.Drawing.Point(4, 22);
            this.tpLab5.Name = "tpLab5";
            this.tpLab5.Padding = new System.Windows.Forms.Padding(3);
            this.tpLab5.Size = new System.Drawing.Size(783, 136);
            this.tpLab5.TabIndex = 4;
            this.tpLab5.Text = "Lab5";
            this.tpLab5.UseVisualStyleBackColor = true;
            // 
            // cbComBlocksSize
            // 
            this.cbComBlocksSize.FormattingEnabled = true;
            this.cbComBlocksSize.Location = new System.Drawing.Point(144, 87);
            this.cbComBlocksSize.Name = "cbComBlocksSize";
            this.cbComBlocksSize.Size = new System.Drawing.Size(121, 21);
            this.cbComBlocksSize.TabIndex = 4;
            // 
            // btnCompressionBlocks
            // 
            this.btnCompressionBlocks.Location = new System.Drawing.Point(6, 87);
            this.btnCompressionBlocks.Name = "btnCompressionBlocks";
            this.btnCompressionBlocks.Size = new System.Drawing.Size(132, 21);
            this.btnCompressionBlocks.TabIndex = 3;
            this.btnCompressionBlocks.Text = "Blocks Compression";
            this.btnCompressionBlocks.UseVisualStyleBackColor = true;
            this.btnCompressionBlocks.Click += new System.EventHandler(this.btnCompressionBlocks_Click);
            // 
            // btnCompressionHuffmans
            // 
            this.btnCompressionHuffmans.Location = new System.Drawing.Point(6, 60);
            this.btnCompressionHuffmans.Name = "btnCompressionHuffmans";
            this.btnCompressionHuffmans.Size = new System.Drawing.Size(132, 21);
            this.btnCompressionHuffmans.TabIndex = 2;
            this.btnCompressionHuffmans.Text = "Huffmans Copression";
            this.btnCompressionHuffmans.UseVisualStyleBackColor = true;
            this.btnCompressionHuffmans.Click += new System.EventHandler(this.btnCompressionHuffmans_Click);
            // 
            // btnCompressionRead
            // 
            this.btnCompressionRead.Location = new System.Drawing.Point(6, 33);
            this.btnCompressionRead.Name = "btnCompressionRead";
            this.btnCompressionRead.Size = new System.Drawing.Size(132, 21);
            this.btnCompressionRead.TabIndex = 1;
            this.btnCompressionRead.Text = "READ Compression";
            this.btnCompressionRead.UseVisualStyleBackColor = true;
            this.btnCompressionRead.Click += new System.EventHandler(this.btnCompressionRead_Click);
            // 
            // btnCompressionRle
            // 
            this.btnCompressionRle.Location = new System.Drawing.Point(6, 6);
            this.btnCompressionRle.Name = "btnCompressionRle";
            this.btnCompressionRle.Size = new System.Drawing.Size(132, 21);
            this.btnCompressionRle.TabIndex = 0;
            this.btnCompressionRle.Text = "RLE Compression";
            this.btnCompressionRle.UseVisualStyleBackColor = true;
            this.btnCompressionRle.Click += new System.EventHandler(this.btnCompressionRle_Click);
            // 
            // tpLab6
            // 
            this.tpLab6.Controls.Add(this.btnTurtle);
            this.tpLab6.Location = new System.Drawing.Point(4, 22);
            this.tpLab6.Name = "tpLab6";
            this.tpLab6.Padding = new System.Windows.Forms.Padding(3);
            this.tpLab6.Size = new System.Drawing.Size(783, 136);
            this.tpLab6.TabIndex = 5;
            this.tpLab6.Text = "Lab6";
            this.tpLab6.UseVisualStyleBackColor = true;
            // 
            // btnTurtle
            // 
            this.btnTurtle.Location = new System.Drawing.Point(6, 101);
            this.btnTurtle.Name = "btnTurtle";
            this.btnTurtle.Size = new System.Drawing.Size(159, 23);
            this.btnTurtle.TabIndex = 0;
            this.btnTurtle.Text = "Turtle";
            this.btnTurtle.UseVisualStyleBackColor = true;
            this.btnTurtle.Click += new System.EventHandler(this.btnTurtle_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oProgramieToolStripMenuItem
            // 
            this.oProgramieToolStripMenuItem.Name = "oProgramieToolStripMenuItem";
            this.oProgramieToolStripMenuItem.Size = new System.Drawing.Size(144, 20);
            this.oProgramieToolStripMenuItem.Text = "Informacja o programie";
            this.oProgramieToolStripMenuItem.Click += new System.EventHandler(this.oProgramieToolStripMenuItem_Click);
            // 
            // txtUserPixel
            // 
            this.txtUserPixel.Location = new System.Drawing.Point(205, 19);
            this.txtUserPixel.Name = "txtUserPixel";
            this.txtUserPixel.Size = new System.Drawing.Size(62, 20);
            this.txtUserPixel.TabIndex = 24;
            // 
            // lbUserPixel
            // 
            this.lbUserPixel.AutoSize = true;
            this.lbUserPixel.Location = new System.Drawing.Point(202, 3);
            this.lbUserPixel.Name = "lbUserPixel";
            this.lbUserPixel.Size = new System.Drawing.Size(56, 13);
            this.lbUserPixel.TabIndex = 25;
            this.lbUserPixel.Text = "User pixel:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 508);
            this.Controls.Add(this.tabCtrlLab);
            this.Controls.Add(this.mainHistogram);
            this.Controls.Add(this.picBoxMain);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainHistogram)).EndInit();
            this.tabCtrlLab.ResumeLayout(false);
            this.tpLab1.ResumeLayout(false);
            this.tpLab2.ResumeLayout(false);
            this.tpLab2.PerformLayout();
            this.tpLab3.ResumeLayout(false);
            this.tpLab3.PerformLayout();
            this.tpLab4.ResumeLayout(false);
            this.tpLab4.PerformLayout();
            this.tpLab5.ResumeLayout(false);
            this.tpLab6.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.PictureBox picBoxMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainHistogram;
        private System.Windows.Forms.Button btnStretch;
        private System.Windows.Forms.Button btnEqFirst;
        private System.Windows.Forms.Button btnEqSecond;
        private System.Windows.Forms.Button btnEqThird;
        private System.Windows.Forms.Button btnEqMine;
        private System.Windows.Forms.ComboBox cbOnePointOp;
        private System.Windows.Forms.Button btnOnePointOp;
        private System.Windows.Forms.TextBox txtThStart;
        private System.Windows.Forms.TextBox txtThEnd;
        private System.Windows.Forms.Label lbThStart;
        private System.Windows.Forms.Label lbThEnd;
        private System.Windows.Forms.ComboBox cbTwoPointOp;
        private System.Windows.Forms.Button btnTwoPointOp;
        private System.Windows.Forms.CheckBox cbSameImage;
        private System.Windows.Forms.CheckBox cbAlreadyChosen;
        private System.Windows.Forms.TabControl tabCtrlLab;
        private System.Windows.Forms.TabPage tpLab1;
        private System.Windows.Forms.TabPage tpLab2;
        private System.Windows.Forms.TabPage tpLab3;
        private System.Windows.Forms.ComboBox cbMasks;
        private System.Windows.Forms.Label lbMask;
        private System.Windows.Forms.TextBox txtMask3_2;
        private System.Windows.Forms.TextBox txtMask3_3;
        private System.Windows.Forms.TextBox txtMask3_1;
        private System.Windows.Forms.TextBox txtMask2_2;
        private System.Windows.Forms.TextBox txtMask2_3;
        private System.Windows.Forms.TextBox txtMask2_1;
        private System.Windows.Forms.TextBox txtMask1_2;
        private System.Windows.Forms.TextBox txtMask1_3;
        private System.Windows.Forms.TextBox txtMask1_1;
        private System.Windows.Forms.Button btnApplyMask;
        private System.Windows.Forms.Label lbKDiv;
        private System.Windows.Forms.CheckBox cbOwnMask;
        private System.Windows.Forms.Label lbMedian;
        private System.Windows.Forms.Button btnApplyMedian;
        private System.Windows.Forms.Label lbScale;
        private System.Windows.Forms.Label lbEdge;
        private System.Windows.Forms.ComboBox cbScaleMethods;
        private System.Windows.Forms.ComboBox cbEdgeMethods;
        private System.Windows.Forms.Label lbMedianMulti;
        private System.Windows.Forms.ComboBox cbMedianY;
        private System.Windows.Forms.ComboBox cbMedianX;
        private System.Windows.Forms.TabPage tpLab4;
        private System.Windows.Forms.Button btnApplyMorph;
        private System.Windows.Forms.ComboBox cbStructElementsMorph;
        private System.Windows.Forms.Label lbElementMorph;
        private System.Windows.Forms.Label lbMorph;
        private System.Windows.Forms.ComboBox cbMorphOperations;
        private System.Windows.Forms.Label lbEdgeOpMorph;
        private System.Windows.Forms.ComboBox cbEdgeMethodsMorph;
        private System.Windows.Forms.TabPage tpLab5;
        private System.Windows.Forms.Button btnCompressionRle;
        private System.Windows.Forms.Button btnCompressionRead;
        private System.Windows.Forms.Button btnCompressionHuffmans;
        private System.Windows.Forms.ComboBox cbComBlocksSize;
        private System.Windows.Forms.Button btnCompressionBlocks;
        private System.Windows.Forms.TabPage tpLab6;
        private System.Windows.Forms.Button btnTurtle;
        private System.Windows.Forms.Label lbEdgeOpSkel;
        private System.Windows.Forms.ComboBox cbEdgeMethodsSkel;
        private System.Windows.Forms.Button btnApplySkel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oProgramieToolStripMenuItem;
        private System.Windows.Forms.Label lbUserPixel;
        private System.Windows.Forms.TextBox txtUserPixel;
    }
}

