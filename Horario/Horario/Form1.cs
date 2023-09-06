using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //centrar ventana 
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 500);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //título de la ventana
            this.Text = "Sistema de Horario";

            //PANEL1

            Panel panel1 = new Panel();
            panel1.Size = new Size(400, 500);
            //imagen
            Bitmap login_img = new Bitmap(Application.StartupPath + @"\img\Login_img.jpg");
            login_img = new Bitmap(login_img, new Size(400, 500));
            panel1.BackgroundImage = login_img;
            // Agregar el Panel al formulario
            this.Controls.Add(panel1);

            //PANEL2

            Panel panel2 = new Panel();
            panel2.Size = new Size(400, 500);
            panel2.BackColor = SystemColors.Window;
            panel2.Location = new Point(this.ClientSize.Width - panel2.Width, 0);
            //contendio del panel 2

            Label titulo = new Label();
            titulo.Text = "Bienvenidos";
            titulo.Size = new Size(200, 40);
            titulo.TextAlign = ContentAlignment.MiddleCenter;
            titulo.Font = new Font("Arial", 20);
            //calcular y centrar
            int centerX = (panel2.Width - titulo.Width) / 2;
            int centerY = 50;
            titulo.SetBounds(centerX, centerY, titulo.Width, titulo.Height);
            panel2.Controls.Add(titulo);

            //panel email

            Panel panel_email = new Panel();
            panel_email.SetBounds(50, 150, 300, 40);
            Label icon1 = new Label();
            icon1.Text = "@";
            icon1.Size = new Size(50, 40);
            icon1.Font = new Font("Arial", 20);
            icon1.Location = new System.Drawing.Point(0, 0);

            TextBox input_email = new TextBox();
            input_email.Name = "inputEmail";
            input_email.AutoSize = false;
            input_email.Size = new System.Drawing.Size(250, 30);
            input_email.Font = new Font("Arial", 15);
            input_email.Location = new System.Drawing.Point(50, 5);
            input_email.Text = "Correo electrónico";
            input_email.ForeColor = System.Drawing.Color.Gray;
            panel_email.Controls.Add(icon1);
            panel_email.Controls.Add(input_email);

            // evento para realizar acciones cuando el texto cambie
            //input_email.TextChanged += (sender, e) =>
            //{
            //    string texto = input_email.Text;
            // Realizar acciones con el texto ingresado
            //    Console.WriteLine("Texto ingresado: " + texto);
            //};

            //panel pwd

            Panel panel_pwd = new Panel();
            panel_pwd.SetBounds(50, 200, 300, 40);
            Label icon2 = new Label();
            icon2.Text = "🔐";
            icon2.Size = new Size(50, 40);
            icon2.Font = new Font("Arial", 20);
            icon2.Location = new System.Drawing.Point(0, 0);

            TextBox input_pwd = new TextBox();
            input_pwd.Name = "inputPwd";
            input_pwd.AutoSize = false;
            input_pwd.Size = new System.Drawing.Size(250, 30);
            input_pwd.Font = new Font("Arial", 15);
            input_pwd.Location = new System.Drawing.Point(50, 5);
            input_pwd.Text = "Contraseña";
            input_pwd.ForeColor = System.Drawing.Color.Gray;
            panel_pwd.Controls.Add(icon2);
            panel_pwd.Controls.Add(input_pwd);

            panel2.Controls.Add(panel_email);
            panel2.Controls.Add(panel_pwd);

            //botones 

            Button btn_login = new Button();
            btn_login.Text = "Login";
            btn_login.SetBounds(100, 280, 250, 30);
            btn_login.BackColor = Color.Blue;
            btn_login.ForeColor = Color.White;
            btn_login.Font = new Font("Arial", 12, FontStyle.Bold);
            btn_login.FlatStyle = FlatStyle.Flat;
            btn_login.FlatAppearance.BorderSize = 0;
            btn_login.Cursor = Cursors.Hand;
            panel2.Controls.Add(btn_login);

            Button btn_crear = new Button();
            btn_crear.Text = "Añadir Cuenta";
            btn_crear.SetBounds(100, 320, 250, 30);
            btn_crear.BackColor = Color.Green;
            btn_crear.ForeColor = Color.White;
            btn_crear.Font = new Font("Arial", 12, FontStyle.Bold);
            btn_crear.FlatStyle = FlatStyle.Flat;
            btn_crear.FlatAppearance.BorderSize = 0;
            btn_crear.Cursor = Cursors.Hand;
            panel2.Controls.Add(btn_crear);

            Button btn_resta = new Button();
            btn_resta.Text = "Restablecer Contraseña";
            btn_resta.SetBounds(100, 360, 250, 30);
            btn_resta.BackColor = Color.Red;
            btn_resta.ForeColor = Color.White;
            btn_resta.Font = new Font("Arial", 12, FontStyle.Bold);
            btn_resta.FlatStyle = FlatStyle.Flat;
            btn_resta.FlatAppearance.BorderSize = 0;
            btn_resta.Cursor = Cursors.Hand;
            panel2.Controls.Add(btn_resta);

            this.Controls.Add(panel2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}