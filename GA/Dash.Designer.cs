namespace GA
{
    partial class frm_dash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_best = new System.Windows.Forms.Label();
            this.pbox_map = new System.Windows.Forms.PictureBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_bomb = new System.Windows.Forms.Button();
            this.btn_coin = new System.Windows.Forms.Button();
            this.btn_wall = new System.Windows.Forms.Button();
            this.btn_empty = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_map)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_best
            // 
            this.lbl_best.AutoSize = true;
            this.lbl_best.Font = new System.Drawing.Font("NeoSans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_best.Location = new System.Drawing.Point(12, 415);
            this.lbl_best.Name = "lbl_best";
            this.lbl_best.Size = new System.Drawing.Size(0, 21);
            this.lbl_best.TabIndex = 1;
            // 
            // pbox_map
            // 
            this.pbox_map.Location = new System.Drawing.Point(12, 12);
            this.pbox_map.Name = "pbox_map";
            this.pbox_map.Size = new System.Drawing.Size(400, 400);
            this.pbox_map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_map.TabIndex = 2;
            this.pbox_map.TabStop = false;
            this.pbox_map.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(418, 360);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(67, 52);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.Btn_start_Click);
            // 
            // btn_bomb
            // 
            this.btn_bomb.BackColor = System.Drawing.Color.Red;
            this.btn_bomb.Location = new System.Drawing.Point(418, 12);
            this.btn_bomb.Name = "btn_bomb";
            this.btn_bomb.Size = new System.Drawing.Size(67, 52);
            this.btn_bomb.TabIndex = 4;
            this.btn_bomb.Text = "Bomb";
            this.btn_bomb.UseVisualStyleBackColor = false;
            this.btn_bomb.Click += new System.EventHandler(this.Btn_bomb_Click);
            // 
            // btn_coin
            // 
            this.btn_coin.BackColor = System.Drawing.Color.Yellow;
            this.btn_coin.Location = new System.Drawing.Point(418, 70);
            this.btn_coin.Name = "btn_coin";
            this.btn_coin.Size = new System.Drawing.Size(67, 52);
            this.btn_coin.TabIndex = 5;
            this.btn_coin.Text = "Coin";
            this.btn_coin.UseVisualStyleBackColor = false;
            this.btn_coin.Click += new System.EventHandler(this.Btn_coin_Click);
            // 
            // btn_wall
            // 
            this.btn_wall.BackColor = System.Drawing.Color.Gray;
            this.btn_wall.Location = new System.Drawing.Point(418, 128);
            this.btn_wall.Name = "btn_wall";
            this.btn_wall.Size = new System.Drawing.Size(67, 52);
            this.btn_wall.TabIndex = 6;
            this.btn_wall.Text = "Wall";
            this.btn_wall.UseVisualStyleBackColor = false;
            this.btn_wall.Click += new System.EventHandler(this.Btn_wall_Click);
            // 
            // btn_empty
            // 
            this.btn_empty.BackColor = System.Drawing.Color.White;
            this.btn_empty.Location = new System.Drawing.Point(418, 186);
            this.btn_empty.Name = "btn_empty";
            this.btn_empty.Size = new System.Drawing.Size(67, 52);
            this.btn_empty.TabIndex = 7;
            this.btn_empty.Text = "Empty";
            this.btn_empty.UseVisualStyleBackColor = false;
            this.btn_empty.Click += new System.EventHandler(this.Btn_empty_Click);
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // frm_dash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 468);
            this.Controls.Add(this.btn_empty);
            this.Controls.Add(this.btn_wall);
            this.Controls.Add(this.btn_coin);
            this.Controls.Add(this.btn_bomb);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.pbox_map);
            this.Controls.Add(this.lbl_best);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_dash";
            this.Text = "GA";
            this.Load += new System.EventHandler(this.Frm_dash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_best;
        private System.Windows.Forms.PictureBox pbox_map;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_bomb;
        private System.Windows.Forms.Button btn_coin;
        private System.Windows.Forms.Button btn_wall;
        private System.Windows.Forms.Button btn_empty;
        private System.Windows.Forms.Timer timer;
    }
}

