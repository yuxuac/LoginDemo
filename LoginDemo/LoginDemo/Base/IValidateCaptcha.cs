using LoginDemo.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LoginDemo.Base
{
    interface IValidateCaptcha
    {
        bool? IsValid(string input, HttpContext context);
    }
}
