using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace VetmanagerAPI
{
    public partial class SettingsForm : Form
    {
        private static readonly HttpClient client = new();

        public SettingsForm()
        {
            InitializeComponent();
        }

        private async void ConnectBtn_Click(object sender, EventArgs e)
        {
            string url = "https://" + domainInput.Text + ".vetmanager.cloud/token_auth.php";

            using MultipartFormDataContent form = new()
            {
                { new StringContent(loginInput.Text, Encoding.UTF8, MediaTypeNames.Text.Plain), "login" },
                { new StringContent(passwordInput.Text, Encoding.UTF8, MediaTypeNames.Text.Plain), "password" },
                { new StringContent("core_junior_exersise", Encoding.UTF8, MediaTypeNames.Text.Plain), "app_name" }
            };

            using HttpResponseMessage response = await client.PostAsync(url, form);
            var settingsResponse = await response.Content.ReadFromJsonAsync<SettingsResponse>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            if (settingsResponse != null)
            {
                if (settingsResponse.Status == 200)
                {
                    if (!settingsResponse.SaveInXML(domainInput.Text))
                    {
                        MessageBox.Show("Ошибка сохранения данных!");
                        return;
                    }
                    if (Owner is MainForm mainForm)
                    {
                        mainForm.serviceToken = settingsResponse.Data;
                        mainForm.LoadClientsData();
                    }

                }
                //MessageBox.Show(HttpUtility.HtmlDecode(serviceToken.Detail)));
                if (MessageBox.Show(settingsResponse.Detail, settingsResponse.Title) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
