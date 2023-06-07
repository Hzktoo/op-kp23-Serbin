using System.Net;
using System.Transactions;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace CursovaForm
{
    public partial class CryptoForm : Form
    {
        private static Dictionary<string, Wallet> _userWallets;
        private AuthenticationManager _authenticationManager;
        private TransactionHistoryManager _transactionHistoryManager;
        private bool _isPremiumUser = false;
        public CryptoForm()
        {
            InitializeComponent();
            _authenticationManager = new AuthenticationManager();
            _transactionHistoryManager = new TransactionHistoryManager();
        }
       

        public void RegisterButton_Click(object sender, EventArgs e)
        {
            AuthenticationManager authManager = new AuthenticationManager();
            authManager.RegisterUser();
        }

        public void LoginButton_Click(object sender, EventArgs e)
        {
            TransactionHistoryManager transactionHistoryManager = new TransactionHistoryManager();
            _userWallets = new Dictionary<string, Wallet>();
            _authenticationManager.Login();

            if (_authenticationManager.IsUserLoggedIn())
            {
                Logger<string> logger = new Logger<string>("error.log");
                string loggedInUserName = _authenticationManager.GetLoggedInUserName();
                LoadBalanceFromFile(loggedInUserName);

                using (Form walletForm = new Form())
                {
                    walletForm.BackColor = Color.LightSlateGray;
                    walletForm.Text = "Wallet Operations";
                    SettedButton addFundsButton = new SettedButton();
                    addFundsButton.Text = "Add Funds";
                    addFundsButton.Location = new System.Drawing.Point(50, 50);
                    addFundsButton.Click += AddFundsButton_Click;

                    SettedButton removeFundsButton = new SettedButton();
                    removeFundsButton.Text = "Remove Funds";
                    removeFundsButton.Location = new System.Drawing.Point(200, 50);
                    removeFundsButton.Click += RemoveFundsButton_Click;

                    SettedButton viewBalanceButton = new SettedButton();
                    viewBalanceButton.Text = "View Balance";
                    viewBalanceButton.Location = new System.Drawing.Point(50, 100);
                    viewBalanceButton.Click += ViewBalanceButton_Click;

                    SettedButton showCurrencyPricesButton = new SettedButton();
                    showCurrencyPricesButton.Text = "Show Currency Prices";
                    showCurrencyPricesButton.Location = new System.Drawing.Point(200, 100);
                    showCurrencyPricesButton.Click += ShowCurrencyPricesButton_Click;

                    SettedButton transferFundsButton = new SettedButton();
                    transferFundsButton.Text = "Transfer Funds";
                    transferFundsButton.Location = new System.Drawing.Point(50, 150);
                    transferFundsButton.Click += TransferFundsButton_Click;

                    SettedButton viewTransactionHistoryButton = new SettedButton();
                    viewTransactionHistoryButton.Text = "View Transaction History";
                    viewTransactionHistoryButton.Location = new System.Drawing.Point(200, 150);
                    viewTransactionHistoryButton.Click += ViewTransactionHistoryButton_Click;

                    SettedButton premiumButton = new SettedButton(); 
                    premiumButton.Text = "Premium";
                    premiumButton.Location = new System.Drawing.Point(50, 200);
                    premiumButton.Click += PremiumButton_Click; 

                    SettedButton logoutButton = new SettedButton();
                    logoutButton.Text = "Logout";
                    logoutButton.Location = new System.Drawing.Point(200, 200);
                    logoutButton.Click += LogoutButton_Click;

                    walletForm.Controls.Add(addFundsButton);
                    walletForm.Controls.Add(removeFundsButton);
                    walletForm.Controls.Add(viewBalanceButton);
                    walletForm.Controls.Add(showCurrencyPricesButton);
                    walletForm.Controls.Add(transferFundsButton);
                    walletForm.Controls.Add(viewTransactionHistoryButton);
                    walletForm.Controls.Add(premiumButton);
                    walletForm.Controls.Add(logoutButton);

                    walletForm.ShowDialog();
                }

            }
        }

        private void AddFundsButton_Click(object sender, EventArgs e)
        {
            Form addFundsForm = new Form();
            addFundsForm.Text = "Add Funds";

            Label currencyLabel = new Label();
            currencyLabel.Text = "Currency:";
            currencyLabel.Location = new System.Drawing.Point(50, 50);

            ComboBox currencyComboBox = new ComboBox();
            currencyComboBox.Items.AddRange(new object[] { "Bitcoin", "Ethereum", "ShibDoge" });
            currencyComboBox.Location = new System.Drawing.Point(150, 50);

            Label amountLabel = new Label();
            amountLabel.Text = "Amount:";
            amountLabel.Location = new System.Drawing.Point(50, 100);

            TextBox amountTextBox = new TextBox();
            amountTextBox.Location = new System.Drawing.Point(150, 100);

            Button addButton = new Button();
            addButton.Text = "Add";
            addButton.Location = new System.Drawing.Point(150, 150);
            string loggedInUserName = _authenticationManager.GetLoggedInUserName();
            addButton.Click += (sender, e) => AddButton_Click(sender, e, amountTextBox, currencyComboBox, loggedInUserName);

            addFundsForm.Controls.Add(currencyLabel);
            addFundsForm.Controls.Add(currencyComboBox);
            addFundsForm.Controls.Add(amountLabel);
            addFundsForm.Controls.Add(amountTextBox);
            addFundsForm.Controls.Add(addButton);

            addFundsForm.ShowDialog();
        }

        private void AddButton_Click(object sender, EventArgs e, TextBox amountTextBox, ComboBox currencyComboBox, string loggedInUserName)
        {
            string currencyToAdd = currencyComboBox.Text;
            decimal amountToAdd = Convert.ToDecimal(amountTextBox.Text);
            LoadBalanceFromFile(loggedInUserName);

            if (_userWallets.ContainsKey(loggedInUserName))
            {
                Wallet wallet = _userWallets[loggedInUserName];

                Transaction.AddFunds(wallet, currencyToAdd, amountToAdd);

                string transaction = $"Added {amountToAdd} to {currencyToAdd}";
                
                _transactionHistoryManager.AddTransaction(loggedInUserName, transaction);
                amountTextBox.Clear();
                SaveBalanceToFile(loggedInUserName);
            }
            else
            {
                MessageBox.Show("User wallet not found");
            }
        }

        private void RemoveFundsButton_Click(object sender, EventArgs e)
        {
            Form removeFundsForm = new Form();
            removeFundsForm.Text = "Remove funds";

            Label currencyLabel = new Label();
            currencyLabel.Text = "Currency:";
            currencyLabel.Location = new System.Drawing.Point(50, 50);

            ComboBox currencyComboBox = new ComboBox();
            currencyComboBox.Items.AddRange(new object[] { "Bitcoin", "Ethereum", "ShibDoge" });
            currencyComboBox.Location = new System.Drawing.Point(150, 50);

            Label amountLabel = new Label();
            amountLabel.Text = "Amount:";
            amountLabel.Location = new System.Drawing.Point(50, 100);

            TextBox amountTextBox = new TextBox();
            amountTextBox.Location = new System.Drawing.Point(150, 100);

            Button removeButtton = new Button();
            removeButtton.Text = "Remove";
            removeButtton.Location = new System.Drawing.Point(150, 150);
            string loggedInUserName = _authenticationManager.GetLoggedInUserName();
            removeButtton.Click += (sender, e) => RemoveButton_Click(sender, e, amountTextBox, currencyComboBox, loggedInUserName);

            removeFundsForm.Controls.Add(currencyLabel);
            removeFundsForm.Controls.Add(currencyComboBox);
            removeFundsForm.Controls.Add(amountLabel);
            removeFundsForm.Controls.Add(amountTextBox);
            removeFundsForm.Controls.Add(removeButtton);

            removeFundsForm.ShowDialog();
        }

        private void RemoveButton_Click(object sender, EventArgs e, TextBox amountTextBox, ComboBox currencyComboBox, string loggedInUserName)
        {
            string currencyToRemove = currencyComboBox.Text;
            decimal amountToRemove = Convert.ToDecimal(amountTextBox.Text);
            LoadBalanceFromFile(loggedInUserName);

            if (_userWallets.ContainsKey(loggedInUserName))
            {
                Wallet wallet = _userWallets[loggedInUserName];

                Transaction.RemoveFunds(wallet, currencyToRemove, amountToRemove);

                string transaction = $"Removed {amountToRemove} from {currencyToRemove}";

                _transactionHistoryManager.AddTransaction(loggedInUserName, transaction);
                amountTextBox.Clear();
                SaveBalanceToFile(loggedInUserName);
            }
            else
            {
                MessageBox.Show("User wallet not found");
            }
        }

        private void ViewBalanceButton_Click(object sender, EventArgs e)
        {
            
            string loggedInUserName = _authenticationManager.GetLoggedInUserName();
            ViewBalance(loggedInUserName);
        }

        private static void ShowCurrencyPricesButton_Click(object sender, EventArgs e)
        {
            CurrencyPrice.ShowCurrencyPrices();
        }

        private void TransferFundsButton_Click(object sender, EventArgs e)
        {
            Form transferFundsForm = new Form();
            transferFundsForm.Text = "Transfer funds";

            Label currency1Label = new Label();
            currency1Label.Size = new Size(75, 38);
            currency1Label.Text = "Currency to transfer:";
            currency1Label.Location = new System.Drawing.Point(50, 50);

            ComboBox currency1ComboBox = new ComboBox();
            currency1ComboBox.Items.AddRange(new object[] { "Bitcoin", "Ethereum", "ShibDoge" });
            currency1ComboBox.Location = new System.Drawing.Point(150, 50);

            Label amountLabel = new Label();
            amountLabel.Text = "Amount:";
            amountLabel.Location = new System.Drawing.Point(50, 100);

            TextBox amountTextBox = new TextBox();
            amountTextBox.Location = new System.Drawing.Point(150, 100);

            Label currency2Label = new Label();
            currency2Label.Size = new Size(75, 38);
            currency2Label.Text = "Currency to receive";
            currency2Label.Location = new System.Drawing.Point(50, 150);

            ComboBox currency2ComboBox = new ComboBox();
            currency2ComboBox.Items.AddRange(new object[] { "Bitcoin", "Ethereum", "ShibDoge" });
            currency2ComboBox.Location = new System.Drawing.Point(150, 150);

            Button transferButton = new Button();
            transferButton.Text = "Transfer";
            transferButton.Location = new System.Drawing.Point(200, 200);
            string loggedInUserName = _authenticationManager.GetLoggedInUserName();
            transferButton.Click += (sender, e) => TransferButton_Click(sender, e, amountTextBox, currency1ComboBox, loggedInUserName, currency2ComboBox);

            transferFundsForm.Controls.Add(currency1Label);
            transferFundsForm.Controls.Add(currency1ComboBox);
            transferFundsForm.Controls.Add(amountLabel);
            transferFundsForm.Controls.Add(amountTextBox);
            transferFundsForm.Controls.Add(currency2Label);
            transferFundsForm.Controls.Add(currency2ComboBox);
            transferFundsForm.Controls.Add(transferButton);

            transferFundsForm.ShowDialog();
        }

        private void TransferButton_Click(object sender, EventArgs e, TextBox amountTextBox, ComboBox currency1ComboBox, string loggedInUserName, ComboBox currency2ComboBox)
        {
            string currencyToTransfer = currency1ComboBox.Text;
            decimal amountToTransfer = Convert.ToDecimal(amountTextBox.Text);
            string currencyToReceive = currency2ComboBox.Text;
            LoadBalanceFromFile(loggedInUserName);

            if (_userWallets.ContainsKey(loggedInUserName))
            {
                Wallet wallet = _userWallets[loggedInUserName];

                Transaction.TransferFunds(wallet, currencyToTransfer, currencyToReceive, amountToTransfer);

                amountTextBox.Clear();
                SaveBalanceToFile(loggedInUserName);
            }
            else
            {
                MessageBox.Show("User wallet not found");
            }
        }

        private void PremiumButton_Click(object sender, EventArgs e)
        {
            
                if (PremiumUser.IsPremiumUser())
                {
                    MessageBox.Show("You are premium user", "Premium");
                }
                else
                {
                    Form removeFundsForm = new Form();
                    removeFundsForm.Text = "Premium paynment";

                    Label currencyLabel = new Label();
                    currencyLabel.Text = "Currency:";
                    currencyLabel.Location = new System.Drawing.Point(50, 50);

                    ComboBox currencyComboBox = new ComboBox();
                    currencyComboBox.Items.AddRange(new object[] { "Bitcoin", "Ethereum", "ShibDoge" });
                    currencyComboBox.Location = new System.Drawing.Point(150, 50);

                    Label amountLabel = new Label();
                    amountLabel.Text = "Amount to pay:";
                    amountLabel.Location = new System.Drawing.Point(50, 100);

                    Label amountlabel1 = new Label();
                    amountlabel1.Text = "150";
                    amountlabel1.Location = new System.Drawing.Point(150, 100);

                    Button becomePremium = new Button();
                    becomePremium.Text = "Remove";
                    becomePremium.Location = new System.Drawing.Point(150, 150);
                    string loggedInUserName = _authenticationManager.GetLoggedInUserName();
                    becomePremium.Click += (sender, e) => BecomePremiumButton_Click(sender, e, currencyComboBox, loggedInUserName);

                    removeFundsForm.Controls.Add(currencyLabel);
                    removeFundsForm.Controls.Add(currencyComboBox);
                    removeFundsForm.Controls.Add(amountLabel);
                    removeFundsForm.Controls.Add(amountlabel1);
                    removeFundsForm.Controls.Add(becomePremium);

                    removeFundsForm.ShowDialog();

                    PremiumUser.SetPremiumUser(); 
                }
        }

        private void BecomePremiumButton_Click(object sender, EventArgs e, ComboBox currencyComboBox, string loggedInUserName)
        {
            string currencyToRemove = currencyComboBox.Text;
            decimal amountToRemove = 150;
            LoadBalanceFromFile(loggedInUserName);

            if (_userWallets.ContainsKey(loggedInUserName))
            {
                Wallet wallet = _userWallets[loggedInUserName];

                Transaction.RemoveFunds(wallet, currencyToRemove, amountToRemove);

                string transaction = $"Removed {amountToRemove} from {currencyToRemove}";

                _transactionHistoryManager.AddTransaction(loggedInUserName, transaction);
                MessageBox.Show("Thank you for becoming premium!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveBalanceToFile(loggedInUserName);
            }
            else
            {
                MessageBox.Show("User wallet not found");
            }
        }

        private void ViewTransactionHistoryButton_Click(object sender, EventArgs e)
        {
            string loggedInUserName = _authenticationManager.GetLoggedInUserName();
            _transactionHistoryManager.ViewTransactionHistory(loggedInUserName);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            string loggedInUserName = _authenticationManager.GetLoggedInUserName();
            SaveBalanceToFile(loggedInUserName);
            _authenticationManager.Logout();
            Application.Exit();
        }

        private static void LoadBalanceFromFile(string loggedInUserName)
        {
            string userBalanceFilePath = $"D:\\{loggedInUserName}_balance.txt";
            if (File.Exists(userBalanceFilePath))
            {
                string[] lines = File.ReadAllLines(userBalanceFilePath);
                decimal bitcoinBalance = decimal.Parse(lines[0]);
                decimal ethereumBalance = decimal.Parse(lines[1]);
                decimal shibDogeBalance = decimal.Parse(lines[2]);
                _userWallets[loggedInUserName] = new Wallet(bitcoinBalance, ethereumBalance, shibDogeBalance);
            }
            else
            {
                _userWallets[loggedInUserName] = new Wallet(0, 0, 0);
            }
        }

        public static void ViewBalance(string loggedInUserName)
        {
            string userBalanceFilePath = $"D:\\{loggedInUserName}_balance.txt";
            if (File.Exists(userBalanceFilePath))
            {
                string[] lines = File.ReadAllLines(userBalanceFilePath);
                decimal bitcoinBalance = decimal.Parse(lines[0]);
                decimal ethereumBalance = decimal.Parse(lines[1]);
                decimal shibDogeBalance = decimal.Parse(lines[2]);
                string balanceMessage = "=== Wallet Balance ===" + Environment.NewLine +
                                    $"Bitcoin: {bitcoinBalance}" + Environment.NewLine +
                                    $"Ethereum: {ethereumBalance}" + Environment.NewLine +
                                    $"ShibDoge: {shibDogeBalance}";

                MessageBox.Show(balanceMessage, "Transaction");
            }
        }

        private void SaveBalanceToFile(string loggedInUserName)
        {
            string userBalanceFilePath = $"D:\\{loggedInUserName}_balance.txt";
            if (_userWallets.ContainsKey(loggedInUserName))
            {
                Wallet wallet = _userWallets[loggedInUserName];
                string[] lines = {
            wallet.BitcoinBalance.ToString(),
            wallet.EthereumBalance.ToString(),
            wallet.ShibDogeBalance.ToString()
        };
                File.WriteAllLines(userBalanceFilePath, lines);
            }
        }
    }
}
































