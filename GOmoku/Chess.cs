using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GOmoku
{
    abstract class Chess: PictureBox //設定abstract，避免重複建立一樣的chess
    {
        private static readonly int IMAGE_WIDTH = 50;//設定一個常數，固定為50
        public Chess(int x, int y)
        {
            this.BackColor = Color.Transparent;//設定背景顏色(透明)
            //給予棋子位置，除以IMAGE_WIDTH/2是因為一開始按的位置是設定在左上角
            this.Location = new Point(x-(IMAGE_WIDTH/2), y-(IMAGE_WIDTH/2));
            this.Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);//給棋子寬和高
        }
        public abstract chessType GetchessType(); //不實作裡面的內容，傳給黑棋或白棋自己去做
    }
}
