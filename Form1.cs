﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Life_WinForms
{
    public partial class Form1 : Form
    {
        private static Label[,] labe;
        private const int x = 20;
        private const int y = 30;
        private static double span = 0.5;
        private Thread temp;
        public Form1()
        {
            InitializeComponent();
            labe = new Label[x, y];
            Random rnd = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    labe[i, j] = new Label();
                    labe[i, j].AutoSize = false;
                    labe[i, j].Size = new Size(30, 30);
                    labe[i, j].BorderStyle = BorderStyle.FixedSingle;
                    labe[i, j].Location = new Point(j * 30 + 10, i * 30 + 10);
                    labe[i, j].Name = rnd.Next(0, 2).ToString();
                    if (labe[i, j].Name == "0")
                    {
                        labe[i, j].BackColor = Color.LightSkyBlue;
                    }
                    else if (labe[i, j].Name == "1")
                    {
                        labe[i, j].BackColor = Color.Black;
                    }
                    Controls.Add(labe[i, j]);
                }
            }
            temp = new Thread(Life);
            temp.Start();
        }

        private static void Life()
        {
            while (true)
            {
                Death();
                Birthday();
                Thread.Sleep(Convert.ToInt32(1000 * span));
            }
        }

        private static void Birthday()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    int temp = 0;
                    if (i - 1 >= 0)
                        if (labe[i - 1, j].Name == "1")
                            temp++;
                    if (i + 1 < x)
                        if (labe[i + 1, j].Name == "1")
                            temp++;
                    if (j - 1 >= 0)
                        if (labe[i, j - 1].Name == "1")
                            temp++;
                    if (j + 1 < y)
                        if (labe[i, j + 1].Name == "1")
                            temp++;
                    if (i - 1 >= 0 && j - 1 >= 0)
                        if (labe[i - 1, j - 1].Name == "1")
                            temp++;
                    if (i - 1 >= 0 && j + 1 < y)
                        if (labe[i - 1, j + 1].Name == "1")
                            temp++;
                    if (i + 1 < x && j - 1 >= 0)
                        if (labe[i + 1, j - 1].Name == "1")
                            temp++;
                    if (i + 1 < x && j + 1 < y)
                        if (labe[i + 1, j + 1].Name == "1")
                            temp++;

                    if (temp == 3 && labe[i, j].Name == "0")
                    {
                        labe[i, j].Name = "1";
                        labe[i, j].BackColor = Color.Black;
                    }
                }
            }
        }

        private static void Death()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    int temp = 0;
                    if (i - 1 >= 0)
                        if (labe[i - 1, j].Name == "1")
                            temp++;
                    if (i + 1 < x)
                        if (labe[i + 1, j].Name == "1")
                            temp++;
                    if (j - 1 >= 0)
                        if (labe[i, j - 1].Name == "1")
                            temp++;
                    if (j + 1 < y)
                        if (labe[i, j + 1].Name == "1")
                            temp++;
                    if (i - 1 >= 0 && j - 1 >= 0)
                        if (labe[i - 1, j - 1].Name == "1")
                            temp++;
                    if (i - 1 >= 0 && j + 1 < y)
                        if (labe[i - 1, j + 1].Name == "1")
                            temp++;
                    if (i + 1 < x && j - 1 >= 0)
                        if (labe[i + 1, j - 1].Name == "1")
                            temp++;
                    if (i + 1 < x && j + 1 < y)
                        if (labe[i + 1, j + 1].Name == "1")
                            temp++;

                    if ((temp > 3 || temp < 2) && labe[i, j].Name == "1")
                    {
                        labe[i, j].Name = "0";
                        labe[i, j].BackColor = Color.LightSkyBlue;
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            temp.Abort();
        }
    }
}
