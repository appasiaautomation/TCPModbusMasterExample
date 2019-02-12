namespace TCPModbusMasterExample
{
    partial class Form1
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtCheckConnect = new System.Windows.Forms.TextBox();
            this.btnReadCoils = new System.Windows.Forms.Button();
            this.btnReadDiscreateInputs = new System.Windows.Forms.Button();
            this.btnReadHoldingRegisters = new System.Windows.Forms.Button();
            this.btnReadInputRegisaters = new System.Windows.Forms.Button();
            this.btnWriteSingleCoil = new System.Windows.Forms.Button();
            this.btnWriteSingleRegister = new System.Windows.Forms.Button();
            this.btnWriteMultipleCoils = new System.Windows.Forms.Button();
            this.btnWriteMultipleRegisters = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearEntry = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnPrepareCoils = new System.Windows.Forms.Button();
            this.lstReadDataFromServer = new System.Windows.Forms.ListBox();
            this.lstWriteDataToServer = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPrepareCoils = new System.Windows.Forms.TextBox();
            this.txtPrepareRegisters = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStartAddress = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStartAddress1 = new System.Windows.Forms.TextBox();
            this.dataRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Lime;
            this.btnConnect.Location = new System.Drawing.Point(457, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 44);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Red;
            this.btnDisconnect.Location = new System.Drawing.Point(582, 6);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 44);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(91, 9);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(100, 20);
            this.txtIpAddress.TabIndex = 4;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(268, 6);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 5;
            // 
            // txtCheckConnect
            // 
            this.txtCheckConnect.BackColor = System.Drawing.Color.Red;
            this.txtCheckConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckConnect.ForeColor = System.Drawing.SystemColors.Window;
            this.txtCheckConnect.Location = new System.Drawing.Point(12, 499);
            this.txtCheckConnect.Name = "txtCheckConnect";
            this.txtCheckConnect.Size = new System.Drawing.Size(810, 31);
            this.txtCheckConnect.TabIndex = 6;
            this.txtCheckConnect.Text = "Not Connected To Server";
            // 
            // btnReadCoils
            // 
            this.btnReadCoils.Location = new System.Drawing.Point(1, 76);
            this.btnReadCoils.Name = "btnReadCoils";
            this.btnReadCoils.Size = new System.Drawing.Size(171, 23);
            this.btnReadCoils.TabIndex = 7;
            this.btnReadCoils.Text = "Read Coils-FC1";
            this.btnReadCoils.UseVisualStyleBackColor = true;
            this.btnReadCoils.Click += new System.EventHandler(this.btnReadCoils_Click);
            // 
            // btnReadDiscreateInputs
            // 
            this.btnReadDiscreateInputs.Location = new System.Drawing.Point(1, 105);
            this.btnReadDiscreateInputs.Name = "btnReadDiscreateInputs";
            this.btnReadDiscreateInputs.Size = new System.Drawing.Size(171, 23);
            this.btnReadDiscreateInputs.TabIndex = 8;
            this.btnReadDiscreateInputs.Text = "Read Discreate Inputs-FC2";
            this.btnReadDiscreateInputs.UseVisualStyleBackColor = true;
            this.btnReadDiscreateInputs.Click += new System.EventHandler(this.btnReadDiscreateInputs_Click);
            // 
            // btnReadHoldingRegisters
            // 
            this.btnReadHoldingRegisters.Location = new System.Drawing.Point(1, 134);
            this.btnReadHoldingRegisters.Name = "btnReadHoldingRegisters";
            this.btnReadHoldingRegisters.Size = new System.Drawing.Size(171, 23);
            this.btnReadHoldingRegisters.TabIndex = 9;
            this.btnReadHoldingRegisters.Text = "Read Holding Registers-FC3";
            this.btnReadHoldingRegisters.UseVisualStyleBackColor = true;
            this.btnReadHoldingRegisters.Click += new System.EventHandler(this.btnReadHoldingRegisters_Click);
            // 
            // btnReadInputRegisaters
            // 
            this.btnReadInputRegisaters.Location = new System.Drawing.Point(1, 163);
            this.btnReadInputRegisaters.Name = "btnReadInputRegisaters";
            this.btnReadInputRegisaters.Size = new System.Drawing.Size(171, 23);
            this.btnReadInputRegisaters.TabIndex = 10;
            this.btnReadInputRegisaters.Text = "Read Input Registers-FC4";
            this.btnReadInputRegisaters.UseVisualStyleBackColor = true;
            this.btnReadInputRegisaters.Click += new System.EventHandler(this.btnReadInputRegisaters_Click);
            // 
            // btnWriteSingleCoil
            // 
            this.btnWriteSingleCoil.Location = new System.Drawing.Point(1, 229);
            this.btnWriteSingleCoil.Name = "btnWriteSingleCoil";
            this.btnWriteSingleCoil.Size = new System.Drawing.Size(171, 23);
            this.btnWriteSingleCoil.TabIndex = 11;
            this.btnWriteSingleCoil.Text = "Write Single Coil-FC5";
            this.btnWriteSingleCoil.UseVisualStyleBackColor = true;
            this.btnWriteSingleCoil.Click += new System.EventHandler(this.btnWriteSingleCoil_Click);
            // 
            // btnWriteSingleRegister
            // 
            this.btnWriteSingleRegister.Location = new System.Drawing.Point(1, 258);
            this.btnWriteSingleRegister.Name = "btnWriteSingleRegister";
            this.btnWriteSingleRegister.Size = new System.Drawing.Size(171, 23);
            this.btnWriteSingleRegister.TabIndex = 12;
            this.btnWriteSingleRegister.Text = "Write Single Register-FC6";
            this.btnWriteSingleRegister.UseVisualStyleBackColor = true;
            this.btnWriteSingleRegister.Click += new System.EventHandler(this.btnWriteSingleRegister_Click);
            // 
            // btnWriteMultipleCoils
            // 
            this.btnWriteMultipleCoils.Location = new System.Drawing.Point(1, 287);
            this.btnWriteMultipleCoils.Name = "btnWriteMultipleCoils";
            this.btnWriteMultipleCoils.Size = new System.Drawing.Size(171, 23);
            this.btnWriteMultipleCoils.TabIndex = 13;
            this.btnWriteMultipleCoils.Text = "Write Multiple Coils-FC7";
            this.btnWriteMultipleCoils.UseVisualStyleBackColor = true;
            this.btnWriteMultipleCoils.Click += new System.EventHandler(this.btnWriteMultipleCoils_Click);
            // 
            // btnWriteMultipleRegisters
            // 
            this.btnWriteMultipleRegisters.Location = new System.Drawing.Point(1, 316);
            this.btnWriteMultipleRegisters.Name = "btnWriteMultipleRegisters";
            this.btnWriteMultipleRegisters.Size = new System.Drawing.Size(171, 23);
            this.btnWriteMultipleRegisters.TabIndex = 14;
            this.btnWriteMultipleRegisters.Text = "Write Multiple Registers-FC16";
            this.btnWriteMultipleRegisters.UseVisualStyleBackColor = true;
            this.btnWriteMultipleRegisters.Click += new System.EventHandler(this.btnWriteMultipleRegisters_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Read Value From Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Write Value To server";
            // 
            // btnClearEntry
            // 
            this.btnClearEntry.Location = new System.Drawing.Point(651, 213);
            this.btnClearEntry.Name = "btnClearEntry";
            this.btnClearEntry.Size = new System.Drawing.Size(75, 38);
            this.btnClearEntry.TabIndex = 17;
            this.btnClearEntry.Text = "Clear Entry";
            this.btnClearEntry.UseVisualStyleBackColor = true;
            this.btnClearEntry.Click += new System.EventHandler(this.btnClearEntry_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(776, 213);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 38);
            this.btnClearAll.TabIndex = 18;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnPrepareCoils
            // 
            this.btnPrepareCoils.Location = new System.Drawing.Point(651, 295);
            this.btnPrepareCoils.Name = "btnPrepareCoils";
            this.btnPrepareCoils.Size = new System.Drawing.Size(83, 23);
            this.btnPrepareCoils.TabIndex = 19;
            this.btnPrepareCoils.Text = "Prepare Coils";
            this.btnPrepareCoils.UseVisualStyleBackColor = true;
            this.btnPrepareCoils.Click += new System.EventHandler(this.btnPrepareCoils_Click);
            // 
            // lstReadDataFromServer
            // 
            this.lstReadDataFromServer.FormattingEnabled = true;
            this.lstReadDataFromServer.Location = new System.Drawing.Point(208, 50);
            this.lstReadDataFromServer.Name = "lstReadDataFromServer";
            this.lstReadDataFromServer.Size = new System.Drawing.Size(225, 134);
            this.lstReadDataFromServer.TabIndex = 20;
            // 
            // lstWriteDataToServer
            // 
            this.lstWriteDataToServer.FormattingEnabled = true;
            this.lstWriteDataToServer.Location = new System.Drawing.Point(208, 213);
            this.lstWriteDataToServer.Name = "lstWriteDataToServer";
            this.lstWriteDataToServer.Size = new System.Drawing.Size(225, 121);
            this.lstWriteDataToServer.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(740, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Prepare Registers";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPrepareCoils
            // 
            this.txtPrepareCoils.Location = new System.Drawing.Point(651, 261);
            this.txtPrepareCoils.Name = "txtPrepareCoils";
            this.txtPrepareCoils.Size = new System.Drawing.Size(83, 20);
            this.txtPrepareCoils.TabIndex = 23;
            this.txtPrepareCoils.Text = "TRUE";
            // 
            // txtPrepareRegisters
            // 
            this.txtPrepareRegisters.Location = new System.Drawing.Point(768, 261);
            this.txtPrepareRegisters.Name = "txtPrepareRegisters";
            this.txtPrepareRegisters.Size = new System.Drawing.Size(83, 20);
            this.txtPrepareRegisters.TabIndex = 24;
            this.txtPrepareRegisters.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(457, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Start Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Size";
            // 
            // txtStartAddress
            // 
            this.txtStartAddress.Location = new System.Drawing.Point(535, 82);
            this.txtStartAddress.Name = "txtStartAddress";
            this.txtStartAddress.Size = new System.Drawing.Size(100, 20);
            this.txtStartAddress.TabIndex = 27;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(535, 136);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(100, 20);
            this.txtSize.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(462, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Start Address";
            // 
            // txtStartAddress1
            // 
            this.txtStartAddress1.Location = new System.Drawing.Point(463, 256);
            this.txtStartAddress1.Name = "txtStartAddress1";
            this.txtStartAddress1.Size = new System.Drawing.Size(89, 20);
            this.txtStartAddress1.TabIndex = 30;
            // 
            // dataRichTextBox
            // 
            this.dataRichTextBox.Location = new System.Drawing.Point(1, 340);
            this.dataRichTextBox.Name = "dataRichTextBox";
            this.dataRichTextBox.Size = new System.Drawing.Size(839, 163);
            this.dataRichTextBox.TabIndex = 31;
            this.dataRichTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 531);
            this.Controls.Add(this.dataRichTextBox);
            this.Controls.Add(this.txtStartAddress1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtStartAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrepareRegisters);
            this.Controls.Add(this.txtPrepareCoils);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lstWriteDataToServer);
            this.Controls.Add(this.lstReadDataFromServer);
            this.Controls.Add(this.btnPrepareCoils);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnClearEntry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnWriteMultipleRegisters);
            this.Controls.Add(this.btnWriteMultipleCoils);
            this.Controls.Add(this.btnWriteSingleRegister);
            this.Controls.Add(this.btnWriteSingleCoil);
            this.Controls.Add(this.btnReadInputRegisaters);
            this.Controls.Add(this.btnReadHoldingRegisters);
            this.Controls.Add(this.btnReadDiscreateInputs);
            this.Controls.Add(this.btnReadCoils);
            this.Controls.Add(this.txtCheckConnect);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "TCPModbusMasterExample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtCheckConnect;
        private System.Windows.Forms.Button btnReadCoils;
        private System.Windows.Forms.Button btnReadDiscreateInputs;
        private System.Windows.Forms.Button btnReadHoldingRegisters;
        private System.Windows.Forms.Button btnReadInputRegisaters;
        private System.Windows.Forms.Button btnWriteSingleCoil;
        private System.Windows.Forms.Button btnWriteSingleRegister;
        private System.Windows.Forms.Button btnWriteMultipleCoils;
        private System.Windows.Forms.Button btnWriteMultipleRegisters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearEntry;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnPrepareCoils;
        private System.Windows.Forms.ListBox lstReadDataFromServer;
        private System.Windows.Forms.ListBox lstWriteDataToServer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPrepareCoils;
        private System.Windows.Forms.TextBox txtPrepareRegisters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStartAddress;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStartAddress1;
        private System.Windows.Forms.RichTextBox dataRichTextBox;
    }
}

