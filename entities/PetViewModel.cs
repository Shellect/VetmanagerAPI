using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetmanagerAPI.entities
{
    public class PetViewModel
    {
        public Pet? SelectedPet { get => Pets.FirstOrDefault(p => p.Pet_id == SelectedId);  }
        public int SelectedId { get; set; } = 0;
        public List<Pet> Pets;
        public PetViewModel() {
            Pets = [];
        }

    }
}
