using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA
{
    abstract class Bank
    {
        public decimal Balance { get; set; }

    }
    class Account
    {
        public decimal Balance { get; set; } = 1000;

    }
}
