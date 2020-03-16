using System;
using System.Collections.Generic;
using System.Linq;

namespace GA
{
    public class Living
    {
        public List<Map.MovementType> chromosome;
        public int fitness;
        public Living(List<Map.MovementType> chromosome)
        {
            this.chromosome = chromosome;
            fitness = Map.Score(chromosome);
        }

        public Living Mate(Living par2)
        {
            List<Map.MovementType> child_chromosome = new List<Map.MovementType>();
            int newSize = Map.rnd.Next(Math.Min(chromosome.Count(), par2.chromosome.Count()), Math.Max(chromosome.Count(), par2.chromosome.Count()));
            if (Map.rnd.Next(0, 15) == 5)
            {
                newSize = Map.rnd.Next(0, 100);
                for (int i = 0; i < newSize; i++)
                {
                    child_chromosome.Add(Map.MutateGene());
                }
            }
            else
            {
                for (int i = 0; i < newSize; i++)
                {
                    float probability = (float)Map.rnd.Next(0, 100) / 100;
                    if (probability < 0.40 && i < chromosome.Count())
                        child_chromosome.Add(chromosome[i]);
                    else if (probability < 0.80 && i < par2.chromosome.Count())
                        child_chromosome.Add(par2.chromosome[i]);
                    else if (probability < 0.95)
                        child_chromosome.Add(Map.MutateGene());
                }


            }
            return new Living(child_chromosome);

        }
    }
}
