using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1IdS_G15Modelo.Entidades
{
    public class Cliente
    {
        public int Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }
        public CondicionTributaria Condicion { get; set; }

    }
}
