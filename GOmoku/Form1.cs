using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOmoku
{
    public partial class Form1 : Form
    {
        private game Game = new game();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Chess chess = Game.PlaceAchess(e.X, e.Y);
            if (chess != null)
            {
                this.Controls.Add(chess);//取得棋子按下去之後的座標

                //檢查是不是有人獲勝
                if(Game.Winner == chessType.BLACK)
                {
                    MessageBox.Show("黑色棋子獲勝");
                }
                else if (Game.Winner == chessType.WHITE)
                {
                    MessageBox.Show("白色棋子獲勝");
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Game.Canbeplaced(e.X, e.Y))//知道能不能放棋子(交給遊戲管理的視窗處理)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string message = "想走了阿";
            const string name = "離開";
            var result = MessageBox.Show(message, name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            const string message = "按下確定重新開始！！";
            const string name = "重新開始 ";
            var result = MessageBox.Show(message, name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
