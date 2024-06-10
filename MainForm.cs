using System.Windows.Forms;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VetmanagerAPI
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient client = new();
        public ServiceToken? serviceToken { get; set; }
        public MainForm()
        {
            InitializeComponent();
            serviceToken = SettingsResponse.LoadFromXML();
            if (serviceToken != null)
            {
                LoadClientsData();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new()
            {
                Owner = this
            };
            settingsForm.Show();

        }

        public async void LoadClientsData()
        {
            if (serviceToken is null)
            {
                return;
            }
            string url = "https://" + serviceToken.DomainName + ".vetmanager.cloud/rest/api/client/clientsSearchData";
            using HttpRequestMessage request = new(HttpMethod.Get, url);
            request.Headers.Add("X-USER-TOKEN", serviceToken.Token);
            request.Headers.Add("X-APP-NAME", serviceToken.Service);
            using HttpResponseMessage response = await client.SendAsync(request);
            ClientResponse? clientResponse = await response.Content.ReadFromJsonAsync<ClientResponse>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            List<Client>? dataSource = clientResponse?.Data?.Client;
            if (dataSource is not null)
            {
                clientsComboBox.DataSource = dataSource;
                clientsComboBox.ValueMember = "Client_id";
                clientsComboBox.DisplayMember = "FullName";
            }
        }

        private async void LoadPetsData(int clientId)
        {
            if (serviceToken is null)
            {
                return;
            }
            string url = "https://" 
                + serviceToken.DomainName 
                + ".vetmanager.cloud/rest/api/pet?filter=[{'property':'owner_id', 'value':'"
                + clientId
                + "'},{'property':'status', 'value':'deleted', 'operator':'!='}]";
            using HttpRequestMessage request = new(HttpMethod.Get, url);
            request.Headers.Add("X-USER-TOKEN", serviceToken.Token);
            request.Headers.Add("X-APP-NAME", serviceToken.Service);
            using HttpResponseMessage response = await client.SendAsync(request);
        }

        private void SelectPet(Client client)
        {
            if (client.Pets is not null)
            {
                petsGridView.DataSource = client.Pets;
            }
        }

        private void Clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clientsComboBox.Focused && clientsComboBox.SelectedItem is Client client)
            {
                //int clientId = (int)clientsComboBox.SelectedValue;
                //LoadPetsData(clientId);
                SelectPet(client);
            }

        }
    }
}
