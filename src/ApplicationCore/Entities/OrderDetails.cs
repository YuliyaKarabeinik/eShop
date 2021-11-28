using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class OrderDetails
    {
        public OrderDetails(int id, IReadOnlyCollection<OrderItem> items, Address address, decimal price)
        {
            Id = id;
            Items = items;
            Address = address;
            Price = price;
        }
        public int Id { get; set; }

        public IReadOnlyCollection<OrderItem> Items { get; set; }

        public Address Address { get; set; }

        public decimal Price { get; set; }
    }
}