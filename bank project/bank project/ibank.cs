using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_project
{
   public interface ibank
    {
        
         string Name { get;  }
         string adress { get; }
        int CustomerCount { get; }   
    }
}
