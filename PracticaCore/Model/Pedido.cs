using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCore.Model
{
    public class Pedido
    {
        public string CodigoPedido { get; set; }
        public string CodigoCliente { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string FormaEnvio { get; set; }
        public int Importe { get; set; }

        public Pedido()
        {
            this.CodigoPedido = null;
            this.CodigoCliente = null;
            this.FechaEntrega = new DateTime();
            this.FormaEnvio = null;
            this.Importe = 0;
        }
        public Pedido(string CodigoPedido, string CodigoCliente, DateTime FechaEntrega, string FormaEnvio, int Importe)
        {
            this.CodigoPedido = CodigoPedido;
            this.CodigoCliente = CodigoCliente;
            this.FechaEntrega = FechaEntrega;
            this.FormaEnvio = FormaEnvio;
            this.Importe = Importe;
        }
    }
}
