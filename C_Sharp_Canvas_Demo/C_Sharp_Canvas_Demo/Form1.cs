using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C_Sharp_Canvas_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataClasses1DataContext db = new DataClasses1DataContext();
        }


    }
}