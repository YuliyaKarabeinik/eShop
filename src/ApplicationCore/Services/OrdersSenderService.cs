using System.Text;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using System.Net.Http;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class OrdersSenderService : IOrdersSenderService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly OrderSenderSettings _orderSenderSettings;


        public OrdersSenderService(
            IHttpClientFactory httpClientFactory,
            IOptions<OrderSenderSettings> options)
        {
            _httpClientFactory = httpClientFactory;
            _orderSenderSettings = options.Value;
        }

        public async Task SendForDelivery(OrderDetails order)
        {
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = _orderSenderSettings.Uri;
            var httpClient = _httpClientFactory.CreateClient();

            await httpClient.PostAsync(url, data);
        }
    }
}