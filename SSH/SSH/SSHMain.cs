﻿using SSH.TrussSolver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DevExpress.XtraCharts;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Series = DevExpress.XtraCharts.Series;
using System.ComponentModel;

namespace SSH
{

    public partial class SSHMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Ctor

        public SSHMain()
        {
            InitializeComponent();
            SubscribeToEvents();
            _nodesList = new List<Node>();
            _TrussElementsList = new List<TrussElement>();
            _restrainedNodes = new List<RestrainedNode>();
            _nodalForces = new List<PointLoad>();

            CreateExample1();

            prepareUI();
            SetNodeTableColumns();
            SetElementsTableColumns();
            SetBCTableColumns();
            SetLoadTableColumns();
            EditNodeTableGridView();
            EditElementsTableGridView();
            EditBCTableGridView();
            EditLoadTableGridView();
            drawChart();
        }

        #endregion

        #region Private Fields

        private List<Node> _nodesList;
        private List<TrussElement> _TrussElementsList;
        private DataTable _dataNodeTable;
        private DataTable _dataTrussElementsTable;
        private DataTable _dataBoundaryConditionsTable;
        private DataTable _dataLoadTable;
        private List<RestrainedNode> _restrainedNodes;
        private List<PointLoad> _nodalForces;
        private Graphics _g;

        #endregion

        #region Private Methods

        private void SubscribeToEvents()
        {
            btnAddNode.Click += BtnAddNode_Click;
            btnAddElement.Click += BtnAddElement_Click;
            btnAddLoad.Click += BtnAddLoad_Click;
            btnAddRestrain.Click += BtnAddRestrain_Click;
            btnSolveTruss.Click += BtnSolveTruss_Click;
            pictureBox1.Paint += canvasPictureBox_Paint;
        }

        private void CreateExample1()
        {
            AddNode(1, 0, 0);
            AddNode(2, 5, 8.66);
            AddNode(3, 15, 8.66);
            AddNode(4, 20, 0);
            AddNode(5, 10, 0);
            AddNode(6, 10, -5);
            var E = 200 * Math.Pow(10, 9);
            var A = 5000;
            AddMember("A", 1, 2, E, A);
            AddMember("B", 2, 3, E, A);
            AddMember("C", 3, 4, E, A);
            AddMember("D", 4, 5, E, A);
            AddMember("E", 1, 5, E, A);
            AddMember("F", 2, 5, E, A);
            AddMember("G", 3, 5, E, A);
            AddMember("H", 5, 6, E, A);
            AddRestrainedNode(4, true, true);
            AddRestrainedNode(6, true, true);
            AddLoad(1, 0, -200000);

        }

        private void CreateExample2()
        {
            AddNode(1, 0, 0);
            AddNode(2, 1, 0);
            AddNode(3, 0.5, 1);
            var E = 1 * Math.Pow(10, 6);
            var A = 10000;
            AddMember("A", 1, 2, E, A);
            AddMember("B", 2, 3, E, A);
            AddMember("C", 3, 1, E, A);
            AddRestrainedNode(1, true, true);
            AddRestrainedNode(2, false, true);
            AddLoad(3, 0, -20);


        }

        private void AddLoad(int nodeId, double fx, double fy)
        {
            var node = (TrussNode)GetNodeById(nodeId);
            node.Fx = fx;
            node.Fy = fy;

        }

        private void AddRestrainedNode(int nodeId, bool isXRestrained, bool isYRestrained)
        {
            var node = (TrussNode)GetNodeById(nodeId);
            node.XDirection = isXRestrained ? eRestraintCondition.restrained : eRestraintCondition.free;
            node.YDirection = isYRestrained ? eRestraintCondition.restrained : eRestraintCondition.free;
        }

        private Node GetNodeById(int NodeId)
        {
            return _nodesList.FirstOrDefault(x => x.ID == NodeId);
        }

        private void AddNode(int ID, double X, double Y)
        {
            _nodesList.Add(new TrussNode(ID, X, Y));
        }

