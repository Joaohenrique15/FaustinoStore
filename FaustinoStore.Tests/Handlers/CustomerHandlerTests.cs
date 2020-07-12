using FaustinoStore.Domain.StoreContext.CustomerCommands.Inputs;
using FaustinoStore.Domain.StoreContext.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FaustinoStore.Tests
{
  [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "João";
            command.LastName = "Faustino";
            command.Document = "12345678910";
            command.Email = "joao.henrique_15@hotmail.com";
            command.Phone = "11987654321";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}