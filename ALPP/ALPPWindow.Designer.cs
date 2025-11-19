


using System.Windows.Forms;

namespace ALPP
{
    partial class ALPPWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            joystickBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)joystickBox).BeginInit();
            SuspendLayout();
            ClientSize = new Size(2457, 1252);
            // 
            // button1
            // 
            button1.Font = new Font("Bahnschrift", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(1934, 92);
            button1.Name = "button1";
            button1.Size = new Size(330, 122);
            button1.TabIndex = 0;
            button1.Text = "PDF Laden";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(1934, 252);
            button2.Name = "button2";
            button2.Size = new Size(330, 122);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(1934, 418);
            button3.Name = "button3";
            button3.Size = new Size(330, 122);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(1934, 585);
            button4.Name = "button4";
            button4.Size = new Size(330, 122);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // joystickBox
            // 
            joystickBox.BackgroundImage = Properties.Resources.Joystick;
            joystickBox.BackgroundImageLayout = ImageLayout.Center;
            joystickBox.Image = Properties.Resources.SmallHandleFilled;
            joystickBox.Location = new Point(ClientSize.Width - 463, ClientSize.Height - 463);
            joystickBox.Name = "joystickBox";
            joystickBox.Size = new Size(463, 463);
            joystickBox.SizeMode = PictureBoxSizeMode.CenterImage;
            joystickBox.TabIndex = 4;
            joystickBox.TabStop = false;
            joystickBox.Paint += PaintJoystick;
            joystickBox.MouseDown += DownJoystick;
            joystickBox.MouseMove += MoveJoystick;
            joystickBox.MouseUp += UpJoystick;
            // 
            // ALPPWindow
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            
            Controls.Add(joystickBox);
            
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
           
            Name = "ALPPWindow";
            Text = "ALPP";
            Resize += ResizeWindow;
            this.MinimumSize = new Size((int)(Screen.FromControl(this).Bounds.Width * 0.52f), (int)(Screen.FromControl(this).Bounds.Height * 0.52f));
            ((System.ComponentModel.ISupportInitialize)joystickBox).EndInit();
            ResumeLayout(false);
        }
        private void ResizeWindow(object sender, EventArgs e)
        {
            int buttonCounter = 0;
            foreach(var c in Controls)
            {
                int padding = 60;

                if (c is Button b)
                {
                    buttonCounter++;
                    b.Location = new Point(Width - Width / 7 - padding, ((Height / 11) + padding/2) * buttonCounter);
                    b.Size = new Size(Width / 7, Height / 11);
                }
                if(c is PictureBox pB) 
                {
                    pB.Location = Width > Height ? 
                        new Point(Width - Width / 6 - padding, (int)(Height - (Width / 6) - (padding*1.3f))) :
                        new Point((int)(Width - Height / 6 - (padding)), (int)(Height - (Height / 6) - (padding * 1.3f)));

                    pB.Size = Width > Height ? new Size(Width / 6, Width / 6) : new Size(Height / 6, Height / 6);
                    joystickPos = new Point(joystickBox.Width / 2 - Properties.Resources.SmallHandleFilled.Width / 2, joystickBox.Height / 2 - Properties.Resources.SmallHandleFilled.Height / 2);
                    joystickBox.Invalidate();
                }
            }
        }
        private void UpJoystick(object sender, MouseEventArgs e)
        {
            isDragging = false;
            joystickPos = new Point(joystickBox.Width/2 - Properties.Resources.SmallHandleFilled.Width / 2, joystickBox.Height / 2 - Properties.Resources.SmallHandleFilled.Height / 2);
            joystickBox.Invalidate();
        }

        private void MoveJoystick(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int padding = Properties.Resources.SmallHandleFilled.Width/2 , 
                x = e.Location.X , 
                y = e.Location.Y ;

                x = x < padding ? padding : x;
                x = x > joystickBox.Width - padding ? joystickBox.Width - padding : x;
                y = y < padding ? padding : y;
                y = y > joystickBox.Height - padding ? joystickBox.Height - padding : y;

                joystickPos = new Point(x - Properties.Resources.SmallHandleFilled.Width / 2, y - Properties.Resources.SmallHandleFilled.Height / 2);

                // translation, sodass mittelpunkt click = 0, 0
                int dx = (e.Location.X - joystickBox.Height / 2);
                int dy = (e.Location.Y - joystickBox.Height / 2);

                int cutX = dx < padding - joystickBox.Width / 2 ? padding - joystickBox.Width / 2 : dx;
                cutX = dx > joystickBox.Width - padding - joystickBox.Width / 2 ? joystickBox.Width - padding - joystickBox.Width / 2 : cutX;

                int cutY = dy < padding - joystickBox.Width / 2 ? padding - joystickBox.Width / 2 : dy;
                cutY = dy > joystickBox.Width - padding - joystickBox.Width / 2 ? joystickBox.Width - padding - joystickBox.Width / 2 : cutY;

                double res = Math.Sqrt(Math.Pow(cutX, 2) + Math.Pow(cutY, 2)) / (joystickBox.Width - (padding * 2));

                // floating point korrektur
                // intervall von 0.07 -> 0.4875
                float tolerance = 0.0125f; 
                res = (res > 0.5f - tolerance) ? 0.5f : res;
                float deadzone = 0.07f;
                res = (res < deadzone) ? 0 : res;
                Console.WriteLine("Delta : " + res + " " + cutX + " " +cutY);

                joystickBox.Invalidate();
            }
        }

        private void PaintJoystick(object sender, PaintEventArgs e)
        {
            joystickPos = joystickPos.X == -1 ? new Point(joystickBox.Width / 2 - Properties.Resources.SmallHandleFilled.Width / 2, joystickBox.Height / 2 - Properties.Resources.SmallHandleFilled.Height / 2) : joystickPos;
            e.Graphics.DrawLine(
                new Pen(Color.Black, 5), 
                new Point(joystickBox.Width / 2 , joystickBox.Height / 2 ), 
                new Point(joystickPos.X + Properties.Resources.SmallHandleFilled.Width / 2, joystickPos.Y + Properties.Resources.SmallHandleFilled.Height / 2)
            );
            e.Graphics.DrawImage(joystickBox.Image, joystickPos);
        }

        private void DownJoystick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("" + e.Location + " " + joystickBox.Bounds);
            isDragging = true;
        }

        #endregion

        private bool isDragging = false;
        private Point joystickPos = new Point(-1,-1);

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private PictureBox joystickBox;
    }
}
