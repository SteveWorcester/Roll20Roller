using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll20Roller.Managers
{
    public static class ViewManager
    {
        public static void ToggleDarkMode(Form window)
        {
            var isDarkMode = window.BackColor.Equals(Color.Black);

            window.ForeColor = isDarkMode ? Color.Black : Color.White;
            window.BackColor = isDarkMode ? Color.White : Color.Black;

            var btnForeColor = isDarkMode ? Color.Black : Color.White;
            var btnBackColor = isDarkMode ? Color.White : Color.DarkSlateGray;

            var txtForeColor = isDarkMode ? Color.Black : Color.White;
            var txtBackColor = isDarkMode ? Color.White : Color.Black;

            var grpForeColor = isDarkMode ? Color.Black : Color.White;
            var grpBackColor = isDarkMode ? Color.White : Color.Black;

            var cbForeColor = isDarkMode ? Color.Black : Color.White;
            var cbBackColor = isDarkMode ? Color.White : Color.Black;

            var lblForeColor = isDarkMode ? Color.Black : Color.White;
            var lblBackColor = isDarkMode ? Color.White : Color.Black;

            var ddlForeColor = isDarkMode ? Color.Black : Color.White;
            var ddlBackColor = isDarkMode ? Color.White : Color.Black;

            foreach (Control ctrl in window.Controls)
            {
                if (ctrl is Button && !ctrl.Text.Equals("Exit"))
                {
                    ctrl.ForeColor = btnForeColor;
                    ctrl.BackColor = btnBackColor;
                }
                if (ctrl is TextBox)
                {
                    ctrl.ForeColor = txtForeColor;
                    ctrl.BackColor = txtBackColor;
                }
                if (ctrl is GroupBox)
                {
                    ctrl.ForeColor = grpForeColor;
                    ctrl.BackColor = grpBackColor;

                    foreach (Control grpCtrl in ctrl.Controls)
                    {
                        if (grpCtrl is Button)
                        {
                            grpCtrl.ForeColor = btnForeColor;
                            grpCtrl.BackColor = btnBackColor;
                        }
                        if (grpCtrl is ComboBox)
                        {
                            grpCtrl.ForeColor = ddlForeColor;
                            grpCtrl.BackColor = ddlBackColor;
                        }
                        if (grpCtrl is CheckBox)
                        {
                            grpCtrl.ForeColor = cbForeColor;
                            grpCtrl.BackColor = cbBackColor;
                        }
                        if (grpCtrl is TextBox)
                        {
                            grpCtrl.ForeColor = txtForeColor;
                            grpCtrl.BackColor = txtBackColor;
                        }
                        if (grpCtrl is Label)
                        {
                            grpCtrl.ForeColor = lblForeColor;
                            grpCtrl.BackColor = lblBackColor;
                        }
                    }
                }
            }
        }
    }
}
