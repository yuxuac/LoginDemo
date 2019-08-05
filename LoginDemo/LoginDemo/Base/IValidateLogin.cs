using LoginDemo.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDemo.Base
{
    interface IValidateLogin
    {
        bool? IsValidLogin(User input);
    }
}
