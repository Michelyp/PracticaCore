using PracticaCore.Model;
using PracticaCore.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;



#region PROCEDIMIENTOS ALAMACENADOS

//esta es una vista
//create view V_CLIENTES_EMPRESAS
//as	
//	SELECT DISTINCT EMPRESA FROM CLIENTES
//GO

//SELECT * FROM V_CLIENTES_EMPRESAS

//create procedure SP_CLIENT_DATA
//(@NOMBRE NVARCHAR(50))
//as
//    select* from CLIENTES WHERE

//    EMPRESA = @NOMBRE
//go


//create procedure SP_PED_CLIENT
//(@CODIGO NVARCHAR(50)) 
//as
//    select PEDIDOS.*
//    from PEDIDOS
//    inner join CLIENTES
//    ON

//    PEDIDOS.CodigoCliente = CLIENTES.CodigoCliente

//    WHERE PEDIDOS.CodigoCliente = @CODIGO
//go


//alter procedure SP_INSERT_PED
//(@CODIGOPEDIDO NVARCHAR(50),
//@CODIGOCLIENTE NVARCHAR(50),
//@FECHA DATETIME, @FORMATOPEDIDO NVARCHAR(50),@IMPORTE int)
//AS
//    INSERT INTO PEDIDOS VALUES (@CODIGOPEDIDO, @CODIGOCLIENTE,
//    @FECHA, @FORMATOPEDIDO, @IMPORTE)
//GO

//create procedure SP_DELETE_PED
//(@CODIGOPEDIDO NVARCHAR(50))
//AS
//    DELETE FROM 
//	pedidos WHERE CodigoPedido = @CODIGOPEDIDO
//GO

#endregion


namespace PracticaCore
{
    public partial class FormPractica : Form
    {
        RepositoryCliente repo;
        private string clienteCodigo;
        private List<Pedido> pedidos;
        public FormPractica()
        {
            InitializeComponent();
            this.repo = new RepositoryCliente();
            this.loadEmpresas();
        }

        private void loadEmpresas()
        {
            List<string> empresas = this.repo.GetEmpresas();
            foreach (string emp in empresas)
            {
                this.cmbclientes.Items.Add(emp);
            }
        }

        private void cmbclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = this.cmbclientes.SelectedItem.ToString();
            //esto son de los clientes y abajo se rellena los datos extraidos del constructor
            Cliente seleccionado = this.repo.GetDatoCliente(nombre);
            this.clienteCodigo = seleccionado.CodigoCliente.ToString();
            this.txtempresa.Text = seleccionado.Empresa.ToString();
            this.txtcontacto.Text = seleccionado.Contacto.ToString();
            this.txtcargo.Text = seleccionado.Cargo.ToString(); ;
            this.txtciudad.Text = seleccionado.Ciudad.ToString();
            this.txttelefono.Text = seleccionado.Telefono.ToString();
        }

        private void btneliminarpedido_Click(object sender, EventArgs e)
        {
            string codigoPedido = this.lstpedidos.SelectedItems.ToString();
            this.repo.DeletePedido(codigoPedido);
            this.cargarPedidosCliente(clienteCodigo);
        }

        private void cargarPedidosCliente(string clienteCodigo)
        {
            this.lstpedidos.Items.Clear();
            //this.pedidos
        }
    }
}
