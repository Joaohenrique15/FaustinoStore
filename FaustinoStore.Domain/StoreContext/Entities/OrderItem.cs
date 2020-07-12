using FaustinoStore.Shared.Entities;
using FluentValidator;

namespace FaustinoStore.Domain.StoreContext.Entities
{
  public class OrderItem : Entity
  {
    public OrderItem(Product product, decimal quantity)
    {
      Product = product;
      Quantity = quantity;
      Price = product.Price;

      if (product.QuantityOnHand < quantity)
        AddNotification("Quantity", "Produto fora de estoque");

    }

    public Product Product { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal Price { get; private set; }
  }
}