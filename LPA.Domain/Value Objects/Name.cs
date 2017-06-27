using FluentValidator;

namespace LPA.Domain.Value_Objects
{
    public class Name : Notifiable
    {
        protected Name() { }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new ValidationContract<Name>(this)
                .IsRequired(x => x.FirstName, "O nome é obrigatório")
                .HasMaxLenght(x => x.FirstName, 60, "Tamanho máximo permitido de 60 caracteres")
                .HasMinLenght(x => x.FirstName, 3, "Tamanho minimo de 3 caracteres")
                .IsRequired(x => x.LastName, "O sobrenome é obrigatório")
                .HasMaxLenght(x => x.LastName, 60, "Tamanho máximo permitido de 60 caracteres")
                .HasMinLenght(x => x.LastName, 3, "Tamanho minimo de 3 caracteres");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
