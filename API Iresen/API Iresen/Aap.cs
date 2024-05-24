using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Iresen
{
    public class Aap
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [StringLength(500)]
        public string Description { get; set; }


        [Required]

        public int RespoId { get; set; }
        public User? Respo { get; set; }

        [Required]
        public int Category { get; set; }

        [StringLength(100)]
        public string Instituthote { get; set; }

        [Range(0, int.MaxValue)]
        public int Budget { get; set; }

        [Range(0, int.MaxValue)]
        public int Dureemin { get; set; }

        [Range(0, int.MaxValue)]
        public int Duremax { get; set; }

        public List<string> Paysautorises { get; set; } 

        [Required]
        public DateTime Datepub { get; set; }

        [Required]
        public DateTime Dateclo { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Soumissionaccepte { get; set; } = 0;

        public int Statut { get; set; } = 0;

    }
}
