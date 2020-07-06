using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOmoku
{
    class game
    {
        Borad borad = new Borad();

        chessType currentplayer = chessType.BLACK;

        private chessType winner = chessType.NONE;
        public chessType Winner { get { return winner; } }

        public bool Canbeplaced (int x, int y)
        {
            return borad.CanbePlaced(x, y);
        }
        public Chess PlaceAchess(int x , int y)
        {
             
            Chess chess = borad.PlaceAchess(x,y, currentplayer);
            if (chess != null)
            {
                Whowin();//檢查現在下棋的人是不是獲勝

                //交換下棋部分
                if (currentplayer == chessType.BLACK)//如果棋子是黑色的話，下一次按就變成白色的
                {
                    currentplayer = chessType.WHITE;
                }
                else if (currentplayer == chessType.WHITE)//如果棋子是白色的話，下一次按就變成黑色的
                {
                    currentplayer = chessType.BLACK;
                }
                return chess;//傳回棋子
            }
            return null;
        }

        public void Whowin()
        {
            int centerX = borad.Lastchess.X;
            int centerY = borad.Lastchess.Y;

            //                  |(x-1,y-1)|(x,y-1)|(x+1,y-1)|
            //                  |---------|-------|---------|
            //檢查八個不同方向  | (x-1,y) | (x,y) | (x+1,y) |
            //                  |---------|-------|---------|
            //                  |(x-1,y+1)|(x,y+1)|(x+1,y+1)| 

            for (int xdir = -1; xdir <= 1; xdir++)
            {                                     
                for (int ydir = -1; ydir <= 1; ydir++) 
                {
                    if(xdir == 0 && ydir == 0)
                    {
                        //如果有符合條件的話，會跳過下面所有的條件，直接開始下一輪迴圈
                        continue;
                    }
                    int count = 1;//紀錄現在有幾顆棋子
                    while (count < 5)
                    {
                        int targetX = centerX + count * xdir;
                        int targetY = centerY + count * ydir;

                        //檢查是不是有超出邊界和檢查顏色是不是一樣
                        if (targetX < 0 || targetX >= Borad.Nodecount ||
                            targetY < 0 || targetY >= Borad.Nodecount ||
                            borad.GetchessType(targetX, targetY) != currentplayer)
                        {
                            break;
                        }
                        count++;
                    }

                    if (count == 5)//檢查是不是有五顆棋子
                    {
                        winner = currentplayer;
                    }
                }
            }
        }
    }
}
