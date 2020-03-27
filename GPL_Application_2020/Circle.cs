using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GPL_Application_2020
{
    public class Circle:Shape
    {
        private float rad;
        public void GetValue(float width, float height, float hypotenus, float radius)
        {
            rad = radius;
        }
        public void Draw(Graphics g, int x, int y)
        {
            //SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawEllipse(new Pen(Color.Black, 5), x, y, rad, rad);
            //g.FillEllipse(sb, 100, 100, 100, 100);// int.Parse(txtshapesize.Text), int.Parse(txtshapesize.Text));
        }

    }
}
