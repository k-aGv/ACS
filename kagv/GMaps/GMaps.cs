﻿/*!
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

using GMap.NET;
using GMap.NET.WindowsForms;


namespace kagv {
    public partial class gmaps : Form {
        internal readonly GMapOverlay myobjects = new GMapOverlay("objects");

        public gmaps() {
            InitializeComponent();
        }
        List<PointLatLng> Destinations = new List<PointLatLng>();
        List<List<double>> Lengths = new List<List<double>>();
        List<GMapOverlay> _markers_overlay = new List<GMapOverlay>();

        public void ReloadMap() {
            gmaps_Load(new object(), new EventArgs());
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
            mymap.Zoom = 8;
            mymap.Overlays.Add(myobjects);
            mymap.DragButton = MouseButtons.Left;
            mymap.InvertedMouseWheelZooming = false;


            //its not a joke ->
            //____________________________________________________________________opacity______________R___________________________G_______________________B
            mymap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));

            //resize GB ...just A E S T H I T I C 
            gb_settings.Size = new Size(gb_settings.Size.Width, mymap.Height);
            //set the label to the bottom
            label1.Location = new Point(10, mymap.Location.Y + mymap.Height + 1);
        }

        private void mymap_MouseClick(object sender, MouseEventArgs e) {

            if (e.Button == MouseButtons.Right) {
                double remoteLat = mymap.FromLocalToLatLng(e.X, e.Y).Lat;
                double remoteLng = mymap.FromLocalToLatLng(e.X, e.Y).Lng;
                mymap.RoutesEnabled = true;

                PointLatLng initial = new PointLatLng(mymap.Position.Lat, mymap.Position.Lng);
                PointLatLng final = new PointLatLng(remoteLat, remoteLng);

                GDirections dir = null;
                var route = new DirectionsStatusCode();
                try {
                    route = GMap.NET.MapProviders.GMapProviders.GoogleMap.GetDirections(out dir, initial, final, false, false, true, false, false);
                    GMapRoute maproute = new GMapRoute(dir.Route, "My route");
                    GMapOverlay overlay = new GMapOverlay("My Overlay");
                    overlay.Routes.Add(maproute);
                    mymap.Overlays.Add(overlay);
                    mymap.UpdateRouteLocalPosition(maproute);
                    mymap.Invalidate();
                    double dist = maproute.Distance;
                    MessageBox.Show(dist + " kms");
                } catch {
                    MessageBox.Show("Cannot create route to an unwalkable position.");
                    return;
                }

            }
            else if (e.Button == MouseButtons.Middle) //place markers
            {
                double remoteLat = mymap.FromLocalToLatLng(e.X, e.Y).Lat;
                double remoteLng = mymap.FromLocalToLatLng(e.X, e.Y).Lng;
                mymap.RoutesEnabled = true;

                PointLatLng initial = new PointLatLng(mymap.Position.Lat, mymap.Position.Lng);
                PointLatLng final = new PointLatLng(remoteLat, remoteLng);

                Destinations.Add(final);

                _markers_overlay.Add(new GMapOverlay("Marker" + Convert.ToString(Destinations.Count - 1)));

                _markers_overlay[_markers_overlay.Count - 1].Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerGoogle(final, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.arrow));
                mymap.UpdateMarkerLocalPosition(_markers_overlay[_markers_overlay.Count - 1].Markers[0]);
                mymap.Overlays.Add(_markers_overlay[_markers_overlay.Count - 1]);

                if (Destinations.Count > 1)
                {
                    GMap.NET.MapProviders.GMapProviders.GoogleMap.GetDirections(
                        out GDirections _d,
                        Destinations[Destinations.Count - 2],
                        Destinations[Destinations.Count - 1],
                        false, false, false, false, false
                        );
                    try
                    {
                        GMapRoute route = new GMapRoute(_d.Route, "Route");
                        GMapOverlay _route_overlay = new GMapOverlay("RouteOverlay");
                        _route_overlay.Routes.Add(route);
                        mymap.UpdateRouteLocalPosition(route);
                        mymap.Overlays.Add(_route_overlay);
                    }
                    catch
                    {
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

        private void reversedWheelToolStripMenuItem_Click(object sender, EventArgs e) {
            reversedWheelToolStripMenuItem.Checked = !reversedWheelToolStripMenuItem.Checked;
            mymap.InvertedMouseWheelZooming = reversedWheelToolStripMenuItem.Checked;
            mymap.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lengths = new List<List<double>>();

            for (int i = 0; i < Destinations.Count; i++)
            {
                Lengths.Add(new List<double>());

                for (int j = 0; j < Destinations.Count; j++)
                {
                    GMap.NET.MapProviders.GMapProviders.GoogleMap.GetDirections(out GDirections _d, Destinations[i], Destinations[j], false, false, false, false, false);
                    try
                    {
                        GMapRoute gMapRoute = new GMapRoute(_d.Route, "e");
                        GMapOverlay overlay = new GMapOverlay();
                        overlay.Routes.Add(gMapRoute);
                        mymap.Overlays.Add(overlay);

                        Lengths[i].Add(gMapRoute.Distance);

                    }
                    catch { }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GMapOverlay overlay = new GMapOverlay();
            for (int i = 0; i < Destinations.Count - 1; i++)
            {
                try
                {
                    GMap.NET.MapProviders.GMapProviders.GoogleMap.GetDirections(out GDirections _d, Destinations[i], Destinations[i + 1], false, false, false, false, false);
                    GMapRoute route = new GMapRoute(_d.Route, "route");
                    mymap.UpdateRouteLocalPosition(route);
                    overlay.Routes.Add(route);

                }
                catch { }


                mymap.Overlays.Add(overlay);
            }
        }
    }
}
