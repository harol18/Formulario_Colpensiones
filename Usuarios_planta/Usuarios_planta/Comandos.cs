﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing;
using MySql.Data.MySqlClient;
using Usuarios_planta.Formularios;

namespace Usuarios_planta
{
    class Comandos
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");



        public void Accesso_Aplicacion()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("control_acceso_aplicaciones", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Usuario", usuario.Nombre);
                cmd.Parameters.AddWithValue("@_Aplicacion", "Colpensiones");
                cmd.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void Guardar_Colpensiones_Ckl(TextBox Txtradicado, TextBox Txtcedula, TextBox Txtnombre, TextBox TxtEstado_cliente, DateTimePicker dtpFecha_Nacimiento,TextBox TxtEdad_Cliente,
                                             TextBox TxtEstatura, TextBox TxtPeso,TextBox Txtafiliacion1, ComboBox cmbtipo, TextBox Txtscoring, TextBox Txtconsecutivo, ComboBox cmbfuerza,
                                             ComboBox cmbdestino, TextBox Txtmonto, TextBox Txtplazo, TextBox Txtcuota, TextBox Txttotal, TextBox Txtpagare, TextBox Txtnit, TextBox Txtentidad,
                                             TextBox Txtcuota_letras, TextBox Txttotal_letras, ComboBox cmbFormato_Seguros, ComboBox cmbReporte_Enfermedad, ComboBox cmbSeguros_Monto , 
                                             ComboBox cmbSobrepeso, ComboBox cmbEstado_Reporte,ComboBox cmbestado, ComboBox cod_suspendido, ComboBox cmbcargue, DateTimePicker dtpcargue, 
                                             DateTimePicker dtpfecha_desembolso,ComboBox cmbresultado, ComboBox cmbrechazo, DateTimePicker dtpfecha_rpta,TextBox Txtplano_dia, TextBox Txtplano_pre,
                                             TextBox TxtN_Plano, TextBox Txtcomentarios)
        {
            con.Open(); 
            MySqlCommand cmd = new MySqlCommand("guardar_colpensiones_ckl", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                dtpcargue.Format = DateTimePickerFormat.Custom;
                dtpfecha_desembolso.Format = DateTimePickerFormat.Custom;
                dtpfecha_rpta.Format = DateTimePickerFormat.Custom;
                dtpfecha_desembolso.CustomFormat = "yyyy-MM-dd";
                dtpcargue.CustomFormat = "yyyy-MM-dd";
                dtpfecha_rpta.CustomFormat = "yyyy-MM-dd";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", Txtradicado.Text);
                cmd.Parameters.AddWithValue("@_Cedula", Txtcedula.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Cliente", Txtnombre.Text);
                cmd.Parameters.AddWithValue("@_Estado_Cliente", TxtEstado_cliente.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Nacimiento_Cliente", dtpFecha_Nacimiento.Text);
                cmd.Parameters.AddWithValue("@_Edad_Cliente", TxtEdad_Cliente.Text);
                cmd.Parameters.AddWithValue("@_Estatura", TxtEstatura.Text);
                cmd.Parameters.AddWithValue("@_Peso", TxtPeso.Text);
                cmd.Parameters.AddWithValue("@_N_Afiliacion1", Txtafiliacion1.Text);
                cmd.Parameters.AddWithValue("@_N_Afiliacion2", Txtafiliacion1.Text);
                cmd.Parameters.AddWithValue("@_Tipo_Documento", cmbtipo.Text);
                cmd.Parameters.AddWithValue("@_Scoring", Txtscoring.Text);
                cmd.Parameters.AddWithValue("@_Consecutivo", Txtconsecutivo.Text);
                cmd.Parameters.AddWithValue("@_Fuerza_Venta", cmbfuerza.Text);
                cmd.Parameters.AddWithValue("@_Destino", cmbdestino.Text);
                cmd.Parameters.AddWithValue("@_Monto_Aprobado", Txtmonto.Text);
                cmd.Parameters.AddWithValue("@_Plazo_Aprobado", Txtplazo.Text);
                cmd.Parameters.AddWithValue("@_Cuota", string.Format("{0:#}", double.Parse(Txtcuota.Text)));// se formate el numero para que no vaya con el . de la separacion de miles
                cmd.Parameters.AddWithValue("@_Total", Txttotal.Text);
                cmd.Parameters.AddWithValue("@_Pagare", Txtpagare.Text);
                cmd.Parameters.AddWithValue("@_Nit", Txtnit.Text);
                cmd.Parameters.AddWithValue("@_Entidades", Txtentidad.Text);
                cmd.Parameters.AddWithValue("@_Cuota_Letras", Txtcuota_letras.Text);
                cmd.Parameters.AddWithValue("@_Total_Letras", Txttotal_letras.Text);
                cmd.Parameters.AddWithValue("@_Formato_Seguros", cmbFormato_Seguros.Text);
                cmd.Parameters.AddWithValue("@_Enfermedad", cmbReporte_Enfermedad.Text);
                cmd.Parameters.AddWithValue("@_Reporte_Monto", cmbSeguros_Monto.Text);
                cmd.Parameters.AddWithValue("@_Reporte_Sobrepeso", cmbSobrepeso.Text);
                cmd.Parameters.AddWithValue("@_Preformalizacion_Seguros", cmbEstado_Reporte.Text);
                cmd.Parameters.AddWithValue("@_Estado_operacion", cmbestado.Text);
                cmd.Parameters.AddWithValue("@_cod_suspendido", cod_suspendido.Text);
                cmd.Parameters.AddWithValue("@_Estado_cargue", cmbcargue.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Cargue", dtpcargue.Text);
                cmd.Parameters.AddWithValue("@_Fecha_desembolso", dtpfecha_desembolso.Text);
                cmd.Parameters.AddWithValue("@_Respuesta_Cargue", cmbresultado.Text);
                cmd.Parameters.AddWithValue("@_Causal_Rechazo", cmbrechazo.Text);
                cmd.Parameters.AddWithValue("@_Fecha_respuesta", dtpfecha_rpta.Text);
                cmd.Parameters.AddWithValue("@_Plano_Dia", Txtplano_dia.Text);
                cmd.Parameters.AddWithValue("@_Plano_Pre", Txtplano_pre.Text);
                cmd.Parameters.AddWithValue("@_Plano", TxtN_Plano.Text);
                cmd.Parameters.AddWithValue("@_Comentarios", Txtcomentarios.Text);                
                cmd.Parameters.AddWithValue("@_Id_Funcionario", usuario.Identificacion);                
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Información Almacenada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dtpcargue.CustomFormat = "dd/MM/yyyy";
                dtpfecha_rpta.CustomFormat = "dd/MM/yyyy";
                dtpfecha_desembolso.CustomFormat = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                myTrans.Rollback();                
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void buscar_colpensiones(TextBox Txtradicado, TextBox Txtcedula, TextBox Txtnombre, TextBox TxtEstado_cliente, DateTimePicker dtpFecha_Nacimiento,TextBox TxtEdad_Cliente,
                                        TextBox TxtEstatura,TextBox TxtPeso,TextBox Txtafiliacion1, ComboBox cmbtipo, TextBox Txtscoring, TextBox Txtconsecutivo, ComboBox cmbfuerza, ComboBox cmbdestino,
                                        TextBox Txtmonto, TextBox Txtplazo, TextBox Txtcuota, TextBox Txttotal, TextBox Txtpagare, TextBox Txtnit, TextBox Txtentidad, TextBox Txtcuota_letras,
                                        TextBox Txttotal_letras, ComboBox cmbFormato_Seguros, ComboBox cmbReporte_Enfermedad, ComboBox cmbSeguros_Monto, ComboBox cmbSobrepeso,
                                        ComboBox cmbEstado_Reporte,ComboBox cmbestado,ComboBox cod_suspendido, ComboBox cmbcargue, DateTimePicker dtpcargue, DateTimePicker dtpfecha_desembolso,
                                        ComboBox cmbresultado, ComboBox cmbrechazo, DateTimePicker dtpfecha_rpta,TextBox Txtplano_dia,TextBox Txtplano_pre, TextBox TxtN_Plano, TextBox Txtcomentarios)
        {          

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("buscar_colpensiones_ckl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", Txtradicado.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    Txtcedula.Text = registro["Cedula"].ToString();
                    Txtnombre.Text = registro["Nombre_Cliente"].ToString();
                    TxtEstado_cliente.Text = registro["Estado_Cliente"].ToString();
                    dtpFecha_Nacimiento.Text = registro["Fecha_Nacimiento_Cliente"].ToString();
                    TxtEdad_Cliente.Text = registro["Edad_Cliente"].ToString();
                    TxtEstatura.Text = registro["Estatura"].ToString();
                    TxtPeso.Text = registro["Peso"].ToString();
                    Txtafiliacion1.Text = registro["N_Afiliacion1"].ToString();                    
                    cmbtipo.Text = registro["Tipo_Documento"].ToString();
                    Txtscoring.Text = registro["Scoring"].ToString();
                    Txtconsecutivo.Text = registro["Consecutivo"].ToString();
                    cmbfuerza.Text = registro["Fuerza_Venta"].ToString();
                    cmbdestino.Text = registro["Destino"].ToString();
                    Txtmonto.Text = registro["Monto_Aprobado"].ToString();
                    Txtplazo.Text = registro["Plazo_Aprobado"].ToString();
                    Txtcuota.Text = registro["Cuota"].ToString();
                    Txttotal.Text = registro["Total"].ToString();
                    Txtpagare.Text = registro["Pagare"].ToString();
                    Txtnit.Text = registro["Nit"].ToString();
                    Txtentidad.Text = registro["Entidades"].ToString();
                    Txtcuota_letras.Text = registro["Cuota_Letras"].ToString();
                    Txttotal_letras.Text = registro["Total_Letras"].ToString();
                    cmbFormato_Seguros.Text = registro["Formato_Seguros"].ToString();
                    cmbReporte_Enfermedad.Text = registro["Enfermedad"].ToString();
                    cmbSeguros_Monto.Text = registro["Reporte_Monto"].ToString();
                    cmbSobrepeso.Text = registro["Reporte_Sobrepeso"].ToString();
                    cmbEstado_Reporte.Text = registro["Preformalizacion_Seguros"].ToString();
                    cmbestado.Text = registro["Estado_operacion"].ToString();
                    cod_suspendido.Text = registro["cod_suspendido"].ToString();
                    cmbcargue.Text = registro["Estado_cargue"].ToString();
                    dtpcargue.Text = registro["Fecha_Cargue"].ToString();
                    dtpfecha_desembolso.Text = registro["Fecha_desembolso"].ToString();
                    cmbresultado.Text = registro["Respuesta_Cargue"].ToString();
                    cmbrechazo.Text = registro["Causal_Rechazo"].ToString();
                    dtpfecha_rpta.Text = registro["Fecha_respuesta"].ToString();
                    Txtplano_dia.Text = registro["Plano_Dia"].ToString();
                    Txtplano_pre.Text = registro["Plano_Pre"].ToString();
                    TxtN_Plano.Text = registro["plano"].ToString();
                    Txtcomentarios.Text = registro["Comentarios"].ToString();                    
                    con.Close();
                }else
                {
                    MessageBox.Show("Caso no existe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpcargue.Text = "01/01/2020";
                    dtpfecha_desembolso.Text = "01/01/2020";
                    dtpfecha_rpta.Text = "01/01/2020";
                    Txtnit.Text = "860003020";
                    cmbdestino.Text = "CPK Libranza";
                    Txtcedula.Text = null;
                    Txtnombre.Text = null; 
                    Txtafiliacion1.Text = null;                    
                    cmbtipo.Text = null;
                    Txtscoring.Text = null;
                    Txtconsecutivo.Text = null;
                    cmbfuerza.Text = null;
                    Txtmonto.Text = null;
                    Txtplazo.Text = null;
                    Txtcuota.Text = null;
                    Txttotal.Text = null;
                    Txtpagare.Text = null;
                    Txtentidad.Text = null;
                    Txtcuota_letras.Text = null;
                    Txttotal_letras.Text = null;
                    cmbestado.Text = null;
                    cmbcargue.Text = null;
                    cmbresultado.Text = null;
                    cmbrechazo.Text = null;
                    Txtplano_dia.Text = null;
                    Txtplano_pre.Text = null;
                    TxtN_Plano.Text = null;
                    Txtcomentarios.Text = null;                    
                }
                con.Close();
            }
            catch (Exception ex)
            {                  
                MessageBox.Show("Caso no existe", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
      
        public void buscar_negadosckl(DateTimePicker dtpproximo, DataGridView dataGridView2)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("buscar_negadosckl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Proximo_Cargue", dtpproximo.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {                
                MessageBox.Show("No hay operaciones para cargar el dia seleccionado", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void buscar_devueltosckl(DateTimePicker dtpproximo, DataGridView dataGridView2)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("buscar_devueltosckl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Proximo_Cargue", dtpproximo.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay operaciones para cargar el dia seleccionado", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cartera_colpensiones(DataGridView dgv_cartera_colpensiones)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("carteras_colpensiones", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@_Fecha_desembolso", dtp_fecha.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_cartera_colpensiones.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void contabilizados_altas(DateTimePicker dtp_cargue, DataGridView dgv_altas)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("contabilizados_altas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_desembolso", dtp_cargue.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_altas.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void contabilizados_bajas(DateTimePicker dtp_cargue, DataGridView dgv_bajas)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("contabilizados_bajas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_desembolso", dtp_cargue.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_bajas.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {                
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Suspendidos_Ckl(DataGridView dgv_datos)
        {

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("suspendidos_ckl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Id_Funcionario", usuario.Identificacion);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_datos.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void busqueda_plano(DataGridView dgv_datos_plano, TextBox Txtbusqueda)
        {

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("busqueda_plano", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_plano", Txtbusqueda.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_datos_plano.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {                
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void busqueda_plano_rta(DataGridView dgv_datos_plano, TextBox Txtbusqueda)
        {

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("busqueda_plano_rta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_plano", Txtbusqueda.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_datos_plano.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void buscar_fallecido(TextBox Txtcedula, TextBox TxtEstado_cliente)
        {

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("buscar_fallecido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Cedula", Txtcedula.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    TxtEstado_cliente.Text = "Fallecido";
                    con.Close();
                }
                else
                {
                    TxtEstado_cliente.Text = "Activo";
                }
                con.Close();
            }
            catch (Exception ex)
            {                
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");
            }
        }

        public void planos_cargue(DataGridView dgv_altas, TextBox Txtplano_alta)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("planos_cargue", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                foreach (DataGridViewRow row in dgv_altas.Rows)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@_Afiliacion", Convert.ToString(row.Cells[0].Value));
                    cmd.Parameters.AddWithValue("@_plano", Txtplano_alta.Text);
                    //cmd.Parameters.AddWithValue("@_Fecha_cargue", fecha.ToString("dd/MM/yyyy"));
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Información Actualizada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {                
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        DateTime fecha = DateTime.Now;

        public void cargue_contabilizados(DataGridView dgv_altas, DateTimePicker dtp_cargue, TextBox Txtplano_alta)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("cargue_contabilizados", con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DataGridViewRow row in dgv_altas.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@_N_Afiliacion2", Convert.ToString(row.Cells[0].Value));
                    cmd.Parameters.AddWithValue("@_Estado_cargue", "Ok Cargue");
                    cmd.Parameters.AddWithValue("@_Fecha_Cargue", fecha.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@_Fecha_desembolso", dtp_cargue.Text);
                    cmd.Parameters.AddWithValue("@_Respuesta_Cargue", "Pdte Dictamen");
                    cmd.Parameters.AddWithValue("@_Plano", Txtplano_alta.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Información Actualizada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {                
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void actualizar_cargueckl(DataGridView dgv_altas,TextBox Txtplano_alta)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("actualizar_cargueckl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DataGridViewRow row in dgv_altas.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@_N_Afiliacion2", Convert.ToString(row.Cells[0].Value));
                    cmd.Parameters.AddWithValue("@_Estado_cargue", "Ok Cargue");
                    cmd.Parameters.AddWithValue("@_Fecha_Cargue", fecha.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@_Respuesta_Cargue", "Pdte Dictamen");
                    cmd.Parameters.AddWithValue("@_Plano", Txtplano_alta.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Información Actualizada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {                
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void buscar_rtackl(DataGridView dgv_datos_plano)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("buscar_rtackl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DataGridViewRow row in dgv_datos_plano.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@_Afiliacion", Convert.ToString(row.Cells[0].Value));
                    cmd.ExecuteNonQuery();
                }
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_datos_plano.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void actualizar_rtackl(DataGridView dgv_datos_plano)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("actualizar_rtackl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DataGridViewRow row in dgv_datos_plano.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@_N_Afiliacion2", Convert.ToString(row.Cells[2].Value));
                    cmd.Parameters.AddWithValue("@_Respuesta_Cargue", Convert.ToString(row.Cells[3].Value));
                    cmd.Parameters.AddWithValue("@_Fecha_respuesta", fecha.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@_Causal_Rechazo", Convert.ToString(row.Cells[4].Value));
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Información Actualizada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {             
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Informe_Ckl(DataGridView dgv_informes, ComboBox cmbinformes, DateTimePicker dtpinicio, DateTimePicker dtpfinal)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("informeckl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Respuesta_Cargue", cmbinformes.Text);
                cmd.Parameters.AddWithValue("@_fecha_inicio", dtpinicio.Text);
                cmd.Parameters.AddWithValue("@_fecha_final", dtpfinal.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_informes.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Actualizar_Contraseña(TextBox Txtusuario, TextBox Txtcontraseña)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("actualizar_contraseña", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Identificacion", Txtusuario.Text);
                cmd.Parameters.AddWithValue("@_Contraseña", Txtcontraseña.Text);
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Información Almacenada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}
