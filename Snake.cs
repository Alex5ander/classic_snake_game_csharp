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
            x += dir[0];
            y += dir[1];
            int bx = x;
            int by = y;
            int i = 0;
            while (tails[i] != null)
            {
                int tx = tails[i][0];
                int ty = tails[i][1];

                tails[i][0] = bx;
                tails[i][1] = by;

                bx = tx;
                by = ty;

                g.FillRectangle(brush, tails[i][0] * 8, tails[i][1] * 8, 8, 8);
                g.DrawRectangle(pen, tails[i][0] * 8, tails[i][1] * 8, 8, 8);
                i++;
            }

        }

        public bool collideBounds()
        {
            return x == 0 || x == 31 || y == 0 || y == 29;
        }
    }
}
