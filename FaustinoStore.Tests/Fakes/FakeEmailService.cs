using FaustinoStore.Domain.StoreContext.Services;

namespace FaustinoStore.Tests
{
  public class FakeEmailService : IEmailService
  {
    public void Send(string to, string from, string subject, string body)
    {

    }
  }
}