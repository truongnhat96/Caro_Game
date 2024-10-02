using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Co_Caro
{
    public partial class Caro : Form
    {
        private Label[,] Map;
        private static int columns, rows;
        
        private int player;
        private bool gameover;
        private bool vsComputer;
        private int[,] vtMap;
        private Stack<Chess> chesses;
        private Chess chess;

        public Caro()
        {
            columns = 24;
            rows = 20;

            vsComputer = false;
            gameover = false;
            player = 1;          
            Map = new Label[rows + 2, columns + 2];
            vtMap = new int[rows + 2, columns + 2];
            chesses = new Stack<Chess>();
            InitializeComponent();

            BuildTable(false);
        }

        void DrawMoveWin()
        {
            int count1 = 0, count2 = 0;

            #region Draw Rows

            for (int i = 1; i <= rows; i++)
            {
                count1 = 0;
                count2 = 0;
                for (int j = 1; j <= columns; j++)
                {
                    if (vtMap[i, j] != 0)
                    {
                        if (vtMap[i, j] == 1)
                        {
                            count1++;
                            if (count1 == 5)
                            {
                                while(count1 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    j--;
                                    count1--;
                                }
                                return;
                            }
                            count2 = 0;
                        }
                        else
                        {
                            count2++;
                            if (count2 == 5)
                            {
                                while (count2 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    j--;
                                    count2--;
                                }
                                return;
                            }
                                count1 = 0;
                        }
                    }
                    else
                    {
                        count1 = 0;
                        count2 = 0;
                    }
                }
            }
            #endregion


            #region Draw Columns

            for (int j = 1; j <= columns; j++)
            {
                count1 = 0;
                count2 = 0;
                for (int i = 1; i <= rows; i++)
                {
                    if (vtMap[i, j] != 0)
                    {
                        if (vtMap[i, j] == 1)
                        {
                            count1++;
                            if (count1 == 5)
                            {
                                while (count1 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    i--;
                                    count1--;
                                }
                                return;
                            }
                            count2 = 0;
                        }
                        else
                        {
                            count2++;
                            if (count2 == 5)
                            {
                                while (count2 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    i--;
                                    count2--;
                                }
                                return;
                            }
                            count1 = 0;
                        }
                    }
                    else
                    {
                        count1 = 0;
                        count2 = 0;
                    }
                }
            }
            #endregion


            #region Draw Main Diagonal

       
            for (int k = 1; k <= columns; k++)
            {
                count1 = 0;
                count2 = 0;
                for (int i = 1, j = k; i <= rows && j <= columns; i++, j++)
                {
                    if (vtMap[i, j] != 0)
                    {
                        if (vtMap[i, j] == 1)
                        {
                            ++count1;
                            if (count1 == 5)
                            {
                                while (count1 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    i--;
                                    j--;
                                    count1--;
                                }
                                return;
                            }
                            count2 = 0;
                        }
                        else
                        {
                            ++count2;
                            if (count2 == 5)
                            {
                                while (count2 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    i--;
                                    j--;
                                    count2--;
                                }
                                return;
                            }
                            count1 = 0;
                        }
                    }
                    else
                    {
                        count1 = 0;
                        count2 = 0;
                    }
                }
            }


            for (int k = 2; k <= rows; k++)
            {
                count1 = 0;
                count2 = 0;
                for (int i = k, j = 1; i <= rows && j <= columns; i++, j++)
                {
                    if (vtMap[i, j] != 0)
                    {
                        if (vtMap[i, j] == 1)
                        {
                            ++count1;
                            if (count1 == 5)
                            {
                                while (count1 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    i--;
                                    j--;
                                    count1--;
                                }
                                return;
                            }
                            count2 = 0;
                        }
                        else
                        {
                            ++count2;
                            if (count2 == 5)
                            {
                                while (count2 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    i--;
                                    j--;
                                    count2--;
                                }
                                return;
                            }
                            count1 = 0;
                        }
                    }
                    else
                    {
                        count1 = 0;
                        count2 = 0;
                    }
                }
            }

            #endregion


            #region Draw Extra Diagonal

            
            for (int k = 1; k <= rows; k++)
            {
                count1 = 0;
                count2 = 0;
                for (int i = k, j = columns; i <= rows && j >= 0; i++, j--)
                {
                    if (vtMap[i, j] != 0)
                    {
                        if (vtMap[i, j] == 1)
                        {
                            ++count1;
                            if (count1 == 5)
                            {
                                while (count1 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    i--;
                                    j++;
                                    count1--;
                                }
                                return;
                            }
                            count2 = 0;
                        }
                        else
                        {
                            ++count2;
                            if (count2 == 5)
                            {
                                while (count2 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    i--;
                                    j++;
                                    count2--;
                                }
                                return;
                            }
                            count1 = 0;
                        }
                    }
                    else
                    {
                        count1 = 0;
                        count2 = 0;
                    }
                }
            }


            for (int k = columns - 1; k >= 1; k--)
            {
                count1 = 0;
                count2 = 0;
                for (int i = 1, j = k; i < rows && j >= 1; i++, j--)
                {
                    if (vtMap[i, j] != 0)
                    {
                        if (vtMap[i, j] == 1)
                        {
                            ++count1;
                            if (count1 == 5)
                            {
                                while (count1 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    i--;
                                    j++;
                                    count1--;
                                }
                                return;
                            }
                            count2 = 0;
                        }
                        else
                        {
                            ++count2;
                            if (count2 == 5)
                            {
                                while (count2 > 0)
                                {
                                    Map[i + 1, j].BackColor = Color.Azure;
                                    i--;
                                    j++;
                                    count2--;
                                }
                                return;
                            }
                            count1 = 0;
                        }
                    }
                    else
                    {
                        count1 = 0;
                        count2 = 0;
                    }
                }
            }
            #endregion

        }

        /// <summary>
        /// Xây dựng bàn cờ với mảng label 2D, set thuộc tính cần thiết cho label
        /// </summary>
        private void BuildTable(bool bot)
        {
            for (int i = 2; i <= rows; i++)
                for (int j = 1; j <= columns; j++)
                {
                    Map[i, j] = new Label();
                    Map[i, j].Parent = pnTableChess; //?
                    Map[i, j].Top = i * Contain.edgeChess; //?
                    Map[i, j].Left = j * Contain.edgeChess; //?
                    Map[i, j].Size = new Size(Contain.edgeChess-1, Contain.edgeChess-1); //?
                    Map[i, j].BackColor = Color.Snow;
                    Map[i, j].FlatStyle = FlatStyle.Flat;
                    Map[i, j].Cursor = Cursors.Hand;

                    Map[i, j].MouseLeave += Caro_MouseLeave;
                    Map[i, j].MouseEnter += Caro_MouseEnter;
                    Map[i, j].Click += Caro_Click;
                }
                if(bot) CptFindChess();
        }

        private void Caro_Click(object sender, EventArgs e)
        {
            if (gameover) return;

            Label lb = sender as Label;
            int x = lb.Top / Contain.edgeChess - 1, y = lb.Left / Contain.edgeChess; //?
            if (vtMap[x, y] != 0) 
                return;

            if (vsComputer)
            {
                player = 1;
                psbCooldownTime.Value = 0;
                tmCooldown.Start();
                lb.Image = Properties.Resources.x;             
                vtMap[x, y] = 1;
                Check(x, y);  //?                      
                CptFindChess(); //?
            }
            else
            {
                if (player == 1)
                {
                    psbCooldownTime.Value = 0;
                    tmCooldown.Start();
                    lb.Image = Properties.Resources.x;                  
                    vtMap[x, y] = 1;
                    Check(x, y);

                    player = 2;
                    ptbPayer.Image = Properties.Resources.onnnn;
                    txtNamePlayer.Text = "Player 2";
                }
                else
                {
                    psbCooldownTime.Value = 0;
                    lb.Image = Properties.Resources.o;                   
                    vtMap[x, y] = 2;
                    Check(x, y);

                    player = 1;
                    ptbPayer.Image = Properties.Resources.x_copy;
                    txtNamePlayer.Text = "Player 1";
                }
            }
            chess = new Chess(lb, x, y);
            chesses.Push(chess);

            if (chesses.Count != 0) menuUndo.Enabled = true;
        }

        private void Caro_MouseEnter(object sender, EventArgs e)
        {
            if (gameover)
                return;
            Label lb = sender as Label;
            if (lb.BackColor != Color.Blue)
                lb.BackColor = Color.Aqua;
        }

        private void Caro_MouseLeave(object sender, EventArgs e)
        {
            if (gameover)
                return;
            Label lb = sender as Label;
            if (lb.BackColor != Color.Blue)
            lb.BackColor = Color.Snow;
        }

        
        private void tmCooldown_Tick(object sender, EventArgs e)
        {
            psbCooldownTime.PerformStep();
            if (psbCooldownTime.Value >= psbCooldownTime.Maximum)
            {
                Gameover();
                if (vsComputer)
                {
                   if(MessageBox.Show("Time's up. You lose!  (T_T)\nDo you want play again ?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        PlayerFirstToolStripMenuItem.PerformClick();
                }
                else
                {
                    if (player == 1)
                        MessageBox.Show("Time's up. Player 2 Win", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Time's up. Player 1 Win", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void menuUndo_Click(object sender, EventArgs e)
        {
            if (gameover) return;

            if(chesses.Count == 0) return;

            if (!vsComputer)
            {
                Chess template = new Chess();
                template = chesses.Pop();
                template.lb.Image = null;
                vtMap[template.X, template.Y] = 0;
                psbCooldownTime.Value = 0;
                ChangePlayer();
            }
            else
            {
                Chess template = new Chess();
                template = chesses.Pop();
                template.lb.Image = null;
                vtMap[template.X, template.Y] = 0;

                template = chesses.Pop();
                template.lb.Image = null;
                vtMap[template.X, template.Y] = 0;

                Map[template.X + 1, template.Y].BackColor = Color.Snow;
                psbCooldownTime.Value = 0;
                player = 1;
            }
        }

        private void menuQuit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void player1VsPlayer2(object sender, EventArgs e)
        {
            vsComputer = false;
            gameover = false;
            psbCooldownTime.Value = 0;
            tmCooldown.Stop();
            pnTableChess.Controls.Clear();

            txtNamePlayer.Text = "Player 1";
            ptbPayer.Image = Properties.Resources.x_copy;
            menuStrip1.Parent = pnTableChess;
            player = 1;
            Map = new Label[rows + 2, columns + 2];
            vtMap = new int[rows + 2, columns + 2];
            chesses = new Stack<Chess>();

            BuildTable(false);
        }
        

        private void PlayerFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vsComputer = true;
            gameover = false;
            psbCooldownTime.Value = 0;
            tmCooldown.Stop();
            pnTableChess.Controls.Clear();

            ptbPayer.Image = Properties.Resources.x_copy;
            txtNamePlayer.Text = "Player";
            menuStrip1.Parent = pnTableChess;
            player = 1;
            Map = new Label[rows + 2, columns + 2];
            vtMap = new int[rows + 2, columns + 2];
            chesses = new Stack<Chess>();

            BuildTable(false);
        }


        private void ComputerFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vsComputer = true;
            gameover = false;
            psbCooldownTime.Value = 0;
            tmCooldown.Start();
            pnTableChess.Controls.Clear();

            ptbPayer.Image = Properties.Resources.x_copy;
            txtNamePlayer.Text = "Player";
            menuStrip1.Parent = pnTableChess;
            player = 1;
            Map = new Label[rows + 2, columns + 2];
            vtMap = new int[rows + 2, columns + 2];
            chesses = new Stack<Chess>();

            BuildTable(true);
        }

        private void Gameover()
        {
            tmCooldown.Stop();
            gameover = true;
            backgroundgameover();
        }
        private void backgroundgameover()
        {
            for (int i = 2; i <= rows; i++)
                for (int j = 1; j <= columns; j++)
                {
                    Map[i, j].BackColor = Color.Gray;
                }
        }

        private void ChangePlayer()
        {
            if (player == 1)
            {
                player = 2;
                txtNamePlayer.Text = "Player 2";
                ptbPayer.Image = Properties.Resources.onnnn;
            }
            else
            {
                player = 1;
                txtNamePlayer.Text = "Player 1";
                ptbPayer.Image = Properties.Resources.x_copy;
            }
        }
        

        private void Check(int x, int y)
        {
            //Kiểm tra và đếm số quân cờ liên tiếp theo cột
            int i = x - 1, j = y;
            int column = 1, row = 1, mdiagonal = 1, ediagonal = 1;
            while (vtMap[x, y] == vtMap[i, j] && i >= 0)
            {
                column++;
                i--;
            }
            i = x + 1;
            while (vtMap[x, y] == vtMap[i, j] && i <= rows)
            {
                column++;
                i++;
            }
            i = x; j = y - 1;
            while (vtMap[x, y] == vtMap[i, j] && j >= 0)
            {
                row++;
                j--;
            }
            j = y + 1;
            while (vtMap[x, y] == vtMap[i, j] && j <= columns)
            {
                row++;
                j++;
            }
            i = x - 1; j = y - 1;
            while (vtMap[x, y] == vtMap[i, j] && i >= 0 && j >= 0)
            {
                mdiagonal++;
                i--;
                j--;
            }
            i = x + 1; j = y + 1;
            while (vtMap[x, y] == vtMap[i, j] && i <= rows && j <= columns)
            {
                mdiagonal++;
                i++;
                j++;
            }
            i = x - 1; j = y + 1;
            while (vtMap[x, y] == vtMap[i, j] && i >= 0 && j <= columns)
            {
                ediagonal++;
                i--;
                j++;
            }
            i = x + 1; j = y - 1;
            while (vtMap[x, y] == vtMap[i, j] && i <= rows && j >= 0)
            {
                ediagonal++;
                i++;
                j--;
            }
            if (row >= 5 || column >= 5 || mdiagonal >= 5 || ediagonal >= 5)
            {
                Gameover();
                DrawMoveWin();
                if (vsComputer)
                {
                    if (player == 1)
                        MessageBox.Show("You win!!!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        if(MessageBox.Show("You lose! (T_T)\nDo you want play again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        PlayerFirstToolStripMenuItem.PerformClick();
                }
                else
                {
                    if (player == 1)
                        MessageBox.Show("Player 1 Win", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Player 2 Win", "Congratulations",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }



        #region AI

        private readonly int[] Attack = new int[7] { 0, 9, 54, 162, 1458, 13112, 118008 };
        private readonly int[] Defense = new int[7] { 0, 3, 27, 99, 729, 6561, 59049 };

        private void PutChess(int x, int y)
        {
            player = 0;
            psbCooldownTime.Value = 0;

            if (chesses.Count == 1)
            {
                Chess preChess = chesses.First();
                Map[preChess.X + 1, preChess.Y].BackColor = Color.Snow;
            }

            if (chesses.Count > 1)
            {
                Chess preChess = chesses.Skip(1).First();
                Map[preChess.X + 1, preChess.Y].BackColor = Color.Snow;
            }

            Map[x+1, y].Image = Properties.Resources.o;
            Map[x + 1, y].BackColor = Color.Blue;

            vtMap[x, y] = 2;
            Check(x, y);

            chess = new Chess(Map[x+1, y], x, y);
            chesses.Push(chess);
            
        }

        private void CptFindChess()
        {
            if (gameover) return;

            long max = 0;
            int imax = 1, jmax = 1;
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                    if (vtMap[i, j] == 0)
                    {
                        long temp = Calculate(i, j);
                        if (temp > max)
                        {
                            max = temp;
                            imax = i; jmax = j;
                        }
                    }
            }
            if (max == 0) PutChess(10, 12);
            else PutChess(imax, jmax);
        }


        private long Calculate(int x, int y)
        {
            return EnemyChesses(x, y) + ComputerChesses(x, y);
        }


        /// <summary>
        /// Tính toán điểm tấn công dựa trên các quân cờ của AI
        /// </summary>
        /// <param name="x" Tọa độ x></param>
        /// <param name="y" Tọa độ y></param>
        /// <returns></returns>
        private long ComputerChesses(int x, int y)
        {

            //Duyệt và đếm theo chiều dọc
            int i = x - 1, j = y;
            int column = 0, row = 0, mdiagonal = 0, ediagonal = 0; //đếm số quân cờ liên tiếp

             //đánh dấu nếu có ô trống ở 1 hoặc 2 đầu theo hướng đang duyệt
            int sc_ = 0, sc = 0, sr_ = 0, sr = 0, sm_ = 0, sm = 0, se_ = 0, se = 0;

            while (vtMap[i, j] == 2 && i >= 0)
            {
                column++;
                i--;
            }
            if (vtMap[i, j] == 0) sc_ = 1;
            i = x + 1;
            while (vtMap[i, j] == 2 && i <= rows)
            {
                column++;
                i++;
            }
            if (vtMap[i, j] == 0) sc = 1;


            //Duyệt và đếm theo chiều ngang
            i = x; j = y - 1;
            while (vtMap[i, j] == 2 && j >= 0)
            {
                row++;
                j--;
            }
            if (vtMap[i, j] == 0) sr_ = 1;
            j = y + 1;
            while (vtMap[i, j] == 2 && j <= columns)
            {
                row++;
                j++;
            }
            if (vtMap[i, j] == 0) sr = 1;


            //Duyệt và đếm theo đường chéo chính
            i = x - 1; j = y - 1;
            while (vtMap[i, j] == 2 && i >= 0 && j >= 0)
            {
                mdiagonal++;
                i--;
                j--;
            }
            if (vtMap[i, j] == 0) sm_ = 1;
            i = x + 1; j = y + 1;
            while (vtMap[i, j] == 2 && i <= rows && j <= columns)
            {
                mdiagonal++;
                i++;
                j++;
            }
            if (vtMap[i, j] == 0) sm = 1;


            //Duyệt và đếm theo đường chéo phụ
            i = x - 1; j = y + 1;
            while (vtMap[i, j] == 2 && i >= 0 && j <= columns)
            {
                ediagonal++;
                i--;
                j++;
            }
            if (vtMap[i, j] == 0) se_ = 1;
            i = x + 1; j = y - 1;
            while (vtMap[i, j] == 2 && i <= rows && j >= 0)
            {
                ediagonal++;
                i++;
                j--;
            }
            if (vtMap[i, j] == 0) se = 1;

            //Nếu có 4 quân cờ liên tiếp thì trả về giá trị lớn nhất
            if (column == 4) column = 5;
            if (row == 4) row = 5;
            if (mdiagonal == 4) mdiagonal = 5;
            if (ediagonal == 4) ediagonal = 5;

            //Nếu có 3 quân cờ liên tiếp và có 2 ô trống tại 2 đầu thì trả về giá trị lớn nhất
            if (column == 3 && sc == 1 && sc_ == 1) column = 4;
            if (row == 3 && sr == 1 && sr_ == 1) row = 4;
            if (mdiagonal == 3 && sm == 1 && sm_ == 1) mdiagonal = 4;
            if (ediagonal == 3 && se == 1 && se_ == 1) ediagonal = 4;

            //Nếu có 2 quân cờ liên tiếp tại hàng và cột và có 2 ô trống ở 2 đầu thì trả về giá trị lớn nhất
            if (column == 2 && row == 2 && sc == 1 && sc_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (column == 2 && mdiagonal == 2 && sc == 1 && sc_ == 1 && sm == 1 && sm_ == 1) column = 3;
            if (column == 2 && ediagonal == 2 && sc == 1 && sc_ == 1 && se == 1 && se_ == 1) column = 3;
            if (row == 2 && mdiagonal == 2 && sm == 1 && sm_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (row == 2 && ediagonal == 2 && se == 1 && se_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (ediagonal == 2 && mdiagonal == 2 && sm == 1 && sm_ == 1 && se == 1 && se_ == 1) column = 3;

            long Sum = Attack[row] + Attack[column] + Attack[mdiagonal] + Attack[ediagonal];

            return Sum;
        }


        /// <summary>
        /// Tính toán điểm phòng thủ dựa trên các quân cờ của người chơi
        /// </summary>
        /// <param name="x" Tọa độ x></param>
        /// <param name="y" Tọa độ y></param>
        /// <returns></returns>
        private long EnemyChesses(int x, int y)
        {
            //Duyệt và đếm theo chiều dọc
            int i = x - 1, j = y;
            int sc_ = 0, sc = 0, sr_ = 0, sr = 0, sm_ = 0, sm = 0, se_ = 0, se = 0;
            int column = 0, row = 0, mdiagonal = 0, ediagonal = 0;
            while (vtMap[i, j] == 1 && i >= 0)
            {
                column++;
                i--;
            }
            if (vtMap[i, j] == 0) sc_ = 1;
            i = x + 1;
            while (vtMap[i, j] == 1 && i <= rows)
            {
                column++;
                i++;
            }
            if (vtMap[i, j] == 0) sc = 1;

            //Duyệt và đếm theo chiều ngang
            i = x; j = y - 1;
            while (vtMap[i, j] == 1 && j >= 0)
            {
                row++;
                j--;
            }
            if (vtMap[i, j] == 0) sr_ = 1;
            j = y + 1;
            while (vtMap[i, j] == 1 && j <= columns)
            {
                row++;
                j++;
            }
            if (vtMap[i, j] == 0) sr = 1;

            //Duyệt và đếm theo đường chéo chính
            i = x - 1; j = y - 1;
            while (vtMap[i, j] == 1 && i >= 0 && j >= 0)
            {
                mdiagonal++;
                i--;
                j--;
            }
            if (vtMap[i, j] == 0) sm_ = 1;
            i = x + 1; j = y + 1;
            while (vtMap[i, j] == 1 && i <= rows && j <= columns)
            {
                mdiagonal++;
                i++;
                j++;
            }
            if (vtMap[i, j] == 0) sm = 1;

            //Duyệt và đếm theo đường chéo phụ
            i = x - 1; j = y + 1;
            while (vtMap[i, j] == 1 && i >= 0 && j <= columns)
            {
                ediagonal++;
                i--;
                j++;
            }
            if (vtMap[i, j] == 0) se_ = 1;
            i = x + 1; j = y - 1;
            while (vtMap[i, j] == 1 && i <= rows && j >= 0)
            {
                ediagonal++;
                i++;
                j--;
            }
            if (vtMap[i, j] == 0) se = 1;

            //Nếu có 4 quân cờ liên tiếp thì trả về giá trị lớn nhất
            if (column == 4) column = 5;
            if (row == 4) row = 5;
            if (mdiagonal == 4) mdiagonal = 5;
            if (ediagonal == 4) ediagonal = 5;

            //Nếu có 3 quân cờ liên tiếp và có 2 ô trống tại 2 đầu thì trả về giá trị lớn nhất
            if (column == 3 && sc == 1 && sc_ == 1) column = 4;
            if (row == 3 && sr == 1 && sr_ == 1) row = 4;
            if (mdiagonal == 3 && sm == 1 && sm_ == 1) mdiagonal = 4;
            if (ediagonal == 3 && se == 1 && se_ == 1) ediagonal = 4;

            //Nếu có 2 quân cờ liên tiếp tại hàng và cột và có 2 ô trống ở 2 đầu thì trả về giá trị lớn nhất
            if (column == 2 && row == 2 && sc == 1 && sc_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (column == 2 && mdiagonal == 2 && sc == 1 && sc_ == 1 && sm == 1 && sm_ == 1) column = 3;
            if (column == 2 && ediagonal == 2 && sc == 1 && sc_ == 1 && se == 1 && se_ == 1) column = 3;
            if (row == 2 && mdiagonal == 2 && sm == 1 && sm_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (row == 2 && ediagonal == 2 && se == 1 && se_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (ediagonal == 2 && mdiagonal == 2 && sm == 1 && sm_ == 1 && se == 1 && se_ == 1) column = 3;

            long Sum = Defense[row] + Defense[column] + Defense[mdiagonal] + Defense[ediagonal];
            return Sum;
        }

        #endregion


        private void Caro_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
