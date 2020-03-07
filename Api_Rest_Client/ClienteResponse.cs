using System;
using System.Collections.Generic;
using System.Text;

namespace Api_Rest_Client
{
    class ClienteResponse
    {
        public string NUMERO_DOCUMENTO { set; get; }
        public string NOMBRE { set; get; }
        public string APELLIDO { set; get; }
        public string TELEFONO { set; get; }
        public string EMAIL { set; get; }
        public string DIRECCION { set; get; }
        public string TIPO_DOCUMENTO { set; get; }
    }
}
