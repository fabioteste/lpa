using System;
using LPA.Domain.Value_Objects;
using LPA.Shared.Entities;

namespace LPA.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Name name, Email email, User user, Document document)
        {
            Name = name;
            Birthdate = null;
            Email = email;
            User = user;
            Document = document;

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
        }

        public Name Name { get; private set; }
        public DateTime? Birthdate { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public User User { get; private set; }


        public void Update(Name name, DateTime birthDate)
        {
            Name = name;
            Birthdate = birthDate;
        }
    }
}
