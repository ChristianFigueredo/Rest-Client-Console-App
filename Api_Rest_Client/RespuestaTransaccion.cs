using System;
using System.Collections.Generic;
using System.Text;

namespace Api_Rest_Client
{
    class RespuestaTransaccion
    {
        public string CODIGO { set; get; }
        public string MENSAJE { set; get; }
        public Exception EXCEPTION_TRACE { set; get; }
    }
}
