using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GOmoku
{
    class Borad
    {
        private static Point NOmatchNode = new Point(-1, -1);//要創一個不存在的點
        

        public static int Nodecount = 9;
        int offset = 75;//判斷棋盤和邊的距離
        int Nodeclosest = 10;//判斷點擊離點的半徑
        int NodeDistance = 75;//判斷點跟點的距離

        private Point lastchess = NOmatchNode;
        public Point Lastchess { get { return lastchess; } }
        public chessType GetchessType(int nodeX, int nodeY)//為了知道現在交叉點上的棋子顏色是甚麼
        {
            if(chess[nodeX,nodeY] == null)
            {
                return chessType.NONE;//如果棋盤沒有棋子的話，會回傳NONE
            }
            else
            {
                return chess[nodeX, nodeY].GetchessType();//有的話就去抓棋子的顏色
            }
        }

        private Chess[,] chess = new Chess[9, 9];//棋盤大小的二維陣列
        public bool CanbePlaced(int x, int y)//設定是不是可以放棋子的位置
        {
            Point nodeID = FindthecloestNode(x, y);//找出最近的節點

            if(nodeID == NOmatchNode)//如果沒有的話，回傳false
            {
                return false;
            }
            if (chess[nodeID.X, nodeID.Y] != null)
            {
                return false;
            }
            return true;//如果有的話，回傳true
        }

        public Chess PlaceAchess(int x, int y, chessType type)
        {
            Point nodeID = FindthecloestNode(x, y);//找出最近的節點

            if (nodeID == NOmatchNode)//如果沒有的話，回傳null
            {
                return null;
            }
            //如果有的話，檢查棋子是不是已經存在了
            if (chess[nodeID.X, nodeID.Y] != null)
            {
                return null;
            }
            //根據 Type 產生對應的棋子
            Point formpos = adjustNodePosition(nodeID);//為了讓棋子剛好在座標點上

            if (type == chessType.BLACK)
            {
                chess[nodeID.X, nodeID.Y] = new Black(formpos.X, formpos.Y);
            }
            else if(type == chessType.WHITE)
            {
                chess[nodeID.X, nodeID.Y] = new White(formpos.X, formpos.Y);
            }

            lastchess = nodeID;//紀錄最後下棋子的位置

            return chess[nodeID.X, nodeID.Y];
        }

        private Point adjustNodePosition(Point nodeID)
        {
            Point position = new Point();//新創一個Point
            //座標X * 點跟點的距離 + 邊到邊緣的距離就會等於一個新座標
            position.X = nodeID.X * NodeDistance + offset;
            //座標Y * 點跟點的距離 + 邊到邊緣的距離就會等於一個新座標
            position.Y = nodeID.Y * NodeDistance + offset;
            return position;
        }

        private Point FindthecloestNode(int x, int y)//找到最近的交叉點
        {
            int nodeX = FindtheclosestNode(x);//找到下面計算x後的結果
            
            if(nodeX == -1 || nodeX >= Nodecount)
            {
                return NOmatchNode;//如果找不到就傳一個不存在的點
            }
            int nodeY = FindtheclosestNode(y);//找到下面計算y後的結果
            if (nodeY== -1 || nodeX >= Nodecount)
            {
                return NOmatchNode;//如果找不到就傳一個不存在的點
            }
            return new Point(nodeX, nodeY);//最後回傳一個座標
        }
        private int FindtheclosestNode(int place)//先計算上面的二維數字，然後再放回去
        {
            place -= offset;//判斷邊到點的半徑
            int answer = place / NodeDistance;//計算邊跟邊的距離
            int last = place % NodeDistance;//計算邊到點的距離

            if(last <= Nodeclosest)
            {
                return answer; //如果last小於等於Nodeclosest就回傳餘數
            }
            else if (last >= NodeDistance - Nodeclosest)
            {
                return answer + 1;//如果last大於等於NodeDistance - Nodeclosest就回傳商數
            }
            else
            {
                return -1;//沒有任何一個點符合
            }

        }
    }
}
