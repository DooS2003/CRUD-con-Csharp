using System;
using System.Data.SqlClient;

namespace CRUD
{
    internal class bd
    {

        public static SqlConnection conectarbd = new SqlConnection("Data Source=LAPTOP-1DM90IEE;Initial Catalog=jugos;Integrated Security=False;User=sa;Password=1234;");


        public void abrir()
        {
            try
            {
                conectarbd.Open();
                Console.WriteLine("Conecto");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        public void cerrar()
        {
            conectarbd.Close();
        }

    }
}
