using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface IOrdersSenderService
    {
        Task SendForDelivery(OrderDetails order);
    }
}