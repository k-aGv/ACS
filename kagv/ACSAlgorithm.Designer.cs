﻿namespace kagv {
    partial class ACSAlgorithm {
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ACSAlgorithm));
            this.calc_stop_BTN = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ACS = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_error = new System.Windows.Forms.TextBox();
            this.lb_a = new System.Windows.Forms.Label();
            this.avalue = new System.Windows.Forms.NumericUpDown();
            this.Length = new System.Windows.Forms.Label();
            this.tb_length = new System.Windows.Forms.TextBox();
            this.lb_rate = new System.Windows.Forms.Label();
            this.lb_rateLocal = new System.Windows.Forms.Label();
            this.lb_b = new System.Windows.Forms.Label();
            this.lb_q0 = new System.Windows.Forms.Label();
            this.lb_ants = new System.Windows.Forms.Label();
            this.lb_iterations = new System.Windows.Forms.Label();
            this.bvalue = new System.Windows.Forms.NumericUpDown();
            this.xvalue = new System.Windows.Forms.NumericUpDown();
            this.rvalue = new System.Windows.Forms.NumericUpDown();
            this.q0value = new System.Windows.Forms.NumericUpDown();
            this.Ants = new System.Windows.Forms.NumericUpDown();
            this.NumIts = new System.Windows.Forms.NumericUpDown();
            this.gb_parameters = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cb_bechmark = new System.Windows.Forms.CheckBox();
            this.cb_lengths = new System.Windows.Forms.CheckBox();
            this.cb_fromFile = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.avalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.q0value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumIts)).BeginInit();
            this.gb_parameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // calc_stop_BTN
            // 
            this.calc_stop_BTN.Location = new System.Drawing.Point(140, 12);
            this.calc_stop_BTN.Name = "calc_stop_BTN";
            this.calc_stop_BTN.Size = new System.Drawing.Size(72, 23);
            this.calc_stop_BTN.TabIndex = 2;
            this.calc_stop_BTN.Text = "Stop calculactions";
            this.calc_stop_BTN.UseVisualStyleBackColor = true;
            this.calc_stop_BTN.Click += new System.EventHandler(this.calc_stop_BTN_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ACS
            // 
            this.ACS.Location = new System.Drawing.Point(12, 12);
            this.ACS.Name = "ACS";
            this.ACS.Size = new System.Drawing.Size(108, 23);
            this.ACS.TabIndex = 1;
            this.ACS.Text = "Ant Colony System";
            this.ACS.UseVisualStyleBackColor = true;
            this.ACS.Click += new System.EventHandler(this.ACS_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Error";
            // 
            // tb_error
            // 
            this.tb_error.Enabled = false;
            this.tb_error.Location = new System.Drawing.Point(76, 320);
            this.tb_error.Name = "tb_error";
            this.tb_error.ReadOnly = true;
            this.tb_error.Size = new System.Drawing.Size(100, 20);
            this.tb_error.TabIndex = 38;
            // 
            // lb_a
            // 
            this.lb_a.AutoSize = true;
            this.lb_a.Location = new System.Drawing.Point(6, 174);
            this.lb_a.Name = "lb_a";
            this.lb_a.Size = new System.Drawing.Size(13, 13);
            this.lb_a.TabIndex = 37;
            this.lb_a.Text = "a";
            // 
            // avalue
            // 
            this.avalue.DecimalPlaces = 2;
            this.avalue.Location = new System.Drawing.Point(128, 172);
            this.avalue.Name = "avalue";
            this.avalue.Size = new System.Drawing.Size(63, 20);
            this.avalue.TabIndex = 36;
            this.avalue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Length
            // 
            this.Length.AutoSize = true;
            this.Length.Location = new System.Drawing.Point(9, 294);
            this.Length.Name = "Length";
            this.Length.Size = new System.Drawing.Size(40, 13);
            this.Length.TabIndex = 35;
            this.Length.Text = "Length";
            // 
            // tb_length
            // 
            this.tb_length.Enabled = false;
            this.tb_length.Location = new System.Drawing.Point(76, 294);
            this.tb_length.Name = "tb_length";
            this.tb_length.ReadOnly = true;
            this.tb_length.Size = new System.Drawing.Size(100, 20);
            this.tb_length.TabIndex = 34;
            // 
            // lb_rate
            // 
            this.lb_rate.AutoSize = true;
            this.lb_rate.Location = new System.Drawing.Point(6, 148);
            this.lb_rate.Name = "lb_rate";
            this.lb_rate.Size = new System.Drawing.Size(93, 13);
            this.lb_rate.TabIndex = 33;
            this.lb_rate.Text = "Evaporation Rate ";
            // 
            // lb_rateLocal
            // 
            this.lb_rateLocal.AutoSize = true;
            this.lb_rateLocal.Location = new System.Drawing.Point(6, 122);
            this.lb_rateLocal.Name = "lb_rateLocal";
            this.lb_rateLocal.Size = new System.Drawing.Size(119, 13);
            this.lb_rateLocal.TabIndex = 32;
            this.lb_rateLocal.Text = "Evaporation Rate Local";
            // 
            // lb_b
            // 
            this.lb_b.AutoSize = true;
            this.lb_b.Location = new System.Drawing.Point(6, 96);
            this.lb_b.Name = "lb_b";
            this.lb_b.Size = new System.Drawing.Size(13, 13);
            this.lb_b.TabIndex = 31;
            this.lb_b.Text = "b";
            // 
            // lb_q0
            // 
            this.lb_q0.AutoSize = true;
            this.lb_q0.Location = new System.Drawing.Point(6, 70);
            this.lb_q0.Name = "lb_q0";
            this.lb_q0.Size = new System.Drawing.Size(19, 13);
            this.lb_q0.TabIndex = 30;
            this.lb_q0.Text = "q0";
            // 
            // lb_ants
            // 
            this.lb_ants.AutoSize = true;
            this.lb_ants.Location = new System.Drawing.Point(6, 42);
            this.lb_ants.Name = "lb_ants";
            this.lb_ants.Size = new System.Drawing.Size(28, 13);
            this.lb_ants.TabIndex = 29;
            this.lb_ants.Text = "Ants";
            // 
            // lb_iterations
            // 
            this.lb_iterations.AutoSize = true;
            this.lb_iterations.Location = new System.Drawing.Point(6, 16);
            this.lb_iterations.Name = "lb_iterations";
            this.lb_iterations.Size = new System.Drawing.Size(102, 13);
            this.lb_iterations.TabIndex = 28;
            this.lb_iterations.Text = "Number of Iterations";
            // 
            // bvalue
            // 
            this.bvalue.DecimalPlaces = 2;
            this.bvalue.Location = new System.Drawing.Point(128, 94);
            this.bvalue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bvalue.Name = "bvalue";
            this.bvalue.Size = new System.Drawing.Size(63, 20);
            this.bvalue.TabIndex = 27;
            this.bvalue.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // xvalue
            // 
            this.xvalue.DecimalPlaces = 2;
            this.xvalue.Location = new System.Drawing.Point(128, 146);
            this.xvalue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.xvalue.Name = "xvalue";
            this.xvalue.Size = new System.Drawing.Size(63, 20);
            this.xvalue.TabIndex = 26;
            this.xvalue.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // rvalue
            // 
            this.rvalue.DecimalPlaces = 2;
            this.rvalue.Location = new System.Drawing.Point(128, 120);
            this.rvalue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.rvalue.Name = "rvalue";
            this.rvalue.Size = new System.Drawing.Size(63, 20);
            this.rvalue.TabIndex = 25;
            this.rvalue.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // q0value
            // 
            this.q0value.DecimalPlaces = 2;
            this.q0value.Location = new System.Drawing.Point(128, 68);
            this.q0value.Name = "q0value";
            this.q0value.Size = new System.Drawing.Size(63, 20);
            this.q0value.TabIndex = 24;
            this.q0value.Value = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            // 
            // Ants
            // 
            this.Ants.DecimalPlaces = 2;
            this.Ants.Location = new System.Drawing.Point(128, 40);
            this.Ants.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Ants.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Ants.Name = "Ants";
            this.Ants.Size = new System.Drawing.Size(63, 20);
            this.Ants.TabIndex = 23;
            this.Ants.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // NumIts
            // 
            this.NumIts.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NumIts.Location = new System.Drawing.Point(128, 14);
            this.NumIts.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumIts.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NumIts.Name = "NumIts";
            this.NumIts.Size = new System.Drawing.Size(63, 20);
            this.NumIts.TabIndex = 22;
            this.NumIts.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // gb_parameters
            // 
            this.gb_parameters.Controls.Add(this.lb_iterations);
            this.gb_parameters.Controls.Add(this.NumIts);
            this.gb_parameters.Controls.Add(this.Ants);
            this.gb_parameters.Controls.Add(this.q0value);
            this.gb_parameters.Controls.Add(this.lb_a);
            this.gb_parameters.Controls.Add(this.rvalue);
            this.gb_parameters.Controls.Add(this.avalue);
            this.gb_parameters.Controls.Add(this.xvalue);
            this.gb_parameters.Controls.Add(this.bvalue);
            this.gb_parameters.Controls.Add(this.lb_ants);
            this.gb_parameters.Controls.Add(this.lb_rate);
            this.gb_parameters.Controls.Add(this.lb_q0);
            this.gb_parameters.Controls.Add(this.lb_rateLocal);
            this.gb_parameters.Controls.Add(this.lb_b);
            this.gb_parameters.Location = new System.Drawing.Point(12, 79);
            this.gb_parameters.Name = "gb_parameters";
            this.gb_parameters.Size = new System.Drawing.Size(200, 202);
            this.gb_parameters.TabIndex = 42;
            this.gb_parameters.TabStop = false;
            this.gb_parameters.Text = "Parameters";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(247, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Customers";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Trip";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(416, 327);
            this.chart1.TabIndex = 45;
            this.chart1.Text = "chart2";
            // 
            // cb_bechmark
            // 
            this.cb_bechmark.AutoSize = true;
            this.cb_bechmark.Location = new System.Drawing.Point(12, 64);
            this.cb_bechmark.Name = "cb_bechmark";
            this.cb_bechmark.Size = new System.Drawing.Size(109, 17);
            this.cb_bechmark.TabIndex = 46;
            this.cb_bechmark.Text = "Read Benchmark";
            this.cb_bechmark.UseVisualStyleBackColor = true;
            this.cb_bechmark.CheckedChanged += new System.EventHandler(this.cb_bechmark_CheckedChanged);
            // 
            // cb_lengths
            // 
            this.cb_lengths.AutoSize = true;
            this.cb_lengths.Checked = true;
            this.cb_lengths.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_lengths.Location = new System.Drawing.Point(12, 41);
            this.cb_lengths.Name = "cb_lengths";
            this.cb_lengths.Size = new System.Drawing.Size(102, 17);
            this.cb_lengths.TabIndex = 47;
            this.cb_lengths.Text = "Read Distances";
            this.cb_lengths.UseVisualStyleBackColor = true;
            this.cb_lengths.CheckedChanged += new System.EventHandler(this.cb_lengths_CheckedChanged);
            // 
            // cb_fromFile
            // 
            this.cb_fromFile.AutoSize = true;
            this.cb_fromFile.Location = new System.Drawing.Point(123, 41);
            this.cb_fromFile.Name = "cb_fromFile";
            this.cb_fromFile.Size = new System.Drawing.Size(91, 17);
            this.cb_fromFile.TabIndex = 48;
            this.cb_fromFile.Text = "Read from file";
            this.cb_fromFile.UseVisualStyleBackColor = true;
            this.cb_fromFile.CheckedChanged += new System.EventHandler(this.cb_fromFile_CheckedChanged);
            // 
            // ACSAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 343);
            this.Controls.Add(this.cb_fromFile);
            this.Controls.Add(this.cb_lengths);
            this.Controls.Add(this.cb_bechmark);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.calc_stop_BTN);
            this.Controls.Add(this.ACS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_error);
            this.Controls.Add(this.Length);
            this.Controls.Add(this.tb_length);
            this.Controls.Add(this.gb_parameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ACSAlgorithm";
            this.Text = "ACS Algorithm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ACSAlgorithm_FormClosing);
            this.Load += new System.EventHandler(this.Ants_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.q0value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumIts)).EndInit();
            this.gb_parameters.ResumeLayout(false);
            this.gb_parameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calc_stop_BTN;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ACS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_error;
        private System.Windows.Forms.Label lb_a;
        private System.Windows.Forms.NumericUpDown avalue;
        private System.Windows.Forms.Label Length;
        private System.Windows.Forms.TextBox tb_length;
        private System.Windows.Forms.Label lb_rate;
        private System.Windows.Forms.Label lb_rateLocal;
        private System.Windows.Forms.Label lb_b;
        private System.Windows.Forms.Label lb_q0;
        private System.Windows.Forms.Label lb_ants;
        private System.Windows.Forms.Label lb_iterations;
        private System.Windows.Forms.NumericUpDown bvalue;
        private System.Windows.Forms.NumericUpDown xvalue;
        private System.Windows.Forms.NumericUpDown rvalue;
        private System.Windows.Forms.NumericUpDown q0value;
        private System.Windows.Forms.NumericUpDown Ants;
        private System.Windows.Forms.NumericUpDown NumIts;
        private System.Windows.Forms.GroupBox gb_parameters;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox cb_bechmark;
        private System.Windows.Forms.CheckBox cb_lengths;
        private System.Windows.Forms.CheckBox cb_fromFile;
    }
}