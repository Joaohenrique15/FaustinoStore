using System;
using System.Collections.Generic;
using FaustinoStore.Domain.StoreContext.Entities;
using FaustinoStore.Domain.StoreContext.Queries;
using FaustinoStore.Domain.StoreContext.Repositories;

namespace FaustinoStore.Tests
{
  public class FakeCustomerRepository : ICustomerRepository
  {
    public bool CheckDocument(string document)
    {
      return false;
    }

    public bool CheckEmail(string email)
    {
      return false;
    }

    public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
    {
      throw new NotImplementedException();
    }

    public void Save(Customer customer)
    {

    }
  }
}