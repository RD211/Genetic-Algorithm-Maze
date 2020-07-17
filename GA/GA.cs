using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace GA
{
    public class GA<T> where T : IGenome
    {
        int PopulationSize { get; }
        bool once = false;
        readonly Func<T,T,T> mateFunction;
        readonly Func<T> creatorFunction;
        List<T> population;
        readonly Random random;
        public GA(int populationSize, Func<T,T,T> mateFunction, Func<T> creatorFunction)
        {
            this.PopulationSize = populationSize;
            random = new Random(populationSize);
            this.creatorFunction = creatorFunction;
            this.mateFunction = mateFunction;
            ResetPopulation();
        }

        public void ResetPopulation()
        {
            population = ParallelEnumerable.Range(0, PopulationSize).Select(x => creatorFunction()).ToList();
        }

        public void Eval()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            population.Sort((a, b) => {
                if (a.Measure() > b.Measure())
                    return -1;
                else if (a.Measure() == b.Measure())
                    return 0;
                else
                    return 1;
            });
            List<T> newPopulation = population.GetRange(0,PopulationSize/10);
            
            newPopulation.AddRange(ParallelEnumerable.Range(0, PopulationSize - PopulationSize/10).AsParallel().Select(i =>
               random.Next(0, 10) == 5 ? creatorFunction()
                : mateFunction(population[i], population[random.Next(0, PopulationSize / 50)])
            ));
            population = newPopulation;
            sw.Stop();
            if (!once)
            {
                once = true;

                MessageBox.Show($"Elapsed={sw.ElapsedMilliseconds}");
            }

            
        }
        public T GetBestContender() => population.First();
    }
}
