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
        public static int mapSize = 20;
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
    }
}
