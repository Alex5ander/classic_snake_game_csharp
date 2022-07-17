﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLASSIC_SNAKE_GAME
{
    public partial class Form1 : Form
    {
        Fruit fruit;
        Snake snake;
        int score;
        Graphics g;
        Graphics b;

        Color grass1 = Color.FromArgb(88, 216, 84);
        Color grass2 = Color.FromArgb(0, 184, 0);
        Color text = Color.FromArgb(252, 252, 252);
        Color brick = Color.FromArgb(64, 88, 100);

        SolidBrush brush = new SolidBrush(Color.FromArgb(0, 64, 88));
        Pen pen = new Pen(Color.FromArgb(252, 252, 252));
        Image buffer;
        byte state = 0;
        public Form1()
        {
            InitializeComponent();
            g = canvas.CreateGraphics();
            buffer = new Bitmap(256, 240);
            b = Graphics.FromImage(buffer);
            initGame();
        }

        private void initGame()
        {
            fruit = new Fruit();
            snake = new Snake();
            score = 0;
            state = 0;
            loop.Enabled = true;
        }

        private void loop_Tick(object sender, EventArgs e)
        {
            if(state == 0)
            {
                draw();
            }
        }

        private void draw()
        {
            b.Clear(Color.FromArgb(8, 8, 8));
           

            if (fruit.checkCollision(snake.x, snake.y))
            {
                fruit = new Fruit();
                score += 1;
                snake.tails[score + 2] = new int[2] { 0, 0 };
            }
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (j == 0 || i == 0 || j == 29 || i == 31)
                    {
                        brush.Color = brick;
                        pen.Color = Color.FromArgb(164, 228, 252);
                        b.FillRectangle(brush, i * 8, j * 8, 8, 8);
                        b.DrawRectangle(pen, i * 8, j * 8, 8, 8);
                    }


                }
            }

            snake.draw(b);
            fruit.draw(b);
            brush.Color = text;
            b.DrawString("Score: " + score.ToString(), this.Font, brush, 16, 16);

            if (!snake.move())
            {
                state = 2;
                brush.Color = Color.FromArgb(168, 16, 0);
                b.DrawString("Game Over", this.Font, brush, 12 * 8, 12 * 8);
                brush.Color = text;
                b.DrawString("Press Space to restart", this.Font, brush, 9 * 8, 14 * 8);
            }
            g.DrawImage(buffer, 0, 0);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && state == 2)
            {
                initGame();
            }

            if(snake.dir[0] != 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    snake.dir = new int[2] { 0, -1 };
                }
                else if (e.KeyCode == Keys.Down)
                {
                    snake.dir = new int[2] { 0, 1 };
                }
            } else if(snake.dir[1] != 0)
            {
                if (e.KeyCode == Keys.Left)
                {
                    snake.dir = new int[2] { -1, 0 };
                }
                else if (e.KeyCode == Keys.Right)
                {
                    snake.dir = new int[2] { 1, 0 };
                }
            }
        }
    }
}