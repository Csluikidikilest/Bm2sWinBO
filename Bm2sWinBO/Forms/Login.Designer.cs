namespace Bm2sWinBO.Forms
{
  partial class Login
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
      this.btnConnection = new System.Windows.Forms.Button();
      this.lblLogin = new System.Windows.Forms.Label();
      this.lblPassword = new System.Windows.Forms.Label();
      this.txtLogin = new System.Windows.Forms.TextBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnConnection
      // 
      this.btnConnection.Location = new System.Drawing.Point(491, 99);
      this.btnConnection.Name = "btnConnection";
      this.btnConnection.Size = new System.Drawing.Size(137, 23);
      this.btnConnection.TabIndex = 0;
      this.btnConnection.Text = "Connection";
      this.btnConnection.UseVisualStyleBackColor = true;
      this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
      // 
      // lblLogin
      // 
      this.lblLogin.AutoSize = true;
      this.lblLogin.Location = new System.Drawing.Point(12, 15);
      this.lblLogin.Name = "lblLogin";
      this.lblLogin.Size = new System.Drawing.Size(33, 13);
      this.lblLogin.TabIndex = 1;
      this.lblLogin.Text = "Login";
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.Location = new System.Drawing.Point(12, 52);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(53, 13);
      this.lblPassword.TabIndex = 2;
      this.lblPassword.Text = "Password";
      // 
      // txtLogin
      // 
      this.txtLogin.Location = new System.Drawing.Point(91, 12);
      this.txtLogin.Name = "txtLogin";
      this.txtLogin.Size = new System.Drawing.Size(537, 20);
      this.txtLogin.TabIndex = 3;
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(91, 49);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(537, 20);
      this.txtPassword.TabIndex = 4;
      // 
      // Login
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(640, 134);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.txtLogin);
      this.Controls.Add(this.lblPassword);
      this.Controls.Add(this.lblLogin);
      this.Controls.Add(this.btnConnection);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.Name = "Login";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Login";
      this.TopMost = true;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnConnection;
    private System.Windows.Forms.Label lblLogin;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtLogin;
    private System.Windows.Forms.TextBox txtPassword;
  }
}