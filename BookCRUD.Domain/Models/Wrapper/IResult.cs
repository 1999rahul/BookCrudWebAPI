using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




public interface IResult<out T>
{
    List<string> Messages { get; set; }

    bool Succeeded { get; set; }
    T Data { get; }
}

