using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku_Atestat
{
    internal class AdvancedGraphics
    {
        private Form container;
        //private Graphics gr;
        private Brush br;

        private int polygonNr = 50;
        private double angle = -15;
        private int polWidth = 3;
        private int polHeight = 200; //30;

        private int containerW, containerH;

        private double stepDx, stepDy, step = 4;

        private List<PointF[]> polygons = new List<PointF[]>();

        private Timer updateTimer = new Timer();
        private Random rand = new Random();

        public AdvancedGraphics(Form c)
        {
            container = c;
            updateTimer.Interval = 20;
            updateTimer.Tick += update;
            //gr = c.CreateGraphics();
            br = new SolidBrush(Color.Magenta); //Color.FromArgb(192, 157, 194)); // 50 alpha

            containerW = container.Width;
            containerH = container.Height;

            stepDx = Cos(angle) * step;
            stepDy = -Sin(angle) * step;
            //Console.WriteLine("{0} {1}",stepDx, stepDy);

            createPolygons();

            c.Paint += (o, e) =>
            {
                foreach (var poly in polygons)
                    movePolygon(poly);
                drawPoligons(e.Graphics);
            };

            updateTimer.Start();
        }

        private void update(object sender, EventArgs e)
        {
            //container.Refresh();
            container.Invalidate();
        }

        private void movePolygon(PointF[] polygon) // 4 pointF's inside
        {
            float[] rectangleBounds = getRectangularBounds(polygon); // xmin xmax ymin ymax
            //foreach (var x in rectangleBounds) Console.Write($"{x}  ");
            //Console.WriteLine();

            float width = rectangleBounds[1] - rectangleBounds[0];
            float height = rectangleBounds[3] - rectangleBounds[2];

            for (int i = 0; i < 4; i++) {
                PointF pf = polygon[i];

                //polygon[i] = new PointF((float)(pf.X + stepDx), (float)(pf.Y + stepDy));

                if (rectangleBounds[1] < 0) // xmax < 0, tp at the right of the screen
                    polygon[i] = new PointF((float)(pf.X + stepDx + containerW + width), (float)(pf.Y + stepDy));

                else if (rectangleBounds[0] > containerW) // xmin > width, tp at the left of the screen
                    polygon[i] = new PointF((float)(pf.X + stepDx - containerW - width), (float)(pf.Y + stepDy));

                else if (rectangleBounds[3] < 0) // ymax < 0, tp at the bottom of the screen
                    polygon[i] = new PointF((float)(pf.X + stepDx), (float)(pf.Y + stepDy + width + containerH));

                else if (rectangleBounds[2] > containerH) // ymin > height, tp at the top of the screen
                    polygon[i] = new PointF((float)(pf.X + stepDx), (float)(pf.Y + stepDy - width - containerH));

                else
                    polygon[i] = new PointF((float)(pf.X + stepDx), (float)(pf.Y + stepDy));
            }
        }

        private void createPolygons()
        {
            for(int i = 0; i < polygonNr; i++)
            {
                int startx = rand.Next(1,container.Width);
                int starty = rand.Next(1,container.Height);

                PointF p1 = new PointF(startx, starty); // stanga sus
                PointF p2 = new PointF((float)(startx + polWidth / Sin(angle)), starty); // dreapta sus
                PointF p3 = new PointF((float)(startx - Cos(angle) * polHeight), (float)(starty + Sin(angle) * polHeight)); // stanga jos
                PointF p4 = new PointF((float)(startx + polWidth / Sin(angle) - Cos(angle) * polHeight), (float)(starty + Sin(angle) * polHeight)); // dreapta jos

                //Console.WriteLine($"p1: {p1} \np2: {p2} \np3: {p3} \np4: {p4}");
                polygons.Add(new PointF[] { p1, p2, p4, p3 });
            }
        }

        private void drawPoligons(Graphics gr)
        {
            //container.Refresh();
            foreach(var poly in polygons)
                gr.FillPolygon(br, poly);
        }

        private float[] getRectangularBounds(PointF[] poly)
        {
            float xmin = int.MaxValue, ymin = int.MaxValue, xmax = int.MinValue, ymax = int.MinValue;
            for(int i = 0; i < 4; i++)
            {
                PointF p = poly[i];
                xmin = Math.Min(xmin, p.X);
                xmax = Math.Max(xmax, p.X);

                ymin = Math.Min(ymin, p.Y);
                ymax = Math.Max(ymax, p.Y);
            }

            return new float[] { xmin, xmax, ymin, ymax };
        }

        private double Rad(double x) => x * Math.PI / 180;
        private double Sin(double x) => Math.Sin(Rad(x));
        private double Cos(double x) => Math.Cos(Rad(x));
    }
}