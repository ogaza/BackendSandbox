using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Address
    {
        public string CountryCode { get; set; }
    }

    public class Order
    {
        public decimal TotalCost { get; set; }

        public decimal WeightInKg { get; set; }

        public string CourierTrackingId { get; set; }

        public Address DispachAddress { get; set; }
    }

    public interface IShippingCourier
    {
        string GenerateConsignmentLabelFor(Address address);
    }

    public class Dhl : IShippingCourier 
    {
        public string GenerateConsignmentLabelFor(Address address) 
        {
            return "Dhl-XXXX-XXXX-XXXX-XXXX";
        }
    }

    public class RoyalMail : IShippingCourier
    {
        public string GenerateConsignmentLabelFor(Address address)
        {
            return "Rm-XXXX-XXXX-XXXX";
        }
    }

    public static class ShippingFactory 
    {
        public static IShippingCourier CreateShippingCourier(Order order) 
        {
            if (order.TotalCost > 100 || order.WeightInKg > 5) 
            {
                return new Dhl();
            }
            return new RoyalMail();
        }
    }

    public class OrderService 
    {
        public void Dispatch(Order order) 
        {
            IShippingCourier courier = ShippingFactory.CreateShippingCourier(order);

            order.CourierTrackingId = courier.GenerateConsignmentLabelFor(order.DispachAddress);
        }
    }
}