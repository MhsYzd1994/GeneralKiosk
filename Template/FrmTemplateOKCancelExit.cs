using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using RasisSolutionsManagement.BALayer;

namespace RasisSolutionsManagement.GUI.Template
{
    public partial class FrmTemplateOKCancelExit : FrmTemplate
    {
        public FrmTemplateOKCancelExit()
        {
            InitializeComponent();
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
