using Dvor.Common.Entities;

namespace Dvor.Common.Interfaces.Services
{
    public interface IOrderService : IService<Order>
    {
        Order GetCurrentOrder();

        void AddDetails(OrderDetails orderDetails);

        void RemoveDetails(string id);
    }
}