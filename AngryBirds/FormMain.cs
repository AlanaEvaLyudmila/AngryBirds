using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngryBirds
{
    public partial class FormMain : Form
    {
        Ball ball = new Ball(150, 150);
        BlueBall blueball = new BlueBall(50, 50);
        GreenBall greenBall = new GreenBall(200, 150);
        public FormMain()
        {
            DoubleBuffered = true;
            InitializeComponent();
            timerBall.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ball.Draw(e.Graphics);
            blueball.Draw(e.Graphics);
            greenBall.Draw(e.Graphics);
        }

        private void timerBall_Tick(object sender, EventArgs e)
        {
            ball.Move(ClientSize.Width, ClientSize.Height);
            blueball.Move(ClientSize.Width, ClientSize.Height);
            greenBall.Move(ClientSize.Width, ClientSize.Height);
            Invalidate();
        }
    }
}
