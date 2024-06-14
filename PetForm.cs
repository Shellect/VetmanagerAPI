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
using VetmanagerAPI.data;
using VetmanagerAPI.entities;
using VetmanagerAPI.responses;

namespace VetmanagerAPI
{
    public partial class PetForm : Form
    {
        private readonly Settings? settings;
        private readonly Client PetOwner;
        private static readonly HttpClient client = new();
        private int? petId;
        public PetForm(Client petOwner, Settings settings, int? id)
        {
            PetOwner = petOwner;
            this.settings = settings;
            this.petId = id;
            InitializeComponent();
            GetAllPetTypes(id);
        }

        private async void GetAllPetTypes(int? id)
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
                int breedId = 0;
                int typeId = 0;
                if (id is not null)
                {
                    PetResponse? petEditResponse = await LoadPet(id);
                    if (petEditResponse is not null && petEditResponse.Success == false)
                    {
                        MessageBox.Show(petEditResponse.Message);
                    }
                    if (petEditResponse?.Data?.Pet is PetInfo pet)
                    {

                        petNameTextBox.Text = pet.Alias;
                        petDateTimePicker.Text = pet.Birthday;
                        petGenderComboBox.SelectedItem = pet.Sex;
                        breedId = pet.Breed_id ?? 0;
                        typeId = pet.Type_id ?? 0;
                        petSaveButton.Click += PetEditButton_Click;
                        petSaveButton.Click -= PetSaveButton_Click;
                    }
                }
                petTypeComboBox.DataSource = dataSource;
                petTypeComboBox.SelectedValue = Math.Max(typeId, 1);
                int selectedypeIndex = Math.Max(petTypeComboBox.SelectedIndex, 0);
                UpdateBreedsCombobox(dataSource[selectedypeIndex].Breeds, breedId);
            }
           
        }

        private async Task<PetResponse?> LoadPet(int? Id)
        {
            string url = "https://"
                + settings.DomainName
                + ".vetmanager.cloud/rest/api/pet/" + Id;
            using HttpRequestMessage request = new(HttpMethod.Get, url);
            request.Headers.Add("X-USER-TOKEN", settings.Token);
            request.Headers.Add("X-APP-NAME", settings.Service);
            using HttpResponseMessage response = await client.SendAsync(request);
            Task<PetResponse?> task = response.Content.ReadFromJsonAsync<PetResponse>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return await task;
        }


        private async void PetSaveButton_Click(object sender, EventArgs e)
        {
            if (settings is null)
            {
                MessageBox.Show("Error!");
                Close();
                return;
            }
            string url = "https://"
                + settings.DomainName
                + ".vetmanager.cloud/rest/api/pet";
            object newPet = new
            {
                owner_id = PetOwner.Client_id,
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
           PetCreateResponse? petCreateResponse = await response.Content.ReadFromJsonAsync<PetCreateResponse>(new JsonSerializerOptions
           {
               PropertyNameCaseInsensitive = true
           });
           if (petCreateResponse is not null)
           {
                if (Owner is MainForm ownerForm)
                {
                    ownerForm.LoadClientsData();
                }
                if (MessageBox.Show(petCreateResponse.Message, petCreateResponse.Message) == DialogResult.OK)
                {
                    Close();
                }
           }
        }

        private async void PetEditButton_Click(object sender, EventArgs e)
        {
            if (settings is null && petId is not null)
            {
                MessageBox.Show("Error!");
                Close();
                return;
            }
            string url = "https://"
                + settings.DomainName
                + ".vetmanager.cloud/rest/api/pet/" + petId;
            object newPet = new
            {
                owner_id = PetOwner.Client_id,
                alias = petNameTextBox.Text,
                type_id = (int?)petTypeComboBox.SelectedValue,
                breed_id = (int?)petBreedComboBox.SelectedValue,
                sex = petGenderComboBox.SelectedItem,
                date_register = petDateTimePicker.Text
            };
            using HttpRequestMessage request = new(HttpMethod.Put, url);
            request.Headers.Add("X-USER-TOKEN", settings.Token);
            request.Headers.Add("X-APP-NAME", settings.Service);
            request.Content = JsonContent.Create(newPet);
            using HttpResponseMessage response = await client.SendAsync(request);
            PetResponse? petCreateResponse = await response.Content.ReadFromJsonAsync<PetResponse>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            if (petCreateResponse is not null)
            {
                if (Owner is MainForm ownerForm)
                {
                    ownerForm.LoadClientsData();
                }
                if (MessageBox.Show(petCreateResponse.Message, petCreateResponse.Message) == DialogResult.OK)
                {
                    Close();
                }
            }
        }

       

        private void PetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (petTypeComboBox.Focused && petTypeComboBox.SelectedItem is PetType petType)
            {
                List<PetBreed>? breeds = petType.Breeds;
                UpdateBreedsCombobox(breeds, 0);
            }
        }

        private void UpdateBreedsCombobox(List<PetBreed>? petBreed, int breedId)
        {
            if (petBreed != null)
            {
                petBreedComboBox.DataSource = petBreed;
                if (breedId > 0)
                {
                    petBreedComboBox.SelectedValue = breedId;
                }
            }
        }
    }
}
