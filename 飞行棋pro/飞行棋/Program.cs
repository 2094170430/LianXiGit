using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞行棋
{enum Sence
    {
        Firsrt,
        Second,
        Three
    }
    enum GridType
    {
        moren=0,
        boom=1,
        shikong=2,
        fei=3,
        user,
        robot

    }
   
    internal class Program
    {
        #region 控制台大小
        static void ConsoleSize(int w, int h)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);
        }
        #endregion
        #region 场景切换
        static void SenceSelect(int w,int h, Sence a=Sence.Firsrt)
        {while (true)
            {
                switch (a)
                {
                    case Sence.Firsrt:
                        //场景一
                        StartMenu(50, 25, ref a);
                        break;
                    case Sence.Second:
                        //场景二
                        Console.Clear();
                        MainGame(w, h,ref a);
                        break;
                    case Sence.Three:
                        Console.Clear();
                        ExitMenu(50, 25, ref a);
                        //场景三
                        break;

                }
            }
        }

        #endregion
        #region 场景一
        static void StartMenu(int w,int h,ref Sence a)
        {
            bool start = true;
            int wordcolor = 0;

            while (start)
            {
                Console.Clear();
                Console.SetCursorPosition(w / 2 - 3, 7);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("飞行棋");
                Console.SetCursorPosition(w / 2 - 4, 9);
                Console.ForegroundColor= wordcolor==0?ConsoleColor.Red:ConsoleColor.White;
                Console.WriteLine("开始游戏");
                Console.SetCursorPosition(w / 2 - 4, 10);
                Console.ForegroundColor = wordcolor == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine("退出游戏");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        wordcolor--;
                        if (wordcolor < 0)
                            wordcolor = 0;
                        break;
                    case ConsoleKey.S:
                        wordcolor++;
                        if (wordcolor > 1)
                            wordcolor = 1;
                        break;
                    case ConsoleKey.J:
                        if (wordcolor == 0)
                        {
                            a = Sence.Second;
                            start = false;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                        break;



                }
            }
        }
        #endregion
        #region 场景二
        static  void MainGame(int w,int h, ref Sence a)
        {
            Obstacle(w,h);//生成环境
            GameRule(w, h);//打印游戏规则
            Console.SetCursorPosition(3, 1);
            Map m1 =new Map(w / 2 - 10, 1, 58);//创建地图

            player p1 = new player(0,m1,GridType.user);
            player p2 = new player(0,m1,GridType.robot);
            DrawPlayer(p1, p2); DrawPlayer(p2, p1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, (int)25 * 3 / 4 + 5);
            Console.Write("按任意键开始游戏");
            Console.ReadKey(true);
            WordClear();
            while (!(p1.ideax ==m1.gridarr.Length-1|| p2.ideax == m1.gridarr.Length-1))
            {
                RandomMove(m1, ref p2);//p2摇色子加打印信息
                DrawPlayer(p2 , p1);//打印角色位置
                //覆盖掉上一步的角色
                if (p1.ideax == p2.oldideax)
                {
                    Draw(m1.gridarr[p2.oldideax]);
                    DrawPlayer(p1, p2);
                }
                else
                {  Draw(m1.gridarr[p2.oldideax]);
                }
                Console.ReadKey(true);
                WordClear();
                //p1摇色子
                RandomMove(m1, ref p1);
                DrawPlayer(p1, p2);
                if (p1.oldideax == p2.ideax)
                {
                    Draw(m1.gridarr[p1.oldideax]);
                    DrawPlayer(p2, p1);
                }
                else
                {
                    Draw(m1.gridarr[p1.oldideax]);
                }
                Console.ReadKey(true);
                WordClear();
            }
            #region 胜利打印
            if (p1.ideax == m1.gridarr.Length - 1)
            {
               WordClear();
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 2);
                Console.Write("{0}到达终点获得胜利", p1.p);

            }
            else if (p1.ideax == p2.ideax)
            {
                WordClear();
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 2);
                Console.Write("{0}和{1}同时到达终点平局", p1.p,p2.p);
            }
            else
            {
                WordClear();
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 2);
                Console.Write("{0}到达终点获得胜利", p2.p);
            }
            Console.ReadKey(true);
            #endregion
            a = Sence.Three;
        }
        #endregion
        #region 红墙
        static void Obstacle(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < x; i += 2)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("正");
                Console.SetCursorPosition(i, y /2  );
                Console.Write("正");
                Console.SetCursorPosition(i,(int)y*3/4+1);
                Console.Write("正");
                Console.SetCursorPosition(i, y-1);
                Console.Write("正");
            }
            for (int i = 0; i < y; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("正");
                Console.SetCursorPosition(x-2, i);
                Console.Write("正");
            }



        }
        #endregion
        #region 游戏规则
        static void GameRule(int w,int h)
        {
            Console.ForegroundColor= ConsoleColor.White;
            Console.SetCursorPosition(2, h / 2+1);
            Console.Write("口:普通格子");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(2, h / 2 + 2);
            Console.Write("孟:玩家   ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(14, h / 2 + 2);
            Console.Write("机:人机");
            Console.SetCursorPosition(2, h / 2 + 3);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("重:玩家与人机重合");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(2, h / 2 + 4);
            Console.Write("时:随机穿越，停止前进，和敌人换换位置");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(2, h / 2 + 5);
            Console.Write("炸:后退五个格子");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(2, h / 2 + 6);
            Console.Write("飞:前进五个格子");
        }
        #endregion
        #region 格子结构体
        struct Grid
        {
            public int x; public int y;
            public GridType type;
          public  Grid(int x, int y, GridType type)
            {
                  this.y = y;
                this.x = x; 
                this.type = type;
            }
        }
        #endregion
        #region 画布
        static void Draw(Grid grid)
        {
            Console.SetCursorPosition(grid.x, grid.y);
            switch (grid.type)
            {
                case GridType.moren:
                    Console.ForegroundColor= ConsoleColor.White;
                    Console.Write("口");
                    break;
                case GridType.boom:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("炸");
                    break;
                case GridType.shikong:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("时");
                    break;
                case GridType.fei:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("飞");
                    break;
                case GridType.user:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("人");
                    break;
                case GridType.robot:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("机");
                    break;
            }
        }
        #endregion
        #region 地图绘制
        struct Map
        {
          public  Grid[] gridarr;


            public Map(int x, int y, int sum)
            {
                Random random = new Random();
                int temp = 2;
                int ideax = 0;
                int ideay = 0;
                 gridarr = new Grid[sum];
                for (int i = 0; i < gridarr.Length; i++)
                {
                    gridarr[i].x = x;
                    gridarr[i].y = y;

                    gridarr[i].type = RandomGrid(random.Next(0, 100));

                    if (i == 0 || i == gridarr.Length - 1)
                    {
                        gridarr[i].type = GridType.moren;

                    }
                    if (ideax == 10)
                    {
                        y++;
                        ideay++;
                        if (ideay == 2)
                        {
                            ideay = 0;
                            ideax = 0;
                            temp = -temp;
                        }
                    }
                    else
                    {
                        x += temp;
                        ideax++;
                    }
                    Draw(gridarr[i]);


                }
            }
            public void draw()
            {
                for (int i = 0; i < gridarr.Length; i++)
                {
                  
                    Draw(gridarr[i]);

                }

            }
        }
        #endregion
        #region 随机格子块
       static GridType RandomGrid(int i)
        {
            if(i<85)
            {
                return GridType.moren;
            }
            else if(i>=85&&i<90)
            {
                return GridType.boom;

            }
            else if (i >= 90 && i < 95)
            {
                return GridType.shikong;

            }
            else if (i >= 95 && i < 100)
            {
                return GridType.fei;

            }
            return GridType.moren;
        }
        #endregion
        #region 人物
        struct player
        {
            public int x;public int y;
           public GridType p;
           public int ideax;
            public int oldideax;
            public bool stop;
          public player(int idex,Map m,GridType gird)
            {
                 ideax = idex;
                oldideax = idex;

                x = m.gridarr[idex].x;
                y = m.gridarr[idex].y;
                p = gird;
                stop = false;
            }
            public void Draw()
            {
                Console.SetCursorPosition(x, y);
                switch (p)
                {
                    case GridType.user:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("人");
                        break;
                    case GridType.robot:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("机");
                        break;

                }
            }
        }

        #endregion
        #region 玩家画布
        static void DrawPlayer(player p1,player p2)
        {
            if (p1.x == p2.x && p1.y == p2.y)
            {
                Console.SetCursorPosition(p1.x, p2.y);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("重");
            }
            else
            {
                p1.Draw();
            }

        }
        #endregion
        #region 扔色子
        static bool RandomMove(Map m1, ref player p1)
        {
            Console.ForegroundColor= p1.p==GridType.robot?ConsoleColor.Cyan:ConsoleColor.DarkGreen;
            if (p1.stop == true)
            {
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 2);
                Console.Write("{0}的回合:遭遇时空乱流本回合不动", p1.p);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 5);
                Console.Write("按任意键继续");
                p1.stop = false;
            return false; }
            Random random = new Random();
            int x = random.Next(1, 7);
            p1.oldideax = p1.ideax;
            p1.ideax += x;
            if (p1.ideax > m1.gridarr.Length - 1)
            {
                p1.ideax = m1.gridarr.Length - 1;
            }
            #region 遭遇的情况和遭遇色子的文字打印
            if (m1.gridarr[p1.ideax].type == GridType.boom)
            {
                p1.ideax -= 5;
                if (p1.ideax <= 0)
                {
                    p1.ideax = 0;
                }
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 2);
                Console.Write("{0}的回合:摇色子摇到了{1}",p1.p,x);
                Console.SetCursorPosition(2,(int)25* 3 / 4 + 3);
                Console.Write("{0}遭遇炸弹后退5格",p1.p);
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 4);
                Console.Write("{0}一共走出{1}格子",p1.p,p1.ideax -p1.oldideax);
            
            }
            else if( m1.gridarr[p1.ideax].type == GridType.fei)
            {
                p1.ideax += 5;
                if (p1.ideax > m1.gridarr.Length-1)
                {
                    p1.ideax = m1.gridarr.Length - 1;
                }
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 2);
                Console.Write("{0}的回合:摇色子摇到了{1}", p1.p, x);
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 3);
                Console.Write("{0}遭遇飞雷神前进5格", p1.p);
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 4);
                Console.Write("{0}一共走出{1}格子", p1.p, p1.ideax - p1.oldideax);
               
            }
            else if(m1.gridarr[p1.ideax].type == GridType.shikong)
            {
                p1.stop = true;
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 2);
                Console.Write("{0}的回合:摇色子摇到了{1}", p1.p, x);
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 3);
                Console.Write("{0}遭遇失控乱流下回合停止行动", p1.p);
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 4);
                Console.Write("{0}一共走出{1}格子", p1.p, p1.ideax - p1.oldideax);
                
            }
            else if (m1.gridarr[p1.ideax].type == GridType.moren)
            {
                
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 2);
                Console.Write("{0}的回合:摇色子摇到了{1}", p1.p, x);
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 3);
                Console.Write("{0}到达安全区域", p1.p);
                Console.SetCursorPosition(2, (int)25 * 3 / 4 + 4);
                Console.Write("{0}一共走出{1}格子", p1.p, p1.ideax - p1.oldideax);
                
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, (int)25 * 3 / 4 + 5);
            Console.Write("按任意键继续");
            #endregion
            p1.x = m1.gridarr[p1.ideax].x; ;
            p1.y = m1.gridarr[p1.ideax].y; ;
            return false;
        }
        #endregion
        #region 色子文字区域的清屏
        static void WordClear()
        {
            Console.SetCursorPosition(2, (int)25 * 3 / 4 + 2);
            for(int i =0;i<40;i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(2, (int)25 * 3 / 4 + 3);
            for (int i = 0; i < 40; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(2, (int)25 * 3 / 4 + 4);
            for (int i = 0; i < 40; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(2, (int)25 * 3 / 4 + 5);
            for (int i = 0; i < 40; i++)
            {
                Console.Write(" ");
            }
        }


        #endregion
        #region 场景三
        static void ExitMenu(int w, int h, ref Sence a)
        {
            bool start = true;
            int wordcolor = 0;

            while (start)
            {
                Console.Clear();
                Console.SetCursorPosition(w / 2 - 11, 7);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("********GameOver********");
                Console.SetCursorPosition(w / 2 - 4, 9);
                Console.ForegroundColor = wordcolor == 0 ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine("继续游戏");
                Console.SetCursorPosition(w / 2 - 4, 10);
                Console.ForegroundColor = wordcolor == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine("退出游戏");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        wordcolor--;
                        if (wordcolor < 0)
                            wordcolor = 0;
                        break;
                    case ConsoleKey.S:
                        wordcolor++;
                        if (wordcolor > 1)
                            wordcolor = 1;
                        break;
                    case ConsoleKey.J:
                        if (wordcolor == 0)
                        {
                             a =Sence.Second;
                            start = false;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }

        #endregion

        static void Main(string[] args)
        {
            int w  = 50 ; int h = 25;
            ConsoleSize(w, h);
            SenceSelect(w, h);
        }
    }
}
