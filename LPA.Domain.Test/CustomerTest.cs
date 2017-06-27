using System;
using LPA.Domain.Entities;
using LPA.Domain.Value_Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LPA.Domain.Test
{
    [TestClass]
    public class CustomerTest
    {
        private readonly User user = new User("fabiorezende", "senha");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void dado_um_nome_invalido_deve_retornar_uma_notificacao()
        {
            var name = new Name("f", "rezende");
            var email = new Email("fabio.emailteste@gmail.com");
            var document = new Document("14582469655");
            var customer = new Customer(name, email, user, document);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void dado_um_sobrenome_invalido_deve_retornar_uma_notificacao()
        {
            var name = new Name("fabio", "r");
            var email = new Email("fabio.emailteste@gmail.com");
            var document = new Document("14582469655");
            var customer = new Customer(name, email, user, document);

            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void dado_um_email_invalido_deve_retornar_uma_notificacao()
        {
            var name = new Name("fabio", "rezende");
            var email = new Email("f");
            var document = new Document("14582469655");
            var customer = new Customer(name, email, user, document);

            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void dado_um_cpf_invalido_deve_retornar_uma_notificacao()
        {
            var name = new Name("fabio", "rezende");
            var email = new Email("fabio.rezende@gmail.com");
            var document = new Document("11111111111");
            var customer = new Customer(name, email, user, document);

            Assert.IsFalse(customer.IsValid());
        }
    }
}
