using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace winformTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Resize
            var rectangle = ScreenRectangle();
            Size = new Size(rectangle.Width, rectangle.Height);
            Location = new Point(0, 0);
        }

        public Rectangle ScreenRectangle()
        {
            return Screen.FromControl(this).Bounds;
        }
    }
}
