using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaForm
{
    public class TransactionHistoryManager
    {
        private Dictionary<string, List<string>> transactionHistory;

        public TransactionHistoryManager()
        {
            transactionHistory = new Dictionary<string, List<string>>();
        }

        public void AddTransaction(string userName, string transaction)
        {
            if (transactionHistory.ContainsKey(userName))
            {
                transactionHistory[userName].Add(transaction);
            }
            else
            {
                transactionHistory[userName] = new List<string> { transaction };
            }
        }

        public void ViewTransactionHistory(string userName)
        {
            if (transactionHistory.ContainsKey(userName))
            {
                List<string> userTransactions = transactionHistory[userName];

                MessageBox.Show($"=== Transaction History of active session for {userName} ===\n\n" +
                                string.Join("\n", userTransactions), "Transaction History");
            }
            else
            {
                MessageBox.Show("Transaction history not found for the user.", "Transaction History");
            }
        }
    }
}
