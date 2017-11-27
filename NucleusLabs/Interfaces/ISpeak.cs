using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    interface ISpeak
    {
        List<String> Messages { get; set; }
        string Speak();
    }
}
