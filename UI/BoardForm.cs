using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using UI;

namespace UI
{
    public partial class BoardForm : Form
    {
        public BoardForm(int i_NumCols, int i_NumRows)
        {
            InitializeComponent();
            generateButtonMatrix(i_NumCols, i_NumRows);
        }



        private void Board_Load(object sender, EventArgs e)
        {

        }

        private void buttons_Click(object sender, EventArgs e)
        {

        }

        private void BoardForm_Load(object sender, EventArgs e)
        {

        }
    }
}