using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using VetmanagerAPI.entities;
using VetmanagerAPI.responses;

namespace VetmanagerAPI
{
    public partial class PetForm : Form
    {
        private readonly Settings settings;
        private readonly Client owner;
        private static readonly HttpClient client = new();
        public PetForm(Settings settings, Client owner)
        {
            this.settings = settings;
            this.owner = owner;
            InitializeComponent();
            GetAllPetTypes();
        }

        private async void PetSaveButton_Click(object sender, EventArgs e)
        {
            if (settings is null)
            {
                return;
            }
            string url = "https://"
                + settings.DomainName
                + ".vetmanager.cloud/rest/api/pet";
            object newPet = new
            {
                owner_id = owner.Client_id,
                alias = petNameTextBox.Text,
                type_id = (int?)petTypeComboBox.SelectedValue,
                breed_id = (int?)petBreedComboBox.SelectedValue,
                sex = petGenderComboBox.SelectedValue,
                date_register = petDateTimePicker.Value
            };
            using HttpRequestMessage request = new(HttpMethod.Post, url);
            request.Headers.Add("X-USER-TOKEN", settings.Token);
            request.Headers.Add("X-APP-NAME", settings.Service);
            request.Content = JsonContent.Create(newPet);
            using HttpResponseMessage response = await client.SendAsync(request);
            Task<object?> task = response.Content.ReadFromJsonAsync<object>();
            object operationResult = await task;
        }

        private async void GetAllPetTypes()
        {
            if (settings is null)
            {
                return;
            }
            string url = "https://"
                + settings.DomainName
                + ".vetmanager.cloud/rest/api/petType";
            using HttpRequestMessage request = new(HttpMethod.Get, url);
            request.Headers.Add("X-USER-TOKEN", settings.Token);
            request.Headers.Add("X-APP-NAME", settings.Service);
            using HttpResponseMessage response = await client.SendAsync(request);
            PetTypeResponse? clientResponse = await response.Content.ReadFromJsonAsync<PetTypeResponse>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            List<PetType>? dataSource = clientResponse?.Data?.PetType;
            if (dataSource is not null)
            {
                petTypeComboBox.DataSource = dataSource;
                UpdateBreedsCombobox(dataSource[0].Breeds);
            }
        }

        private void PetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (petTypeComboBox.Focused && petTypeComboBox.SelectedItem is PetType petType)
            {
                List<PetBreed>? breeds = petType.Breeds;
                UpdateBreedsCombobox(breeds);
            }
        }

        private void UpdateBreedsCombobox(List<PetBreed>? petBreed)
        {
            if (petBreed != null)
            {
                petBreedComboBox.Items.Clear();
                petBreedComboBox.DataSource = petBreed;
            }
        }
    }
}
