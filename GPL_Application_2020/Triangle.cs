using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System. Drawing;

namespace GPL_Application_2020
{
   public  class Triangle : IShape
    {
        private float wid;
        private float hght;
        private float hypt;
        public void GetValue(float width, float height, float hypotenus, float radius)


        {
            wid = width;
            hght = height;
            hypt = hypotenus;

        }
        public Boolean checkTriangleValidity()
        {
            // check condition 
            if (wid + hght <= hypt || wid + hypt <= hght || hght + hypt <= wid)
                return false;
            else
                return true;

        }
        public void Draw(Graphics g, int x, int y)
        {
            if (checkTriangleValidity())
            {
                Pen myPen = new Pen(Color.Black, 5);
                Point[] pnt = new Point[3];

                pnt[0].X = x;
                pnt[0].Y = y;

                pnt[1].X = Convert.ToInt32(x - wid);
                pnt[1].Y = y;

                pnt[2].X = x;
                pnt[2].Y = Convert.ToInt32(y - hght);

                g.DrawPolygon(myPen, pnt);
               
            
            
            }



        }
    }
}
