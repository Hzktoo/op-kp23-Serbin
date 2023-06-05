using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CursovaForm
{
    public class CurrencyPrice
    {
        public static void ShowCurrencyPrices()
        {
            bool isShowingPrices = true;

            while (isShowingPrices)
            {
                MessageBox.Show("=== Currency Prices ===\n\n" +
                                "1. Bitcoin\n" +
                                "2. Ethereum\n" +
                                "3. ShibDoge\n" +
                                "4. Back to Main Menu", "Currency Prices");

                string input = Microsoft.VisualBasic.Interaction.InputBox("Please choose a currency (1-4):", "Currency Prices");
                int option;

                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                            ShowBTCprice();
                            break;
                        case 2:
                            ShowETHprice();
                            break;
                        case 3:
                            ShowShibDogePrice();
                            break;
                        case 4:
                            isShowingPrices = false;
                            break;
                        default:
                            MessageBox.Show("Invalid option.", "Currency Prices");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid option.", "Currency Prices");
                }
            }
        }


        private static void ShowBTCprice()
        {
            WebRequest request = WebRequest.Create("https://api.coinbase.com/v2/prices/BTC-USD/spot");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            string price = json.Substring(json.IndexOf("amount") + 9, 8);

            MessageBox.Show("Current Bitcoin Price: $" + price, "Currency Prices");
        }

        private static void ShowETHprice()
        {
            WebRequest request = WebRequest.Create("https://api.coinbase.com/v2/prices/ETH-USD/spot");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            string price = json.Substring(json.IndexOf("amount") + 8, 7);

            MessageBox.Show("Current Ethereum Price: $" + price, "Currency Prices");
        }

        private static void ShowShibDogePrice()
        {
            WebRequest request = WebRequest.Create("https://api.coinbase.com/v2/prices/SHIB-USD/spot");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            JObject data = JObject.Parse(json);
            string price = data["data"]["amount"].ToString();

            MessageBox.Show("Current ShibDoge Price: $" + price, "Currency Prices");
        }
    }
}
