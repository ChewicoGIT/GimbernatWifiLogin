using System.Net;
using System.Text;

namespace GimbernatWifLogIn {
    internal class Program {
        static void Main(string[] args) {

            for(int x = 0; x < 20; x++) {
                try {

                    Thread.Sleep(3000);

                    WebRequest wr = WebRequest.Create(
                        "https://wifi.eug.es/login.html");


                    byte[] bytes = Encoding.UTF8.GetBytes("buttonClicked=4&" +
                        "redirect_url=" + Uri.EscapeDataString("www.msfconnecttest.com/redirect")
                        + "&err_flag=0" +
                        "&info_flag=0" +
                        "&info_msg=0" +
                        "&network_name=" + Uri.EscapeDataString("Guest Network"));

                    wr.ContentType = "application/x-www-form-urlencoded";
                    wr.ContentLength = bytes.Length;
                    wr.Method = "POST";

                    Stream inDataS = wr.GetRequestStream();
                    inDataS.Write(bytes, 0, bytes.Length);
                    inDataS.Close();

                    HttpWebResponse response = (HttpWebResponse)wr.GetResponse();

                    Console.WriteLine(response.StatusDescription);
                    if (response.StatusDescription == "OK")
                        return;
                    response.Close();
                } catch {
                    Console.WriteLine("Error connecting...");
                }

            }
        }
    }
}
