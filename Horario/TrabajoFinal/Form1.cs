using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace TrabajoFinal
{
    public partial class Form1 : Form
    {
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MOVE = 0xF012;
        private const int HTCAPTION = 0x2;

        // Import the ReleaseCapture and SendMessage functions from user32.dll
        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private string connectionString = "Data Source=DESKTOP-2QR1BR7\\SQLEXPRESS;Initial Catalog=BD_IE_CM;Integrated Security=True;User ID=DESKTOP-2QR1BR7\\Equipo";
        private SqlConnection conn;
        public Form1()
        {
            InitializeComponent();

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                // Consulta SQL para contar estudiantes de secundaria
                string querySecundaria = "SELECT COUNT(*) FROM Estudiantes WHERE Nivel = 'Secundaria'";
                // Consulta SQL para contar estudiantes de primaria
                string queryPrimaria = "SELECT COUNT(*) FROM Estudiantes WHERE Nivel = 'Primaria'";

                using (SqlCommand commandSecundaria = new SqlCommand(querySecundaria, conn))
                using (SqlCommand commandPrimaria = new SqlCommand(queryPrimaria, conn))
                {
                    int countSecundaria = (int)commandSecundaria.ExecuteScalar(); // Estudiantes de secundaria
                    int countPrimaria = (int)commandPrimaria.ExecuteScalar(); // Estudiantes de primaria

                    // Configurar el gráfico
                    ChartArea chartArea = Cantidad.ChartAreas[0];
                    chartArea.AxisX.Title = "Nivel Académico";

                    // Crear una serie de datos
                    Series series2 = new Series("Series2");
                    series2.ChartType = SeriesChartType.Doughnut;
                    series2.IsValueShownAsLabel = true;

                    // Configurar los colores de las secciones
                    series2.Palette = ChartColorPalette.SeaGreen;
                    series2.CustomProperties = "DoughnutRadius=60, PieDrawingStyle=Concave";

                    // Agregar puntos al gráfico con las cantidades y colores adecuados
                    DataPoint dataPointSecundaria = new DataPoint();
                    dataPointSecundaria.SetValueY(countSecundaria);
                    dataPointSecundaria.Label = "Secundaria";

                    DataPoint dataPointPrimaria = new DataPoint();
                    dataPointPrimaria.SetValueY(countPrimaria);
                    dataPointPrimaria.Label = "Primaria";

                    DataPoint dataPointInicial = new DataPoint();
                    dataPointInicial.SetValueY(countPrimaria);
                    dataPointInicial.Label = "Inicial";

                    series2.Points.Add(dataPointSecundaria);
                    series2.Points.Add(dataPointPrimaria);
                    series2.Points.Add(dataPointInicial);

                    // Agregar la serie al gráfico
                    Cantidad.Series.Add(series2);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bD_IE_CMDataSet1.Estudiantes' Puede moverla o quitarla según sea necesario.
            this.estudiantesTableAdapter.Fill(this.bD_IE_CMDataSet1.Estudiantes);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnMaxi.Visible = false;
            BtnMini.Visible = true;
        }
        private void BtnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BtnMaxi.Visible = true;
            BtnMini.Visible = false;
        }
        private void BtnOcul_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void Barra_Control_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Barra_Control_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void BtnCerrar_MouseHover(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //metodo para cambiar el panel sin abrir otra ventana 
        private void AbrirFormHija(object formhija)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);

            Form formHijo = formhija as Form;
            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.Fill;
            this.Contenedor.Controls.Add(formHijo);
            this.Contenedor.Tag = formHijo;
            formHijo.Show();
        }
        //abre el form hijo
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new inicio());
        }
    }
}
