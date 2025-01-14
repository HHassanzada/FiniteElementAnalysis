﻿
namespace SSH
{
    partial class SSHMain
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribPgTrussSolver = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.txtStiffness = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSectionArea = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNodeJ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNodeI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddElement = new System.Windows.Forms.Button();
            this.gcTrussElements = new DevExpress.XtraGrid.GridControl();
            this.gvTrussElements = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gcNodes = new DevExpress.XtraGrid.GridControl();
            this.gvNodes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gcLoads = new DevExpress.XtraGrid.GridControl();
            this.gvLoads = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAddLoad = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.gcBoundaryConditions = new DevExpress.XtraGrid.GridControl();
            this.gvBoundaryConditions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAddRestrain = new System.Windows.Forms.Button();
            this.btnSolveTruss = new System.Windows.Forms.Button();
            this.chartDrawing = new DevExpress.XtraCharts.ChartControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNodeIdLoading = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNodeY = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNodeX = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYComponent = new System.Windows.Forms.TextBox();
            this.txtXComponent = new System.Windows.Forms.TextBox();
            this.cmbSupportType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBCNodeId = new System.Windows.Forms.TextBox();
            this.N = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTrussElements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTrussElements)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNodes)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLoads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLoads)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBoundaryConditions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBoundaryConditions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDrawing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribPgTrussSolver,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(1309, 158);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribPgTrussSolver
            // 
            this.ribPgTrussSolver.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribPgTrussSolver.Name = "ribPgTrussSolver";
            this.ribPgTrussSolver.Text = "Truss Solver";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // txtStiffness
            // 
            this.txtStiffness.Location = new System.Drawing.Point(58, 29);
            this.txtStiffness.Name = "txtStiffness";
            this.txtStiffness.Size = new System.Drawing.Size(85, 21);
            this.txtStiffness.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "E";
            // 
            // txtSectionArea
            // 
            this.txtSectionArea.Location = new System.Drawing.Point(58, 56);
            this.txtSectionArea.Name = "txtSectionArea";
            this.txtSectionArea.Size = new System.Drawing.Size(85, 21);
            this.txtSectionArea.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNodeJ);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNodeI);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(205, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 89);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nodes Info";
            // 
            // txtNodeJ
            // 
            this.txtNodeJ.Location = new System.Drawing.Point(72, 56);
            this.txtNodeJ.Name = "txtNodeJ";
            this.txtNodeJ.Size = new System.Drawing.Size(85, 21);
            this.txtNodeJ.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Node J-ID";
            // 
            // txtNodeI
            // 
            this.txtNodeI.Location = new System.Drawing.Point(72, 29);
            this.txtNodeI.Name = "txtNodeI";
            this.txtNodeI.Size = new System.Drawing.Size(85, 21);
            this.txtNodeI.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Node I-ID";
            // 
            // btnAddElement
            // 
            this.btnAddElement.Location = new System.Drawing.Point(406, 70);
            this.btnAddElement.Name = "btnAddElement";
            this.btnAddElement.Size = new System.Drawing.Size(86, 49);
            this.btnAddElement.TabIndex = 16;
            this.btnAddElement.Text = "Add";
            this.btnAddElement.UseVisualStyleBackColor = true;
            // 
            // gcTrussElements
            // 
            this.gcTrussElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gcTrussElements.Location = new System.Drawing.Point(16, 142);
            this.gcTrussElements.MainView = this.gvTrussElements;
            this.gcTrussElements.MenuManager = this.ribbonControl1;
            this.gcTrussElements.Name = "gcTrussElements";
            this.gcTrussElements.Size = new System.Drawing.Size(628, 154);
            this.gcTrussElements.TabIndex = 17;
            this.gcTrussElements.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTrussElements});
            // 
            // gvTrussElements
            // 
            this.gvTrussElements.GridControl = this.gcTrussElements;
            this.gvTrussElements.Name = "gvTrussElements";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.gcTrussElements);
            this.groupBox3.Controls.Add(this.btnAddElement);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 461);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(687, 302);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Elements Info";
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.groupBox2.Controls.Add(this.txtStiffness);
            this.groupBox2.Controls.Add(this.txtSectionArea);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(16, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 89);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Section Info";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtNodeY);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtNodeX);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.gcNodes);
            this.groupBox4.Controls.Add(this.btnAddNode);
            this.groupBox4.Location = new System.Drawing.Point(12, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(337, 289);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nodes Info";
            // 
            // gcNodes
            // 
            this.gcNodes.Location = new System.Drawing.Point(16, 113);
            this.gcNodes.MainView = this.gvNodes;
            this.gcNodes.MenuManager = this.ribbonControl1;
            this.gcNodes.Name = "gcNodes";
            this.gcNodes.Size = new System.Drawing.Size(305, 175);
            this.gcNodes.TabIndex = 17;
            this.gcNodes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNodes});
            // 
            // gvNodes
            // 
            this.gvNodes.GridControl = this.gcNodes;
            this.gvNodes.Name = "gvNodes";
            // 
            // btnAddNode
            // 
            this.btnAddNode.Location = new System.Drawing.Point(155, 38);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(66, 34);
            this.btnAddNode.TabIndex = 16;
            this.btnAddNode.Text = "Add Node";
            this.btnAddNode.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtNodeIdLoading);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtYComponent);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtXComponent);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.gcLoads);
            this.groupBox5.Controls.Add(this.btnAddLoad);
            this.groupBox5.Location = new System.Drawing.Point(362, 165);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(337, 290);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Loading Info";
            // 
            // gcLoads
            // 
            this.gcLoads.Location = new System.Drawing.Point(16, 113);
            this.gcLoads.MainView = this.gvLoads;
            this.gcLoads.MenuManager = this.ribbonControl1;
            this.gcLoads.Name = "gcLoads";
            this.gcLoads.Size = new System.Drawing.Size(305, 175);
            this.gcLoads.TabIndex = 17;
            this.gcLoads.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLoads});
            // 
            // gvLoads
            // 
            this.gvLoads.GridControl = this.gcLoads;
            this.gvLoads.Name = "gvLoads";
            // 
            // btnAddLoad
            // 
            this.btnAddLoad.Location = new System.Drawing.Point(163, 38);
            this.btnAddLoad.Name = "btnAddLoad";
            this.btnAddLoad.Size = new System.Drawing.Size(66, 36);
            this.btnAddLoad.TabIndex = 16;
            this.btnAddLoad.Text = "Add Load";
            this.btnAddLoad.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.cmbSupportType);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.txtBCNodeId);
            this.groupBox8.Controls.Add(this.N);
            this.groupBox8.Controls.Add(this.gcBoundaryConditions);
            this.groupBox8.Controls.Add(this.btnAddRestrain);
            this.groupBox8.Location = new System.Drawing.Point(705, 165);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(338, 290);
            this.groupBox8.TabIndex = 23;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Boundary Conditions Info";
            // 
            // gcBoundaryConditions
            // 
            this.gcBoundaryConditions.Location = new System.Drawing.Point(16, 113);
            this.gcBoundaryConditions.MainView = this.gvBoundaryConditions;
            this.gcBoundaryConditions.MenuManager = this.ribbonControl1;
            this.gcBoundaryConditions.Name = "gcBoundaryConditions";
            this.gcBoundaryConditions.Size = new System.Drawing.Size(305, 175);
            this.gcBoundaryConditions.TabIndex = 17;
            this.gcBoundaryConditions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBoundaryConditions});
            // 
            // gvBoundaryConditions
            // 
            this.gvBoundaryConditions.GridControl = this.gcBoundaryConditions;
            this.gvBoundaryConditions.Name = "gvBoundaryConditions";
            // 
            // btnAddRestrain
            // 
            this.btnAddRestrain.Location = new System.Drawing.Point(180, 40);
            this.btnAddRestrain.Name = "btnAddRestrain";
            this.btnAddRestrain.Size = new System.Drawing.Size(66, 34);
            this.btnAddRestrain.TabIndex = 16;
            this.btnAddRestrain.Text = "Add Constraint";
            this.btnAddRestrain.UseVisualStyleBackColor = true;
            // 
            // btnSolveTruss
            // 
            this.btnSolveTruss.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolveTruss.Location = new System.Drawing.Point(1089, 167);
            this.btnSolveTruss.Name = "btnSolveTruss";
            this.btnSolveTruss.Size = new System.Drawing.Size(158, 49);
            this.btnSolveTruss.TabIndex = 19;
            this.btnSolveTruss.Text = "Solve Truss";
            this.btnSolveTruss.UseVisualStyleBackColor = true;
            // 
            // chartDrawing
            // 
            this.chartDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartDrawing.Legend.Name = "Default Legend";
            this.chartDrawing.Location = new System.Drawing.Point(705, 469);
            this.chartDrawing.Name = "chartDrawing";
            this.chartDrawing.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartDrawing.Size = new System.Drawing.Size(465, 294);
            this.chartDrawing.TabIndex = 30;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(1179, 469);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 294);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // txtNodeIdLoading
            // 
            this.txtNodeIdLoading.Location = new System.Drawing.Point(68, 30);
            this.txtNodeIdLoading.Name = "txtNodeIdLoading";
            this.txtNodeIdLoading.Size = new System.Drawing.Size(67, 21);
            this.txtNodeIdLoading.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Node ID";
            // 
            // txtNodeY
            // 
            this.txtNodeY.Location = new System.Drawing.Point(62, 56);
            this.txtNodeY.Name = "txtNodeY";
            this.txtNodeY.Size = new System.Drawing.Size(67, 21);
            this.txtNodeY.TabIndex = 21;
            this.txtNodeY.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Ycoord";
            // 
            // txtNodeX
            // 
            this.txtNodeX.Location = new System.Drawing.Point(62, 29);
            this.txtNodeX.Name = "txtNodeX";
            this.txtNodeX.Size = new System.Drawing.Size(67, 21);
            this.txtNodeX.TabIndex = 19;
            this.txtNodeX.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Xcoord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "X";
            // 
            // txtYComponent
            // 
            this.txtYComponent.Location = new System.Drawing.Point(68, 84);
            this.txtYComponent.Name = "txtYComponent";
            this.txtYComponent.Size = new System.Drawing.Size(67, 21);
            this.txtYComponent.TabIndex = 21;
            // 
            // txtXComponent
            // 
            this.txtXComponent.Location = new System.Drawing.Point(68, 57);
            this.txtXComponent.Name = "txtXComponent";
            this.txtXComponent.Size = new System.Drawing.Size(67, 21);
            this.txtXComponent.TabIndex = 19;
            // 
            // cmbSupportType
            // 
            this.cmbSupportType.FormattingEnabled = true;
            this.cmbSupportType.Location = new System.Drawing.Point(93, 57);
            this.cmbSupportType.Name = "cmbSupportType";
            this.cmbSupportType.Size = new System.Drawing.Size(67, 21);
            this.cmbSupportType.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Restrained Dir";
            // 
            // txtBCNodeId
            // 
            this.txtBCNodeId.Location = new System.Drawing.Point(93, 30);
            this.txtBCNodeId.Name = "txtBCNodeId";
            this.txtBCNodeId.Size = new System.Drawing.Size(67, 21);
            this.txtBCNodeId.TabIndex = 19;
            // 
            // N
            // 
            this.N.AutoSize = true;
            this.N.Location = new System.Drawing.Point(41, 33);
            this.N.Name = "N";
            this.N.Size = new System.Drawing.Size(46, 13);
            this.N.TabIndex = 18;
            this.N.Text = "Node ID";
            // 
            // SSHMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 789);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chartDrawing);
            this.Controls.Add(this.btnSolveTruss);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "SSHMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTrussElements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTrussElements)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNodes)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLoads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLoads)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBoundaryConditions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBoundaryConditions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDrawing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribPgTrussSolver;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.TextBox txtStiffness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSectionArea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNodeI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddElement;
        private DevExpress.XtraGrid.GridControl gcTrussElements;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTrussElements;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAddNode;
        private DevExpress.XtraGrid.GridControl gcNodes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNodes;
        private System.Windows.Forms.TextBox txtNodeJ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevExpress.XtraGrid.GridControl gcLoads;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLoads;
        private System.Windows.Forms.Button btnAddLoad;
        private System.Windows.Forms.GroupBox groupBox8;
        private DevExpress.XtraGrid.GridControl gcBoundaryConditions;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBoundaryConditions;
        private System.Windows.Forms.Button btnAddRestrain;
        private System.Windows.Forms.Button btnSolveTruss;
        private DevExpress.XtraCharts.ChartControl chartDrawing;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNodeY;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNodeX;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNodeIdLoading;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtYComponent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtXComponent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSupportType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBCNodeId;
        private System.Windows.Forms.Label N;
    }
}

