using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Applicationcore.Entities
{
   public class Adress : Base
    {
        public int ClientId { get; set; }
        
        public virtual Client Client { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Endereço")]
        public string street { get; set; }

        [Required(ErrorMessage = "Número é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Número")]
        public int number { get; set; }

        [Required(ErrorMessage = "Complemento obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Complemento")]
        public string complement { get; set; }

        [Display(Name = "Vizinhança")]
        public string neightborhood { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Cidade")]
        public string city { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Estado")]
        public string state { get; set; }
    }

    public class AdressValidation : AbstractValidator<Adress>
    {
        public AdressValidation()
        {
            RuleFor(x => x.street).Length(3, 100).NotNull().WithMessage("Nome completo da rua.");
            RuleFor(x => x.number).NotNull().WithMessage("Número a Rua Vazio.");
            RuleFor(x => x.neightborhood).Length(3, 100).NotNull().WithMessage("Informe a vizinhança.");
            RuleFor(x => x.city).Length(3, 50).NotNull().WithMessage("Informe a Cidade.");
            RuleFor(x => x.state).Length(2).NotNull().WithMessage("Informe o Estado.");
        }
    }

}
