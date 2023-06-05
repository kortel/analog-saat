using System.Reflection;

namespace analog_saat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Pen yelkovanpen = new Pen(Color.Red, 3);
        Pen saniyepen = new Pen(Color.Black, 1);
        Pen akreppen = new Pen(Color.Blue, 5);
        Pen saniyes = new Pen(Color.Maroon, 3);
        Pen saats = new Pen(Color.Aqua, 7);
        void yelkovan(int x0, int y0, double r, double q, PaintEventArgs e)
        {
            e.Graphics.DrawLine(yelkovanpen, new Point(x0, y0), new Point((int)(r * Math.Cos(q * Math.PI / 180)) + x0, (int)(r * -Math.Sin(q * Math.PI / 180)) + y0));
        }
        void akrep(int x0, int y0, double r, double q, PaintEventArgs e)
        {
            e.Graphics.DrawLine(akreppen, new Point(x0, y0), new Point((int)(r * Math.Cos(q * Math.PI / 180)) + x0, (int)(r * -Math.Sin(q * Math.PI / 180)) + y0));
        }
        void saniye(int x0, int y0, double r, double q, PaintEventArgs e)
        {
            e.Graphics.DrawLine(saniyepen, new Point(x0, y0), new Point((int)(r * Math.Cos(q * Math.PI / 180)) + x0, (int)(r * -Math.Sin(q * Math.PI / 180)) + y0));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Refresh();
        }
        int fps = 60;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / fps;
            timer1.Start();
            PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            aProp.SetValue(panel1, true);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int panelw = panel1.Width / 2, panelh = panel1.Height / 2;
            int r = Math.Min(panelw, panelh);
            e.Graphics.DrawEllipse(yelkovanpen, new Rectangle((panel1.Width / 2) - (r), (panel1.Height / 2) - (r), 2 * r, 2 * r));
            for (int i = 0; i < 60; i++)
            {
                e.Graphics.DrawLine(saniyes, new Point((int)(r * Math.Cos(i * 6 * Math.PI / 180)) + panelw, (int)(r * -Math.Sin(i * 6 * Math.PI / 180)) + panelh), new Point((int)(r * 0.95 * Math.Cos(i * 6 * Math.PI / 180)) + panelw, (int)(r * 0.95 * -Math.Sin(i * 6 * Math.PI / 180) + panelh)));
                e.Graphics.DrawLine(saats, new Point((int)(r * Math.Cos(i * 30 * Math.PI / 180)) + panelw, (int)(r * -Math.Sin(i * 30 * Math.PI / 180)) + panelh), new Point((int)(r * 0.9 * Math.Cos(i * 30 * Math.PI / 180)) + panelw, (int)(r * 0.9 * -Math.Sin(i * 30 * Math.PI / 180) + panelh)));
            }
            int Ts = DateTime.Now.Second;
            int Tm = DateTime.Now.Minute;
            int Th = DateTime.Now.Hour;
            double saniyeaci = 90 - (6 * Ts);
            double yelkovanaci = 90 - ((Tm * 6) + (Ts * 0.1));
            double akrepaci = 90 - ((30 * Th) + (Tm * 0.5) + (Ts * (1 / 120)));
            yelkovan(panelw, panelh, (0.7 * r), yelkovanaci, e);
            akrep(panelw, panelh, (0.5 * r), akrepaci, e);
            saniye(panelw, panelh, (0.9 * r), saniyeaci, e);
        }
    }
}