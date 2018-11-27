using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ordertest
{

    /**
     * OrderService:provide service for users about ordering,
     * like add order, remove order, query order and so on
     * 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
     * */
    public class OrderService
    {

        // uint : orderId, Order : Order obj
        private Dictionary<uint, Order> orderDict;

        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> Orders
        {
            get { return orderDict.Values.ToList(); }
        }

        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order">the order will be added</param>
        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.OrderId))
                throw new Exception("Order is already existed!");
            orderDict[order.OrderId] = order;
        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="orderId">id of the order which will be canceled</param> 
        public void RemoveOrder(uint orderId)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict.Remove(orderId);
            }
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns> 
        public List<Order> QueryOrderById(uint orderId)
        {
            return orderDict.Values.ToList<Order>()
                .Where(order => order.OrderId == orderId)
                .ToList();      // LINQ Query
        }

        /// <summary>
        /// query by goodsName
        /// </summary>
        /// <param name="goodsName">the name of goods in order's orderDetail</param>
        /// <returns></returns> 
        public List<Order> QueryOrdersByGoodsName(string goodsName)
        {
            List<Order> result = new List<Order>();
            orderDict.Values.ToList().ForEach(order => {    // using Lamada
                List<OrderDetail> orderDetailsList = order.OrderDetails
                    .Where(orderDetail => orderDetail.Goods.GoodsName == goodsName)
                    .ToList();      // using LINQ
                if (orderDetailsList.Count > 0)
                    result.Add(order);
            });
            return result;
        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns> 
        public List<Order> QueryOrdersByCustomerName(string customerName)
        {
            return orderDict.Values.ToList()
                .Where(order => order.Customer.CustomerName == customerName)
                .ToList();  // LINQ Query
        }

        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateOrderCustomer(uint orderId, Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else {
                throw new Exception("Order is not existed!");
            }
        }

        /// <summary>
        /// Store the order object to file orders.xml
        /// </summary>
        public string Export()
        {
            DateTime time = System.DateTime.Now;
            string fileName = "orders_" + time.Year + "_" + time.Month
                + "_" + time.Day + "_" + time.Hour + "_" + time.Minute
                + "_" + time.Second + ".xml";
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, Orders);
            }
            return fileName;
        }

        /// <summary>
        /// import the orders object from xml file in path
        /// return the order imported to service obj
        /// </summary>
        public List<Order> Import(string path)
        {
            if (Path.GetExtension(path) != ".xml")
                throw new ArgumentException("It isn't a xml file!");
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            List<Order> result = new List<Order>();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    List<Order> temp = (List<Order>)xs.Deserialize(fs);
                    temp.ForEach(order => {
                        if (!orderDict.Keys.Contains(order.OrderId))
                        {
                            orderDict[order.OrderId] = order;
                            result.Add(order);
                        }
                    });
                }
            }
            catch (FileNotFoundException)
            {
                throw new Exception("File not found!");
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Xml file code error!");
            }
            return result;
        }
        /*other update function will write in the future.*/
    }
}
