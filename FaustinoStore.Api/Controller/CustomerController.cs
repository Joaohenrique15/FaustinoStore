using System;
using System.Collections.Generic;
using FaustinoStore.Domain.StoreContext.CustomerCommands.Inputs;
using FaustinoStore.Domain.StoreContext.Entities;
using FaustinoStore.Domain.StoreContext.Handlers;
using FaustinoStore.Domain.StoreContext.Queries;
using FaustinoStore.Domain.StoreContext.Repositories;
using FaustinoStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace FaustinoStore.Api.Controllers
{
  public class CustomerController : Controller
  {
    private readonly ICustomerRepository _repository;
    private readonly CustomerHandler _handler;

    public CustomerController(ICustomerRepository repository, CustomerHandler handler)
    {
      _repository = repository;
      _handler = handler;
    }

    [HttpGet]
    [Route("v1/customers")]
    public IEnumerable<ListCustomerQueryResult> Get()
    {
      return _repository.Get();
    }

    [HttpGet]
    [Route("v1/customers/{id}")]
    public GetCustomerQueryResult GetById(Guid id)
    {
      return _repository.Get(id);
    }

    [HttpGet]
    [Route("v2/customers/{document}")]
    public GetCustomerQueryResult GetByDocument(Guid document)
    {
      return _repository.Get(document);
    }

    [HttpGet]
    [Route("v1/customers/{id}/orders")]
    public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
    {
      return _repository.GetOrders(id);
    }

    [HttpPost]
    [Route("v1/customers")]
    public ICommandResult Post([FromBody] CreateCustomerCommand command)
    {
      var result = (CreateCustomerCommandResult)_handler.Handle(command);
      return result;
    }
  }
}