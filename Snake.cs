using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CLASSIC_SNAKE_GAME
{
    class Snake
    {
        public int x { get; set; }
        public int y { get; set; }

        public int[] dir = new int[2] { 1, 0 };

        public int[][] tails = new int[60000][];

        Brush brush;
        Pen pen;

        public Snake()
        {
            this.x = 16;
            this.y = 15;

            brush = new SolidBrush(Color.FromArgb(0, 184, 0));
            pen = new Pen(Color.FromArgb(0, 120, 0));
            tails[0] = new int[2] { this.x, this.y };
            tails[1] = new int[2] { this.x - 1, this.y };
            tails[2] = new int[2] { this.x - 2, this.y };
        }

        public void draw(Graphics g)
        {
            int bx = this.x;
            int by = this.y;

            for (int i = 0; i < tails.Length; i++)
            {
                if(tails[i] != null)
                {
                    int tx = tails[i][0];
                    int ty = tails[i][1];

                    tails[i][0] = bx;
                    tails[i][1] = by;

                    bx = tx;
                    by = ty;

                    g.FillRectangle(brush, tails[i][0] * 8, tails[i][1] * 8, 8, 8);
                    g.DrawRectangle(pen, tails[i][0] * 8, tails[i][1] * 8, 8, 8);
                }
            }

        }

        public bool move()
        {
            int nx = this.x + this.dir[0];
            int ny = this.y + this.dir[1];

            if ( nx < 1 || nx > 30 || ny < 1 || ny > 28)
            {
                return false;
            }else
            {
                this.x = nx;
                this.y = ny;
            }

            return true;
        }
    }
}
