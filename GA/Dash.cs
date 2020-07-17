using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GA
{

    public partial class frm_dash : Form
    {
        int generationCounter = 0;
        Map.CellType selectedCellType = Map.CellType.Empty;
        GA<Living> solution;
        public frm_dash()
        {
            InitializeComponent();
            solution = new GA<Living>(100, Mate, () => new Living(Map.GenerateGnome()));
        }
        private Living Mate(Living a, Living b)
        {
            List<Map.MovementType> child_chromosome = new List<Map.MovementType>();
            int newSize = Map.rnd.Next(Math.Min(a.chromosome.Count(), b.chromosome.Count()), Math.Max(a.chromosome.Count(), b.chromosome.Count()));
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
                    if (probability < 0.40 && i < a.chromosome.Count())
                        child_chromosome.Add(a.chromosome[i]);
                    else if (probability < 0.80 && i < b.chromosome.Count())
                        child_chromosome.Add(b.chromosome[i]);
                    else if (probability < 0.95)
                        child_chromosome.Add(Map.MutateGene());
                }
            }
            return new Living(child_chromosome);
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
                var best = solution.GetBestContender();
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
                this.btn_start.Text = "Stop";
                timer.Start();
            }
            else
            {
                timer.Stop();
                this.btn_start.Text = "Start";
                solution.ResetPopulation();
                this.generationCounter = 0;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Point pointOfClick = ((MouseEventArgs)e).Location;
            Map.harta[pointOfClick.X / (pbox_map.Width /Map.mapSize), pointOfClick.Y / (pbox_map.Height/ Map.mapSize)] = selectedCellType;
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
            solution.Eval();
            this.lbl_best.Text = "Best score: "+solution.GetBestContender().fitness + " \nGeneration number: " + generationCounter++;
            if(generationCounter%10==0)
                DrawMap(true);
        }
    }
}
