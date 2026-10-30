using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngryBirds
{
    class Ball : PictureBox
    {
        protected int radius = 40;

        protected int dx, dy;
        Random rand = new Random();

        public Ball(int x, int y)
        {
            Width = radius * 2;
            Height = radius * 2;
            Image = Image.FromFile("images/red.png");
            SizeMode = PictureBoxSizeMode.StretchImage;
            

            Left = x - radius;
            Top = y - radius;

            dx = rand.Next(-5, 6);
            dy = rand.Next(-5, 6);

        }


        public virtual void Move(int width, int height)
        {
            Left += dx;
            Top += dy;
        }
    }


    class BlueBall : Ball
    {
        public BlueBall(int x, int y) : base(x, y)
        {
            Image = Image.FromFile("images/blue.png");
        }


        public override void Move(int width, int height)
        {
            base.Move(width, height);

            if (Left < 0 || Right > width)
            {
                dx = -dx;
            }

            if (Top < 0 || Bottom > height)
            {
                dy = -dy;
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
            Image = Image.FromFile("images/green.png");
        }


        public override void Move(int width, int height)
        {
            if (!fallBall)
            {
                speedY += gravity;
                dy = (int)speedY;

               Top += dy;
            }
            if (Bottom >= height)
            {
                Top = height - Height;
                fallBall = true;
                dy = 0;
            }
        }
    }


}
