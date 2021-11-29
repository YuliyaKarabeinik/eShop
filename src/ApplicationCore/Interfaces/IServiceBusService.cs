using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface IServiceBusService
    {
        Task ReserveOrder(IEnumerable<ReservedOrder> reservedOrders);
    }
}