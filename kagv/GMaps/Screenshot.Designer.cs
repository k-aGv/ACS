namespace kagv {
    partial class Screenshot {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Screenshot));
            this.btn_save = new System.Windows.Forms.Button();
            this.pb_save = new System.Windows.Forms.ProgressBar();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lb_info = new System.Windows.Forms.Label();
            this.cb_drawinfo = new System.Windows.Forms.CheckBox();
            this.cb_drawscale = new System.Windows.Forms.CheckBox();
            this.nud_zoom = new System.Windows.Forms.NumericUpDown();
            this.lb_zoom = new System.Windows.Forms.Label();
            this.btn_color = new System.Windows.Forms.Button();
            this.nud_opacity = new System.Windows.Forms.NumericUpDown();
            this.lb_opacity = new System.Windows.Forms.Label();
            this.gb_recSettings = new System.Windows.Forms.GroupBox();
            this.gb_container = new System.Windows.Forms.GroupBox();
            this.cd = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nud_zoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_opacity)).BeginInit();
            this.gb_recSettings.SuspendLayout();
            this.gb_container.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(253, 58);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(84, 32);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // pb_save
            // 
            this.pb_save.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pb_save.Location = new System.Drawing.Point(6, 6);
            this.pb_save.Margin = new System.Windows.Forms.Padding(2);
            this.pb_save.Name = "pb_save";
            this.pb_save.Size = new System.Drawing.Size(340, 25);
            this.pb_save.TabIndex = 2;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Location = new System.Drawing.Point(285, 161);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(61, 21);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Location = new System.Drawing.Point(102, 33);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(160, 13);
            this.lb_info.TabIndex = 5;
            this.lb_info.Text = "Hold alt while pressing right click";
            // 
            // cb_drawinfo
            // 
            this.cb_drawinfo.AutoSize = true;
            this.cb_drawinfo.Checked = true;
            this.cb_drawinfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_drawinfo.Location = new System.Drawing.Point(6, 26);
            this.cb_drawinfo.Name = "cb_drawinfo";
            this.cb_drawinfo.Size = new System.Drawing.Size(127, 17);
            this.cb_drawinfo.TabIndex = 6;
            this.cb_drawinfo.Text = "Also draw coords info";
            this.cb_drawinfo.UseVisualStyleBackColor = true;
            // 
            // cb_drawscale
            // 
            this.cb_drawscale.AutoSize = true;
            this.cb_drawscale.Checked = true;
            this.cb_drawscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_drawscale.Location = new System.Drawing.Point(6, 49);
            this.cb_drawscale.Name = "cb_drawscale";
            this.cb_drawscale.Size = new System.Drawing.Size(120, 17);
            this.cb_drawscale.TabIndex = 7;
            this.cb_drawscale.Text = "Also draw scale info";
            this.cb_drawscale.UseVisualStyleBackColor = true;
            // 
            // nud_zoom
            // 
            this.nud_zoom.Location = new System.Drawing.Point(6, 27);
            this.nud_zoom.Name = "nud_zoom";
            this.nud_zoom.Size = new System.Drawing.Size(45, 20);
            this.nud_zoom.TabIndex = 8;
            // 
            // lb_zoom
            // 
            this.lb_zoom.AutoSize = true;
            this.lb_zoom.Location = new System.Drawing.Point(3, 11);
            this.lb_zoom.Name = "lb_zoom";
            this.lb_zoom.Size = new System.Drawing.Size(34, 13);
            this.lb_zoom.TabIndex = 9;
            this.lb_zoom.Text = "Zoom";
            // 
            // btn_color
            // 
            this.btn_color.Location = new System.Drawing.Point(6, 72);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(78, 36);
            this.btn_color.TabIndex = 10;
            this.btn_color.Text = "Color";
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // nud_opacity
            // 
            this.nud_opacity.Location = new System.Drawing.Point(6, 69);
            this.nud_opacity.Name = "nud_opacity";
            this.nud_opacity.Size = new System.Drawing.Size(45, 20);
            this.nud_opacity.TabIndex = 12;
            this.nud_opacity.ValueChanged += new System.EventHandler(this.nud_opacity_ValueChanged);
            // 
            // lb_opacity
            // 
            this.lb_opacity.AutoSize = true;
            this.lb_opacity.Location = new System.Drawing.Point(3, 53);
            this.lb_opacity.Name = "lb_opacity";
            this.lb_opacity.Size = new System.Drawing.Size(43, 13);
            this.lb_opacity.TabIndex = 11;
            this.lb_opacity.Text = "Opacity";
            this.lb_opacity.Click += new System.EventHandler(this.lb_opacity_Click);
            // 
            // gb_recSettings
            // 
            this.gb_recSettings.Controls.Add(this.btn_color);
            this.gb_recSettings.Controls.Add(this.cb_drawinfo);
            this.gb_recSettings.Controls.Add(this.cb_drawscale);
            this.gb_recSettings.Controls.Add(this.gb_container);
            this.gb_recSettings.Location = new System.Drawing.Point(6, 58);
            this.gb_recSettings.Name = "gb_recSettings";
            this.gb_recSettings.Size = new System.Drawing.Size(211, 116);
            this.gb_recSettings.TabIndex = 13;
            this.gb_recSettings.TabStop = false;
            this.gb_recSettings.Text = "Rectangle Settings";
            // 
            // gb_container
            // 
            this.gb_container.Controls.Add(this.lb_zoom);
            this.gb_container.Controls.Add(this.nud_zoom);
            this.gb_container.Controls.Add(this.lb_opacity);
            this.gb_container.Controls.Add(this.nud_opacity);
            this.gb_container.Location = new System.Drawing.Point(139, 11);
            this.gb_container.Name = "gb_container";
            this.gb_container.Size = new System.Drawing.Size(58, 97);
            this.gb_container.TabIndex = 13;
            this.gb_container.TabStop = false;
            // 
            // Screenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 188);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.pb_save);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.gb_recSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(20, 164);
            this.Name = "Screenshot";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screenshot";
            this.Load += new System.EventHandler(this.Screenshot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_zoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_opacity)).EndInit();
            this.gb_recSettings.ResumeLayout(false);
            this.gb_recSettings.PerformLayout();
            this.gb_container.ResumeLayout(false);
            this.gb_container.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ProgressBar pb_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.CheckBox cb_drawinfo;
        private System.Windows.Forms.CheckBox cb_drawscale;
        private System.Windows.Forms.NumericUpDown nud_zoom;
        private System.Windows.Forms.Label lb_zoom;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.NumericUpDown nud_opacity;
        private System.Windows.Forms.Label lb_opacity;
        private System.Windows.Forms.GroupBox gb_recSettings;
        private System.Windows.Forms.GroupBox gb_container;
        private System.Windows.Forms.ColorDialog cd;
    }
}