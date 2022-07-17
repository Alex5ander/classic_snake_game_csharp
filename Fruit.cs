using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CLASSIC_SNAKE_GAME
{
    class Fruit
    {
        public int x { get; }
        public int y { get; }
        private SolidBrush brush;
        private Pen pen;
        private Random r = new Random();
        public Fruit() 
        {
            this.x = r.Next(1, 30);
            this.y = r.Next(1, 28);
            this.brush = new SolidBrush(Color.FromArgb(248, 56, 0));
            this.pen = new Pen(Color.FromArgb(248, 120, 88));
        }

        public void draw(Graphics g)
        {
            g.FillEllipse(this.brush, this.x * 8, this.y * 8, 8, 8);
            g.DrawEllipse(this.pen, this.x * 8, this.y * 8, 8, 8);
        }

        public bool checkCollision(int x, int y)
        {
            return this.x == x && this.y == y;
        }
    }
}
