using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GPL_Application_2020
{
    public interface IShape
    {
        void Draw(Graphics g, int x, int y);
        void GetValue(float width, float height, float hypotenus, float radius);
    }
}
