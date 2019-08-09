using FluentValidation;

namespace Applicationcore.Entities
{
    public class Phone : Base
    {
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int numero { get; set; }
    }
   

    public class PhoneValidation : AbstractValidator<Phone>
    {
        public PhoneValidation()
        {
            RuleFor(x => x.numero).NotNull().WithMessage("Digite o telefone.");
        }
    }

}
