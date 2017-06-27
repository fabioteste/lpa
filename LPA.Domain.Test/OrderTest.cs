﻿using System.Runtime.InteropServices;
using LPA.Domain.Entities;
using LPA.Domain.Value_Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LPA.Domain.Test
{
    [TestClass]
    public class OrderTest
    {
      private readonly Customer _customer = new Customer(new Name("fabio", "rezende"), new Email("fabio.rezende@gmail.com"), new User("fabiorezende", "senha"), new Document("14582469655"));


        [TestMethod]
        [TestCategory("Order - New Order")]
        public void Quando_nao_tiver_produto_em_estoque_retorna_erro()
        {
            var mouse = new Product("Mouse", 290, "mouse.img", 0);

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void Dado_um_produto_em_estoque_deve_dar_um_update_na_quantidadeemmaos()
        {
            var mouse = new Product("Mouse", 290, "mouse.img", 20);

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsTrue(mouse.QuantityOnHand == 18);
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void Dado_uma_ordem_valida_deve_retornar_valor_correto()
        {
            var mouse = new Product("Mouse", 300, "mouse.img", 20);

            var order = new Order(_customer, 12, 2);
            order.AddItem(new OrderItem(mouse, 1));

            Assert.IsTrue(order.Total() == 310);
        } 
    }
}
