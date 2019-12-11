using Dvor.Common.Entities;
using Dvor.Common.Entities.DTO;
using Dvor.Common.Enums;

namespace Dvor.Common.Interfaces.Services
{
    public interface IOrderService : IService<Order>
    {
        Order GetCurrentOrder();

        void AddDetails(OrderDetailsDTO orderDetails);

        void RemoveDetails(string id);

        void Submit(string userId);

        void ChangeStatus(string id, OrderStatus status)
    }
}