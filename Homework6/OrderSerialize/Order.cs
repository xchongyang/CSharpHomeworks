using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ordertest
{

    /**
     * Order class : order 
     * to record each goods and its quantity in this ordering
     **/
    public class Order
    {

        private List<OrderDetail> orderDetailsList;

        /// <summary>
        /// default constructor
        /// </summary>
        public Order() { orderDetailsList = new List<OrderDetail>(); }

        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="orderId">order id</param>
        /// <param name="customer">who orders goods</param>
        public Order(uint orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer;
            orderDetailsList = new List<OrderDetail>();
        }
        /// <summary>
        /// order id
        /// </summary>
        public uint OrderId { get; set; }

        /// <summary>
        /// the man who orders goods
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// List of all orderDetails in this order
        /// </summary>
        /// <returns>List<OrderDetail></returns>
        public List<OrderDetail> OrderDetails
        {
            get { return orderDetailsList; }
        }

        /// <summary>
        /// add a new orderDetail to order
        /// </summary>
        /// <param name="orderDetail">the new orderDetail which will be added</param>
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetailsList
                .Where(od => od.OrderDetailId == orderDetail.OrderDetailId)
                .ToList().Count > 0)
            {
                throw new Exception($"orderDetails-{orderDetail.OrderDetailId} is already existed!");
            }
            else {
                orderDetailsList.Add(orderDetail);
            }
        }

        /// <summary>
        /// remove orderDetail by orderDetailId from order
        /// </summary>
        /// <param name="orderDetailId">id of the orderDetail which will be removed</param>
        public void RemoveOrderDetail(uint orderDetailId)
        {
            for (int i = 0; i < orderDetailsList.Count; ++i)
            {
                if (orderDetailsList[i].OrderDetailId == orderDetailId)
                {
                    orderDetailsList.RemoveAt(i);
                    return;
                }
            }
            throw new Exception($"orderDetails-{orderDetailId} is not existed!");
        }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the Order object</returns>
        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{OrderId}, customer:({Customer})";
            orderDetailsList.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
    }
}
