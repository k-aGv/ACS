using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;


namespace kagv {
    public partial class FormDemands : Form {
        public FormDemands() {
            InitializeComponent();
        }
        public FormDemands(List<Label> _lb_demands, List<NumericUpDown> _nUD_demands) {
            AutoSize = true;

            InitializeComponent();
            _lb_Demands = new List<Label>(_lb_demands);
            _nUD_Demands = new List<NumericUpDown>(_nUD_demands);
            _Demands = new int[_lb_demands.Count];
            SetInterface();
        }

        private int[] _Demands;
        public int[] Demands { get => _Demands; }

        private List<Label> _lb_Demands;
        private List<NumericUpDown> _nUD_Demands;
        Button btn_SetDemands;
        

        private void SetInterface() {
            Text = "Demands";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            btn_SetDemands = new Button();
            btn_SetDemands.Click += Btn_SetDemands_Click;
            btn_SetDemands.Width = 85;
            btn_SetDemands.Text = "Set Demands";
            
            int column = 0;
            int row = 0;
            for(int i=0; i<_lb_Demands.Count;i++) {

                _lb_Demands[i].Location = new Point(
                    10 + (column * (_lb_Demands[i].Width + _nUD_Demands[i].Width+35)), 
                    5 + (row*25)
                    );
                

                _nUD_Demands[i].Location = new Point(
                    _lb_Demands[i].Location.X + _lb_Demands[i].Width+30,
                    _lb_Demands[i].Location.Y
                    );
                Controls.Add(_lb_Demands[i]);
                Controls.Add(_nUD_Demands[i]);
                column++;
                if(column>Math.Sqrt(_lb_Demands.Count)-1) {
                    column = 0;
                    row++;
                }
            }
            btn_SetDemands.Location = new Point(
                Convert.ToInt32((Size.Width / 2) - (btn_SetDemands.Width/2))-7,
                Convert.ToInt32(Size.Height - btn_SetDemands.Height)
                );
            Controls.Add(btn_SetDemands);
            Width += 10;
        }

        private void Btn_SetDemands_Click(object sender, EventArgs e) {
            int control_index = 0;
            foreach(NumericUpDown nUD in _nUD_Demands) {
                _Demands[control_index] = Convert.ToInt32(nUD.Value);
                control_index++;
            }
            Close();
        }
    }
}
