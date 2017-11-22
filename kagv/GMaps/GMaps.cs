/*!
The MIT License (MIT)

Copyright (c) 2017 Dimitris Katikaridis <dkatikaridis@gmail.com>,Giannis Menekses <johnmenex@hotmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

using GMap.NET;
using GMap.NET.WindowsForms;


namespace kagv {
    public partial class gmaps : Form {

        public gmaps() {
            InitializeComponent();
        }

        public gmaps(int[] _optimal, List<double[,]> _destinations) {
            InitializeComponent();

            if (_optimal == null || _destinations ==null) {
                return;
            }

            mymap.Overlays.Clear();
            Optimal = _optimal;
            _Destinations = ConvertListToPointLatLng(_destinations);
            Visualize(Optimal, _Destinations);

        }

        public gmaps(int[] _optimal, double[,] _destinations) {
            InitializeComponent();
            if (_optimal == null || _destinations == null)
                return;

            mymap.Overlays.Clear();
            Visualize(_optimal, ConvertArraytoPointLatLngList(_destinations));
        }
        

        List<GMapOverlay> _markers_overlay = new List<GMapOverlay>();

        List<PointLatLng> _Destinations = new List<PointLatLng>();
        List<List<double>> _Distances = new List<List<double>>();

        public List<List<double>> Distances { get => _Distances; }
        public List<PointLatLng> Destinations { get => _Destinations; }

        Button btn_OpenACS;
        Button btn_demands;
        List<Label> lb_demands = new List<Label>();
        List<NumericUpDown> nUD_demands = new List<NumericUpDown>();
        
        int[] Optimal;
        int[] _demands;

        double _zoomFactor;
        
        private List<PointLatLng> ConvertArraytoPointLatLngList(double[,] Destinations) {
            List<PointLatLng> _converted = new List<PointLatLng>();

            for (int i = 0; i < Destinations.GetLength(0); i++) {
                _converted.Add(new PointLatLng(Destinations[i, 1], Destinations[i, 2]));
            }
            return _converted;
        }

        private List<PointLatLng> ConvertListToPointLatLng(List<double[,]> ListDist) {

            List<PointLatLng> _converted = new List<PointLatLng>();
            for (int i=0;i<ListDist.Count;i++)
                _converted.Add(new PointLatLng(ListDist[i][0, 0], ListDist[i][0, 1]));
            return _converted;
        }

        private List<double[,]> ConvertPointLatLngToList(List<PointLatLng> Destinations) {

            List<double[,]> _converted = new List<double[,]>();
            for(int i=0;i<Destinations.Count;i++) {
                _converted.Add(new double[1,3]);
                _converted[i][0, 0] = i;
                _converted[i][0, 1] = Destinations[i].Lat;
                _converted[i][0, 2] = Destinations[i].Lng;
            }

            return _converted;
        }

        public void ReloadMap() {
            gmaps_Load(new object(), new EventArgs());
        }

        private void Visualize(int[] _optimal, List<PointLatLng> _dest) {

            for (int i = 0; i < _dest.Count; i++) {
                GMap.NET.MapProviders.GMapProviders.GoogleMap.GetDirections(
                    out GDirections _d,
                    _dest[_optimal[i]],
                    _dest[_optimal[i + 1]],
                    avoidHighwaysToolStripMenuItem.Checked,
                        avoidTollsToolStripMenuItem.Checked,
                        useWalkingModeToolStripMenuItem.Checked,
                        false,
                        metricToolStripMenuItem.Checked
                    );
                try {

                    GMapRoute route = new GMapRoute(_d.Route, "Route " + i);
                    GMapOverlay _route_overlay = new GMapOverlay("RouteOverlay " + i);

                    _route_overlay.Routes.Add(route);
                    mymap.UpdateRouteLocalPosition(route);
                    mymap.Overlays.Add(_route_overlay);

                    _markers_overlay.Add(new GMapOverlay("Marker" + i));
                    _route_overlay.Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                            _dest[_optimal[i + 1]],
                            GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green));


                    var ret = GMap.NET.MapProviders.GMapProviders.GoogleSatelliteMap.GetPlacemark(_route_overlay.Markers[0].Position, out GeoCoderStatusCode status);
                    if (status == GeoCoderStatusCode.G_GEO_SUCCESS && ret != null) {
                        _route_overlay.Markers[0].ToolTipText = (i + 1) + " " + ret.Value.Address+", City: "+(i+1);
                        _route_overlay.Markers[0].ToolTipMode = MarkerTooltipMode.Always;
                    }

                    mymap.UpdateMarkerLocalPosition(_route_overlay.Markers[0]);
                    mymap.Overlays.Add(_route_overlay);


                    Application.DoEvents();
                } catch { MessageBox.Show("An unexpected errorhas occured. Possible internet \nconnection problem."); }

            }
        }

        private void gmaps_Load(object sender, EventArgs e) {

            //calculate margin
            int margin = mymap.Location.X + SystemInformation.Border3DSize.Width;

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            CenterToScreen();
            Screen s = Screen.FromControl(this);
            int usableSizeWidth = s.WorkingArea.Width;
            int usableSizeHeight = s.WorkingArea.Height;
            int BoardersWidth = 2 * SystemInformation.Border3DSize.Width;
            Location = new Point(s.WorkingArea.X, s.WorkingArea.Y);
            Size = new Size(usableSizeWidth, usableSizeHeight);
            _zoomFactor = 8;


            gb_settings.Location = new Point(Size.Width - gb_settings.Width - BoardersWidth - margin, gb_settings.Location.Y);



            //map implementation
            //get title's bar size
            Rectangle screenRectangle = RectangleToScreen(ClientRectangle);
            int titleHeight = screenRectangle.Top - Top;

            mymap.Width = gb_settings.Location.X - margin;
            mymap.Height = Size.Height - margin - titleHeight - (2 * label1.Height) - ms_Settings.Height;
            mymap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;//using it as FULL reference to have the complete list of providers
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            cb_provider.Items.Add("GoogleMapProvider");
            cb_provider.Items.Add("GoogleTerrainMapProvider");
            cb_provider.Items.Add("BingSatelliteMapProvider");
            cb_provider.Text = "GoogleMapProvider";

            mymap.SetPositionByKeywords("greece,thessaloniki");
            mymap.MinZoom = 0;
            mymap.MaxZoom = 18;
            mymap.Zoom = _zoomFactor;
            mymap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            mymap.DragButton = MouseButtons.Left;
            mymap.InvertedMouseWheelZooming = false;

            cb_scale.Checked = true;
            combo_scale.SelectedIndex = 1; //city scale as default


            //its not a joke ->
            //____________________________________________________________________opacity______________R___________________________G_______________________B
            mymap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));

            //resize GB ...just A E S T H I T I C 
            //gb_settings.Size = new Size(gb_settings.Size.Width, mymap.Height);
            //set the label to the bottom
            label1.Location = new Point(10, mymap.Location.Y + mymap.Height + 1);
        }

        private void mymap_MouseClick(object sender, MouseEventArgs e) {

            if (e.Button == MouseButtons.Left && !mymap.IsDragging) //place markers
            {
                PointLatLng final = new PointLatLng(
                    mymap.FromLocalToLatLng(e.X, e.Y).Lat,
                    mymap.FromLocalToLatLng(e.X, e.Y).Lng
                    );

                Destinations.Add(final);
                _markers_overlay.Add(new GMapOverlay("Marker" + Convert.ToString(Destinations.Count - 1)));
                _markers_overlay[_markers_overlay.Count - 1].Markers.Add(
                    new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                        final,
                        GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green));

                //GoogleSatelliteMap is more accurate while trying to find addresses
                var ret = GMap.NET.MapProviders.GMapProviders.GoogleSatelliteMap.GetPlacemark(_markers_overlay[_markers_overlay.Count - 1].Markers[0].Position, out GeoCoderStatusCode status);
                if (status == GeoCoderStatusCode.G_GEO_SUCCESS && ret != null) {
                    _markers_overlay[_markers_overlay.Count - 1].Markers[0].ToolTipText = ret.Value.Address + ", City: " + (Destinations.Count); ;
                    //_markers_overlay[_markers_overlay.Count - 1].Markers[0].ToolTip.Foreground
                    _markers_overlay[_markers_overlay.Count - 1].Markers[0].ToolTipMode = MarkerTooltipMode.Always;
                }

                mymap.UpdateMarkerLocalPosition(_markers_overlay[_markers_overlay.Count - 1].Markers[0]);
                mymap.Overlays.Add(_markers_overlay[_markers_overlay.Count - 1]);

                if (Destinations.Count > 1) {
                    GMap.NET.MapProviders.GMapProviders.GoogleMap.GetDirections(
                        out GDirections _d,
                        Destinations[Destinations.Count - 2],
                        Destinations[Destinations.Count - 1],
                        avoidHighwaysToolStripMenuItem.Checked,
                        avoidTollsToolStripMenuItem.Checked,
                        useWalkingModeToolStripMenuItem.Checked,
                        false,
                        metricToolStripMenuItem.Checked
                        );
                    try {
                        GMapRoute route = new GMapRoute(_d.Route, "Route");
                        GMapOverlay _route_overlay = new GMapOverlay("RouteOverlay");
                        _route_overlay.Routes.Add(route);
                        mymap.UpdateRouteLocalPosition(route);
                        mymap.Overlays.Add(_route_overlay);
                    } catch {
                        Destinations.RemoveAt(Destinations.Count - 1);
                        _markers_overlay[_markers_overlay.Count - 1].Markers.Clear();
                    }
                }
            }
        }

        private void cb_provider_SelectedIndexChanged(object sender, EventArgs e) {
            if (cb_provider.SelectedItem.ToString() == "GoogleTerrainMapProvider")
                mymap.MapProvider = GMap.NET.MapProviders.GoogleTerrainMapProvider.Instance;
            if (cb_provider.SelectedItem.ToString() == "GoogleMapProvider")
                mymap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            if (cb_provider.SelectedItem.ToString() == "BingSatelliteMapProvider")
                mymap.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;

            mymap.Refresh();
        }

        private void mymap_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                mymap.Refresh();
                return;
            }
            //latitude = width
            //longitude = height
            //THERE IS A FUNCTION mymap.FromLatLngToLocal :D :D :D
            double remoteLat = mymap.FromLocalToLatLng(e.X, e.Y).Lat;
            double remoteLng = mymap.FromLocalToLatLng(e.X, e.Y).Lng;

            label1.Text = mymap.ViewArea + "";

            lb_lat.Text = "Lat:\r\n" + mymap.Position.Lat + "";
            lb_lng.Text = "Lng:\r\n" + mymap.Position.Lng + "";
            lb_widthlng.Text = "WidthLng:\r\n" + mymap.ViewArea.WidthLng + "";
            lb_heightlat.Text = "HeightLat:\r\n" + mymap.ViewArea.HeightLat + "";

            lb_coords.Text = "Current coordinates:\r\n" + "X/Lat:" + remoteLat + "\r\n" + "Y/Lng:" + remoteLng;

        }

        private void getScreenShotToolStripMenuItem_Click(object sender, EventArgs e) {
            if (getScreenShotToolStripMenuItem.Enabled) {
                getScreenShotToolStripMenuItem.Enabled = false;
            }
            Screenshot st = new Screenshot(this);
            st.Owner = this;
            st.Show();
        }

        private void showCrossToolStripMenuItem_Click(object sender, EventArgs e) {
            showCrossToolStripMenuItem.Checked = !showCrossToolStripMenuItem.Checked;
            mymap.ShowCenter = showCrossToolStripMenuItem.Checked;
            mymap.Refresh();
        }
        
        private bool GetDistances() {
            if (Destinations.Count < 2) {
                MessageBox.Show("User must place at least 2 destinations.");
                return false;
            }

            _Distances = new List<List<double>>();
            StreamWriter _writer = new StreamWriter("routeDistances.txt");
            _writer.WriteLine("{Distances}");

            pb.Maximum = Destinations.Count * Destinations.Count;
            int interval = 0;

            for (int i = 0; i < Destinations.Count; i++) {

                lb_demands.Add(new Label());
                lb_demands[i].AutoSize = true;
                lb_demands[i].Text = "City " + (i+1) + ": demand =";

                nUD_demands.Add(new NumericUpDown());
                nUD_demands[i].Minimum = 0;
                nUD_demands[i].Value = 0;
                nUD_demands[i].Size = new Size(35, 20);


                _Distances.Add(new List<double>());
                _writer.WriteLine("<Destination " + (i + 1) + ">: " + Destinations[i].Lat +" , "+Destinations[i].Lng);
                for (int j = 0; j < Destinations.Count; j++) {
                    GDirections _d = new GDirections();
                    do {
                        try {
                            GMap.NET.MapProviders.GMapProviders.GoogleMap.GetDirections(out _d, Destinations[i], Destinations[j], false, false, false, false, true);

                            _Distances[i].Add(_d.DistanceValue);

                            _writer.WriteLine("Distance from " + i + " to " + j + " : " + _d.DistanceValue + "\n");
                        } catch { }
                    } while (_d == null);
                    Application.DoEvents();
                    pb_calculated.Text = "Current progress... " + ((100 * interval) / (Destinations.Count * Destinations.Count)) + "%\nDistances calculated: " + interval + "/" + Destinations.Count * Destinations.Count;
                    pb.PerformStep();
                    interval++;

                }
                _writer.WriteLine("\n");
            }
            _writer.Close();
            pb_calculated.Text = "Completed... " + ((100 * interval) / (Destinations.Count * Destinations.Count)) + "%\nDistances calculated: " + interval + "/" + Destinations.Count * Destinations.Count;
            pb.PerformStep();
            return true;

        }

        private void mymap_KeyPress(object sender, KeyPressEventArgs e) {
            if (mymap.Focused && e.KeyChar == '\x1B') { // =(char)27 . ESC ASCII code
                mymap.SelectedArea = new RectLatLng(0, 0, 0, 0);
                mymap.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (textBox1.Text == "") {
                MessageBox.Show("No destination was given.", "Bad destination request...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var coords = GMap.NET.MapProviders.GMapProviders.GoogleMap.GetPoint(textBox1.Text, out GeoCoderStatusCode _e);
            if (coords.HasValue && _e.Equals(GeoCoderStatusCode.G_GEO_SUCCESS)) {
                mymap.SetPositionByKeywords(textBox1.Text);
                if (combo_scale.Enabled)
                    mymap.Zoom = getZoomScale();
                else
                    mymap.Zoom = _zoomFactor;
            } else
                MessageBox.Show("Destination \"" + textBox1.Text + "\" could not be found.", "Bad destination request...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cb_scale_CheckedChanged(object sender, EventArgs e) {
            combo_scale.Enabled = cb_scale.Checked;
        }

        private void mymap_OnMapZoomChanged() {
            _zoomFactor = mymap.Zoom;
        }

        private double getZoomScale() {
            int scale = 8;
            switch (combo_scale.SelectedIndex) {
                case 0:
                    scale = 16;
                    break;
                case 1:
                    scale = 11;
                    break;
                case 2:
                    scale = 6;
                    break;
            }
            return scale;
        }

        private void reversedWheelToolStripMenuItem1_Click(object sender, EventArgs e) {
            reversedWheelToolStripMenuItem.Checked = !reversedWheelToolStripMenuItem.Checked;
            mymap.InvertedMouseWheelZooming = reversedWheelToolStripMenuItem.Checked;
            mymap.Refresh();
        }

        private void TargetTheMouseToolStripMenuItem_Click(object sender, EventArgs e) {
            mymap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            TargetTheMouseToolStripMenuItem.Checked = true;
            TargetTheMouseAndChangeCenterToolStripMenuItem.Checked = false;
            TargetTheCenterOfMapToolStripMenuItem.Checked = false;
        }

        private void TargetTheMouseAndChangeCenterToolStripMenuItem_Click(object sender, EventArgs e) {
            mymap.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            TargetTheMouseToolStripMenuItem.Checked = false;
            TargetTheMouseAndChangeCenterToolStripMenuItem.Checked = true;
            TargetTheCenterOfMapToolStripMenuItem.Checked = false;
        }

        private void TargetTheCenterOfMapToolStripMenuItem_Click(object sender, EventArgs e) {
            mymap.MouseWheelZoomType = MouseWheelZoomType.ViewCenter;
            TargetTheMouseToolStripMenuItem.Checked = false;
            TargetTheMouseAndChangeCenterToolStripMenuItem.Checked = false;
            TargetTheCenterOfMapToolStripMenuItem.Checked = true;
        }
        

        private void Btn_OpenACS_Click(object sender, EventArgs e) {
            ACSAlgorithm acs = new ACSAlgorithm(Distances, ConvertPointLatLngToList(Destinations),_demands);
            acs.ShowDialog();
            if (acs.Optimal == null)
                return;
            mymap.Overlays.Clear();
            Optimal = acs.Optimal;
            Visualize(Optimal, Destinations);
        }

        
        
        private void Btn_demands_Click(object sender, EventArgs e) {
            FormDemands formDemands = new FormDemands(lb_demands, nUD_demands);
            formDemands.ShowDialog();

            _demands = formDemands.Demands;
            formDemands.Dispose();

            btn_OpenACS = new Button();
            btn_OpenACS.AutoSize = true;
            btn_OpenACS.Text = "Run ACS";
            btn_OpenACS.Click += Btn_OpenACS_Click;
            btn_OpenACS.Location = new Point(
                btn_demands.Location.X,
                btn_demands.Location.Y+btn_demands.Height
                );
            Controls.Add(btn_OpenACS);
        }

        private void btn_getDistances_Click(object sender, EventArgs e) {
            bool success = GetDistances();
            if (!success)
                return;
            btn_demands = new Button();
            btn_demands.AutoSize = true;
            btn_demands.Text = "City demands";
            btn_demands.Click += Btn_demands_Click;
            btn_demands.Location = new Point(
                gb_settings.Location.X, 
                gb_settings.Location.Y + gb_settings.Height + 5
                );
            Controls.Add(btn_demands);
        } 
    }
}
