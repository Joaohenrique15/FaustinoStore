using System;
using System.Collections.Generic;
using FluentValidator;

namespace FaustinoStore.Domain.StoreContext.OrderCommands.Inputs
{
  public class PlaceOrderCommand : Notifiable
  {
    public PlaceOrderCommand()
    {
      OrderItems = new List<OrderItemCommand>();
    }

    public Guid Customer { get; set; }
    public IList<OrderItemCommand> OrderItems { get; set; }

    public class OrderItemCommand
    {
      public Guid Product { get; set; }
      public decimal Quantity { get; set; }
    }
  }
}