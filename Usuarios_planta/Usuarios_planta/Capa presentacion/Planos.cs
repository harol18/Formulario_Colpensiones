﻿using System;
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
    public partial class Planos : Form
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");

        Comandos cmds = new Comandos();

        public Planos()
        {
            InitializeComponent(); 
        }


        private void ch_plano_alta_CheckedChanged(object sender, EventArgs e)
        {
            ch_plano_baja.Checked = false;
        }

        private void ch_plano_baja_CheckedChanged(object sender, EventArgs e)
        {
            ch_plano_alta.Checked = false;
        }

        DateTime fecha = DateTime.Now;

        private void Btn_Crear_plano_Click(object sender, EventArgs e)
        {
            if (TxtCod_plano.Text == "")
            {
                MessageBox.Show("Debe digitar el codigo del plano","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            else
            {
                if (ch_plano_alta.Checked)
                {
                    //Esta línea de código crea un archivo de texto para la exportación de datos.
                    //StreamWriter file = new StreamWriter(@"C:\\Users\\BBVA\\Desktop\\Colpensiones\\" + Txtplano_alta.Text + ".txt");
                    StreamWriter file = new StreamWriter(@"D:\\Colpensiones\\" + Txtplano_alta.Text + ".txt");
                    try
                    {
                        string sLine = "";
                        //Este bucle for recorre cada fila de la tabla
                        for (int r = 0; r <= dgv_altas.Rows.Count - 1; r++)
                        {
                            //Este bucle for recorre cada columna y el número de fila
                            //se pasa desde el bucle for arriba.
                            for (int c = 0; c <= dgv_altas.Columns.Count - 1; c++)
                            {
                                sLine = sLine + dgv_altas.Rows[r].Cells[c].Value;
                                if (c != dgv_altas.Columns.Count - 1)
                                {
                                    //Una coma se agrega como delimitador de texto para
                                    //para separar cada campo en el archivo de texto.
                                    //Puede elegir otro carácter como delimitador, para este caso no se pone delimitador dado
                                    //que el plano va toda la informacion pegada sin espacios ni caracteres.
                                    sLine = sLine + "";
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
                else if (ch_plano_baja.Checked)
                {
                    //Esta línea de código crea un archivo de texto para la exportación de datos.
                    //StreamWriter file = new StreamWriter(@"C:\\Users\\BBVA\\Desktop\\Colpensiones\\" + Txtplano_baja.Text + ".txt");
                    StreamWriter file = new StreamWriter(@"D:\\Colpensiones\\" + Txtplano_baja.Text + ".txt");
                    try
                    {
                        string sLine = "";
                        //Este bucle for recorre cada fila de la tabla
                        for (int r = 0; r <= dgv_bajas.Rows.Count - 1; r++)
                        {
                            //Este bucle for recorre cada columna y el número de fila
                            //se pasa desde el bucle for arriba.
                            for (int c = 0; c <= dgv_bajas.Columns.Count - 1; c++)
                            {
                                sLine = sLine + dgv_bajas.Rows[r].Cells[c].Value;
                                if (c != dgv_bajas.Columns.Count - 1)
                                {
                                    // Una coma se agrega como delimitador de texto para
                                    //para separar cada campo en el archivo de texto.
                                    //Puede elegir otro carácter como delimitador.
                                    sLine = sLine + "";
                                }
                            }
                            //El texto exportado se escribe en el archivo de texto, una línea a la vez.
                            file.WriteLine(sLine);
                            sLine = "";
                        }

                        file.Close();
                        MessageBox.Show("Ok Archivo plano creado.", "Program Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        file.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar que plano va a crear","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
    }

        private void TxtCod_funcionario_TextChanged(object sender, EventArgs e)
        {
            String sCadena = fecha.ToString("dd/MM/yyyy");
            String año = sCadena.Substring(6, 4);
            String mes = sCadena.Substring(3, 2);
            String dia = sCadena.Substring(0, 2);
            Txtplano_alta.Text = "PR_00860003020_" + año + mes + dia + TxtCod_plano.Text;
            Txtplano_baja.Text = "RP_00860003020_" + año + mes + dia + TxtCod_plano.Text;
        }

        private void btn_Validar_Click(object sender, EventArgs e)
        {
            if (cmb_Gestion2.Text == "Negados")
            {
                cmds.buscar_negadosckl(dtp_cargue, dgv_altas);
                lbtotal.Text = dgv_altas.Rows.Count.ToString();
            }
            else if (cmb_Gestion2.Text == "Contabilizados")
            {
                cmds.contabilizados_altas(dtp_cargue, dgv_altas);
                cmds.contabilizados_bajas(dtp_cargue, dgv_bajas);
                lbtotal.Text = dgv_altas.Rows.Count.ToString();
            }
        }
        
        private void Planos_Load(object sender, EventArgs e)
        {            
            lblfecha_actual.Text = fecha.ToString("yyyy-MM-dd");
            String sCadena = fecha.ToString("dd/MM/yyyy");
            String año = sCadena.Substring(6, 4);
            String mes = sCadena.Substring(3, 2);
            String dia = sCadena.Substring(0, 2);
            Txtplano_alta.Text = "PR_00860003020_" + año + mes + dia + TxtCod_plano.Text;
            Txtplano_baja.Text = "RP_00860003020_" + año + mes + dia + TxtCod_plano.Text;
        }

        private void Btn_busqueda_Click(object sender, EventArgs e)
        {
            cmds.busqueda_plano(dgv_datos_plano, Txtbusqueda);            
        }

        private void cmb_Gestion2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_altas.DataSource = null;
            dgv_bajas.DataSource = null;

            if (cmb_Gestion2.Text=="Negados")
            {                
                ch_plano_baja.Visible = false;
            }
            else if(cmb_Gestion2.Text == "Contabilizados")
            {
                ch_plano_baja.Visible = true;
            }
        }

        private void Btn_actualizar_cargue_Click(object sender, EventArgs e)
        {
            if (cmb_Gestion2.Text == "Negados")
            {
                cmds.actualizar_cargueckl(dgv_altas, Txtplano_alta);
                cmds.planos_cargue(dgv_altas, Txtplano_alta);
                //cmds.agregar_historico_colp(dgv_altas);
                dgv_altas.DataSource = null;
                dgv_bajas.DataSource = null;
            }
            else if (cmb_Gestion2.Text == "Contabilizados")
            {
                cmds.cargue_contabilizados(dgv_altas, dtp_cargue, Txtplano_alta);
                cmds.planos_cargue(dgv_altas, Txtplano_alta);                
                dgv_altas.DataSource = null;
                dgv_bajas.DataSource = null;
            }
        }

        private void Btn_actualizar_rta_Click(object sender, EventArgs e)
        {
            cmds.busqueda_plano_rta(dgv_datos_plano, Txtbusqueda);            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

            if (cmb_Gestion2.Text == "Negados")
            {
                cmds.buscar_negadosckl(dtp_cargue, dgv_altas);
                lbtotal.Text = dgv_altas.Rows.Count.ToString();
            }
            else if (cmb_Gestion2.Text == "Devueltos")
            {
                cmds.buscar_devueltosckl(dtp_cargue, dgv_altas);                
                lbtotal.Text = dgv_altas.Rows.Count.ToString();
            }
            else if (cmb_Gestion2.Text == "Contabilizados")
            {
                cmds.contabilizados_altas(dtp_cargue, dgv_altas);
                cmds.contabilizados_bajas(dtp_cargue, dgv_bajas);
                lbtotal.Text = dgv_altas.Rows.Count.ToString();
            }
        }

        private void ExportarDatos(DataGridView dgvDatos)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
                excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
                int IndiceColumna = 0;
                foreach (DataGridViewColumn columna in dgv_datos_plano.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                {
                    IndiceColumna++;
                    excel.Cells[1, IndiceColumna] = columna.Name;
                    excel.Cells[1, IndiceColumna].Font.Bold = true;
                    excel.Cells[1, IndiceColumna].Interior.Color = System.Drawing.Color.FromArgb(219, 229, 241);
                }
                int IndiceFila = 0;
                foreach (DataGridViewRow fila in dgv_datos_plano.Rows) //Aquí leemos las filas de las columnas leídas
                {
                    IndiceFila++;
                    IndiceColumna = 0;
                    foreach (DataGridViewColumn columna in dgv_datos_plano.Columns)
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

        private void btnDescargar_Excel2_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgv_datos_plano);
            MessageBox.Show("Actualizar respuestas en el excel y posteriormente cargar archivo segun corresponda");
        }

        private void btnDescargar_Excel1_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
                excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
                int IndiceColumna = 0;
                foreach (DataGridViewColumn columna in dgv_altas.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                {
                    IndiceColumna++;
                    excel.Cells[1, IndiceColumna] = columna.Name;
                    excel.Cells[1, IndiceColumna].Font.Bold = true;
                    excel.Cells[1, IndiceColumna].Interior.Color = System.Drawing.Color.FromArgb(219, 229, 241);
                }
                int IndiceFila = 0;
                foreach (DataGridViewRow fila in dgv_altas.Rows) //Aquí leemos las filas de las columnas leídas
                {
                    IndiceFila++;
                    IndiceColumna = 0;
                    foreach (DataGridViewColumn columna in dgv_altas.Columns)
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
    }
}
