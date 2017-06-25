using System;
using LPA.Domain.Entities;
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
            var customer = new Customer("f", "rezende", "fabio.emailteste@gmail.com", user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void dado_um_sobrenome_invalido_deve_retornar_uma_notificacao()
        {
            var customer = new Customer("fabio", "r", "fabio.emailteste@gmail.com", user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void dado_um_email_invalido_deve_retornar_uma_notificacao()
        {
            var customer = new Customer("fabio", "rezende", "fabio", user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}
