using FaustinoStore.Domain.StoreContext.Entities;
using FaustinoStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FaustinoStore.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      var name = new Name("João", "Faustino");
      var document = new Document("12345678910");
      var email = new Email("joao.henrique_15@hotmail.com");
      var customer = new Customer(name, document, email, "11965857443", "Rua xpto, n° 10 - Vila Dev SP/SP");
      var mouse = new Product("Mouse", "Rato", "image.png", 59.10M, 10);
      var teclado = new Product("Teclado", "Teclado", "image.png", 159.10M, 10);

      var order = new Order(customer);
      order.AddItem(new OrderItem(mouse, 5));
      order.AddItem(new OrderItem(teclado, 5));

      //Realizar pedido
      order.Place();

      //Verificar se o pedido é válido
      var valid  = order.Valid;

      //Realizar o pagamento
      order.Pay();

      //Realizar o envio
      order.Ship();

      //Realizar o cancelamento
      order.Cancel();
    }
  }
}
