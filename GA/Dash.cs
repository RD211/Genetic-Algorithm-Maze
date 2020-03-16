using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GA
{

    public partial class frm_dash : Form
    {
        static int populationSize = 5000;
        int generationCounter = 0;
        List<Living> population = new List<Living>();
        Map.CellType selectedCellType = Map.CellType.Empty;
        public frm_dash()
        {
            InitializeComponent();
        }

        private void Frm_dash_Load(object sender, EventArgs e)
        {
            DrawMap();
        }

        private void DrawMap(bool drawBest = false)
        {
            Bitmap bmp = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush brsh = new SolidBrush(Color.White);
            for(int i = 0;i<Map.mapSize; i++)
            {
                for(int j = 0;j<Map.mapSize; j++)
                {
                    switch(Map.harta[i,j])
                    {
                        case Map.CellType.Bomb:
                            brsh = new SolidBrush(Color.Red);
                            break;
                        case Map.CellType.Coin:
                            brsh = new SolidBrush(Color.Yellow);
                            break;
                        case Map.CellType.Empty:
                            brsh = new SolidBrush(Color.White);
                            break;
                        case Map.CellType.Wall:
                            brsh = new SolidBrush(Color.Black);
                            break;
                    }
                    g.FillRectangle(brsh, i * 1000/Map.mapSize, j * 1000/ Map.mapSize, 1000/Map.mapSize, 1000/Map.mapSize);
                }
            }
            if(drawBest)
            {
                var best = population[0];
                Point pos = new Point(0, 0);
                for(int i = 0;i<best.chromosome.Count();i++)
                {
                    Point copyPos = pos;
                    switch (best.chromosome[i])
                    {
                        case Map.MovementType.Left:
                            if (copyPos.X - 1 >= 0)
                                copyPos.X--;
                            break;
                        case Map.MovementType.Right:
                            if (copyPos.X + 1 < Map.mapSize)
                                copyPos.X++;
                            break;
                        case Map.MovementType.Up:
                            if (copyPos.Y - 1 >= 0)
                                copyPos.Y--;
                            break;
                        case Map.MovementType.Down:
                            if (copyPos.Y + 1 < Map.mapSize)
                                copyPos.Y++;
                            break;
                    }
                    if(Map.harta[copyPos.X, copyPos.Y]!=Map.CellType.Wall)
                    {
                        pos = copyPos;
                        brsh = new SolidBrush(Color.FromArgb(150, Color.Green));
                        g.FillRectangle(brsh, pos.X * 1000 / Map.mapSize, pos.Y * 1000 / Map.mapSize, 1000/Map.mapSize, 1000 / Map.mapSize);
                    }



                }
            }
            this.pbox_map.Image = bmp;
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            if (btn_start.Text == "Start")
            {
                for (int i = 0; i < populationSize; i++)
                {
                    population.Add(new Living(Map.GenerateGnome()));
                }

                this.btn_start.Text = "Stop";
                timer.Start();
            }
            else
            {
                timer.Stop();
                this.btn_start.Text = "Start";
                population.Clear();
                this.generationCounter = 0;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Point pointOfClick = ((MouseEventArgs)e).Location;
            pointOfClick.X /= 4;
            pointOfClick.Y /= 4;
            Map.harta[pointOfClick.X / 10, pointOfClick.Y / 10] = selectedCellType;
            DrawMap();
        }

        private void Btn_bomb_Click(object sender, EventArgs e)
        {
            this.selectedCellType = Map.CellType.Bomb;
        }

        private void Btn_coin_Click(object sender, EventArgs e)
        {
            this.selectedCellType = Map.CellType.Coin;

        }

        private void Btn_wall_Click(object sender, EventArgs e)
        {
            this.selectedCellType = Map.CellType.Wall;

        }

        private void Btn_empty_Click(object sender, EventArgs e)
        {
            this.selectedCellType = Map.CellType.Empty;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var orderedPopulation = population.OrderBy(live => live.fitness).Reverse().ToList();
            List<Living> newGen = new List<Living>();
            for (int i = 0; i < (10*populationSize) / 100; i++)
            {
                newGen.Add(orderedPopulation[i]);
            }
            for (int i = 0; i < (90 * populationSize) / 100; i++)
            {
                int r = Map.rnd.Next(0, populationSize / 2);
                Living parent1 = orderedPopulation[r];
                r = Map.rnd.Next(0, populationSize / 2);
                Living parent2 = orderedPopulation[r];
                Living offspring = parent1.Mate(parent2);
                newGen.Add(offspring);
            }
            population = new List<Living>(newGen);
            this.lbl_best.Text = "Best score: "+population[0].fitness + " \nGeneration number: " + generationCounter++;
            if(generationCounter%2==0)
            DrawMap(true);
        }
    }
}
