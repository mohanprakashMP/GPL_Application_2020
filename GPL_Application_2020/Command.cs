using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;

namespace GPL_Application_2020
{
    public class Command
    {

        int mouseX;
        int mouseY;
        int xaxis;
        int yaxis;
        float radius = 0;

        String[] command = { "moveto", "drawto" };
        String[] shapes = { "circle", "rectangle", "triangle" };
        String[] variables = { "width", "height", "radius", "hypotenus"};

        public void Commandline(string textcmd, Graphics g)
        {
          
                try
                {
                    textcmd = Regex.Replace(textcmd, @"\s+", " ");
                    string[] words = textcmd.Split(' ');
                    //removing white spaces in between words
                    for (int i = 0; i < words.Length; i++)
                    {
                        words[i] = words[i].Trim();
                    }
                    String firstWord = words[0].ToLower();
                    Boolean firstWordcom = command.Contains(firstWord);
                    if (firstWordcom)
                    {
                        if (firstWord == "moveto")
                        {
                            String args = textcmd.Substring(6, (textcmd.Length - 6));
                            String[] parms = args.Split(',');
                            for (int i = 0; i < parms.Length; i++)
                            {
                                parms[i] = parms[i].Trim();
                            }
                            mouseX = int.Parse(parms[0]);
                            mouseY = int.Parse(parms[1]);
                            g.TranslateTransform(mouseX, mouseY);
                        }
                        else if (firstWord == "drawto")
                        {
                            String args = textcmd.Substring(6, (textcmd.Length - 6));
                            String[] parms = args.Split(',');
                            for (int i = 0; i < parms.Length; i++)
                            {
                                parms[i] = parms[i].Trim();
                            }
                            xaxis = int.Parse(parms[0]);
                            yaxis = int.Parse(parms[1]);
                            g.TranslateTransform(xaxis, yaxis);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            public void Shapecommand(string textcmd, Graphics g)
            {
                try
                {
                    textcmd = Regex.Replace(textcmd, @"\s+", " ");
                    string[] words = textcmd.Split(' ');
                    //removing white spaces in between words
                    for (int i = 0; i < words.Length; i++)
                    {
                        words[i] = words[i].Trim();
                    }
                    String firstWord = words[0].ToLower();
                    Boolean firstWordShape = shapes.Contains(firstWord);
                    ShapeFactory sf = new ShapeFactory();
                    if (firstWordShape)
                    {
                        if (firstWord == "circle")
                        {
                            Boolean secondwordvariable = variables.Contains(words[1].ToLower());
                            if (secondwordvariable)
                            {
                                if (words[1].ToLower().Equals("radius"))
                                {
                                    IShape sh = sf.Getshape("circle");
                                    sh.GetValue(0, 0, 0, radius);
                                    sh.Draw(g, xaxis, yaxis);
                                }
                            }
                            else
                            {
                                IShape sh = sf.Getshape("circle");
                                sh.GetValue(0, 0, 0, float.Parse(words[1]));
                                sh.Draw(g, xaxis, yaxis);
                            }
                        }
                        else if (firstWord == "rectangle")
                        {
                            String args = textcmd.Substring(9, (textcmd.Length - 9));
                            String[] parms = args.Split(',');
                            for (int i = 0; i < parms.Length; i++)
                            {
                                parms[i] = parms[i].Trim();
                            }

                            float secondvariable = float.Parse(parms[0]);
                            float thirdvariable = float.Parse(parms[1]);

                            IShape shc = sf.Getshape("rectangle");
                            shc.GetValue(secondvariable, thirdvariable, 0, 0);
                            shc.Draw(g, xaxis, yaxis);
                        }
                        else if (firstWord == "triangle")
                        {
                            String args = textcmd.Substring(8, (textcmd.Length - 8));
                            String[] parms = args.Split(',');
                            for (int i = 0; i < parms.Length; i++)
                            {
                                parms[i] = parms[i].Trim();
                            }

                            float secondvar = float.Parse(parms[0]);
                            float thirdvar = float.Parse(parms[1]);
                            float fourth = float.Parse(parms[2]);

                            IShape shp = sf.Getshape("triangle");
                            shp.GetValue(secondvar, thirdvar, fourth, 0);
                            shp.Draw(g, xaxis, yaxis);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