        public void AddMember(string memberLabel, int nodeI, int nodeJ, double Area, double E)
        {
            var nodei = GetNodeById(nodeI);
            var nodej = GetNodeById(nodeJ);
            _TrussElementsList.Add(new TrussElement(memberLabel, nodei, nodej, E, Area));
        }

        private void RefreshGraphics()
        {
            Pen pen = new Pen(new SolidBrush(Color.SkyBlue));
            //for (int i = 0; i < 500; i+=100)
            //{
            //}
            _g.DrawLine(pen, new Point(0, 100), new Point(1000, 100));
            _g.DrawLine(pen, new Point(0, 0), new Point(1000, 200));
            _g.DrawLine(pen, new Point(0, 150), new Point(1000, 300));
        }

        private void prepareUI()
        {
            //cmbSupportType.Items.Add(eRestraintCondition.X);
            //cmbSupportType.Items.Add(eRestraintCondition.Y);
            //cmbSupportType.Items.Add(eRestraintCondition.XY);
            // Add a title to the chart (if necessary).
            //chElements.Titles.Add(new ChartTitle());
            //chElements.Titles[0].Text = "A Line Chart";
            //drawingControl.OptionsView.ShowRulers = false;
            //drawingControl.OptionsView.ShowPageBreaks = false;
            //drawingControl.OptionsView.ShowGrid= false;
        }

        private void BtnSolveTruss_Click(object sender, EventArgs e)
        {
            Assembler assembler = new Assembler(_TrussElementsList, _nodesList);
            //AdddisplacementToSeries();
            GenerateColorMap(0, 0, 5, 8.66, 0,10);
        }

        private void BtnAddRestrain_Click(object sender, EventArgs e)
        {
            eRestraintCondition restraniedType = (eRestraintCondition)cmbSupportType.SelectedIndex;
            int Id = Convert.ToInt32(txtBCNodeId.Text);
            _restrainedNodes.Add(new RestrainedNode(Id, restraniedType));
            AddRestrainedDataRows();
        }

        private void BtnAddElement_Click(object sender, EventArgs e)
        {
            var startnodeId = Convert.ToInt32(txtNodeI.Text);
            var EndnodeId = Convert.ToInt32(txtNodeJ.Text);
            //NodesInfo startNode = _nodesList.Find(obj => obj.ID == startnodeId);
            //NodesInfo endNode = _nodesList.Find(obj => obj.ID == EndnodeId);
            //var E = Convert.ToDouble(txtStiffness.Text);
            //var A = Convert.ToDouble(txtSectionArea.Text);

            //_TrussElementsList.Add(new TrussElement(startNode, endNode, E, A));
            AddElementsDataRows();
        }

