using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeatures
{
    public static class Records
    {
        public record Person(string name, string latsname, string[] PhoneNumbers);
    }
}
