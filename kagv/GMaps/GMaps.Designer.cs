namespace kagv {
    partial class gmaps {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gmaps));
            this.gb_settings = new System.Windows.Forms.GroupBox();
            this.pb_calculated = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.gb_coords = new System.Windows.Forms.GroupBox();
            this.combo_scale = new System.Windows.Forms.ComboBox();
            this.cb_scale = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lb_navigate = new System.Windows.Forms.Label();
            this.lb_coords = new System.Windows.Forms.Label();
            this.lb_heightlat = new System.Windows.Forms.Label();
            this.lb_widthlng = new System.Windows.Forms.Label();
            this.lb_lng = new System.Windows.Forms.Label();
            this.lb_lat = new System.Windows.Forms.Label();
            this.gb_provider = new System.Windows.Forms.GroupBox();
            this.cb_provider = new System.Windows.Forms.ComboBox();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.ms_Settings = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getScreenShotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCrossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reversedWheelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routeFindingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avoidHighwaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avoidTollsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useWalkingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mymap = new GMap.NET.WindowsForms.GMapControl();
            this.gb_settings.SuspendLayout();
            this.gb_coords.SuspendLayout();
            this.gb_provider.SuspendLayout();
            this.ms_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_settings
            // 
            this.gb_settings.Controls.Add(this.pb_calculated);
            this.gb_settings.Controls.Add(this.pb);
            this.gb_settings.Controls.Add(this.button1);
            this.gb_settings.Controls.Add(this.gb_coords);
            this.gb_settings.Controls.Add(this.gb_provider);
            this.gb_settings.Location = new System.Drawing.Point(895, 12);
            this.gb_settings.Name = "gb_settings";
            this.gb_settings.Size = new System.Drawing.Size(181, 562);
            this.gb_settings.TabIndex = 4;
            this.gb_settings.TabStop = false;
            this.gb_settings.Text = "Settings";
            // 
            // pb_calculated
            // 
            this.pb_calculated.AutoSize = true;
            this.pb_calculated.Location = new System.Drawing.Point(7, 425);
            this.pb_calculated.Name = "pb_calculated";
            this.pb_calculated.Size = new System.Drawing.Size(93, 13);
            this.pb_calculated.TabIndex = 11;
            this.pb_calculated.Text = "Current progress...";
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(8, 455);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(154, 23);
            this.pb.Step = 1;
            this.pb.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Calculate all lengths";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gb_coords
            // 
            this.gb_coords.Controls.Add(this.combo_scale);
            this.gb_coords.Controls.Add(this.cb_scale);
            this.gb_coords.Controls.Add(this.button2);
            this.gb_coords.Controls.Add(this.textBox1);
            this.gb_coords.Controls.Add(this.lb_navigate);
            this.gb_coords.Controls.Add(this.lb_coords);
            this.gb_coords.Controls.Add(this.lb_heightlat);
            this.gb_coords.Controls.Add(this.lb_widthlng);
            this.gb_coords.Controls.Add(this.lb_lng);
            this.gb_coords.Controls.Add(this.lb_lat);
            this.gb_coords.Location = new System.Drawing.Point(7, 82);
            this.gb_coords.Name = "gb_coords";
            this.gb_coords.Size = new System.Drawing.Size(168, 293);
            this.gb_coords.TabIndex = 6;
            this.gb_coords.TabStop = false;
            this.gb_coords.Text = "Coordinates";
            // 
            // combo_scale
            // 
            this.combo_scale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_scale.FormattingEnabled = true;
            this.combo_scale.Items.AddRange(new object[] {
            "Street",
            "City",
            "Country"});
            this.combo_scale.Location = new System.Drawing.Point(3, 266);
            this.combo_scale.Name = "combo_scale";
            this.combo_scale.Size = new System.Drawing.Size(90, 21);
            this.combo_scale.TabIndex = 12;
            // 
            // cb_scale
            // 
            this.cb_scale.AutoSize = true;
            this.cb_scale.Location = new System.Drawing.Point(3, 247);
            this.cb_scale.Name = "cb_scale";
            this.cb_scale.Size = new System.Drawing.Size(81, 17);
            this.cb_scale.TabIndex = 11;
            this.cb_scale.Text = "Scale zoom";
            this.cb_scale.UseVisualStyleBackColor = true;
            this.cb_scale.CheckedChanged += new System.EventHandler(this.cb_scale_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(98, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 40);
            this.button2.TabIndex = 10;
            this.button2.Text = "Move to location";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 221);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 20);
            this.textBox1.TabIndex = 9;
            // 
            // lb_navigate
            // 
            this.lb_navigate.AutoSize = true;
            this.lb_navigate.Location = new System.Drawing.Point(3, 205);
            this.lb_navigate.Name = "lb_navigate";
            this.lb_navigate.Size = new System.Drawing.Size(83, 13);
            this.lb_navigate.TabIndex = 8;
            this.lb_navigate.Text = "Location to find:";
            // 
            // lb_coords
            // 
            this.lb_coords.AutoSize = true;
            this.lb_coords.Location = new System.Drawing.Point(6, 153);
            this.lb_coords.Name = "lb_coords";
            this.lb_coords.Size = new System.Drawing.Size(103, 13);
            this.lb_coords.TabIndex = 7;
            this.lb_coords.Text = "Current Coordinates:";
            // 
            // lb_heightlat
            // 
            this.lb_heightlat.AutoSize = true;
            this.lb_heightlat.Location = new System.Drawing.Point(6, 114);
            this.lb_heightlat.Name = "lb_heightlat";
            this.lb_heightlat.Size = new System.Drawing.Size(56, 13);
            this.lb_heightlat.TabIndex = 0;
            this.lb_heightlat.Text = "HeightLat:";
            // 
            // lb_widthlng
            // 
            this.lb_widthlng.AutoSize = true;
            this.lb_widthlng.Location = new System.Drawing.Point(6, 78);
            this.lb_widthlng.Name = "lb_widthlng";
            this.lb_widthlng.Size = new System.Drawing.Size(56, 13);
            this.lb_widthlng.TabIndex = 0;
            this.lb_widthlng.Text = "WidthLng:";
            // 
            // lb_lng
            // 
            this.lb_lng.AutoSize = true;
            this.lb_lng.Location = new System.Drawing.Point(6, 46);
            this.lb_lng.Name = "lb_lng";
            this.lb_lng.Size = new System.Drawing.Size(28, 13);
            this.lb_lng.TabIndex = 0;
            this.lb_lng.Text = "Lng:";
            // 
            // lb_lat
            // 
            this.lb_lat.AutoSize = true;
            this.lb_lat.Location = new System.Drawing.Point(6, 16);
            this.lb_lat.Name = "lb_lat";
            this.lb_lat.Size = new System.Drawing.Size(25, 13);
            this.lb_lat.TabIndex = 0;
            this.lb_lat.Text = "Lat:";
            // 
            // gb_provider
            // 
            this.gb_provider.Controls.Add(this.cb_provider);
            this.gb_provider.Location = new System.Drawing.Point(7, 19);
            this.gb_provider.Name = "gb_provider";
            this.gb_provider.Size = new System.Drawing.Size(168, 57);
            this.gb_provider.TabIndex = 5;
            this.gb_provider.TabStop = false;
            this.gb_provider.Text = "Map provider";
            // 
            // cb_provider
            // 
            this.cb_provider.FormattingEnabled = true;
            this.cb_provider.Location = new System.Drawing.Point(6, 19);
            this.cb_provider.Name = "cb_provider";
            this.cb_provider.Size = new System.Drawing.Size(156, 21);
            this.cb_provider.TabIndex = 4;
            this.cb_provider.SelectedIndexChanged += new System.EventHandler(this.cb_provider_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 544);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // ms_Settings
            // 
            this.ms_Settings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.ms_Settings.Location = new System.Drawing.Point(0, 0);
            this.ms_Settings.Name = "ms_Settings";
            this.ms_Settings.Size = new System.Drawing.Size(1088, 24);
            this.ms_Settings.TabIndex = 7;
            this.ms_Settings.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getScreenShotToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "Map";
            // 
            // getScreenShotToolStripMenuItem
            // 
            this.getScreenShotToolStripMenuItem.Name = "getScreenShotToolStripMenuItem";
            this.getScreenShotToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.getScreenShotToolStripMenuItem.Text = "Get Screenshot";
            this.getScreenShotToolStripMenuItem.Click += new System.EventHandler(this.getScreenShotToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCrossToolStripMenuItem,
            this.reversedWheelToolStripMenuItem,
            this.routeFindingToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // showCrossToolStripMenuItem
            // 
            this.showCrossToolStripMenuItem.Checked = true;
            this.showCrossToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCrossToolStripMenuItem.Name = "showCrossToolStripMenuItem";
            this.showCrossToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.showCrossToolStripMenuItem.Text = "Show Cross";
            this.showCrossToolStripMenuItem.Click += new System.EventHandler(this.showCrossToolStripMenuItem_Click);
            // 
            // reversedWheelToolStripMenuItem
            // 
            this.reversedWheelToolStripMenuItem.Name = "reversedWheelToolStripMenuItem";
            this.reversedWheelToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.reversedWheelToolStripMenuItem.Text = "Reversed Wheel";
            this.reversedWheelToolStripMenuItem.Click += new System.EventHandler(this.reversedWheelToolStripMenuItem_Click);
            // 
            // routeFindingToolStripMenuItem
            // 
            this.routeFindingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avoidHighwaysToolStripMenuItem,
            this.avoidTollsToolStripMenuItem,
            this.useWalkingModeToolStripMenuItem,
            this.metricToolStripMenuItem});
            this.routeFindingToolStripMenuItem.Name = "routeFindingToolStripMenuItem";
            this.routeFindingToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.routeFindingToolStripMenuItem.Text = "Route finding...";
            // 
            // avoidHighwaysToolStripMenuItem
            // 
            this.avoidHighwaysToolStripMenuItem.Name = "avoidHighwaysToolStripMenuItem";
            this.avoidHighwaysToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.avoidHighwaysToolStripMenuItem.Text = "Avoid Highways";
            // 
            // avoidTollsToolStripMenuItem
            // 
            this.avoidTollsToolStripMenuItem.Name = "avoidTollsToolStripMenuItem";
            this.avoidTollsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.avoidTollsToolStripMenuItem.Text = "Avoid Tolls";
            // 
            // useWalkingModeToolStripMenuItem
            // 
            this.useWalkingModeToolStripMenuItem.Name = "useWalkingModeToolStripMenuItem";
            this.useWalkingModeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.useWalkingModeToolStripMenuItem.Text = "Use Walking Mode";
            // 
            // metricToolStripMenuItem
            // 
            this.metricToolStripMenuItem.Checked = true;
            this.metricToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metricToolStripMenuItem.Name = "metricToolStripMenuItem";
            this.metricToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.metricToolStripMenuItem.Text = "Use origin based units";
            // 
            // mymap
            // 
            this.mymap.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mymap.Bearing = 0F;
            this.mymap.CanDragMap = true;
            this.mymap.EmptyTileColor = System.Drawing.Color.LightSkyBlue;
            this.mymap.GrayScaleMode = false;
            this.mymap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mymap.LevelsKeepInMemmory = 5;
            this.mymap.Location = new System.Drawing.Point(12, 27);
            this.mymap.MarkersEnabled = true;
            this.mymap.MaxZoom = 2;
            this.mymap.MinZoom = 2;
            this.mymap.MouseWheelZoomEnabled = true;
            this.mymap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mymap.Name = "mymap";
            this.mymap.NegativeMode = false;
            this.mymap.PolygonsEnabled = true;
            this.mymap.RetryLoadTile = 0;
            this.mymap.RoutesEnabled = true;
            this.mymap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mymap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mymap.ShowTileGridLines = false;
            this.mymap.Size = new System.Drawing.Size(877, 609);
            this.mymap.TabIndex = 3;
            this.mymap.Zoom = 0D;
            this.mymap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.mymap_OnMapZoomChanged);
            this.mymap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mymap_KeyPress);
            this.mymap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mymap_MouseClick);
            this.mymap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mymap_MouseMove);
            // 
            // gmaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 660);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gb_settings);
            this.Controls.Add(this.mymap);
            this.Controls.Add(this.ms_Settings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ms_Settings;
            this.MaximizeBox = false;
            this.Name = "gmaps";
            this.Text = "Google Maps implementation";
            this.Load += new System.EventHandler(this.gmaps_Load);
            this.gb_settings.ResumeLayout(false);
            this.gb_settings.PerformLayout();
            this.gb_coords.ResumeLayout(false);
            this.gb_coords.PerformLayout();
            this.gb_provider.ResumeLayout(false);
            this.ms_Settings.ResumeLayout(false);
            this.ms_Settings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public GMap.NET.WindowsForms.GMapControl mymap;//BE CAREFUL WITH THIS ONE
        private System.Windows.Forms.GroupBox gb_settings;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.GroupBox gb_provider;
        private System.Windows.Forms.ComboBox cb_provider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_coords;
        private System.Windows.Forms.Label lb_lng;
        private System.Windows.Forms.Label lb_lat;
        private System.Windows.Forms.Label lb_heightlat;
        private System.Windows.Forms.Label lb_widthlng;
        private System.Windows.Forms.Label lb_coords;
        private System.Windows.Forms.MenuStrip ms_Settings;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getScreenShotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCrossToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reversedWheelToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label pb_calculated;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.ToolStripMenuItem routeFindingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avoidHighwaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avoidTollsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useWalkingModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metricToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lb_navigate;
        private System.Windows.Forms.ComboBox combo_scale;
        private System.Windows.Forms.CheckBox cb_scale;
    }
}