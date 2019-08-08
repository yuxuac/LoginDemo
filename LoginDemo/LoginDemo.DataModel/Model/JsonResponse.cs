using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDemo.DataModel.Model
{
    public class JsonResponse
    {
        public RespCode code { get; set; }
        public string message { get; set; }
        public object respObj { get; set; }

        public bool ShouldSerializerespObj()
        {
            return this.respObj != null;
        }
    }

    public enum RespCode
    {
        exception = -1,
        notok = 0,
        ok = 1,
        redirect = 2,
    }
}
