using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetmanagerAPI.entities
{
    public class Pet
    {
        [System.ComponentModel.DisplayName("ID")]
        public int? Pet_id { get; set; }
        [System.ComponentModel.DisplayName("Имя")]
        public string? Alias { get; set; }
        [System.ComponentModel.DisplayName("Пол")]
        public string? Sex { get; set; }
        [System.ComponentModel.DisplayName("Дата рождения")]
        public string? Birthday { get; set; }
        internal int? Owner_id { get; set; }
        public string? Pet_type { get; set; }
        [System.ComponentModel.DisplayName("Порода")]
        public string? Breed { get; set; }
        [System.ComponentModel.DisplayName("Вид")]
        public string? Pet_type_title { get; set; }
        
        internal int? Pet_type_id { get; set; }
    }
}
