using FaustinoStore.Domain.StoreContext.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FaustinoStore.Tests
{
  [TestClass]
  public class CreateCustomerCommandTests
  {
    [TestMethod]
    public void ShouldValidateWhenCommandIsValid()
    {
      var command = new CreateCustomerCommand();
      command.FirstName = "João";
      command.LastName = "Faustino";
      command.Document = "12345678910";
      command.Email = "joao.henrique_15@hotmail.com";
      command.Phone = "1198654321";

      Assert.AreEqual(true, command.Valid());
    }
  }
}