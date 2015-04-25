using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;






namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //   [DllImport("user32.dll", EntryPoint = "GetDC")]
        //     public static extern IntPtr GetDC(IntPtr hWnd);
        // private Graphics g_desktop = null;

        bool isOverlayed;
        Boolean bHaveMouse;
        Point ptOriginal = new Point();
        Point ptLast = new Point();

        UserRect rect;
        
        bool choose = false;
        int x, y, lx, ly = 0;
        Color paintColor = Color.Brown;

//        PictureBox PictureBox1;



        bool isDrag = false;
        Rectangle theRectangle = new Rectangle
            (new Point(0, 0), new Size(0, 0));
        Point startPoint;


        // one example 'object'
        Rectangle R0 = new Rectangle(182, 82, 31, 31);

        // a few helpers
        Point curMouse = Point.Empty;
        Point downMouse = Point.Empty;
        Rectangle RM = Rectangle.Empty;

        float angle = 30;
        Point center = new Point(-55, -22);


        public Form1()
        {
            InitializeComponent();
            isOverlayed = false;
            this.pictureBox1.Size = new Size(1,1);
            this.pictureBox1.Hide();
      //      bHaveMouse = false;
        }
  
        private void Form1_Load(object sender, EventArgs e)
        {
            Screen rightmost = Screen.AllScreens[0]; // .SystemParameters.WorkArea;
            var desktopWorkingArea = rightmost.WorkingArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Top + this.Height;



            this.Size = new Size(35,35);

            this.BackColor = Color.Yellow;

            this.DoubleBuffered = true;

            this.pictureBox1.Size = new Size(this.Width, this.Height);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
//            pictureBox1.BackColor = Color.Green;

        }

        private void Form1_Click(object sender, EventArgs e)
        {
//            this.BackColor = Color.Red;
            isOverlayed = true;
            overlay();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            if(isOverlayed)
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        void overlay()
        {
            WindowState = FormWindowState.Maximized;
            Form2 f2 = new Form2();
            

            if ( isOverlayed )
            {
                this.MaximizeBox = true;
             

                this.pictureBox1.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                this.pictureBox1.MaximumSize = new System.Drawing.Size(this.MaximizedBounds.Width, this.MaximizedBounds.Height);
                this.pictureBox1.Show();
                this.BackColor = Color.Yellow;
                this.Opacity = .5;
                this.TransparencyKey = Color.Blue;
                this.TopMost = false;

                f2.TopMost = true;
                f2.Width = 30;
                f2.Show();

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Form1_DoubleClick(sender, e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           // MessageBox.Show( " drawing =  " + CommonProperties.drawing.ToString() );
//            mPictureBox_MouseMove
            if ( isOverlayed )
            {
                if( CommonProperties.drawing )
                {
                    x = e.X;
                    y = e.Y;
                }
                else
                {
                    Rectangle rc = new Rectangle(Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    rect = new UserRect(rc, this.TransparencyKey);
                    rect.SetPictureBox(this.pictureBox1);
                    rect.mPictureBox_MouseDown(sender, e);
                } 
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (CommonProperties.drawing) 
            {
                lx = e.X;
                ly = e.Y;
                if ( CommonProperties.currItem == CommonProperties.Item.Line)
                { 
                        Graphics g = pictureBox1.CreateGraphics();
                        g.DrawLine(new Pen(new SolidBrush(Color.Red)), new Point(x, y), new Point(lx, ly));
                        g.Dispose()
                }
                else if( CommonProperties.currItem == CommonProperties.Item.Ellipse )
                {

                }
                else if(CommonProperties.currItem == CommonProperties.Item.Rectangle)
                {

                }
            
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //TODO: make picturebox size equal to the selected region size;
            
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }




        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }
    }
}



