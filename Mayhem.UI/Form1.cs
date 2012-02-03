using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Mayhem.DTO;
using Mayhem.Logic;

namespace Mayhem.UI
{
    public partial class Form1 : Form
    {
        DataSet _MayhemDS;

        public Form1()
        {
            InitializeComponent();
        }

        private void expoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //First, declare a variable to hold the user’s file selection.
            string input = string.Empty;

            //Create a new instance of the OpenFileDialog because it's an object. 
            OpenFileDialog dialog = new OpenFileDialog();

            //Now set the file type 
            dialog.Filter = "xml files (*.xml)|*.xml";

            //Set the starting directory and the title. 
            //dialog.InitialDirectory = "C:"; dialog.Title = "Select a text file"; 

            //Present to the user. 
            DialogResult result;
            result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                input = dialog.FileName;
            }
            LoadDataSet(input);
        }

        private void LoadDataSet(string input)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(DataSet));
            TextReader textReader = new StreamReader(input);
            _MayhemDS = (DataSet)deserializer.Deserialize(textReader);
            textReader.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataSet("Mayhem.xml");

            //Case Number
            BindingSource cboCaseNumberBindingSource = new BindingSource();
            cboCaseNumberBindingSource.DataSource = _MayhemDS.Tables["Incidents"];
            cboCaseNumber.DataSource = cboCaseNumberBindingSource;
            cboCaseNumber.DisplayMember = "IncidentsID";
            cboCaseNumber.SelectedIndex = -1;

            //Evaluator
            BindingSource cboEvaluatorBindingSource = new BindingSource();
            cboEvaluatorBindingSource.DataSource = _MayhemDS.Tables["Dispatchers"];
            cboEvaluator.DataSource = cboEvaluatorBindingSource;
            cboEvaluator.DisplayMember = "DispatcherID";
            cboEvaluator.SelectedIndex = -1;

            //Dispatcher_1
            BindingSource cboDispatcher_1BindingSource = new BindingSource();
            cboDispatcher_1BindingSource.DataSource = _MayhemDS.Tables["Dispatchers"];
            cboDispatcher_1.DataSource = cboDispatcher_1BindingSource;
            cboDispatcher_1.DisplayMember = "DispatcherID";
            cboDispatcher_1.SelectedIndex = -1;

            //Shift_1
            BindingSource cboShift_1BindingSource = new BindingSource();
            cboShift_1BindingSource.DataSource = _MayhemDS.Tables["Shifts"];
            cboShift_1.DataSource = cboShift_1BindingSource;
            cboShift_1.DisplayMember = "ShiftName";
            cboShift_1.SelectedIndex = -1;

            //Dispatcher_2
            BindingSource cboDispatcher_2BindingSource = new BindingSource();
            cboDispatcher_2BindingSource.DataSource = _MayhemDS.Tables["Dispatchers"];
            cboDispatcher_2.DataSource = cboDispatcher_2BindingSource;
            cboDispatcher_2.DisplayMember = "DispatcherID";
            cboDispatcher_2.SelectedIndex = -1;

            //Shift_2
            BindingSource cboShift_2BindingSource = new BindingSource();
            cboShift_2BindingSource.DataSource = _MayhemDS.Tables["Shifts"];
            cboShift_2.DataSource = cboShift_2BindingSource;
            cboShift_2.DisplayMember = "ShiftName";
            cboShift_2.SelectedIndex = -1;

            //Channels_2
            BindingSource cboChannel_2BindingSource = new BindingSource();
            cboChannel_2BindingSource.DataSource = _MayhemDS.Tables["Channels"];
            cboChannel_2.DataSource = cboChannel_2BindingSource;
            cboChannel_2.DisplayMember = "ChannelName";
            cboChannel_2.SelectedIndex = -1;

            ResetForm();
            CalculateScore();

        }

        private void manageDispatchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigManager dispatcherManager = new ConfigManager("Dispatchers", _MayhemDS);
            dispatcherManager.Show();
        }

        private void manageShiftsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigManager shiftManager = new ConfigManager("Shifts", _MayhemDS);
            shiftManager.Show();
        }

        private void manageChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigManager channelManager = new ConfigManager("Channels", _MayhemDS);
            channelManager.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: Check to make sure that all the fields have been validated!
            if (ValidateFields())
            {
                SaveData();
            }

        }

        private void SaveData()
        {
            DataRow incidentRow = _MayhemDS.Tables["Incidents"].NewRow();
            //incidentsCol[0] = new DataColumn("Evaluator", typeof(string));
            incidentRow["Evaluator"] = cboEvaluator.Text;
            //incidentsCol[1] = new DataColumn("Channel_1", typeof(int));
            incidentRow["Channel_1"] = 1;
            //
            incidentRow["IncidentsID"] = lblCaseNumberValue.Text;
            //incidentsCol[2] = new DataColumn("Dispatcher_1", typeof(string));
            incidentRow["Dispatcher_1"] = cboDispatcher_1.Text;
            //incidentsCol[3] = new DataColumn("Shift_1", typeof(int));
            DataRow cboShift_1_Row = (cboShift_1.SelectedItem as DataRowView).Row;
            int cboShift_1ID = (int)cboShift_1_Row["ShiftID"];
            incidentRow["Shift_1"] = cboShift_1ID;
            //incidentsCol[4] = new DataColumn("DateTime_1", typeof(DateTime));
            incidentRow["DateTime_1"] = dateTimePicker_1.Value;
            //incidentsCol[5] = new DataColumn("ToneAlertUsed_1", typeof(bool));
            incidentRow["ToneAlertUsed_1"] = BinaryRadioButtons(rbToneAlertUsedY_1, rbToneAlertUsedN_1);
            //incidentsCol[6] = new DataColumn("Priority_1", typeof(bool));
            incidentRow["Priority_1"] = BinaryRadioButtons(rbPriorityY_1, rbPriorityN_1);
            //incidentsCol[7] = new DataColumn("Sunstar3DigitNumber_1", typeof(bool));
            incidentRow["Sunstar3DigitNumber_1"] = BinaryRadioButtons(rbSunstar3digitNumberY_1, rbSunstar3digitNumberN_1);
            //incidentsCol[8] = new DataColumn("Location_1", typeof(bool));
            incidentRow["Location_1"] = BinaryRadioButtons(rbLocationY_1, rbLocationN_1);
            //incidentsCol[9] = new DataColumn("MapGrid_1", typeof(bool));
            incidentRow["MapGrid_1"] = BinaryRadioButtons(rbMapGridY_1, rbMapGridN_1);
            //incidentsCol[10] = new DataColumn("NatureOfCall_1", typeof(bool));
            incidentRow["NatureOfCall_1"] = BinaryRadioButtons(rbNatureOfCallY_1, rbNatureOfCallN_1);
            //incidentsCol[11] = new DataColumn("SSTacChannel_1", typeof(bool));
            incidentRow["SSTacChannel_1"] = BinaryRadioButtons(rbSSTacChannelY_1, rbSSTacChannelN_1);
            //incidentsCol[12] = new DataColumn("PertinentIntRouting_1", typeof(bool));
            incidentRow["PertinentIntRouting_1"] = BinaryRadioButtons(rbPertinentIntRoutingY_1, rbPertinentIntRoutingN_1);
            //incidentsCol[13] = new DataColumn("InfoGivenOutOfOrder_1", typeof(bool));
            incidentRow["InfoGivenOutOfOrder_1"] = BinaryRadioButtons(rbInfoGivenOutOfOrderY_1, rbInfoGivenOutOfOrderN_1);
            //incidentsCol[14] = new DataColumn("DisplayedServiceAttitude_1", typeof(string));
            incidentRow["DisplayedServiceAttitude_1"] =
                TertiaryRadioButtons(rbDSACorrect_1, rbDSAMinor_1, rbDSAIncorrect_1, "Correct", "Minor", "Incorrect");
            //incidentsCol[15] = new DataColumn("UsedCorrectVolumeTone_1", typeof(string));
            incidentRow["UsedCorrectVolumeTone_1"] =
                TertiaryRadioButtons(rbUsedCorVolTonCorrect_1, rbUsedCorVolTonMinor_1, rbUsedCorVolTonIncorrect_1, "Correct", "Minor", "Incorrect");
            //incidentsCol[16] = new DataColumn("UsedProhibitedBehavior_1", typeof(bool));
            incidentRow["UsedProhibitedBehavior_1"] = BinaryRadioButtons(rbUsedProBehCorrect_1, rbUsedProBehIncorrect_1);


            //incidentsCol[17] = new DataColumn("Channel_2", typeof(int));
            DataRow cboChannel_2_Row = (cboChannel_2.SelectedItem as DataRowView).Row;
            int cboChannel_2_ID = (int)cboChannel_2_Row["ChannelID"];
            incidentRow["Channel_2"] = cboChannel_2_ID;
            //incidentsCol[18] = new DataColumn("Dispatcher_2", typeof(string));
            incidentRow["Dispatcher_2"] = cboDispatcher_2.Text;
            //incidentsCol[19] = new DataColumn("Shift_2", typeof(int));
            DataRow cboShift_2_Row = (cboShift_2.SelectedItem as DataRowView).Row;
            int cboShift_2ID = (int)cboShift_2_Row["ShiftID"];
            incidentRow["Shift_2"] = cboShift_2ID;
            //incidentsCol[20] = new DataColumn("DateTime_2", typeof(DateTime));
            incidentRow["DateTime_2"] = dateTimePicker_2.Value;
            //incidentsCol[21] = new DataColumn("Sunstar3DigitNumber_2", typeof(bool));
            incidentRow["Sunstar3DigitNumber_2"] = BinaryRadioButtons(rbSunstar3digitNumberY_2, rbSunstar3digitNumberN_2);
            //incidentsCol[22] = new DataColumn("NatureOfCall_2", typeof(bool));
            incidentRow["NatureOfCall_2"] = BinaryRadioButtons(rbNatureOfCallY_2, rbNatureOfCallN_2);
            //incidentsCol[23] = new DataColumn("Location_2", typeof(bool));
            incidentRow["Location_2"] = BinaryRadioButtons(rbLocationY_2, rbLocationN_2);
            //incidentsCol[24] = new DataColumn("MapGrid_2", typeof(bool));
            incidentRow["MapGrid_2"] = BinaryRadioButtons(rbMapGridY_2, rbMapGridN_2);
            //incidentsCol[25] = new DataColumn("FDUnitsAndTacCh_2", typeof(bool));
            incidentRow["FDUnitsAndTacCh_2"] = BinaryRadioButtons(rbFDUnitsAndTacChY_2, rbFDUnitsAndTacChN_2);
            //incidentsCol[26] = new DataColumn("ScriptingDocumented_2", typeof(bool));
            incidentRow["ScriptingDocumented_2"] = BinaryRadioButtons(rbScriptDocumentedY_2, rbScriptDocumentedN_2);
            //incidentsCol[27] = new DataColumn("SevenMin_2", typeof(bool));
            incidentRow["SevenMin_2"] = BinaryRadioButtons(rbSevMinY_2, rbSevMinN_2);
            //incidentsCol[28] = new DataColumn("TwelveMin_2", typeof(bool));
            incidentRow["TwelveMin_2"] = BinaryRadioButtons(rbTwelveY_2, rbTwelveN_2);
            //incidentsCol[29] = new DataColumn("ETALocationAsked_2", typeof(bool));
            incidentRow["ETALocationAsked_2"] = BinaryRadioButtons(rbETALocAskY_2, rbETALocAskN_2);
            //incidentsCol[30] = new DataColumn("ETADocumented_2", typeof(bool));
            incidentRow["ETADocumented_2"] = BinaryRadioButtons(rbETADocumentedY_2, rbETADocumentedN_2);
            //incidentsCol[31] = new DataColumn("ProactiveRoutingGiven_2", typeof(string));
            incidentRow["ProactiveRoutingGiven_2"] =
                TertiaryRadioButtons(rbProRouGivY_2, rbProRouGivNo_2, rbProRouGivNA_2, "Yes", "No", "N/A");
            //incidentsCol[32] = new DataColumn("CorrectRouting_2", typeof(string));
            incidentRow["CorrectRouting_2"] =
                TertiaryRadioButtons(rbCorRouY_2, rbCorRouNo_2, rbCorRouNA_2, "Yes", "No", "N/A");
            //incidentsCol[33] = new DataColumn("RoutingDocumented_2", typeof(bool));
            incidentRow["RoutingDocumented_2"] = BinaryRadioButtons(rbRoutDocumentedY_2, rbRoutDocumentedN_2);
            //incidentsCol[34] = new DataColumn("PreArrivalGiven_2", typeof(bool));
            incidentRow["PreArrivalGiven_2"] = BinaryRadioButtons(rbPreArrGivY_2, rbPreArrGivN_2);
            //incidentsCol[35] = new DataColumn("EMDDocumented_2", typeof(bool));
            incidentRow["EMDDocumented_2"] = BinaryRadioButtons(rbEMDDocumentedY_2, rbEMDDocumentedN_2);
            //incidentsCol[36] = new DataColumn("DisplayedServiceAttitude_2", typeof(string));
            incidentRow["DisplayedServiceAttitude_2"] =
                TertiaryRadioButtons(rbDSACorrect_2, rbDSAMinor_2, rbDSAIncorrect_2, "Correct", "Minor", "Incorrect");
            //incidentsCol[37] = new DataColumn("UsedCorrectVolumeTone_2", typeof(string));
            incidentRow["UsedCorrectVolumeTone_2"] =
                TertiaryRadioButtons(rbUsedCorVolTonCorrect_2, rbUsedCorVolTonMinor_2, rbUsedCorVolTonIncorrect_2,
                "Correct", "Minor", "Incorrect");
            //incidentsCol[38] = new DataColumn("UsedProhibitedBehavior_2", typeof(bool));
            incidentRow["UsedProhibitedBehavior_2"] = BinaryRadioButtons(rbUsedProBehCorrect_2, rbUsedProBehIncorrect_2);
            //incidentsCol[39] = new DataColumn("PatchedChannels_2", typeof(bool));
            incidentRow["PatchedChannels_2"] = BinaryRadioButtons(rbPatChanY_2, rbPatChanN_2);
            //incidentsCol[40] = new DataColumn("Phone_2", typeof(bool));
            incidentRow["Phone_2"] = BinaryRadioButtons(rbPhoneY_2, rbPhoneN_2);
            _MayhemDS.Tables["Incidents"].Rows.Add(incidentRow);
        }

        private bool ValidateFields()
        {
            return true;
        }

        string TertiaryRadioButtons(RadioButton rb1, RadioButton rb2, RadioButton rb3, string string1, string string2, string string3)
        {
            if (rb1.Checked)
            {
                return string1;
            }
            if (rb2.Checked)
            {
                return string2;
            }
            if (rb3.Checked)
            {
                return string3;
            }
            return null;
        }

        bool BinaryRadioButtons(RadioButton rb1, RadioButton rb2)
        {
            if (rb1.Checked)
            {
                return true;
            }
            if (rb2.Checked)
            {
                return false;
            }
            bool? flag = null;
            return (bool)flag;
        }

        private void viewIncidentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigManager incidentsManager = new ConfigManager("Incidents", _MayhemDS);
            incidentsManager.Show();
        }

        private void ResetForm()
        {

            cboCaseNumber.SelectedIndex = -1;
            cboEvaluator.SelectedIndex = -1;

            //Form A
            cboDispatcher_1.SelectedIndex = -1;
            cboShift_1.SelectedIndex = -1;
            rbToneAlertUsedY_1.Checked = true;
            rbPriorityY_1.Checked = true;
            rbSunstar3digitNumberY_1.Checked = true;
            rbLocationY_1.Checked = true;
            rbMapGridY_1.Checked = true;
            rbNatureOfCallY_1.Checked = true;
            rbSSTacChannelY_1.Checked = true;
            rbPertinentIntRoutingY_1.Checked = true;
            rbInfoGivenOutOfOrderY_1.Checked = true;
            rbDSACorrect_1.Checked = true;
            rbUsedCorVolTonCorrect_1.Checked = true;
            rbUsedProBehCorrect_1.Checked = true;

            //Form B
            cboDispatcher_2.SelectedIndex = -1;
            cboShift_2.SelectedIndex = -1;
            cboChannel_2.SelectedIndex = -1;
            rbPatChanN_2.Checked = true;
            rbPhoneN_2.Checked = true;
            rbSunstar3digitNumberY_2.Checked = true;
            rbNatureOfCallY_2.Checked = true;
            rbLocationY_2.Checked = true;
            rbMapGridY_2.Checked = true;
            rbFDUnitsAndTacChY_2.Checked = true;
            rbScriptDocumentedY_2.Checked = true;
            rbSevMinY_2.Checked = true;
            rbTwelveY_2.Checked = true;
            rbETALocAskY_2.Checked = true;
            rbETADocumentedY_2.Checked = true;
            rbProRouGivY_2.Checked = true;
            rbCorRouY_2.Checked = true;
            rbRoutDocumentedY_2.Checked = true;
            rbPreArrGivY_2.Checked = true;
            rbEMDDocumentedY_2.Checked = true;
            rbDSACorrect_2.Checked = true;
            rbUsedCorVolTonCorrect_2.Checked = true;
            rbUsedProBehCorrect_2.Checked = true;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show
                ("Do you want to reset the form(s) to the default settings? If so, click yes.",
                "Important Note", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                ResetForm();
            }
        }

        private void CalculateScore()
        {
            PopulateScore_FormA();
            PopulateScore_FormB();
        }

        #region PopulateScore FormA and FormB
        private void PopulateScore_FormA()
        {
            PrimaryFormPoints input = new PrimaryFormPoints();
            input.ToneAlertUsed = rbToneAlertUsedY_1.Checked;
            input.Priority = rbPriorityY_1.Checked;
            input.SunstarThreeDigitUnit = rbSunstar3digitNumberY_1.Checked;
            input.Location = rbLocationY_1.Checked;
            input.MapGrid = rbMapGridY_1.Checked;
            input.NatureOfCall = rbNatureOfCallY_1.Checked;
            input.SsTacChannel = rbSSTacChannelY_1.Checked;
            input.DisplayedServiceAttitude = TertiaryRadioButtons(rbDSACorrect_1,
                                                                  rbDSAMinor_1,
                                                                  rbDSAIncorrect_1,
                                                                  "Correct",
                                                                  "Minor",
                                                                  "Incorrect");
            input.UsedCorrectVolTone = TertiaryRadioButtons(rbUsedCorVolTonCorrect_1,
                                                            rbUsedCorVolTonMinor_1,
                                                            rbUsedCorVolTonIncorrect_1,
                                                            "Correct",
                                                            "Minor",
                                                            "Incorrect");
            input.UsedProhibitedBehavior = rbUsedProBehCorrect_1.Checked;
            decimal formScore = PointSystem.PointTabulation(input);

            lblTotalScore_1.Text = string.Format("{0:0.##}%", formScore);

        }

        private void PopulateScore_FormB()
        {
            SecondaryFormPoints input = new SecondaryFormPoints();
            input.SunstarThreeDigitUnit = rbSunstar3digitNumberY_2.Checked;
            input.NatureOfCall = rbNatureOfCallY_2.Checked;
            input.Location = rbLocationY_2.Checked;
            input.MapGrid = rbMapGridY_2.Checked;
            input.FdUnitAndTacCh = rbFDUnitsAndTacChY_2.Checked;
            input.Documented1 = rbScriptDocumentedY_2.Checked;
            input.SevMin = rbSevMinY_2.Checked;
            input.TwelveMin = rbTwelveY_2.Checked;
            input.EtaLocationAsked = rbETALocAskY_2.Checked;
            input.Documented2 = rbETADocumentedY_2.Checked;
            input.ProactiveRoutingGiven = TertiaryRadioButtons(rbProRouGivY_2,
                                                               rbProRouGivNo_2,
                                                               rbProRouGivNA_2,
                                                               "Yes", "No", "N/A");
            input.CorrectRouting = TertiaryRadioButtons(rbCorRouY_2,
                                                        rbCorRouNo_2,
                                                        rbCorRouNA_2,
                                                        "Yes", "No", "N/A");
            input.Documented3 = rbRoutDocumentedY_2.Checked;
            input.PreArrivalGiven = rbPreArrGivY_2.Checked;
            input.Documented4 = rbEMDDocumentedY_2.Checked;
            input.DisplayedServiceAttitude = TertiaryRadioButtons(rbDSACorrect_2,
                                                                  rbDSAMinor_2,
                                                                  rbDSAIncorrect_2,
                                                                  "Correct", "Minor", "Incorrect");
            input.UsedCorrectVolTone = TertiaryRadioButtons(rbUsedCorVolTonCorrect_2,
                                                            rbUsedCorVolTonMinor_2,
                                                            rbUsedCorVolTonIncorrect_2,
                                                            "Correct", "Minor", "Incorrect"); ;
            input.UsedProhibitedBehavior = rbUsedProBehCorrect_2.Checked;
            decimal formScore = PointSystem.PointTabulation(input);
            lblTotalScore_2.Text = string.Format("{0:0.##}%", formScore);
        }
        #endregion

        #region Radio Button Events
        private void rbToneAlertUsedY_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbPriorityY_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbSunstar3digitNumberY_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbLocationY_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbMapGridY_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbNatureOfCallY_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbSSTacChannelY_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbPertinentIntRoutingY_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbInfoGivenOutOfOrderY_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbDSACorrect_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbDSAMinor_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbDSAIncorrect_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbUsedCorVolTonCorrect_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbUsedCorVolTonMinor_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbUsedCorVolTonIncorrect_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbUsedProBehCorrect_1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbSunstar3digitNumberY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbNatureOfCallY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbLocationY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbMapGridY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbFDUnitsAndTacChY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbScriptDocumentedY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbSevMinY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbTwelveY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbETALocAskY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbETADocumentedY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbProRouGivY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbCorRouY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbRoutDocumentedY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbPreArrGivY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbEMDDocumentedY_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbDSACorrect_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbDSAMinor_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbDSAIncorrect_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbUsedCorVolTonCorrect_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbUsedCorVolTonMinor_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbUsedCorVolTonIncorrect_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }

        private void rbUsedProBehCorrect_2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateScore();
        }
        #endregion

        private void cboCaseNumber_TextUpdate(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void newCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchNewCaseWindow();
        }

        private void LaunchNewCaseWindow()
        {
            NewIncidentForm form = new NewIncidentForm(lblCaseNumberValue);
            form.ShowDialog();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                LaunchNewCaseWindow();
            }
        }

        private void lblCaseNumberValue_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnSave.Enabled = true;

            ResetForm();
        }
    }
}
