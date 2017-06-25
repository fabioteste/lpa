using System;
using FluentValidator;
using LPA.Shared.Entities;

namespace LPA.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string firstName, string lastName, string email, User user)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = null;
            Email = email;
            User = user;

            //Validacoes
            new ValidationContract<Customer>(this)
                .IsRequired(x => x.FirstName, "O nome é obrigatório")
                .HasMaxLenght(x => x.FirstName, 60, "Tamanho máximo permitido de 60 caracteres")
                .HasMinLenght(x => x.FirstName, 3, "Tamanho minimo de 3 caracteres")
                .IsRequired(x => x.LastName, "O sobrenome é obrigatório")
                .HasMaxLenght(x => x.LastName, 60, "Tamanho máximo permitido de 60 caracteres")
                .HasMinLenght(x => x.LastName, 3, "Tamanho minimo de 3 caracteres")
                .IsEmail(x => x.Email, "Email inválido");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? Birthdate { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }


        public void Update(string firstname, string lastname, DateTime birthDate)
        {
            FirstName = firstname;
            LastName = lastname;
            Birthdate = birthDate;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
