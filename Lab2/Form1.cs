﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiguresLab
{
    public partial class Form1 : Form
    {
        int x1, y1;
        Graphics graphic;
        public Form1()
        {
            InitializeComponent();
            graphic = CreateGraphics();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            Cursor = Cursors.Cross;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Modules.FigureCollection figcol = new Modules.FigureCollection(x1, y1, e.X, e.Y, graphic);

            foreach (Modules.Figure element in figcol.figures)
            {
                if ((figcol.figures.IndexOf(element)) == comboBox1.SelectedIndex)
                {
                    figcol.figures[comboBox1.SelectedIndex].DrawFigure();
                }
            }
            Cursor = Cursors.Default;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.Azure);
        }
    }
}
