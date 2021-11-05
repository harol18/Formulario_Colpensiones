using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Usuarios_planta.Capa_presentacion
{
    public partial class cartera_colpensiones : Form
    {

        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");

        Comandos cmds = new Comandos();
        public cartera_colpensiones()
        {
            InitializeComponent();
        }

        private void BtnCarteras_colpensiones_Click(object sender, EventArgs e)
        {
            dgv_cartera_colpensiones.Columns.Clear();
            cmds.cartera_colpensiones(dgv_cartera_colpensiones);
            dgv_cartera_colpensiones.Columns.Add("Cruce Pagare", "Cruce Pagare");
            dgv_cartera_colpensiones.Columns.Add("Cuota", "Cuota");
            dgv_cartera_colpensiones.Columns.Add("Estado_Cuota", "Estado_Cuota");
            foreach (DataGridViewRow row in dgv_cartera_colpensiones.Rows)
            {

                string Pagare_Contabilizados = row.Cells["Pagare Contabilizados"].Value.ToString();
                string Pagare_Recaudos = row.Cells["Pagare Recaudos"].Value.ToString();
                string Cuota_Contabilizados = row.Cells["Cuota Contabilizados"].Value.ToString();
                string Cuota_recaudos = row.Cells["Cuota recaudos"].Value.ToString();
                string Estado_Cuota = row.Cells["Diferencia Cuota"].Value.ToString();


                if (Pagare_Recaudos == "")
                {
                    row.Cells["Cruce Pagare"].Value = "Sin Descuento";                    
                }
                else if (Pagare_Recaudos != "")
                {
                    if (Pagare_Contabilizados == Pagare_Recaudos)
                    {
                        row.Cells["Cruce Pagare"].Value = "Verdadero";
                    }
                    else
                    {
                        row.Cells["Cruce Pagare"].Value = "Falso";
                    }
                }

                if (Cuota_recaudos == "")
                {
                    row.Cells["Cuota"].Value = "Sin Descuento";
                }
                else if (Cuota_recaudos != "")
                {
                    if (Cuota_Contabilizados == Cuota_recaudos)
                    {
                        row.Cells["Cuota"].Value = "Igual";
                    }
                    else
                    {
                        row.Cells["Cuota"].Value = "Diferente";
                    }
                }

                if (Estado_Cuota != "")
                {
                    if (Convert.ToInt32(Estado_Cuota) > 1000)
                    {
                        row.Cells["Estado_Cuota"].Value = "Mayor Valor";
                    }
                    else
                    {
                        row.Cells["Estado_Cuota"].Value = "Menor Valor";
                    }
                }
                else if (Estado_Cuota == "")
                {
                    row.Cells["Estado_Cuota"].Value = "Sin Descuento";
                }
            }
        }

        private void btnDescargar_Txt_Click(object sender, EventArgs e)
        {
            //Esta línea de código crea un archivo de texto para la exportación de datos.
            //StreamWriter file = new StreamWriter(@"C:\\Users\\BBVA\\Desktop\\Colpensiones\\" + "base_desembolso.txt");
            StreamWriter file = new StreamWriter(@"D:\\Cartera Colpensiones\\" + "carteras_colpensiones.txt");
            try
            {
                string sLine = "";
                //Este bucle for recorre cada fila de la tabla
                for (int r = 0; r <= dgv_cartera_colpensiones.Rows.Count - 1; r++)
                {
                    //Este bucle for recorre cada columna y el número de fila
                    //se pasa desde el bucle for arriba.
                    for (int c = 0; c <= dgv_cartera_colpensiones.Columns.Count - 1; c++)
                    {
                        sLine = sLine + dgv_cartera_colpensiones.Rows[r].Cells[c].Value;
                        if (c != dgv_cartera_colpensiones.Columns.Count - 1)
                        {
                            //Una coma se agrega como delimitador de texto para
                            //para separar cada campo en el archivo de texto.
                            //Puede elegir otro carácter como delimitador, para este caso no se pone delimitador dado
                            //que el plano va toda la informacion pegada sin espacios ni caracteres.
                            sLine = sLine + "|";
                        }
                    }
                    //El texto exportado se escribe en el archivo de texto, una línea a la vez.
                    file.WriteLine(sLine);
                    sLine = "";
                }

                file.Close();
                MessageBox.Show("Ok archivo plano creado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                file.Close();
            }
        }
    }
}
