namespace VNA_Visa_Example
{
    partial class FormMain
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
            this.groupBoxCommand = new System.Windows.Forms.GroupBox();
            this.buttonCmdRst = new System.Windows.Forms.Button();
            this.buttonCmdOpc = new System.Windows.Forms.Button();
            this.buttonCmdCls = new System.Windows.Forms.Button();
            this.buttonCmdSystErr = new System.Windows.Forms.Button();
            this.buttonCmdIdn = new System.Windows.Forms.Button();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupBoxResponse = new System.Windows.Forms.GroupBox();
            this.richTextBoxLogVna = new System.Windows.Forms.RichTextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxVisaResourceName = new System.Windows.Forms.GroupBox();
            this.comboBoxVisaResourceName = new System.Windows.Forms.ComboBox();
            this.buttonConnectDisconnectVna = new System.Windows.Forms.Button();
            this.groupBoxCommand.SuspendLayout();
            this.groupBoxResponse.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxVisaResourceName.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCommand
            // 
            this.groupBoxCommand.Controls.Add(this.buttonCmdRst);
            this.groupBoxCommand.Controls.Add(this.buttonCmdOpc);
            this.groupBoxCommand.Controls.Add(this.buttonCmdCls);
            this.groupBoxCommand.Controls.Add(this.buttonCmdSystErr);
            this.groupBoxCommand.Controls.Add(this.buttonCmdIdn);
            this.groupBoxCommand.Controls.Add(this.textBoxCommand);
            this.groupBoxCommand.Controls.Add(this.buttonSend);
            this.groupBoxCommand.Location = new System.Drawing.Point(18, 91);
            this.groupBoxCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxCommand.Name = "groupBoxCommand";
            this.groupBoxCommand.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxCommand.Size = new System.Drawing.Size(775, 115);
            this.groupBoxCommand.TabIndex = 17;
            this.groupBoxCommand.TabStop = false;
            this.groupBoxCommand.Text = "Command";
            // 
            // buttonCmdRst
            // 
            this.buttonCmdRst.Location = new System.Drawing.Point(393, 31);
            this.buttonCmdRst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCmdRst.Name = "buttonCmdRst";
            this.buttonCmdRst.Size = new System.Drawing.Size(120, 35);
            this.buttonCmdRst.TabIndex = 4;
            this.buttonCmdRst.Text = "*RST";
            this.buttonCmdRst.UseVisualStyleBackColor = true;
            this.buttonCmdRst.Click += new System.EventHandler(this.buttonCmdRst_Click);
            // 
            // buttonCmdOpc
            // 
            this.buttonCmdOpc.Location = new System.Drawing.Point(137, 31);
            this.buttonCmdOpc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCmdOpc.Name = "buttonCmdOpc";
            this.buttonCmdOpc.Size = new System.Drawing.Size(120, 35);
            this.buttonCmdOpc.TabIndex = 2;
            this.buttonCmdOpc.Text = "*OPC?";
            this.buttonCmdOpc.UseVisualStyleBackColor = true;
            this.buttonCmdOpc.Click += new System.EventHandler(this.buttonCmdOpc_Click);
            // 
            // buttonCmdCls
            // 
            this.buttonCmdCls.Location = new System.Drawing.Point(265, 31);
            this.buttonCmdCls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCmdCls.Name = "buttonCmdCls";
            this.buttonCmdCls.Size = new System.Drawing.Size(120, 35);
            this.buttonCmdCls.TabIndex = 3;
            this.buttonCmdCls.Text = "*CLS";
            this.buttonCmdCls.UseVisualStyleBackColor = true;
            this.buttonCmdCls.Click += new System.EventHandler(this.buttonCmdCls_Click);
            // 
            // buttonCmdSystErr
            // 
            this.buttonCmdSystErr.Location = new System.Drawing.Point(521, 31);
            this.buttonCmdSystErr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCmdSystErr.Name = "buttonCmdSystErr";
            this.buttonCmdSystErr.Size = new System.Drawing.Size(120, 35);
            this.buttonCmdSystErr.TabIndex = 5;
            this.buttonCmdSystErr.Text = "SYST:ERR?";
            this.buttonCmdSystErr.UseVisualStyleBackColor = true;
            this.buttonCmdSystErr.Click += new System.EventHandler(this.buttonCmdSystErr_Click);
            // 
            // buttonCmdIdn
            // 
            this.buttonCmdIdn.Location = new System.Drawing.Point(9, 31);
            this.buttonCmdIdn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCmdIdn.Name = "buttonCmdIdn";
            this.buttonCmdIdn.Size = new System.Drawing.Size(120, 35);
            this.buttonCmdIdn.TabIndex = 1;
            this.buttonCmdIdn.Text = "*IDN?";
            this.buttonCmdIdn.UseVisualStyleBackColor = true;
            this.buttonCmdIdn.Click += new System.EventHandler(this.buttonCmdIdn_Click);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCommand.Location = new System.Drawing.Point(10, 72);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(631, 26);
            this.textBoxCommand.TabIndex = 6;
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.Location = new System.Drawing.Point(649, 29);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(115, 75);
            this.buttonSend.TabIndex = 7;
            this.buttonSend.Text = "&Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // groupBoxResponse
            // 
            this.groupBoxResponse.Controls.Add(this.richTextBoxLogVna);
            this.groupBoxResponse.Location = new System.Drawing.Point(18, 212);
            this.groupBoxResponse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxResponse.Name = "groupBoxResponse";
            this.groupBoxResponse.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxResponse.Size = new System.Drawing.Size(775, 585);
            this.groupBoxResponse.TabIndex = 15;
            this.groupBoxResponse.TabStop = false;
            // 
            // richTextBoxLogVna
            // 
            this.richTextBoxLogVna.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxLogVna.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLogVna.Location = new System.Drawing.Point(10, 19);
            this.richTextBoxLogVna.Margin = new System.Windows.Forms.Padding(5);
            this.richTextBoxLogVna.Name = "richTextBoxLogVna";
            this.richTextBoxLogVna.ReadOnly = true;
            this.richTextBoxLogVna.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxLogVna.Size = new System.Drawing.Size(754, 556);
            this.richTextBoxLogVna.TabIndex = 0;
            this.richTextBoxLogVna.TabStop = false;
            this.richTextBoxLogVna.Text = "";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelText,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelVersion});
            this.statusStrip.Location = new System.Drawing.Point(0, 814);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(808, 30);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 18;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(64, 25);
            this.toolStripStatusLabel.Text = "Status:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 25);
            // 
            // toolStripStatusLabelText
            // 
            this.toolStripStatusLabelText.Name = "toolStripStatusLabelText";
            this.toolStripStatusLabelText.Size = new System.Drawing.Size(33, 25);
            this.toolStripStatusLabelText.Text = "---";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(645, 25);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelVersion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabelVersion.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(38, 25);
            this.toolStripStatusLabelVersion.Text = "v ---";
            this.toolStripStatusLabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxVisaResourceName
            // 
            this.groupBoxVisaResourceName.Controls.Add(this.comboBoxVisaResourceName);
            this.groupBoxVisaResourceName.Controls.Add(this.buttonConnectDisconnectVna);
            this.groupBoxVisaResourceName.Location = new System.Drawing.Point(18, 7);
            this.groupBoxVisaResourceName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxVisaResourceName.Name = "groupBoxVisaResourceName";
            this.groupBoxVisaResourceName.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxVisaResourceName.Size = new System.Drawing.Size(775, 74);
            this.groupBoxVisaResourceName.TabIndex = 16;
            this.groupBoxVisaResourceName.TabStop = false;
            this.groupBoxVisaResourceName.Text = "Visa Resource Name";
            // 
            // comboBoxVisaResourceName
            // 
            this.comboBoxVisaResourceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVisaResourceName.FormattingEnabled = true;
            this.comboBoxVisaResourceName.Location = new System.Drawing.Point(10, 29);
            this.comboBoxVisaResourceName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxVisaResourceName.Name = "comboBoxVisaResourceName";
            this.comboBoxVisaResourceName.Size = new System.Drawing.Size(631, 28);
            this.comboBoxVisaResourceName.TabIndex = 1;
            this.comboBoxVisaResourceName.SelectedIndexChanged += new System.EventHandler(this.comboBoxVisaResourceName_SelectedIndexChanged);
            // 
            // buttonConnectDisconnectVna
            // 
            this.buttonConnectDisconnectVna.Location = new System.Drawing.Point(649, 27);
            this.buttonConnectDisconnectVna.Margin = new System.Windows.Forms.Padding(5);
            this.buttonConnectDisconnectVna.Name = "buttonConnectDisconnectVna";
            this.buttonConnectDisconnectVna.Size = new System.Drawing.Size(115, 35);
            this.buttonConnectDisconnectVna.TabIndex = 2;
            this.buttonConnectDisconnectVna.TabStop = false;
            this.buttonConnectDisconnectVna.Text = "Connect";
            this.buttonConnectDisconnectVna.UseVisualStyleBackColor = true;
            this.buttonConnectDisconnectVna.Click += new System.EventHandler(this.buttonConnectDisconnectVna_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 844);
            this.Controls.Add(this.groupBoxCommand);
            this.Controls.Add(this.groupBoxResponse);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBoxVisaResourceName);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "< application title goes here >";
            this.groupBoxCommand.ResumeLayout(false);
            this.groupBoxCommand.PerformLayout();
            this.groupBoxResponse.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxVisaResourceName.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCommand;
        private System.Windows.Forms.Button buttonCmdRst;
        private System.Windows.Forms.Button buttonCmdOpc;
        private System.Windows.Forms.Button buttonCmdCls;
        private System.Windows.Forms.Button buttonCmdSystErr;
        private System.Windows.Forms.Button buttonCmdIdn;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.GroupBox groupBoxResponse;
        private System.Windows.Forms.RichTextBox richTextBoxLogVna;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.GroupBox groupBoxVisaResourceName;
        private System.Windows.Forms.ComboBox comboBoxVisaResourceName;
        private System.Windows.Forms.Button buttonConnectDisconnectVna;
    }
}

