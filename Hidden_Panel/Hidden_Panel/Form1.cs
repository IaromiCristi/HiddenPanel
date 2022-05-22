using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hidden_Panel
{
    public partial class Form1 : Form
    {
        private Button[,] B;
        private int[,] A;
        private Form1 f1;
        private Form2 f2 = new Form2();

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            f1 = this;
            f2.Show();
            B = new Button[8, 8];
            A = new int[8, 8];
            tableGeneration(8, 8, 21);
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    B[i, j] = new Button();
                    f2.Controls.Add(B[i, j]);
                    B[i, j].Height = 50;
                    B[i, j].Width = 50;
                    B[i, j].BackColor = SystemColors.Control;
                    if (i == 0)
                        B[i, j].Top = 4;
                    else B[i, j].Top = B[i - 1, j].Bottom;
                    if (j == 0)
                        B[i, j].Left = 4;
                    else B[i, j].Left = B[i, j - 1].Right;
                    buttonText(i, j, 8, 8);
                    B[i, j].Click += new EventHandler(Click_Button_Easy);
                }
            f2.Height = 450;
            f2.Width = 430;
            f2.FormClosing += new FormClosingEventHandler(Form2_Closing);
        }

        void tableGeneration(int n, int m, int rand)
        {
            Random r = new Random();
            int nr = 0;
            for (int i = 0; i < rand; i++)
            {
                int l = r.Next(0, n), c = r.Next(0, m);
                if (A[l, c] != -1)
                    A[l, c] = -1;
                else i--;
                nr++;
            }
        }

        void buttonText(int i, int j, int n, int m)
        {
            int nr = 0;
            if (i == 0)
            {
                if (j == 0)
                {
                    if (A[i + 1, j] == -1) nr++;
                    if (A[i + 1, j + 1] == -1) nr++;
                    if (A[i, j + 1] == -1) nr++;
                    B[i, j].Text = Convert.ToString(3 - nr);
                }
                else
                if (j == m - 1)
                {
                    if (A[i + 1, j] == -1) nr++;
                    if (A[i + 1, j - 1] == -1) nr++;
                    if (A[i, j - 1] == -1) nr++;
                    B[i, j].Text = Convert.ToString(3 - nr);
                }
                else
                {
                    if (A[i, j - 1] == -1) nr++;
                    if (A[i + 1, j - 1] == -1) nr++;
                    if (A[i + 1, j] == -1) nr++;
                    if (A[i + 1, j + 1] == -1) nr++;
                    if (A[i, j + 1] == -1) nr++;
                    B[i, j].Text = Convert.ToString(5 - nr);
                }
            }
            else
            if (i == n - 1)
            {
                if (j == 0)
                {
                    if (A[i - 1, j] == -1) nr++;
                    if (A[i - 1, j + 1] == -1) nr++;
                    if (A[i, j + 1] == -1) nr++;
                    B[i, j].Text = Convert.ToString(3 - nr);
                }
                else
                if (j == m - 1)
                {
                    if (A[i - 1, j] == -1) nr++;
                    if (A[i - 1, j - 1] == -1) nr++;
                    if (A[i, j - 1] == -1) nr++;
                    B[i, j].Text = Convert.ToString(3 - nr);
                }
                else
                {
                    if (A[i, j - 1] == -1) nr++;
                    if (A[i - 1, j - 1] == -1) nr++;
                    if (A[i - 1, j] == -1) nr++;
                    if (A[i - 1, j + 1] == -1) nr++;
                    if (A[i, j + 1] == -1) nr++;
                    B[i, j].Text = Convert.ToString(5 - nr);
                }
            }
            else
            {
                if (j == 0)
                {
                    if (A[i - 1, j] == -1) nr++;
                    if (A[i - 1, j + 1] == -1) nr++;
                    if (A[i, j + 1] == -1) nr++;
                    if (A[i + 1, j + 1] == -1) nr++;
                    if (A[i + 1, j] == -1) nr++;
                    B[i, j].Text = Convert.ToString(5 - nr);
                }
                else
                if (j == m - 1)
                {
                    if (A[i - 1, j] == -1) nr++;
                    if (A[i - 1, j - 1] == -1) nr++;
                    if (A[i, j - 1] == -1) nr++;
                    if (A[i + 1, j - 1] == -1) nr++;
                    if (A[i + 1, j] == -1) nr++;
                    B[i, j].Text = Convert.ToString(5 - nr);
                }
                else
                {
                    if (A[i, j - 1] == -1) nr++;
                    if (A[i - 1, j - 1] == -1) nr++;
                    if (A[i - 1, j] == -1) nr++;
                    if (A[i - 1, j + 1] == -1) nr++;
                    if (A[i, j + 1] == -1) nr++;
                    if (A[i + 1, j + 1] == -1) nr++;
                    if (A[i + 1, j] == -1) nr++;
                    if (A[i + 1, j - 1] == -1) nr++;
                    B[i, j].Text = Convert.ToString(8 - nr);
                }
            }
        }

        private void Click_Button_Easy(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (sender == B[i, j])
                        markButton(i, j, 8, 8);
        }

        void Form2_Closing(object sender,EventArgs e)
        {
            f1.Visible = true;
            f2 = new Form2();
        }

        void markButton(int i, int j, int n, int m)
        {
            if (A[i, j] == -1)
            {
                this.gameOver(n, m);
                MessageBox.Show("Game over!");
                System.Threading.Thread.Sleep(2000);
                f2.Close();
            }
            else
            {
                B[i, j].BackColor = Color.Green;
                B[i, j].Enabled = false;
                if (this.isWinning(n, m))
                {
                    MessageBox.Show("Well done!");
                    System.Threading.Thread.Sleep(2000);
                    f2.Close();
                }
                else this.markBombs(n, m);
            }
        }

        void gameOver(int n, int m)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (A[i, j] == -1)
                    {
                        B[i, j].BackColor = Color.Red;
                        B[i, j].Refresh();
                    }
        }

        bool isWinning(int n,int m)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (B[i, j].BackColor == SystemColors.Control)
                        return false;
            return true;
        }

        void markBombs(int n,int m)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    int nr = 0;
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            if (B[i + 1, j].BackColor == Color.Green) nr++;
                            if (B[i + 1, j + 1].BackColor == Color.Green) nr++;
                            if (B[i, j + 1].BackColor == Color.Green) nr++;
                            if (nr == int.Parse(B[i, j].Text) && int.Parse(B[i, j].Text) != 0)
                            {
                                if (B[i + 1, j].BackColor != Color.Green) { B[i + 1, j].BackColor = Color.Red; B[i + 1, j].Enabled = false; }
                                if (B[i + 1, j + 1].BackColor != Color.Green) { B[i + 1, j + 1].BackColor = Color.Red; B[i + 1, j + 1].Enabled = false; }
                                if (B[i, j + 1].BackColor != Color.Green) { B[i, j + 1].BackColor = Color.Red; B[i, j + 1].Enabled = false; }
                            }
                        }
                        else
                        if (j == m - 1)
                        {
                            if (B[i + 1, j].BackColor == Color.Green) nr++;
                            if (B[i + 1, j - 1].BackColor == Color.Green) nr++;
                            if (B[i, j - 1].BackColor == Color.Green) nr++;
                            if (nr == int.Parse(B[i, j].Text) && int.Parse(B[i, j].Text) != 0)
                            {
                                if (B[i + 1, j].BackColor != Color.Green) { B[i + 1, j].BackColor = Color.Red; B[i + 1, j].Enabled = false; }
                                if (B[i + 1, j - 1].BackColor != Color.Green) { B[i + 1, j - 1].BackColor = Color.Red; B[i + 1, j - 1].Enabled = false; }
                                if (B[i, j - 1].BackColor != Color.Green) { B[i, j - 1].BackColor = Color.Red; B[i, j - 1].Enabled = false; }
                            }
                        }
                        else
                        {
                            if (B[i, j - 1].BackColor == Color.Green) nr++;
                            if (B[i + 1, j - 1].BackColor == Color.Green) nr++;
                            if (B[i + 1, j].BackColor == Color.Green) nr++;
                            if (B[i + 1, j + 1].BackColor == Color.Green) nr++;
                            if (B[i, j + 1].BackColor == Color.Green) nr++;
                            if (nr == int.Parse(B[i, j].Text) && int.Parse(B[i, j].Text) != 0)
                            {
                                if (B[i, j - 1].BackColor != Color.Green) { B[i, j - 1].BackColor = Color.Red; B[i, j - 1].Enabled = false; }
                                if (B[i + 1, j - 1].BackColor != Color.Green) { B[i + 1, j - 1].BackColor = Color.Red; B[i + 1, j - 1].Enabled = false; }
                                if (B[i + 1, j].BackColor != Color.Green) { B[i + 1, j].BackColor = Color.Red; B[i + 1, j].Enabled = false; }
                                if (B[i + 1, j + 1].BackColor != Color.Green) { B[i + 1, j + 1].BackColor = Color.Red; B[i + 1, j + 1].Enabled = false; }
                                if (B[i, j + 1].BackColor != Color.Green) { B[i, j + 1].BackColor = Color.Red; B[i, j + 1].Enabled = false; }
                            }
                        }
                    }
                    else
                    if (i == n - 1)
                    {
                        if (j == 0)
                        {
                            if (B[i - 1, j].BackColor == Color.Green) nr++;
                            if (B[i - 1, j + 1].BackColor == Color.Green) nr++;
                            if (B[i, j + 1].BackColor == Color.Green) nr++;
                            if (nr == int.Parse(B[i, j].Text) && int.Parse(B[i, j].Text) != 0)
                            {
                                if (B[i - 1, j].BackColor != Color.Green) { B[i - 1, j].BackColor = Color.Red; B[i - 1, j].Enabled = false; }
                                if (B[i - 1, j + 1].BackColor != Color.Green) { B[i - 1, j + 1].BackColor = Color.Red; B[i - 1, j + 1].Enabled = false; }
                                if (B[i, j + 1].BackColor != Color.Green) { B[i, j + 1].BackColor = Color.Red; B[i, j + 1].Enabled = false; }
                            }
                        }
                        else
                        if (j == m - 1)
                        {
                            if (B[i - 1, j].BackColor == Color.Green) nr++;
                            if (B[i - 1, j - 1].BackColor == Color.Green) nr++;
                            if (B[i, j - 1].BackColor == Color.Green) nr++;
                            if (nr == int.Parse(B[i, j].Text) && int.Parse(B[i, j].Text) != 0)
                            {
                                if (B[i - 1, j].BackColor != Color.Green) { B[i - 1, j].BackColor = Color.Red; B[i - 1, j].Enabled = false; }
                                if (B[i - 1, j - 1].BackColor != Color.Green) { B[i - 1, j - 1].BackColor = Color.Red; B[i - 1, j - 1].Enabled = false; }
                                if (B[i, j - 1].BackColor != Color.Green) { B[i, j - 1].BackColor = Color.Red; B[i, j - 1].Enabled = false; }
                            }
                        }
                        else
                        {
                            if (B[i, j - 1].BackColor == Color.Green) nr++;
                            if (B[i - 1, j - 1].BackColor == Color.Green) nr++;
                            if (B[i - 1, j].BackColor == Color.Green) nr++;
                            if (B[i - 1, j + 1].BackColor == Color.Green) nr++;
                            if (B[i, j + 1].BackColor == Color.Green) nr++;
                            if (nr == int.Parse(B[i, j].Text) && int.Parse(B[i, j].Text) != 0)
                            {
                                if (B[i, j - 1].BackColor != Color.Green) { B[i, j - 1].BackColor = Color.Red; B[i, j - 1].Enabled = false; }
                                if (B[i - 1, j - 1].BackColor != Color.Green) { B[i - 1, j - 1].BackColor = Color.Red; B[i - 1, j - 1].Enabled = false; }
                                if (B[i - 1, j].BackColor != Color.Green) { B[i - 1, j].BackColor = Color.Red; B[i - 1, j].Enabled = false; }
                                if (B[i - 1, j + 1].BackColor != Color.Green) { B[i - 1, j + 1].BackColor = Color.Red; B[i - 1, j + 1].Enabled = false; }
                                if (B[i , j + 1].BackColor != Color.Green) { B[i, j + 1].BackColor = Color.Red; B[i, j + 1].Enabled = false; }
                            }
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            if (B[i - 1, j].BackColor == Color.Green) nr++;
                            if (B[i - 1, j + 1].BackColor == Color.Green) nr++;
                            if (B[i, j + 1].BackColor == Color.Green) nr++;
                            if (B[i + 1, j + 1].BackColor == Color.Green) nr++;
                            if (B[i + 1, j].BackColor == Color.Green) nr++;
                            if (nr == int.Parse(B[i, j].Text) && int.Parse(B[i, j].Text) != 0)
                            {
                                if (B[i - 1, j].BackColor != Color.Green) { B[i - 1, j].BackColor = Color.Red; B[i - 1, j].Enabled = false; }
                                if (B[i - 1, j + 1].BackColor != Color.Green) { B[i - 1, j + 1].BackColor = Color.Red; B[i - 1, j + 1].Enabled = false; }
                                if (B[i, j + 1].BackColor != Color.Green) { B[i, j + 1].BackColor = Color.Red; B[i, j + 1].Enabled = false; }
                                if (B[i + 1, j + 1].BackColor != Color.Green) { B[i + 1, j + 1].BackColor = Color.Red; B[i + 1, j + 1].Enabled = false; }
                                if (B[i + 1, j].BackColor != Color.Green) { B[i + 1, j].BackColor = Color.Red; B[i + 1, j].Enabled = false; }
                            }
                        }
                        else
                        if (j == m - 1)
                        {
                            if (B[i - 1, j].BackColor == Color.Green) nr++;
                            if (B[i - 1, j - 1].BackColor == Color.Green) nr++;
                            if (B[i, j - 1].BackColor == Color.Green) nr++;
                            if (B[i + 1, j - 1].BackColor == Color.Green) nr++;
                            if (B[i + 1, j].BackColor == Color.Green) nr++;
                            if (nr == int.Parse(B[i, j].Text) && int.Parse(B[i, j].Text) != 0)
                            {
                                if (B[i - 1, j].BackColor != Color.Green) { B[i - 1, j].BackColor = Color.Red; B[i - 1, j].Enabled = false; }
                                if (B[i - 1, j - 1].BackColor != Color.Green) { B[i - 1, j - 1].BackColor = Color.Red; B[i - 1, j - 1].Enabled = false; }
                                if (B[i, j - 1].BackColor != Color.Green) { B[i, j - 1].BackColor = Color.Red; B[i, j - 1].Enabled = false; }
                                if (B[i + 1, j - 1].BackColor != Color.Green) { B[i + 1, j - 1].BackColor = Color.Red; B[i + 1, j - 1].Enabled = false; }
                                if (B[i + 1, j].BackColor != Color.Green) { B[i + 1, j].BackColor = Color.Red; B[i + 1, j].Enabled = false; }
                            }
                        }
                        else
                        {
                            if (B[i, j - 1].BackColor == Color.Green) nr++;
                            if (B[i - 1, j - 1].BackColor == Color.Green) nr++;
                            if (B[i - 1, j].BackColor == Color.Green) nr++;
                            if (B[i - 1, j + 1].BackColor == Color.Green) nr++;
                            if (B[i, j + 1].BackColor == Color.Green) nr++;
                            if (B[i + 1, j + 1].BackColor == Color.Green) nr++;
                            if (B[i + 1, j].BackColor == Color.Green) nr++;
                            if (B[i + 1, j - 1].BackColor == Color.Green) nr++;
                            if (nr == int.Parse(B[i, j].Text) && int.Parse(B[i, j].Text) != 0)
                            {
                                if (B[i, j - 1].BackColor != Color.Green) { B[i, j - 1].BackColor = Color.Red; B[i, j - 1].Enabled = false; }
                                if (B[i - 1, j - 1].BackColor != Color.Green) { B[i - 1, j - 1].BackColor = Color.Red; B[i - 1, j - 1].Enabled = false; }
                                if (B[i - 1, j].BackColor != Color.Green) { B[i - 1, j].BackColor = Color.Red; B[i - 1, j].Enabled = false; }
                                if (B[i - 1, j + 1].BackColor != Color.Green) { B[i - 1, j + 1].BackColor = Color.Red; B[i - 1, j + 1].Enabled = false; }
                                if (B[i, j + 1].BackColor != Color.Green) { B[i, j + 1].BackColor = Color.Red; B[i, j + 1].Enabled = false; }
                                if (B[i + 1, j + 1].BackColor != Color.Green) { B[i + 1, j + 1].BackColor = Color.Red; B[i + 1, j + 1].Enabled = false; }
                                if (B[i + 1, j].BackColor != Color.Green) { B[i + 1, j].BackColor = Color.Red; B[i + 1, j].Enabled = false; }
                                if (B[i + 1, j - 1].BackColor != Color.Green) { B[i + 1, j - 1].BackColor = Color.Red; B[i + 1, j - 1].Enabled = false; }
                            }
                        }
                    }
                }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            f1 = this;
            f2.Show();
            B = new Button[9, 8];
            A = new int[9, 8];
            this.tableGeneration(9, 8, 28);
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 8; j++)
                {
                    B[i, j] = new Button();
                    f2.Controls.Add(B[i, j]);
                    B[i, j].Height = 50;
                    B[i, j].Width = 50;
                    B[i, j].BackColor = SystemColors.Control;
                    if (i == 0)
                        B[i, j].Top = 4;
                    else B[i, j].Top = B[i - 1, j].Bottom;
                    if (j == 0)
                        B[i, j].Left = 4;
                    else B[i, j].Left = B[i, j - 1].Right;
                    this.buttonText(i, j, 9, 8);
                    B[i, j].Click += new EventHandler(Click_Button_Medium);
                }
            f2.Height = 500;
            f2.Width = 430;
            f2.FormClosing += new FormClosingEventHandler(Form2_Closing);
        }

        private void Click_Button_Medium(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 8; j++)
                    if (sender == B[i, j])
                        this.markButton(i, j, 9, 8);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            f1 = this;
            f2.Show();
            B = new Button[10, 9];
            A = new int[10, 9];
            this.tableGeneration(10, 9, 33);
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 9; j++)
                {
                    B[i, j] = new Button();
                    f2.Controls.Add(B[i, j]);
                    B[i, j].Height = 50;
                    B[i, j].Width = 50;
                    B[i, j].BackColor = SystemColors.Control;
                    if (i == 0)
                        B[i, j].Top = 4;
                    else B[i, j].Top = B[i - 1, j].Bottom;
                    if (j == 0)
                        B[i, j].Left = 4;
                    else B[i, j].Left = B[i, j - 1].Right;
                    this.buttonText(i, j, 10, 9);
                    B[i, j].Click += new EventHandler(Click_Button_Hard);
                }
            f2.Height = 550;
            f2.Width = 480;
            f2.FormClosing += new FormClosingEventHandler(Form2_Closing);
        }

        private void Click_Button_Hard(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 9; j++)
                    if (sender == B[i, j])
                        this.markButton(i, j, 10, 9);
        }
    }
}
