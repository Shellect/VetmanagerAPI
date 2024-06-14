using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetmanagerAPI.data
{
    public class PetInfo
    {
        public int? Id { get; set; }
        public int? Owner_id { get; set; }
        public int? Type_id { get; set; }
        public string? Alias { get; set; }
        public string? Sex { get; set; }
        public string? Date_register { get; set; }
        public string? Birthday { get; set; }
        public string? Note { get; set; }
        public int? Breed_id { get; set; }
        public int? Old_id { get; set; }
        public int? Color_id { get; set; }
        public string? Deathnote { get; set; }
        public string? Deathdate { get; set; }
        public string? Chip_number { get; set; }
        public string? Lab_number { get; set; }
        public string? Picture { get; set; }
        public string? Status { get; set; }
        public string? Weight { get; set; }
        public string? Edit_date { get; set; }
    }
}
