namespace HansihnBotForTwit
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.idText = new System.Windows.Forms.TextBox();
            this.id_label = new System.Windows.Forms.Label();
            this.pass_label = new System.Windows.Forms.Label();
            this.passText = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.Appstatus = new System.Windows.Forms.StatusStrip();
            this.statuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.Appstatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // idText
            // 
            this.idText.Location = new System.Drawing.Point(33, 46);
            this.idText.Name = "idText";
            this.idText.Size = new System.Drawing.Size(239, 19);
            this.idText.TabIndex = 0;
            // 
            // id_label
            // 
            this.id_label.AutoSize = true;
            this.id_label.Location = new System.Drawing.Point(11, 49);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(16, 12);
            this.id_label.TabIndex = 1;
            this.id_label.Text = "ID";
            // 
            // pass_label
            // 
            this.pass_label.AutoSize = true;
            this.pass_label.Location = new System.Drawing.Point(3, 77);
            this.pass_label.Name = "pass_label";
            this.pass_label.Size = new System.Drawing.Size(30, 12);
            this.pass_label.TabIndex = 3;
            this.pass_label.Text = "Pass";
            // 
            // passText
            // 
            this.passText.Location = new System.Drawing.Point(33, 74);
            this.passText.Name = "passText";
            this.passText.PasswordChar = '*';
            this.passText.Size = new System.Drawing.Size(239, 19);
            this.passText.TabIndex = 4;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(33, 99);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(239, 47);
            this.submit.TabIndex = 5;
            this.submit.Text = "Twitterへ接続";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // Appstatus
            // 
            this.Appstatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuslabel});
            this.Appstatus.Location = new System.Drawing.Point(0, 422);
            this.Appstatus.Name = "Appstatus";
            this.Appstatus.Size = new System.Drawing.Size(627, 22);
            this.Appstatus.TabIndex = 6;
            // 
            // statuslabel
            // 
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Browser
            // 
            this.Browser.Location = new System.Drawing.Point(278, 41);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(337, 378);
            this.Browser.TabIndex = 7;
            this.Browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.Browser_DocumentCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "HakaseDiceBot for Twitter";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 444);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Appstatus);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.pass_label);
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.idText);
            this.Controls.Add(this.Browser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Appstatus.ResumeLayout(false);
            this.Appstatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idText;
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.Label pass_label;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.StatusStrip Appstatus;
        private System.Windows.Forms.WebBrowser Browser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel statuslabel;
    }
}

