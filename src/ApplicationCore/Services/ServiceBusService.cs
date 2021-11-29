using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class ServiceBusService : IServiceBusService
    {
        private IQueueClient _queueClient;
        private readonly ServiceBusSettings _serviceBusSettings;

        public ServiceBusService(IOptions<ServiceBusSettings> serviceBusSettings)
        {
            _serviceBusSettings = serviceBusSettings.Value;
        }

        public async Task ReserveOrder(IEnumerable<ReservedOrder> reservedOrders)
        {
            _queueClient = new QueueClient(
                _serviceBusSettings.ServiceBusConnectionString,
                _serviceBusSettings.QueueName);

            await SendMessages(reservedOrders);
        }

        private async Task SendMessages(IEnumerable<ReservedOrder> reservedOrders)
        {
            var messageBody = JsonConvert.SerializeObject(reservedOrders);
            try
            {
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                await _queueClient.SendAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

            await _queueClient.CloseAsync();
        }
    }
}