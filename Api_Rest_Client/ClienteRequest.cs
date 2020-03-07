using System;
using System.Collections.Generic;
using System.Text;

namespace Api_Rest_Client
{
    class ClienteRequest
    {
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int? IdTipoDocumento { get; set; }
    }
}
