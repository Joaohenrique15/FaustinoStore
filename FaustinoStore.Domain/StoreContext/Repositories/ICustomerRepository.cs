using System;
using System.Collections.Generic;
using FaustinoStore.Domain.StoreContext.Entities;
using FaustinoStore.Domain.StoreContext.Queries;

namespace FaustinoStore.Domain.StoreContext.Repositories
{
  public interface ICustomerRepository
  {
    bool CheckDocument(string document);
    bool CheckEmail(string email);
    void Save(Customer customer);
    CustomerOrdersCountResult GetCustomerOrdersCount(string document);
    IEnumerable<ListCustomerQueryResult> Get();
    GetCustomerQueryResult Get(Guid id);
    IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);
  }
}