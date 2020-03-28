using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Application_2020
{
    public class ShapeFactory;
    public IShape Getshape(string ShapeType)
    {
        if (ShapeType == null)
        {
            return null;
        }
        if (ShapeType == ("Circle").ToLower())
        {
            return new Circle();
        }
        if (ShapeType == ("Rectangle").ToLower())
        {
            return new Rectangle();
        }
        if (ShapeType == ("Triangle").ToLower())
        {
            return new Triangle();
        }
        return null;
    }
}




















}








