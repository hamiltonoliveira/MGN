using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Applicationcore.Entities
{
    public class Client : Base
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string name { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "Digite o Nr. Documento", AllowEmptyStrings = false)]
        public int identificationDocument { get; set; }

        [Display(Name = "Aniversário")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Informe a data do Aniversário", AllowEmptyStrings = false)]
        public DateTime birdDate { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "Informe o gênero", AllowEmptyStrings = false)]
        public string gender { get; set; }
    }

    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Nome não pode estar em branco e no máximo 100 caracteres.");
            RuleFor(x => x.identificationDocument).NotNull().WithMessage("Número de identificação.");
            RuleFor(x => x.birdDate).NotNull().WithMessage("Informe a data do Aniversário.");
            RuleFor(x => x.gender).NotEmpty().WithMessage("Informe o gênero.");
        }
    }
}
