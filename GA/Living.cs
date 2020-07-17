using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static GA.Map;

namespace GA
{
    public class Living : IGenome
    {
        public List<Map.MovementType> chromosome;
        public double? fitness=null;
        public Living(List<Map.MovementType> chromosome)
        {
            this.chromosome = chromosome;
            fitness = Measure();
        }

        public double Measure()
        {
            if (fitness != null)
                return (double)fitness;
            
            Point pos = new Point(0, 0);
            bool[,] was = new bool[Map.mapSize, Map.mapSize];
            double fitnessLocal = 0;
            chromosome.ForEach((c) =>
            {
                Point copyPos = pos;
                switch (c)
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
                switch (harta[copyPos.X, copyPos.Y])
                {
                    case CellType.Bomb:
                        if (!was[copyPos.X, copyPos.Y])
                            fitnessLocal -= 5;
                        pos = copyPos;
                        break;
                    case CellType.Coin:
                        if (!was[copyPos.X, copyPos.Y])
                            fitnessLocal += 5;
                        pos = copyPos;
                        break;
                    case CellType.Empty:
                        if (!was[copyPos.X, copyPos.Y])
                            fitnessLocal += 2;
                        pos = copyPos;
                        break;
                }
                was[pos.X, pos.Y] = true;
            });
            this.fitness = fitnessLocal;
            return (double)fitness;
        }
    }
}
