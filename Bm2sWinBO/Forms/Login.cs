using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bm2sWinBO.Utils;

namespace Bm2sWinBO.Forms
{
  public partial class Login : Form
  {
    public Login()
    {
      InitializeComponent();
      TranslationUtils.Translate(this);
    }

    private void btnConnection_Click(object sender, EventArgs e)
    {
      UserUtils.OpenSession(this.txtLogin.Text, this.txtPassword.Text);
    }
  }
}
