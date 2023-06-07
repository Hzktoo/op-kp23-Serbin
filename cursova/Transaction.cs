using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaForm
{
    public class Transaction
    {
        private static TransactionHistoryManager transactionHistoryManager;

        static Transaction()
        {
            transactionHistoryManager = new TransactionHistoryManager();
        }

        public static void AddFunds(Wallet wallet, string currency, decimal amount)
        {
            switch (currency.ToLower())
            {
                case "bitcoin":
                    wallet.BitcoinBalance += amount;
                    MessageBox.Show("Funds added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "ethereum":
                    wallet.EthereumBalance += amount;
                    MessageBox.Show("Funds added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "shibdoge":
                    wallet.ShibDogeBalance += amount;
                    MessageBox.Show("Funds added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show("Invalid currency.", "Transaction");
                    break;
            }
        }

        public static void RemoveFunds(Wallet wallet, string currency, decimal amount)
        {
            switch (currency.ToLower())
            {
                case "bitcoin":
                    if (wallet.BitcoinBalance >= amount)
                    {
                        wallet.BitcoinBalance -= amount;
                        MessageBox.Show("Funds removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Insufficient balance.", "Transaction");
                    }
                    break;
                case "ethereum":
                    if (wallet.EthereumBalance >= amount)
                    {
                        wallet.EthereumBalance -= amount;
                        MessageBox.Show("Funds removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Insufficient balance.", "Transaction");
                    }
                    break;
                case "shibdoge":
                    if (wallet.ShibDogeBalance >= amount)
                    {
                        wallet.ShibDogeBalance -= amount;
                        MessageBox.Show("Funds removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Insufficient balance.", "Transaction");
                    }
                    break;
                default:
                    MessageBox.Show("Invalid currency.", "Transaction");
                    break;
            }
        }

        public static void TransferFunds(Wallet sourceWallet, string sourceCurrency, string destinationCurrency, decimal amount)
        {
            switch (sourceCurrency.ToLower())
            {
                case "bitcoin":
                    if (sourceWallet.BitcoinBalance >= amount)
                    {
                        sourceWallet.BitcoinBalance -= amount;
                        switch (destinationCurrency.ToLower())
                        {
                            case "bitcoin":
                                sourceWallet.BitcoinBalance += amount;
                                MessageBox.Show("Funds transfered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case "ethereum":
                                sourceWallet.EthereumBalance += amount;
                                MessageBox.Show("Funds transfered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case "shibdoge":
                                sourceWallet.ShibDogeBalance += amount;
                                MessageBox.Show("Funds transfered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            default:
                                MessageBox.Show("Invalid destination currency.", "Transaction");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insufficient balance in the source wallet.", "Transaction");
                    }
                    break;
                case "ethereum":
                    if (sourceWallet.EthereumBalance >= amount)
                    {
                        sourceWallet.EthereumBalance -= amount;
                        switch (destinationCurrency.ToLower())
                        {
                            case "bitcoin":
                                sourceWallet.BitcoinBalance += amount;
                                MessageBox.Show("Funds transfered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case "ethereum":
                                sourceWallet.EthereumBalance += amount;
                                MessageBox.Show("Funds transfered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case "shibdoge":
                                sourceWallet.ShibDogeBalance += amount;
                                MessageBox.Show("Funds transfered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            default:
                                MessageBox.Show("Invalid destination currency.", "Transaction");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insufficient balance in the source wallet.", "Transaction");
                    }
                    break;
                case "shibdoge":
                    if (sourceWallet.ShibDogeBalance >= amount)
                    {
                        sourceWallet.ShibDogeBalance -= amount;
                        switch (destinationCurrency.ToLower())
                        {
                            case "bitcoin":
                                sourceWallet.BitcoinBalance += amount;
                                MessageBox.Show("Funds transfered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case "ethereum":
                                sourceWallet.EthereumBalance += amount;
                                MessageBox.Show("Funds transfered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case "shibdoge":
                                sourceWallet.ShibDogeBalance += amount;
                                MessageBox.Show("Funds transfered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            default:
                                MessageBox.Show("Invalid destination currency.", "Transaction");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insufficient balance in the source wallet.", "Transaction");
                    }
                    break;
                default:
                    MessageBox.Show("Invalid source currency.", "Transaction");
                    break;
            }
        }
    }
}
