using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Mayhem.UI
{
    public partial class ConfigManager : Form
    {
        DataSet _MayhemDS;
        BindingSource _TableBinding;

        public ConfigManager(string tableName, DataSet mayhemDS)
        {
            InitializeComponent();
            this._MayhemDS = mayhemDS;
            _TableBinding = new BindingSource();
            _TableBinding.DataSource = mayhemDS.Tables[tableName];
            dgvManager.DataSource = _TableBinding;
        }



        public ConfigManager()
        {
            InitializeComponent();
        }

        private void ConfigManager_Load(object sender, EventArgs e)
        {
            
        }

        private void ConfigManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataSet));
            TextWriter textWriter = new StreamWriter(@"Mayhem.xml");
            serializer.Serialize(textWriter, _MayhemDS);
            textWriter.Close();
        }
    }
}
