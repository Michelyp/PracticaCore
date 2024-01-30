using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCore.Model
{
    public class Cliente
    {
        public string CodigoCliente { get; set; }
        public string Empresa { get; set; }
        public string Contacto { get; set; }    
        public string Cargo { get; set; }
        public string Ciudad { get; set; }
        public int Telefono { get; set; }

        public Cliente()
        {
            this.CodigoCliente = null;
            this.Empresa = null;
            this.Contacto = null;
            this.Cargo = null;
            this.Ciudad = null;
            this.Telefono = 0;
        }

        public Cliente (string CodigoCliente, string Empresa, string Contacto, string Cargo, string Ciudad, int Telefono)
        {
            this.CodigoCliente=CodigoCliente;
            this.Empresa=Empresa;
            this.Contacto=Contacto; 
            this.Cargo=Cargo;
            this.Ciudad = Ciudad;
            this.Telefono = Telefono;
        }


    }
}
