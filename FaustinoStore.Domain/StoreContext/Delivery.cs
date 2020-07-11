using System;
using System.Collections.Generic;

namespace FaustinoStore.Domain.StoreContext
{
  public class Delivery
  {
    public DateTime CreateDate { get; set; }
    public DateTime EstimateDeliveryDate { get; set; }
    public string Status { get; set; }
  }
}