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

            foreach (Control ctrl in window.Controls)
            {
                if (ctrl is Button && !ctrl.Text.Equals("Exit"))
                {
                    ctrl.ForeColor = isDarkMode ? Color.Black : Color.White;
                    ctrl.BackColor = isDarkMode ? Color.White : Color.DarkSlateGray;
                }
                if (ctrl is TextBox)
                {
                    ctrl.ForeColor = isDarkMode ? Color.Black : Color.White;
                    ctrl.BackColor = isDarkMode ? Color.White : Color.Black;
                }
                if (ctrl is GroupBox)
                {
                    ctrl.ForeColor = isDarkMode ? Color.Black : Color.White;
                    ctrl.BackColor = isDarkMode ? Color.White : Color.Black;

                    var grpButtons = ctrl.Controls;
                    foreach (Control grpCtrl in grpButtons)
                    {
                        if (grpCtrl is Button)
                        {
                            grpCtrl.ForeColor = isDarkMode ? Color.Black : Color.White;
                            grpCtrl.BackColor = isDarkMode ? Color.White : Color.DarkSlateGray;
                        }
                        if (grpCtrl is ComboBox)
                        {
                            grpCtrl.ForeColor = isDarkMode ? Color.Black : Color.White;
                            grpCtrl.BackColor = isDarkMode ? Color.White : Color.Black;
                        }
                        if (grpCtrl is CheckBox)
                        {
                            grpCtrl.ForeColor = isDarkMode ? Color.Black : Color.White;
                            grpCtrl.BackColor = isDarkMode ? Color.White : Color.Black;
                        }
                        if (grpCtrl is TextBox)
                        {
                            grpCtrl.ForeColor = isDarkMode ? Color.Black : Color.White;
                            grpCtrl.BackColor = isDarkMode ? Color.White : Color.Black;
                        }
                        if (grpCtrl is Label)
                        {
                            grpCtrl.ForeColor = isDarkMode ? Color.Black : Color.White;
                            grpCtrl.BackColor = isDarkMode ? Color.White : Color.Black;
                        }
                    }
                }
            }
        }
    }
}
