using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaForm
{
    public class Wallet
    {
        public decimal BitcoinBalance { get; set; }
        public decimal EthereumBalance { get; set; }
        public decimal ShibDogeBalance { get; set; }

        public Wallet(decimal bitcoinBalance, decimal ethereumBalance, decimal shibDogeBalance)
        {
            BitcoinBalance = bitcoinBalance;
            EthereumBalance = ethereumBalance;
            ShibDogeBalance = shibDogeBalance;
        }
    }
}
