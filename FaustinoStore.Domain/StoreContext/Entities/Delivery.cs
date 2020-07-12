using System;
using System.Collections.Generic;
using FaustinoStore.Domain.StoreContext.Enums;
using FaustinoStore.Shared.Entities;
using FluentValidator;

namespace FaustinoStore.Domain.StoreContext.Entities
{
  public class Delivery : Entity
  {
    public Delivery(DateTime estimateDeliveryDate)
    {
      CreateDate = DateTime.Now;
      EstimateDeliveryDate = estimateDeliveryDate;
      Status = EDeliveryStatus.Waiting;
    }

    public DateTime CreateDate { get; private set; }
    public DateTime EstimateDeliveryDate { get; private set; }
    public EDeliveryStatus Status { get; private set; }

    public void Ship()
    {
      //Se a Data estimada de entrega for no passado, não entregar
      Status = EDeliveryStatus.Shipped;
    }

    public void Cancel()
    {
      // Se o status já estiver entregue, nao pode cancelar
      Status = EDeliveryStatus.Canceled;  
    }
  }
}