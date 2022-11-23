using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.Utils
{
    public class DefaultKeyGenerator : IDefaultKeyGenerator
    {
        public string GetKey(string emailAddress)
        {
            return emailAddress.Replace("@", string.Empty).Replace(".", string.Empty);
        }
    }
}
