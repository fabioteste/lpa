using FluentValidator;

namespace LPA.Domain.Value_Objects
{
    public class Email : Notifiable
    {
        protected Email() { }

        public Email(string address)
        {
            Address = address;

            new ValidationContract<Email>(this)
                .IsEmail(x => x.Address, "E-mail inválido");
        }

        public string Address { get; private set; }
    }
}
