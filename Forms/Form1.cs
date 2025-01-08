using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button_guardar_Click(object sender, EventArgs e)
        {

            bd conexion = new bd();
            conexion.abrir();
            string cmd = "SP_insertarJugo";
            SqlCommand comando= new SqlCommand(cmd, bd.conectarbd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@codigo", text_codigo.Text);
            comando.Parameters.AddWithValue("@sabor", text_sabor.Text);
            comando.Parameters.AddWithValue("@marca", text_marca.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Jugo Guardado correctamente");
            conexion.cerrar();
            borrar_campos();
            button_listar_Click(null, null);
        }

        public void borrar_campos()
        {
            text_codigo.Text = "";
            text_marca.Text = "";
            text_sabor.Text = "";
        }

        private void button_listar_Click(object sender, EventArgs e)
        {
            string cmd = "SP_mostrarJugo";
            bd conexion = new bd();
            conexion.abrir();    
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd, bd.conectarbd);
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            conexion.cerrar();
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            string cmd = "SP_modificarJugo";
            bd conexion = new bd();
            conexion.abrir();
            SqlCommand comando = new SqlCommand(cmd, bd.conectarbd);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo", text_codigo.Text);
            comando.Parameters.AddWithValue("@sabor", text_sabor.Text);
            comando.Parameters.AddWithValue("@marca", text_marca.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Datos modificados");
            conexion.cerrar();
            borrar_campos();
            button_listar_Click(null, null);
        }




        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                text_codigo.Text = row.Cells["Codigo"].Value.ToString();
                text_sabor.Text = row.Cells["Sabor"].Value.ToString();
                text_marca.Text = row.Cells["Marca"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd= "SP_eliminarJugo";
            bd conexion= new bd();
            conexion.abrir();
            SqlCommand comando = new SqlCommand(cmd, bd.conectarbd);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo", text_codigo.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Datos Eliminados" + text_codigo.Text);
            conexion.cerrar();
            button_listar_Click(null, null);
            borrar_campos();
        }
    }
}
