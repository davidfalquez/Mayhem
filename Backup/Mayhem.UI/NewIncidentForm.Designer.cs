namespace Mayhem.UI
{
    partial class NewIncidentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNewIncident = new System.Windows.Forms.Label();
            this.txboxCaseNumber = new System.Windows.Forms.TextBox();
            this.btnNewIncident = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNewIncident
            // 
            this.lblNewIncident.AutoSize = true;
            this.lblNewIncident.Location = new System.Drawing.Point(22, 31);
            this.lblNewIncident.Name = "lblNewIncident";
            this.lblNewIncident.Size = new System.Drawing.Size(47, 13);
            this.lblNewIncident.TabIndex = 0;
            this.lblNewIncident.Text = "Case #: ";
            // 
            // txboxCaseNumber
            // 
            this.txboxCaseNumber.Location = new System.Drawing.Point(75, 24);
            this.txboxCaseNumber.Name = "txboxCaseNumber";
            this.txboxCaseNumber.Size = new System.Drawing.Size(100, 20);
            this.txboxCaseNumber.TabIndex = 1;
            // 
            // btnNewIncident
            // 
            this.btnNewIncident.Location = new System.Drawing.Point(181, 21);
            this.btnNewIncident.Name = "btnNewIncident";
            this.btnNewIncident.Size = new System.Drawing.Size(75, 23);
            this.btnNewIncident.TabIndex = 2;
            this.btnNewIncident.Text = "Done";
            this.btnNewIncident.UseVisualStyleBackColor = true;
            this.btnNewIncident.Click += new System.EventHandler(this.btnNewIncident_Click);
            // 
            // NewIncidentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 56);
            this.Controls.Add(this.btnNewIncident);
            this.Controls.Add(this.txboxCaseNumber);
            this.Controls.Add(this.lblNewIncident);
            this.Name = "NewIncidentForm";
            this.Text = "New Case";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewIncident;
        private System.Windows.Forms.TextBox txboxCaseNumber;
        private System.Windows.Forms.Button btnNewIncident;
    }
}