using FaustinoStore.Domain.StoreContext.Entities;

namespace FaustinoStore.Domain.StoreContext.Repositories
{
  public interface ICustomerRepository
  {
    bool CheckDocument(string document);
    bool CheckEmail(string email);
    void Save(Customer customer);

  }
}