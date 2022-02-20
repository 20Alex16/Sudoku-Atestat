using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedEffects
{
    class Transversal_Lines
    {
        private Form container;
        private Brush br;

        private int polygonNr = 50;
        private double angle; // = 30;
        private int polWidth = 3;
        private int polHeight = 200; //30;

        private int containerW, containerH;

        private double stepDx, stepDy, step; // = 4;

        private List<PointF[]> polygons = new List<PointF[]>();

        private Timer updateTimer = new Timer();
        private Random rand = new Random();

        public Transversal_Lines(Form c, double _angle = 30, double _step = 4, Color? _color = null, int _count = 50)
        {
            container = c;
            angle = _angle;
            step = _step;
            polygonNr = _count;
            updateTimer.Interval = 20;
            updateTimer.Tick += update;
            //gr = c.CreateGraphics();
            br = new SolidBrush(_color ?? Color.Magenta); //Color.FromArgb(192, 157, 194)); // 50 alpha

            containerW = container.Width;
            containerH = container.Height;

            stepDx = Cos(angle) * step;
            stepDy = -Sin(angle) * step;
            //Console.WriteLine("{0} {1}",stepDx, stepDy);

            createPolygons();

            container.Resize += (o, e) => { containerW = container.Width; containerH = container.Height; };

            container.Paint += (o, e) =>
            {
                foreach (var poly in polygons)
                    movePolygon(poly);
                drawPolygons(e.Graphics);
            };

            updateTimer.Start();
        }

        private void update(object sender, EventArgs e)
        {
            container.Refresh();
            //container.Invalidate();
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

        private void drawPolygons(Graphics gr)
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

    class RandomParticles
    {
        private Form container;
        private Brush br;
        private int containerW, containerH;
        private Random rand;
        private Timer update;

        private int particleCount = 500;
        private double rawForce;

        private List<particle> particles;

        public RandomParticles(Form c, Color? _color = null, int pc = 500, double rf = 500)
        {
            particleCount = pc;
            rawForce = rf;
            container = c;
            container.Resize += (o, e) => { containerW = container.Width; containerH = container.Height; };
            containerW = container.Width; containerH = container.Height;

            br = new SolidBrush(_color ?? Color.White);
            rand = new Random(); rand.Next();
            particles = new List<particle>();
            update = new Timer();

            update.Interval = 30;
            update.Tick += (o, e) => container.Refresh();

            for (int i = 0; i < particleCount; i++)
            {
                double size = rand.NextDouble() * 6 + 0.1;
                particles.Add(new particle(new RectangleF(rand.Next(0, containerW), rand.Next(0, containerW), (float)size, (float)size), size * 0.07, -rand.Next(200,350)));
            }

            container.Paint += (o, e) =>
            {
                foreach (var part in particles)
                    part.update(rand, containerW, containerH, true);
                drawParticles(e.Graphics);
            };

            container.MouseMove += (o,e) => { foreach (var part in particles) part.fling(e.Location, rawForce); };

            update.Start();
        }

        private void drawParticles(Graphics gr)
        {
            foreach (var part in particles)
                gr.FillRectangle(br, part.rect);
        }
    }

    public class particle
    {
        public RectangleF rect;
        public double speed;
        public double angle;

        public particle(RectangleF rect, double speed, double angle)
        {
            this.rect = rect;
            this.speed = speed;
            this.angle = angle;
        }

        public void update(Random rand, int cW, int cH, bool useRandom)
        {
            if (useRandom)
            {
                rand.Next(); rand.Next();
                this.angle += rand.NextDouble()/10;
            }

            //this.rect.Offset((float)(Cos(this.angle) * this.speed), (float)(Sin(this.angle) * this.speed));

            if (rect.X+rect.Width < 0)
                this.rect.Offset((float)(Cos(this.angle) * this.speed) + cW + rect.Width, (float)(Sin(-this.angle) * this.speed));

            else if (rect.X > cW)
                this.rect.Offset((float)(Cos(this.angle) * this.speed) - cW - rect.Width, (float)(Sin(-this.angle) * this.speed));

            else if (rect.Y + rect.Height < 0)
                this.rect.Offset((float)(Cos(this.angle) * this.speed), (float)(Sin(-this.angle) * this.speed) + cH + rect.Height);

            else if (rect.Y > cH)
                this.rect.Offset((float)(Cos(this.angle) * this.speed), (float)(Sin(-this.angle) * this.speed) - cH - rect.Height);

            else
                this.rect.Offset((float)(Cos(this.angle) * this.speed), (float)(Sin(-this.angle) * this.speed));

            /*
            this.rect = new RectangleF(
                this.rect.X + (float)(Cos(this.angle) * this.speed),
                this.rect.Y + (float)(Sin(this.angle) * this.speed),
                this.rect.Width,
                this.rect.Height
            );*/

            //Console.WriteLine("{0}, {1}", this.rect.X, this.rect.X + (float)(Cos(this.angle) * this.speed));
        }

        public void fling(Point p, double rawForce = 400) // fling particle when hovering with mouse by them
        {
            double dist = distance(this.rect.Location, p);
            double flingForce = rawForce / (dist * dist); // de la fizica stim ca forta de atractie universala e k * 1/d^2
            double dx = flingForce * (this.rect.X - p.X);
            double dy = flingForce * (this.rect.Y - p.Y);

            this.rect.Offset((float)dx, (float)dy);
        }

        private static double distance(Point p1, Point p2) => Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        private static double distance(PointF p1, Point p2) => Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));

        private static double Rad(double x) => x * Math.PI / 180;
        private static double Sin(double x) => Math.Sin(Rad(x));
        private static double Cos(double x) => Math.Cos(Rad(x));
    }
}