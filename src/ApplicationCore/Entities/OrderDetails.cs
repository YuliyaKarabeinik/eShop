using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class OrderDetails
    {
        public OrderDetails(int id, IReadOnlyCollection<OrderItem> items, Address address)
        {
            Id = id;
            Items = items;
            Address = address;
            Price = Total();
        }
        public int Id { get; set; }

        public IReadOnlyCollection<OrderItem> Items { get; set; }

        public Address Address { get; set; }

        public decimal Price { get; set; }

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Units), 2);
        }
    }
}