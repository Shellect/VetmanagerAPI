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

        private PetViewModel petViewModel;

        public int SelectedClient = 0;
        public MainForm()
        {
            InitializeComponent();
            ServiceToken = SettingsResponse.LoadFromXML();
            if (ServiceToken != null)
            {
                LoadClientsData();
            }
            petViewModel = new PetViewModel();
          //  petsGridView.DataBindings.Add(new Binding("DataSource", DataContext, "Pets", false, DataSourceUpdateMode.OnPropertyChanged));
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
                PetForm petForm = new(client, ServiceToken, null)
                {
                    Owner = this
                };
                petForm.Show();
            }
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (ServiceToken is null)
            {
                return;
            }
            if (petsGridView.SelectedCells.Count == 0)
            {
                return;
            }
            int selectedRowIndex = petsGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = petsGridView.Rows[selectedRowIndex];
            int petId = (int)selectedRow.Cells[0].Value;

            string url = "https://" + ServiceToken.DomainName + ".vetmanager.cloud/rest/api/pet/" + petId;
            using HttpRequestMessage request = new(HttpMethod.Delete, url);
            request.Headers.Add("X-USER-TOKEN", ServiceToken.Token);
            request.Headers.Add("X-APP-NAME", ServiceToken.Service);
            using HttpResponseMessage response = await client.SendAsync(request);
            PetResponse? clientResponse = await response.Content.ReadFromJsonAsync<PetResponse>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (clientResponse is not null)
            {
                MessageBox.Show(clientResponse.Message);
                LoadClientsData();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (ServiceToken != null && clientsComboBox.SelectedItem is Client client)
            {
                PetForm petForm = new(client, ServiceToken, petViewModel.SelectedId)
                {
                    Owner = this
                };
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
                clientsComboBox.SelectedIndex = SelectedClient;
                SelectPet(dataSource[SelectedClient]);
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
                SelectedClient = clientsComboBox.SelectedIndex;
                SelectPet(client);
                AddBtn.Enabled = true;
            }
        }

        private void PetsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (petsGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = petsGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = petsGridView.Rows[selectedRowIndex];
                petViewModel.SelectedId = (int)selectedRow.Cells[0].Value;
                EditBtn.Enabled = true;
            }
            DeleteBtn.Enabled = true;
        }
    }
}