        private void EditNodeTableGridView()
        {
            gvNodes.OptionsView.ShowGroupPanel = false;
            gvNodes.OptionsCustomization.AllowColumnMoving = false;
            gvNodes.OptionsCustomization.AllowFilter = false;
            gvNodes.OptionsMenu.EnableColumnMenu = false;
            gvNodes.OptionsView.ShowIndicator = false;
            gvNodes.OptionsView.AllowHtmlDrawHeaders = true;
            gvNodes.OptionsView.ColumnAutoWidth = true;
            gvNodes.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gvNodes.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvNodes.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvNodes.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gvNodes.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvNodes.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void EditElementsTableGridView()
        {
            gvTrussElements.OptionsView.ShowGroupPanel = false;
            gvTrussElements.OptionsCustomization.AllowColumnMoving = false;
            gvTrussElements.OptionsCustomization.AllowFilter = false;
            gvTrussElements.OptionsMenu.EnableColumnMenu = false;
            gvTrussElements.OptionsView.ShowIndicator = false;
            gvTrussElements.OptionsView.AllowHtmlDrawHeaders = true;
            gvTrussElements.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gvTrussElements.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvTrussElements.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvTrussElements.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gvTrussElements.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvTrussElements.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void EditBCTableGridView()
        {
            gvBoundaryConditions.OptionsView.ShowGroupPanel = false;
            gvBoundaryConditions.OptionsCustomization.AllowColumnMoving = false;
            gvBoundaryConditions.OptionsCustomization.AllowFilter = false;
            gvBoundaryConditions.OptionsMenu.EnableColumnMenu = false;
            gvBoundaryConditions.OptionsView.ShowIndicator = false;
            gvBoundaryConditions.OptionsView.AllowHtmlDrawHeaders = true;
            gvBoundaryConditions.OptionsView.ColumnAutoWidth = true;
            gvBoundaryConditions.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gvBoundaryConditions.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvBoundaryConditions.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gvBoundaryConditions.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void EditLoadTableGridView()
        {
            gvLoads.OptionsView.ShowGroupPanel = false;
            gvLoads.OptionsCustomization.AllowColumnMoving = false;
            gvLoads.OptionsCustomization.AllowFilter = false;
            gvLoads.OptionsMenu.EnableColumnMenu = false;
            gvLoads.OptionsView.ShowIndicator = false;
            gvLoads.OptionsView.AllowHtmlDrawHeaders = true;
            gvLoads.OptionsView.ColumnAutoWidth = true;
            gvLoads.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gvLoads.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvLoads.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gvLoads.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void AddNodesDataRows()
        {
            DataRow row;
            _dataNodeTable.Rows.Clear();
            foreach (Node node in _nodesList)
            {
                row = _dataNodeTable.NewRow();
                row[0] = node.ID;
                row[1] = node.Xcoord;
                row[2] = node.Ycoord;
                _dataNodeTable.Rows.Add(row);
            }
        }

        private void AddElementsDataRows()
        {
            DataRow row;
            _dataTrussElementsTable.Rows.Clear();
            foreach (TrussElement elemnent in _TrussElementsList)
            {
                row = _dataTrussElementsTable.NewRow();
                row[0] = elemnent.NodeI.ID;
                row[1] = elemnent.NodeJ.ID;
                row[1] = elemnent.NodeJ.ID;
                row[2] = elemnent.L;
                row[3] = elemnent.Theta;
                _dataTrussElementsTable.Rows.Add(row);
            }
        }

        private void AddLoadsDataRows()
        {
            DataRow row;
            _dataLoadTable.Rows.Clear();
            foreach (PointLoad force in _nodalForces)
            {
                row = _dataLoadTable.NewRow();
                row[0] = force.NodeID;
                row[1] = force.Load.XComponent;
                row[2] = force.Load.YComponent;
                _dataLoadTable.Rows.Add(row);
            }
        }
        private void AddRestrainedDataRows()
        {
            DataRow row;
            _dataBoundaryConditionsTable.Rows.Clear();
            foreach (RestrainedNode restrain in _restrainedNodes)
            {
                row = _dataBoundaryConditionsTable.NewRow();
                row[0] = restrain.NodeID;
                row[1] = restrain.Direction;
                _dataBoundaryConditionsTable.Rows.Add(row);
            }
        }

        private void SetNodeTableColumns()
        {
            _dataNodeTable = new DataTable();
            _dataNodeTable.Columns.Add("NodeID", typeof(int));
            _dataNodeTable.Columns.Add("Xcoord", typeof(double)); ;
            _dataNodeTable.Columns.Add("Ycoord", typeof(double));
            gcNodes.DataSource = _dataNodeTable;
        }

        private void SetElementsTableColumns()
        {
            _dataTrussElementsTable = new DataTable();
            _dataTrussElementsTable.Columns.Add("Start NodeID", typeof(int));
            _dataTrussElementsTable.Columns.Add("End NodeID", typeof(int));
            _dataTrussElementsTable.Columns.Add("Length", typeof(double));
            _dataTrussElementsTable.Columns.Add("Angle", typeof(double));
            gcTrussElements.DataSource = _dataTrussElementsTable;
        }
        private void SetBCTableColumns()
        {
            _dataBoundaryConditionsTable = new DataTable();
            _dataBoundaryConditionsTable.Columns.Add(" Node ID", typeof(int));
            _dataBoundaryConditionsTable.Columns.Add("Restrained Direction", typeof(eRestraintCondition));
            gcBoundaryConditions.DataSource = _dataBoundaryConditionsTable;
        }

        private void SetLoadTableColumns()
        {
            _dataLoadTable = new DataTable();
            _dataLoadTable.Columns.Add(" Node ID", typeof(int));
            _dataLoadTable.Columns.Add("X Component", typeof(double));
            _dataLoadTable.Columns.Add("Y Component", typeof(double));
            gcLoads.DataSource = _dataLoadTable;
        }

        private void drawChart()
        {
            //// Add elements to the series
            //AddElementsToSeries();

            //// Add nodes to the series
            //AddNodesToSeries();














            ////Add the series to the chart.
            //XYDiagram diagram = (XYDiagram)chartDrawing.Diagram;
            //diagram.AxisY.WholeRange.MinValue = -_nodesList.Min(x => x.Ycoord);
            //diagram.AxisY.WholeRange.MaxValue = 5;

            //// Set the numerical argument scale types for the series,
            //// as it is qualitative, by default.
            ////series1.ArgumentScaleType = ScaleType.Numerical;

            //// Access the view-type-specific options of the series.
            ////((LineSeriesView)series1.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            ////((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Circle;

            //// Access the type-specific options of the diagram.
            //((XYDiagram)chartDrawing.Diagram).EnableAxisXZooming = true;

            //// Hide the legend (if necessary).
            //chartDrawing.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;






































            //double xmin = 0;
            //double xmax = 15;
            //double ymin = 0;
            //double ymax = 8.66;
            //int numPoints = 100;

            //Color[] cmapColors = Enumerable.Range(0, 256).Select(i => Color.FromArgb(255, jet_cmap(i / 255.0))).ToArray();
            //ChartColorPalette jetPalette = ChartColorPalette.None;

            //double[] x = Enumerable.Range(0, numPoints).Select(i => xmin + i * (xmax - xmin) / (numPoints - 1.0)).ToArray();
            //double[] y = Enumerable.Repeat(ymin, numPoints).ToArray();

            //// Divide the line into numPoints points and calculate the colors for each point
            //Color[] pointColors = x.Select(v => jetPalette == ChartColorPalette.None ? cmapColors[(int)Math.Round((v - xmin) * 255.0 / (xmax - xmin))] : Color.FromArgb(255, jet_cmap((v - xmin) / (xmax - xmin)))).ToArray();

            //// Create a chart and add a series for the line
            //ChartControl chartControl1 = new ChartControl();
            //this.Controls.Add(chartControl1);
            //chartControl1.Dock = DockStyle.Fill;
            //chartControl1.Titles.Add(new ChartTitle());
            //chartControl1.Titles[0].Text = "Jet Colormap";
            //chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            //Series series3 = new Series("Line", ViewType.Line);
            //for (int i = 0; i < numPoints; i++)
            //{
            //    series3.Points.Add(new SeriesPoint(x[i], y[i]) { Color = pointColors[i] });
            //}
            //chartControl1.Series.Add(series3);

            //// Set the axis labels and range
            //XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            //diagram.AxisX.Title.Text = "X-Values";
            //diagram.AxisY.Title.Text = "Y-Values";
            //diagram.AxisX.WholeRange.Auto = false;
            //diagram.AxisX.WholeRange.SetMinMaxValues(xmin, xmax);
            //diagram.AxisY.WholeRange.Auto = false;
            //diagram.AxisY.WholeRange.SetMinMaxValues(ymin, ymax);

























            //double x1 = 5; // starting x-coordinate
            //double y1 = 8.5; // starting y-coordinate
            //double x2 = 15; // ending x-coordinate
            //double y2 = 8.5; // ending y-coordinate
            //int numPoints = 200; // number of points to interpolate

            //double deltaX = (x2 - x1) / (numPoints);
            //double deltaY = (y2 - y1) / (numPoints);

            //double[] xVals = Enumerable.Range(0, numPoints).Select(i => x1 + i * deltaX).ToArray();
            //double[] yVals = Enumerable.Range(0, numPoints).Select(i => y1 + i * deltaY).ToArray();


            //// Create a line series.
            //Series series2 = new Series("Series 1", ViewType.Point);
            //Random rnd = new Random();
            //int nPoints = 50;
            //double[] x = new double[nPoints];
            //double[] y = new double[nPoints];
            //Color[] colors = { Color.Blue, Color.Cyan, Color.Lime, Color.Yellow, Color.Orange, Color.Red };
            //double minValue = 0;
            //double maxValue = 10;
            //double segmentRatio = 1.0 / (colors.Length - 1);
            //for (int i = 0; i < xVals.Length; i++)
            //{
            //    double value = xVals[i];
            //    double ratio = (value - minValue) / (maxValue - minValue);

            //    // Map the ratio to a segment and calculate the segment-specific ratio
            //    int segmentIndex = (int)(ratio / segmentRatio);

            //    if (ratio >= 1.0)
            //    {
            //        // Handle the case where the ratio is greater than or equal to 1.0
            //        segmentIndex = colors.Length - 2;
            //    }

            //    double segmentRatioValue = (ratio - segmentIndex * segmentRatio) / segmentRatio;

            //    // Interpolate between the colors of the current segment and the next segment
            //    Color startColor = colors[segmentIndex];
            //    Color endColor = colors[segmentIndex + 1];
            //    if (startColor.G > endColor.G)
            //    {
            //        startColor = colors[segmentIndex + 1];
            //        endColor = colors[segmentIndex];
            //    }
            //    int r = (int)(startColor.R + segmentRatioValue * (endColor.R - startColor.R));
            //    int g = (int)(startColor.G + segmentRatioValue * (endColor.G - startColor.G));
            //    int b = (int)(startColor.B + segmentRatioValue * (endColor.B - startColor.B));
            //    if (g < 0)
            //    {
            //        g = 0;
            //    }
            //    else if (g > 255)
            //    {
            //        g = 255;
            //    }
            //    Color interpolatedColor = Color.FromArgb(r, g, b);

            //    // Assign the interpolated color to the data point
            //    series2.Points.Add(new SeriesPoint(xVals[i], yVals[i]) { Color = interpolatedColor });

            //}

            //// Add the series to the chart.
            //chartDrawing.Series.Add(series2);
            //diagram = (XYDiagram)chartDrawing.Diagram;

            //// Set the numerical argument scale types for the series,
            //// as it is qualitative, by default.
            //series2.ArgumentScaleType = ScaleType.Numerical;

            //// Access the type-specific options of the diagram.
            //((XYDiagram)chartDrawing.Diagram).EnableAxisXZooming = true;

            //// Hide the legend (if necessary).
            //chartDrawing.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;


            //double x1 = 5; // starting x-coordinate
            //double y1 = 8.5; // starting y-coordinate
            //double x2 = 15; // ending x-coordinate
            //double y2 = 8.5; // ending y-coordinate
            //int numPoints = 300; // number of points to interpolate

            //double deltaX = (x2 - x1) / (numPoints);
            //double deltaY = (y2 - y1) / (numPoints);

            //double[] xVals = Enumerable.Range(0, numPoints).Select(i => x1 + i * deltaX).ToArray();
            //double[] yVals = Enumerable.Range(0, numPoints).Select(i => y1 + i * deltaY).ToArray();


            //// Create a line series.
            //Series series2 = new Series("Series 1", ViewType.Point);
            //Random rnd = new Random();
            //int nPoints = 50;
            //double[] x = new double[nPoints];
            //double[] y = new double[nPoints];
            //Color[] colors = { Color.Blue, Color.Cyan, Color.Lime, Color.Yellow, Color.Orange, Color.Red };
            //double minValue = 0;
            //double maxValue = 10;
            //double segmentRatio = 1.0 / (colors.Length - 1);
            //for (int i = 0; i < xVals.Length; i++)
            //{
            //    double value = xVals[i];
            //    double ratio = (value - minValue) / (maxValue - minValue);

            //    // Map the ratio to a segment and calculate the segment-specific ratio
            //    int segmentIndex = (int)(ratio / segmentRatio);
            //    double segmentRatioValue = (ratio - segmentIndex * segmentRatio) / segmentRatio;

            //    // Interpolate between the colors of the current segment and the next segment
            //    Color startColor = colors[segmentIndex];
            //    Color endColor = colors[segmentIndex + 1];
            //    int r = (int)(startColor.R + segmentRatioValue * (endColor.R - startColor.R));
            //    int g = (int)(startColor.G + segmentRatioValue * (endColor.G - startColor.G));
            //    int b = (int)(startColor.B + segmentRatioValue * (endColor.B - startColor.B));
            //    Color interpolatedColor = Color.FromArgb(r, g, b);

            //    // Assign the interpolated color to the data point
            //    series2.Points.Add(new SeriesPoint(xVals[i], yVals[i]) { Color = interpolatedColor });
            //}

            //// Add the series to the chart.
            //chartDrawing.Series.Add(series2);
            //diagram = (XYDiagram)chartDrawing.Diagram;

            //// Set the numerical argument scale types for the series,
            //// as it is qualitative, by default.
            //series2.ArgumentScaleType = ScaleType.Numerical;

            //// Access the type-specific options of the diagram.
            //((XYDiagram)chartDrawing.Diagram).EnableAxisXZooming = true;

            //// Hide the legend (if necessary).
            //chartDrawing.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            //this.Controls.Add(chartDrawing);
        }

        private void GenerateColorMap(double x1, double y1, double x2, double y2, double minvalue, double maxvalue, int numPoints = 300)
        {

            double[] x = Enumerable.Range(0, numPoints).Select(i => x1 + i * (x2 - x1) / (numPoints - 1.0)).ToArray();
            double[] y = Enumerable.Range(0, numPoints).Select(i => y1 + i * (y2 - y1) / (numPoints - 1.0)).ToArray();

            // Evaluate intensity for each point using interpolation
            double[] intensities = new double[numPoints];
            intensities[0] = minvalue;
            intensities[intensities.Length - 1] = maxvalue;

            for (int i = 1; i < intensities.Length - 1; i++)
            {
                double t = (double)i / (intensities.Length - 1);
                intensities[i] = (1 - t) * intensities[0] + t * intensities[intensities.Length - 1];
            }


            // Normalize the intensities
            var maxIntensity = intensities.Max();
            var normalizedIntensities = intensities.Select(i => i / maxIntensity).ToArray();

            // Define the colors
            Color[] colors = { Color.Blue, Color.Cyan, Color.Lime, Color.Yellow, Color.Orange, Color.Red };

            // Create a scatter chart series
            var series = new Series("Intensity", ViewType.Point);
            for (int i = 0; i < numPoints; i++)
            {
                var intensity = normalizedIntensities[i];
                var colorIndex = (int)(intensity * (colors.Length - 1));
                var pointColor = colors[colorIndex];
                var seriesPoint = new SeriesPoint(x[i], y[i]) { Color = pointColor };
                series.Points.Add(seriesPoint);
            }

            // Add the series to the chart
            chartDrawing.Series.Add(series);
        }

        private void AddNodesToSeries()
        {
            foreach (TrussNode nodes in _nodesList)
            {
                Series series1 = new Series("Nodes", ViewType.Point);
                PointSeriesView seriesView = (PointSeriesView)series1.View;
                if (nodes.XDirection == eRestraintCondition.free)
                {
                    seriesView.PointMarkerOptions.Kind = MarkerKind.Circle;
                    seriesView.Color = Color.Blue;
                    series1.Points.Add(new SeriesPoint(nodes.Xcoord, nodes.Ycoord));
                }
                else
                {
                    seriesView.Color = Color.Red;
                    seriesView.PointMarkerOptions.Kind = MarkerKind.Triangle;
                    series1.Points.Add(new SeriesPoint(nodes.Xcoord, nodes.Ycoord));

                    seriesView.PointMarkerOptions.Size = 15;
                }
                series1.ShowInLegend = false;
                chartDrawing.Series.Add(series1);
            }
        }

        private void AddElementsToSeries()
        {
            foreach (var element in _TrussElementsList)
            {
                Series series = new Series(element.Memberlabel, ViewType.Line);
                series.Points.Add(new SeriesPoint(element.NodeI.Xcoord, element.NodeI.Ycoord));
                series.Points.Add(new SeriesPoint(element.NodeJ.Xcoord, element.NodeJ.Ycoord));
                LineSeriesView lineView = (LineSeriesView)series.View;
                lineView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
                //lineView.LineMarkerOptions.Size = 1;
                //lineView.LineMarkerOptions.Kind = MarkerKind.Circle;
                lineView.LineStyle.Thickness = 1;
                lineView.LineMarkerOptions.BorderColor = Color.Black;
                lineView.LineMarkerOptions.BorderVisible = true;
                series.ShowInLegend = false;
                chartDrawing.Series.Add(series);
                series.View.Color = Color.LightGray;
            }
        }

        private void AdddisplacementToSeries()
        {
            var magnificationFactor = 150000000;
            foreach (var element in _TrussElementsList)
            {
                var NodeI = (TrussNode)element.NodeI;
                var NodeJ = (TrussNode)element.NodeJ;
                Series series = new Series(element.Memberlabel, ViewType.Line);
                series.Points.Add(new SeriesPoint(NodeI.getXcoordFinal(magnificationFactor), NodeI.getYcoordFinal(magnificationFactor)));
                series.Points.Add(new SeriesPoint(NodeJ.getXcoordFinal(magnificationFactor), NodeJ.getYcoordFinal(magnificationFactor)));
                LineSeriesView lineView = (LineSeriesView)series.View;
                lineView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
                //lineView.LineMarkerOptions.Size = 1;
                //lineView.LineMarkerOptions.Kind = MarkerKind.Circle;
                lineView.LineStyle.Thickness = 1;
                lineView.LineMarkerOptions.BorderColor = Color.Black;
                lineView.LineMarkerOptions.BorderVisible = true;
                series.ShowInLegend = false;
                chartDrawing.Series.Add(series);
                series.View.Color = Color.Cyan;
            }
        }

        private Color jet_cmap(double v)
        {
            double r, g, b;

            if (v < 0.0 || v > 1.0)
            {
                throw new ArgumentException("Value must be in the range [0, 1].");
            }
            else if (v < 0.125)
            {
                r = 0.0;
                g = 0.0;
                b = 0.5 + 4.0 * v;
            }
            else if (v < 0.375)
            {
                r = 0.0;
                g = 4.0 * (v - 0.125);
                b = 0.5;
            }
            else if (v < 0.625)
            {
                r = 4.0 * (v - 0.375);
                g = 1.0;
                b = 1.5 - 4.0 * v;
            }
            else if (v < 0.875)
            {
                r = 1.0;
                g = 1.0 - 4.0 * (v - 0.625);
                b = 0.5;
            }
            else
            {
                r = 1.0 - 4.0 * (v - 0.875);
                g = 0.0;
                b = 0.5;
            }
            int red = (int)Math.Round(r * 255.0);
            int green = (int)Math.Round(g * 255.0);
            int blue = (int)Math.Round(Math.Max(b, 0) * 255.0);

            return Color.FromArgb(red, green, blue);
        }

        #endregion

        #region Events

        private void BtnAddNode_Click(object sender, EventArgs e)
        {
            var Xcoord = Convert.ToDouble(txtNodeX.Text);
            var Ycoord = Convert.ToDouble(txtNodeY.Text);

            //_nodesList.Add(new NodesInfo(Xcoord, Ycoord, ++_nodeCount));
            AddNodesDataRows();
            drawChart();
            //CreateChart();
            //RefreshGraphics();
            //drawingControl.Refresh();
        }

        private void BtnAddLoad_Click(object sender, EventArgs e)
        {
            int node = Convert.ToInt32(txtNodeIdLoading.Text);
            double xComponent = Convert.ToDouble(txtXComponent.Text);
            double YComponent = Convert.ToDouble(txtYComponent.Text);
            _nodalForces.Add(new PointLoad(node, new Load(xComponent, YComponent)));
            AddLoadsDataRows();

        }

        private void canvasPictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Define the min and max values and the number of pieces
            int minVal = 0;
            int maxVal = 100;
            int pieces = 10;

            // Define the width and height of the color bar
            int colorBarWidth = 30;
            int colorBarHeight = chartDrawing.Height;

            // Create a new LinearGradientBrush to paint the color bar with jet colors
            //Color[] colors = { Color.Blue, Color.Cyan, Color.Lime, Color.Yellow, Color.Orange, Color.Red };
            Color[] colors = { Color.Red, Color.Orange, Color.Yellow, Color.Lime, Color.Cyan, Color.Blue };
            float[] positions = { 0.0f, 0.2f, 0.4f, 0.6f, 0.8f, 1.0f };
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(colorBarWidth, 0), new Point(colorBarWidth, colorBarHeight),
                Color.Red, Color.Blue);
            ColorBlend blend = new ColorBlend();
            blend.Colors = colors;
            blend.Positions = positions;
            brush.InterpolationColors = blend;

            // Create a new Graphics object from the PictureBox's image
            Graphics g = e.Graphics;

            // Fill the rectangle for the color bar with the LinearGradientBrush
            g.FillRectangle(brush, 0, 0, colorBarWidth, colorBarHeight);

            // Draw the text for the minimum and maximum values on both sides of the color bar
            Font font = new Font("Arial", 8);
            Brush textBrush = new SolidBrush(Color.Black);
            for (int i = 1; i <= pieces - 1; i++)
            {
                int val = (int)Math.Round((double)i * maxVal / pieces);
                float y = colorBarHeight - (float)i * colorBarHeight / pieces - 6;
                g.DrawString(val.ToString(), font, textBrush, colorBarWidth + 4, y - 3);
                g.DrawLine(Pens.Black, colorBarWidth - 2, y + 4, colorBarWidth, y + 4);
                //g.DrawLine(Pens.Black, 0, y + 4, colorBarWidth - 2, y + 4);
            }
            g.DrawString(minVal.ToString(), font, textBrush, colorBarWidth + 4, colorBarHeight - 12);
            g.DrawString(maxVal.ToString(), font, textBrush, colorBarWidth + 4, 0);

        }

        #endregion


    }

    public class JetColorizer : IColorizer
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Color GetAggregatedPointColor(object argument, object[] values, SeriesPoint[] points, Palette palette)
        {
            throw new NotImplementedException();
        }

        public Color GetColor(double value)
        {
            double r, g, b;
            if (value < 0.25)
            {
                r = 0;
                g = 4 * value;
                b = 1;
            }
            else if (value < 0.5)
            {
                r = 0;
                g = 1;
                b = 1 + 4 * (0.25 - value);
            }
            else if (value < 0.75)
            {
                r = 4 * (value - 0.5);
                g = 1;
                b = 0;
            }
            else
            {
                r = 1;
                g = 1 + 4 * (0.75 - value);
                b = 0;
            }
            return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
        }

        public Color GetPointColor(object argument, object[] values, object colorKey, Palette palette)
        {
            throw new NotImplementedException();
        }

        public Color GetPointColor(object argument, object[] values, object[] colorKeys, Palette palette)
        {
            throw new NotImplementedException();
        }
    }
}
