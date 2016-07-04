namespace MainApp
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
            this.lstBoxEvent = new System.Windows.Forms.ListBox();
            this.lstBoxSub = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstBoxEvent
            // 
            this.lstBoxEvent.FormattingEnabled = true;
            this.lstBoxEvent.Location = new System.Drawing.Point(13, 13);
            this.lstBoxEvent.Name = "lstBoxEvent";
            this.lstBoxEvent.Size = new System.Drawing.Size(125, 225);
            this.lstBoxEvent.TabIndex = 0;
            // 
            // lstBoxSub
            // 
            this.lstBoxSub.FormattingEnabled = true;
            this.lstBoxSub.Location = new System.Drawing.Point(145, 13);
            this.lstBoxSub.Name = "lstBoxSub";
            this.lstBoxSub.Size = new System.Drawing.Size(137, 225);
            this.lstBoxSub.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(13, 285);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "SendMsg";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(289, 13);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(195, 225);
            this.txtMessage.TabIndex = 3;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(13, 255);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(125, 20);
            this.txtInput.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 470);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lstBoxSub);
            this.Controls.Add(this.lstBoxEvent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxEvent;
        private System.Windows.Forms.ListBox lstBoxSub;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtInput;
    }
}

