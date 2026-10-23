using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds
{
    class Ball
    {
        public int radius = 20;

        public int x, y;

        public int dx, dy;
        Random rand = new Random();

        public Ball(int x, int y)
        {
            this.x = x;
            this.y = y;
            dx = rand.Next(-5, 6);
            dy = rand.Next(-5, 6);

        }

        public virtual void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Red, x, y, radius * 2, radius * 2);
        }

        public virtual void Move(int width, int height)
        {
            x += dx;
            y += dy;
        }
    }


    class BlueBall : Ball
    {
        public BlueBall(int x, int y) : base(x, y)
        {

        }

        public virtual void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Blue, x - radius, y - radius, radius * 2, radius * 2);
        }

        public override void Move(int width, int height)
        {
            base.Move(width, height);

            if (x < 0 || x + radius * 2 > width)
            {
                dx = -dx;
                x += dx;
            }

            if (y < 0 || y + radius * 2 > height)
            {
                dy = -dy;
                y += dy;
            }
        }
    }

    class GreenBall : Ball 
    {
        double gravity = 0.8;
        double speedY = -10;

        bool fallBall = false;

        public GreenBall(int x, int y): base(x, y)
        {

        }

        public virtual void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Green, x - radius, y - radius, radius * 2, radius * 2);
        }

        public override void Move(int width, int height)
        {
            if (!fallBall)
            {
                speedY += gravity;
                dy = (int)speedY;

                y += dy;
            }
            if (y + radius >= height)
            {
                y = height - radius;
                fallBall = true;
                dy = 0;
            }
        }
    }


}
