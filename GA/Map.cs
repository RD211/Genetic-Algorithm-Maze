using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public static class Map
    {
        public static Random rnd = new Random(System.DateTime.Now.Millisecond);
        public enum CellType
        {
            Empty,
            Coin,
            Bomb,
            Wall
        };
        public enum MovementType
        {
            Left,
            Right,
            Down,
            Up
        };
        public static int movementTypes = 3;
        public static int mapSize = 10;
        public static CellType[,] harta = new CellType[mapSize, mapSize];

        public static MovementType MutateGene()
        {
            int num = rnd.Next(-1, Map.movementTypes+1);
            return (Map.MovementType)num;
        }

        public static List<MovementType> GenerateGnome()
        {
            List<Map.MovementType> gnome = new List<MovementType>();
            int randomSize = rnd.Next(0, 100);
            for (int i = 0; i < randomSize; i++) gnome.Add(MutateGene());
            return gnome;
        }
        public static int Score(List<MovementType> ins)
        {
            Point pos = new Point(0, 0);
            bool[,] was = new bool[mapSize, mapSize];
            int fitness = 0;
            ins.ForEach((c) =>
            {
                Point copyPos = pos;
                switch(c)
                {
                    case MovementType.Left:
                        if (copyPos.X - 1 >= 0)
                            copyPos.X--;
                        break;
                    case MovementType.Right:
                        if (copyPos.X + 1 < mapSize)
                            copyPos.X++;
                        break;
                    case MovementType.Up:
                        if (copyPos.Y - 1 >= 0)
                            copyPos.Y--;
                        break;
                    case MovementType.Down:
                        if (copyPos.Y + 1 < mapSize)
                            copyPos.Y++;
                        break;
                }
                switch (harta[copyPos.X,copyPos.Y])
                {
                    case CellType.Bomb:
                        if(!was[copyPos.X, copyPos.Y]) 
                            fitness-=5;
                        pos = copyPos;
                        break;
                    case CellType.Coin:
                        if (!was[copyPos.X, copyPos.Y])
                            fitness += 5;
                        pos = copyPos;
                        break;
                    case CellType.Empty:
                        if (!was[copyPos.X, copyPos.Y])
                            fitness+=2;
                            pos = copyPos;
                        break;
                }
                was[pos.X, pos.Y] = true;
            });
            return fitness;
        }
    }
}
