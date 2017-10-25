namespace kagv {
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.avalue = new System.Windows.Forms.NumericUpDown();
            this.Length = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bvalue = new System.Windows.Forms.NumericUpDown();
            this.xvalue = new System.Windows.Forms.NumericUpDown();
            this.rvalue = new System.Windows.Forms.NumericUpDown();
            this.q0value = new System.Windows.Forms.NumericUpDown();
            this.Ants = new System.Windows.Forms.NumericUpDown();
            this.NumIts = new System.Windows.Forms.NumericUpDown();
            this.gb_parameters = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.calc_stop_BTN.Location = new System.Drawing.Point(117, 12);
            this.calc_stop_BTN.Name = "calc_stop_BTN";
            this.calc_stop_BTN.Size = new System.Drawing.Size(112, 23);
            this.calc_stop_BTN.TabIndex = 41;
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
            this.ACS.Location = new System.Drawing.Point(2, 12);
            this.ACS.Name = "ACS";
            this.ACS.Size = new System.Drawing.Size(109, 23);
            this.ACS.TabIndex = 40;
            this.ACS.Text = "Ant Colony System";
            this.ACS.UseVisualStyleBackColor = true;
            this.ACS.Click += new System.EventHandler(this.ACS_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Error";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(76, 282);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "a";
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
            this.Length.Location = new System.Drawing.Point(9, 256);
            this.Length.Name = "Length";
            this.Length.Size = new System.Drawing.Size(40, 13);
            this.Length.TabIndex = 35;
            this.Length.Text = "Length";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 256);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Evaporation Rate ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Evaporation Rate Local";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "b";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "q0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Ants";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Number of Iterations";
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
            this.gb_parameters.Controls.Add(this.label1);
            this.gb_parameters.Controls.Add(this.NumIts);
            this.gb_parameters.Controls.Add(this.Ants);
            this.gb_parameters.Controls.Add(this.q0value);
            this.gb_parameters.Controls.Add(this.label7);
            this.gb_parameters.Controls.Add(this.rvalue);
            this.gb_parameters.Controls.Add(this.avalue);
            this.gb_parameters.Controls.Add(this.xvalue);
            this.gb_parameters.Controls.Add(this.bvalue);
            this.gb_parameters.Controls.Add(this.label2);
            this.gb_parameters.Controls.Add(this.label6);
            this.gb_parameters.Controls.Add(this.label3);
            this.gb_parameters.Controls.Add(this.label5);
            this.gb_parameters.Controls.Add(this.label4);
            this.gb_parameters.Location = new System.Drawing.Point(12, 41);
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
            this.chart1.Size = new System.Drawing.Size(372, 327);
            this.chart1.TabIndex = 45;
            this.chart1.Text = "chart2";
            // 
            // AntsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 316);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.calc_stop_BTN);
            this.Controls.Add(this.ACS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Length);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gb_parameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AntsForm";
            this.Text = "kagv ACS Algorithm";
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown avalue;
        private System.Windows.Forms.Label Length;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown bvalue;
        private System.Windows.Forms.NumericUpDown xvalue;
        private System.Windows.Forms.NumericUpDown rvalue;
        private System.Windows.Forms.NumericUpDown q0value;
        private System.Windows.Forms.NumericUpDown Ants;
        private System.Windows.Forms.NumericUpDown NumIts;
        private System.Windows.Forms.GroupBox gb_parameters;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}