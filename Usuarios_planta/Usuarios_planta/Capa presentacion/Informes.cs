using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Usuarios_planta.Capa_presentacion;

namespace Usuarios_planta.Formularios
{
    public partial class Informes : Form
    {

        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");

        Comandos cmds = new Comandos();
        

        public Informes()
        {
            InitializeComponent();
        }

        private void Btn_busqueda_Click(object sender, EventArgs e)
        {
            cmds.Informe_Ckl(dgv_informes,cmbinformes,dtpinicio,dtpfinal);
        }

        private void ExportarDatos(DataGridView dgv_informes)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
                excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
                int IndiceColumna = 0;
                foreach (DataGridViewColumn columna in dgv_informes.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                {
                    IndiceColumna++;
                    excel.Cells[1, IndiceColumna] = columna.Name;
                    excel.Cells[1, IndiceColumna].Font.Bold = true;
                    excel.Cells[1, IndiceColumna].Interior.Color = System.Drawing.Color.FromArgb(219, 229, 241);
                }
                int IndiceFila = 0;
                foreach (DataGridViewRow fila in dgv_informes.Rows) //Aquí leemos las filas de las columnas leídas
                {
                    IndiceFila++;
                    IndiceColumna = 0;
                    foreach (DataGridViewColumn columna in dgv_informes.Columns)
                    {
                        IndiceColumna++;
                        excel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                    }
                }
                excel.Columns.AutoFit();
                excel.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("No hay Registros a Exportar.");
            }
        }

        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgv_informes);
        }
    }
}
