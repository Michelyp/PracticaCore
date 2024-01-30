using PracticaCore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace PracticaCore.Repository
{
    

    public class RepositoryCliente
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryCliente()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=NETCORE;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<string> GetEmpresas()
        {
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = "select * from V_CLIENTES_EMPRESAS";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<string> listadoE= new List<string>();
            while(this.reader.Read())
            {
                listadoE.Add(this.reader["EMPRESA"].ToString());
            }
            this.cn.Close();
            this.reader.Close();
            return listadoE;
        }
        
        public Cliente GetDatoCliente(string nombre)
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_CLIENT_DATA";
            
            SqlParameter pamNombre = new SqlParameter("@NOMBRE", nombre);
            this.com.Parameters.Add(pamNombre);
            this.cn.Open();

            this.reader = this.com.ExecuteReader();

            Cliente cliente = new Cliente();
            while(this.reader.Read())
            {
                string codigo, empresa, contacto, cargo, ciudad;
                int telefono;
                codigo= this.reader["CodigoCliente"].ToString();
                empresa = this.reader["Empresa"].ToString();
                contacto = this.reader["Contacto"].ToString();
                cargo = this.reader["Cargo"].ToString();
                ciudad = this.reader["Cargo"].ToString();
                telefono = int.Parse(this.reader["Telefono"].ToString()) - 1;


                cliente = new Cliente(
                    codigo, empresa, contacto, cargo,ciudad,telefono
                    );
            }
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
            return cliente;
        }
        public List<Pedido> GetClientePedido(string codigo)
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_PED_CLIENT";
            SqlParameter pamNombre = new SqlParameter("@CODIGO", codigo);
            this.com.Parameters.Add(pamNombre);
            this.cn.Open();
            List<Pedido> listaPedidos = new List<Pedido>();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string codigoPE, cliente, formaEnvio;
                DateTime fecha;
                 int importe;

                codigoPE = this.reader["CodigoPedido"].ToString();
                cliente = this.reader["CodigoCliente"].ToString();
                fecha = DateTime.Parse(this.reader["FechaEntrega"].ToString());
                formaEnvio = this.reader["FormaEnvio"].ToString();
                importe = int.Parse(this.reader["Importe"].ToString());


                //listaPedidos = new Pedido(codigoPE, cliente, fecha, formaEnvio, importe);
            }
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
            return listaPedidos;
        }
        public void InsertarPedido(string codigoPedido, string codigoCliente, DateTime fecha, string formatoPedido, int importe) {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_INSERT_PED";
            SqlParameter pamcodigoPedido = new SqlParameter("@CODIGOPEDIDO", codigoPedido);
            SqlParameter pamcodigoCliente = new SqlParameter("@CODIGOCLIENTE", codigoCliente);
            SqlParameter pamfecha = new SqlParameter("@FECHA", fecha);
            SqlParameter pamformatoPedido = new SqlParameter("@FORMATOPEDIDO", formatoPedido);
            SqlParameter pamimporte = new SqlParameter("@IMPORTE", importe);

        }
        public void DeletePedido(string codigo)
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_DELETE_PED";
            SqlParameter pamNombre = new SqlParameter("@CODIGOPEDIDO", codigo);
            this.com.Parameters.Add(pamNombre);
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();


        }

    }

}
