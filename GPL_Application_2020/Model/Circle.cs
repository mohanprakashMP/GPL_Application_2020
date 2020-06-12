using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GPL_Application_2020
{

    /// <summary>
    /// circle class
    /// </summary>
    public class Circle:IShape
    {
        private float rad;
        public void GetValue(float width, float height, float hypotenus, float radius)
        {
            rad = radius;
        }

        /// <summary>
        /// draw function
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Draw(Graphics g, int x, int y)
        {
            //SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawEllipse(new Pen(Color.Black, 5), x, y, rad, rad);
            //g.FillEllipse(sb, 100, 100, 100, 100);// int.Parse(txtshapesize.Text), int.Parse(txtshapesize.Text));
        }

    }
}
