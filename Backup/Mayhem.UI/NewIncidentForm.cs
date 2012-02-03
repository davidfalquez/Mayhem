using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mayhem.UI
{
    public partial class NewIncidentForm : Form
    {
        private Label _OtherCaseLabel;

        //public NewIncidentForm()
        //{
        //    InitializeComponent();
        //}

        public NewIncidentForm(Label otherCaseLabel)
        {
            InitializeComponent();
            _OtherCaseLabel = otherCaseLabel;

        }

        private void btnNewIncident_Click(object sender, EventArgs e)
        {
            _OtherCaseLabel.Text = txboxCaseNumber.Text;
            this.Close();
        }
    }
}
