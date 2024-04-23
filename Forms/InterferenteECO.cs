using InterferenteECO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterferenteECO.Forms
{
    public partial class InterferenteECO : Form
    {
        public string username;
        public Image background;
        Bitmap GridBackground;
        string hartaOpen;
        Bitmap bmpAddedItems;
        int width, height;
        string deflectorPosition = "leftUp";
        bool putDeflector = false;
        PointF[] pointsPlace = new PointF[4];
        List<ObiecteMatrice> obiecteMatrice = new List<ObiecteMatrice>();
        int cellX, cellY;
        Bitmap bmpDeflector;
        public InterferenteECO()
        {
            InitializeComponent();
        }

        private void InterferenteECO_Load(object sender, EventArgs e)
        {
           
            this.Text = "Interferente ECO - "+ username;
            backgroundPictureBox.BackgroundImage = background;
            GridBackground = new Bitmap(backgroundPictureBox.Width, backgroundPictureBox.Height);
            bmpAddedItems = new Bitmap(backgroundPictureBox.Width, backgroundPictureBox.Height);
            Graphics graphics0 = Graphics.FromImage(bmpAddedItems);
            graphics0.DrawImage(background,0,0, bmpAddedItems.Width, bmpAddedItems.Height);
            Graphics graphics = Graphics.FromImage(GridBackground);
            graphics.DrawImage(background, 0, 0, GridBackground.Width, GridBackground.Height);
            Pen pen = new Pen(Color.White);
             width = GridBackground.Width / 20;
             height = GridBackground.Height / 10;
            for (int i = 0; i <= 20; i++)
            {
                graphics.DrawLine(pen, i * width, 0, i * width, backgroundPictureBox.Height);
            }
            for (int i = 0; i <= 10; i++)
            {
                graphics.DrawLine(pen, 0, i * height, GridBackground.Width, i * height);
            }
            pictureBoxDeflector.Width = width;
            pictureBoxDeflector.Height = height;
            Bitmap deflector = new Bitmap(width, height);
            Graphics graphics1 = Graphics.FromImage(deflector);
            PointF[] points = new PointF[3];
            points[0] = new PointF(0, 0);
            points[1] = new PointF(width, 0);
            points[2]= new PointF(0,height);
            Brush brush = new SolidBrush(Color.White);
            graphics1.FillPolygon(brush, points);
            pictureBoxDeflector.BackgroundImage = deflector;
            

        }

        private void caroiajCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(caroiajCheckBox.Checked)
            {
               
                backgroundPictureBox.BackgroundImage= GridBackground;
            }
            else { backgroundPictureBox.BackgroundImage = bmpAddedItems; }
        }

        private void buttonIncarcaHarta_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\Users\\Miriam\\Documents\\Aplicatii C\\CSHARP Nationala\\InterferenteECO\\Resurse\\";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
               hartaOpen = openFileDialog.FileName;
            }


            Bitmap usedbmp = new Bitmap(bmpAddedItems.Width, bmpAddedItems.Height);
            Graphics graphics = Graphics.FromImage(usedbmp);
            graphics.DrawImage(background, 0, 0, bmpAddedItems.Width, bmpAddedItems.Height);
    
            using (StreamReader  reader = new StreamReader(hartaOpen))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] split = line.Split(' ');
                    if (split[0] == "Robot")
                    {
                       
                        Image robot = Image.FromFile("C:\\Users\\Miriam\\Documents\\Aplicatii C\\CSHARP Nationala\\InterferenteECO\\Resurse\\Robot\\Robot.png");
                        int width = bmpAddedItems.Width / 20;
                        int height = bmpAddedItems.Height / 10;
                        int x = Convert.ToInt32(split[1]);
                        int y = Convert.ToInt32(split[2]);
                        graphics.DrawImage(robot, (x - 1) * width, (y - 1) * height, width, height);
                        
                        ObiecteMatrice obiect = new ObiecteMatrice();
                        obiect.Obiect = "robot";
                        obiect.Location = new Point(x,y);
                        obiecteMatrice.Add(obiect);


                    }
                    if (split[0].Contains("Meduza"))
                    {
                        Image meduza = Image.FromFile("C:\\Users\\Miriam\\Documents\\Aplicatii C\\CSHARP Nationala\\InterferenteECO\\Resurse\\Meduze\\" + split[0] + ".png");
                        int width = bmpAddedItems.Width / 20;
                        int height = bmpAddedItems.Height / 10;
                        int x = Convert.ToInt32(split[1]);
                        int y = Convert.ToInt32(split[2]);
                        graphics.DrawImage(meduza, (x - 1) * width, (y - 1) * height, width, height);

                        ObiecteMatrice obiect = new ObiecteMatrice();
                        obiect.Obiect = "meduza";
                        obiect.Location = new Point(x, y);
                        obiecteMatrice.Add(obiect);


                    }
                    if (split[0] == "Hartie")
                    {
                        Image hartie = Image.FromFile("C:\\Users\\Miriam\\Documents\\Aplicatii C\\CSHARP Nationala\\InterferenteECO\\Resurse\\MaterialeReciclabile\\Hartie.png");
                        int width = bmpAddedItems.Width / 20;
                        int height = bmpAddedItems.Height / 10;
                        int x = Convert.ToInt32(split[1]);
                        int y = Convert.ToInt32(split[2]);
                        graphics.DrawImage(hartie, (x - 1) * width, (y - 1) * height, width, height);

                        ObiecteMatrice obiect = new ObiecteMatrice();
                        obiect.Obiect = "hartie";
                        obiect.Location = new Point(x, y);
                        obiecteMatrice.Add(obiect);

                    }
                    if (split[0] == "Sticla")
                    {
                        Image sticla = Image.FromFile("C:\\Users\\Miriam\\Documents\\Aplicatii C\\CSHARP Nationala\\InterferenteECO\\Resurse\\MaterialeReciclabile\\Sticla.png");
                        int width = bmpAddedItems.Width / 20;
                        int height = bmpAddedItems.Height / 10;
                        int x = Convert.ToInt32(split[1]);
                        int y = Convert.ToInt32(split[2]);
                        graphics.DrawImage(sticla, (x - 1) * width, (y - 1) * height, width, height);

                        ObiecteMatrice obiect = new ObiecteMatrice();
                        obiect.Obiect = "sticla";
                        obiect.Location = new Point(x, y);
                        obiecteMatrice.Add(obiect);

                    }
                    if (split[0] == "Plastic")
                    {
                        Image plastic = Image.FromFile("C:\\Users\\Miriam\\Documents\\Aplicatii C\\CSHARP Nationala\\InterferenteECO\\Resurse\\MaterialeReciclabile\\Plastic.png");
                        int width = bmpAddedItems.Width / 20;
                        int height = bmpAddedItems.Height / 10;
                        int x = Convert.ToInt32(split[1]);
                        int y = Convert.ToInt32(split[2]);
                        graphics.DrawImage(plastic, (x - 1) * width, (y - 1) * height, width, height);

                        ObiecteMatrice obiect = new ObiecteMatrice();
                        obiect.Obiect = "plastic";
                        obiect.Location = new Point(x, y);
                        obiecteMatrice.Add(obiect);

                    }
                }
            }

            
            Bitmap bitmap = new Bitmap(GridBackground.Width, GridBackground.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(usedbmp, 0, 0, bitmap.Width, bitmap.Height);
            Pen pen = new Pen(Color.White);
            int widthGrid = bitmap.Width / 20;
            int heightGrid = bitmap.Height / 10;
            for (int i = 0; i <= 20; i++)
            {
                g.DrawLine(pen, i * widthGrid, 0, i * widthGrid, backgroundPictureBox.Height);
            }
            for (int i = 0; i <= 10; i++)
            {
                g.DrawLine(pen, 0, i * heightGrid, bitmap.Width, i * heightGrid);
            }
            GridBackground = bitmap;
            bmpAddedItems = usedbmp;
            if (caroiajCheckBox.Checked) {
                
                backgroundPictureBox.BackgroundImage = GridBackground;
            }
            else { backgroundPictureBox.BackgroundImage = bmpAddedItems; }
           
        }

     

        private void backgroundPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (putDeflector)
            {
                if (caroiajCheckBox.Checked)
                {

                    backgroundPictureBox.BackgroundImage = GridBackground;
                }
                else { backgroundPictureBox.BackgroundImage = bmpAddedItems; }

                bmpDeflector = new Bitmap(bmpAddedItems.Width, bmpAddedItems.Height);
                Graphics graphics = Graphics.FromImage(bmpDeflector);
                graphics.DrawImage(bmpAddedItems, 0, 0, bmpAddedItems.Width, bmpAddedItems.Height);
                Point point = e.Location;
                 cellX = point.X / width;
                 cellY = point.Y / height;
                switch (deflectorPosition)
                {
                    case "leftUp":

                        pointsPlace = new PointF[3];
                        pointsPlace[0] = new PointF(cellX * width, cellY * height);
                        pointsPlace[1] = new PointF((cellX + 1) * width, cellY * height);
                        pointsPlace[2] = new PointF(cellX * width, (cellY + 1) * height);

                        break;

                    case "rightUp":

                        pointsPlace = new PointF[3];
                        pointsPlace[0] = new PointF(cellX * width, cellY * height);
                        pointsPlace[1] = new PointF((cellX + 1) * width, cellY * height);
                        pointsPlace[2] = new PointF((cellX + 1) * width, (cellY + 1) * height);

                        break;

                    case "rightDown":

                        pointsPlace = new PointF[3];
                        pointsPlace[0] = new PointF(cellX * width, (cellY + 1) * height);
                        pointsPlace[1] = new PointF((cellX + 1) * width, cellY * height);
                        pointsPlace[2] = new PointF((cellX + 1) * width, (cellY + 1) * height);

                        break;

                    case "leftDown":

                        pointsPlace = new PointF[3];
                        pointsPlace[0] = new PointF(cellX * width, cellY * height);
                        pointsPlace[1] = new PointF(cellX * width, (cellY + 1) * height);
                        pointsPlace[2] = new PointF((cellX + 1) * width, (cellY + 1) * height);
                        break;
                }

                Brush brush = new SolidBrush(Color.White);
                graphics.FillPolygon(brush, pointsPlace);
               
                if (caroiajCheckBox.Checked)
                {

                    Bitmap bitmap = new Bitmap(GridBackground.Width, GridBackground.Height);
                    Graphics g = Graphics.FromImage(bitmap);
                    g.DrawImage(bmpDeflector, 0, 0, bitmap.Width, bitmap.Height);
                    Pen pen = new Pen(Color.White);
                    int widthGrid = bitmap.Width / 20;
                    int heightGrid = bitmap.Height / 10;
                    for (int i = 0; i <= 20; i++)
                    {
                        g.DrawLine(pen, i * widthGrid, 0, i * widthGrid, backgroundPictureBox.Height);
                    }
                    for (int i = 0; i <= 10; i++)
                    {
                        g.DrawLine(pen, 0, i * heightGrid, bitmap.Width, i * heightGrid);
                    }
                    backgroundPictureBox.BackgroundImage = bitmap;
                }
                else {  backgroundPictureBox.BackgroundImage = bmpDeflector;}
            }

        }

        private void buttonAddDeflector_Click(object sender, EventArgs e)
        {
            putDeflector = true;
        }

        private void buttonCurata_Click(object sender, EventArgs e)
        {
            GridBackground = new Bitmap(backgroundPictureBox.Width, backgroundPictureBox.Height);
            bmpAddedItems = new Bitmap(backgroundPictureBox.Width, backgroundPictureBox.Height);
            Graphics graphics0 = Graphics.FromImage(bmpAddedItems);
            graphics0.DrawImage(background, 0, 0, bmpAddedItems.Width, bmpAddedItems.Height);
            Graphics graphics = Graphics.FromImage(GridBackground);
            graphics.DrawImage(background, 0, 0, GridBackground.Width, GridBackground.Height);
            Pen pen = new Pen(Color.White);
            width = GridBackground.Width / 20;
            height = GridBackground.Height / 10;
            for (int i = 0; i <= 20; i++)
            {
                graphics.DrawLine(pen, i * width, 0, i * width, backgroundPictureBox.Height);
            }
            for (int i = 0; i <= 10; i++)
            {
                graphics.DrawLine(pen, 0, i * height, GridBackground.Width, i * height);
            }
            if (caroiajCheckBox.Checked)
            {

                backgroundPictureBox.BackgroundImage = GridBackground;
            }
            else { backgroundPictureBox.BackgroundImage = bmpAddedItems; }

        }

        private void backgroundPictureBox_Click(object sender, EventArgs e)
        {
            if (putDeflector == true)
            {
                Point deflectorLoc = new Point(cellX + 1, cellY + 1);
                if (obiecteMatrice.Find(i => i.Location == deflectorLoc) == null)
                {
                    putDeflector = false;

                    Bitmap bitmap = new Bitmap(GridBackground.Width, GridBackground.Height);
                    Graphics g = Graphics.FromImage(bitmap);
                    g.DrawImage(bmpDeflector, 0, 0, bitmap.Width, bitmap.Height);
                    Pen pen = new Pen(Color.White);
                    int widthGrid = bitmap.Width / 20;
                    int heightGrid = bitmap.Height / 10;
                    for (int i = 0; i <= 20; i++)
                    {
                        g.DrawLine(pen, i * widthGrid, 0, i * widthGrid, backgroundPictureBox.Height);
                    }
                    for (int i = 0; i <= 10; i++)
                    {
                        g.DrawLine(pen, 0, i * heightGrid, bitmap.Width, i * heightGrid);
                    }
                    GridBackground = bitmap;
                    bmpAddedItems = bmpDeflector;
                    if (caroiajCheckBox.Checked)
                    {

                        backgroundPictureBox.BackgroundImage = GridBackground;
                    }
                    else { backgroundPictureBox.BackgroundImage = bmpAddedItems; }

                }
                
            }
            
               
        }

        private void buttonRoteste_Click(object sender, EventArgs e)
        {
            Bitmap deflector;
            Graphics graphics1;
            PointF[] points;
            switch (deflectorPosition)
            {
                case "leftUp": deflectorPosition = "rightUp";
                    deflector = new Bitmap(width, height);
                    graphics1 = Graphics.FromImage(deflector);
                    points = new PointF[3];
                    points[0] = new PointF(0, 0);
                    points[1] = new PointF(width, 0);
                    points[2] = new PointF(width, height);
                    Brush brush = new SolidBrush(Color.White);
                    graphics1.FillPolygon(brush, points);
                    pictureBoxDeflector.BackgroundImage = deflector;
                    break;

                case "rightUp":
                    deflectorPosition = "rightDown";
                    deflector = new Bitmap(width, height);
                    graphics1 = Graphics.FromImage(deflector);
                    points = new PointF[3];
                    points[0] = new PointF(0, height);
                    points[1] = new PointF(width, 0);
                    points[2] = new PointF(width, height);
                    brush = new SolidBrush(Color.White);
                    graphics1.FillPolygon(brush, points);
                    pictureBoxDeflector.BackgroundImage = deflector;
                    break;

                case "rightDown":
                    deflectorPosition = "leftDown";
                    deflector = new Bitmap(width, height);
                    graphics1 = Graphics.FromImage(deflector);
                    points = new PointF[3];
                    points[0] = new PointF(0,height);
                    points[1] = new PointF(0, 0);
                    points[2] = new PointF(width, height);
                    brush = new SolidBrush(Color.White);
                    graphics1.FillPolygon(brush, points);
                    pictureBoxDeflector.BackgroundImage = deflector;
                    break;

                case "leftDown":
                    deflectorPosition = "leftUp";
                    deflector = new Bitmap(width, height);
                    graphics1 = Graphics.FromImage(deflector);
                    points = new PointF[3];
                    points[0] = new PointF(0, height);
                    points[1] = new PointF(width, 0);
                    points[2] = new PointF(0, 0);
                    brush = new SolidBrush(Color.White);
                    graphics1.FillPolygon(brush, points);
                    pictureBoxDeflector.BackgroundImage = deflector;
                    break;
            }
        }
    }
}
