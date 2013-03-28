using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SampleQuery();
        }

        public void SampleQuery()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            //var all = from a in dc.GetTable<Table_2>() select a;

            dataGridView1.DataSource = dc.GetTable<Table_2>();
        }
    }
}
