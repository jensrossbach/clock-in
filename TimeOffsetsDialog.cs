using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockIn
{
    public partial class TimeOffsetsDialog : Form
    {
        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public TimeOffsetsDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   Handles a click on the close button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
