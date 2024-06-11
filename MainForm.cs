using System.Windows.Forms;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using VetmanagerAPI.responses;
using VetmanagerAPI.entities;

namespace VetmanagerAPI
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient client = new();
        public Settings? ServiceToken { get; set; }
        public MainForm()
        {
            InitializeComponent();
            ServiceToken = SettingsResponse.LoadFromXML();
            if (ServiceToken != null)
            {
                LoadClientsData();
            }
        }

        private void APIButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new(ServiceToken)
            {
                Owner = this
            };
            settingsForm.Show();

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (ServiceToken != null && clientsComboBox.SelectedItem is Client client)
            {
                PetForm petForm = new(ServiceToken, client);
                petForm.Show();
            }
        }

        public async void LoadClientsData()
        {
            if (ServiceToken is null)
            {
                return;
            }
            string url = "https://" + ServiceToken.DomainName + ".vetmanager.cloud/rest/api/client/clientsSearchData";
            using HttpRequestMessage request = new(HttpMethod.Get, url);
            request.Headers.Add("X-USER-TOKEN", ServiceToken.Token);
            request.Headers.Add("X-APP-NAME", ServiceToken.Service);
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
                SelectPet(dataSource[0]);
                AddBtn.Enabled = true;
            }
        }

        private async void LoadPetsData(int clientId)
        {
            if (ServiceToken is null)
            {
                return;
            }
            string url = "https://"
                + ServiceToken.DomainName
                + ".vetmanager.cloud/rest/api/pet?filter=[{'property':'owner_id', 'value':'"
                + clientId
                + "'},{'property':'status', 'value':'deleted', 'operator':'!='}]";
            using HttpRequestMessage request = new(HttpMethod.Get, url);
            request.Headers.Add("X-USER-TOKEN", ServiceToken.Token);
            request.Headers.Add("X-APP-NAME", ServiceToken.Service);
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
                AddBtn.Enabled = true;
            }

        }


    }
}
