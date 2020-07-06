using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOmoku
{
    class Black :Chess
    {
        public Black(int x ,int y) : base(x, y)
        {
            this.Image = Properties.Resources.black;//直接呼叫原本在resources檔案裡面的黑色棋子圖片
        }
        public override chessType GetchessType()//複寫chessType裡面的資料
        {
            return chessType.BLACK;
        }
    }
}
