using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Applicationcore.Entities
{
   public  class ClientViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string name { get; set; }
        [Display(Name = "Endereço")]
        public string street { get; set; }
        [Display(Name = "Número")]
        public int number { get; set; }
        [Display(Name = "Complemento")]
        public string complement { get; set; }
        [Display(Name = "Vizinhança")]
        public string neightborhood { get; set; }
        [Display(Name = "Cidade")]
        public string city { get; set; }
        [Display(Name = "Estado")]
        public string state { get; set; }
    }
}
