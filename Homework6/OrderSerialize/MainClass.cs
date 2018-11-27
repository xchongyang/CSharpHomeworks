﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{

    class MainClass
    {
        public static void Main()
        {
            try
            {

                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Goods milk = new Goods(1, "Milk", 69.9);
                Goods eggs = new Goods(2, "eggs", 4.99);
                Goods apple = new Goods(3, "apple", 5.59);

                OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
                OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
                OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

                Order order1 = new Order(1, customer1);
                Order order2 = new Order(2, customer2);
                Order order3 = new Order(3, customer2);
                order1.AddOrderDetail(orderDetails1);
                order1.AddOrderDetail(orderDetails2);
                order1.AddOrderDetail(orderDetails3);

                //order1.AddOrderDetails(orderDetails3);
                order2.AddOrderDetail(orderDetails2);
                order2.AddOrderDetail(orderDetails3);
                order3.AddOrderDetail(orderDetails3);

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);
                os.Export();

                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.Orders;
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("GetOrdersByCustomerName:'Customer2'");
                orders = os.QueryOrdersByCustomerName("Customer2");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("GetOrdersByGoodsName:'apple'");
                orders = os.QueryOrdersByGoodsName("apple");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("Remove order(id=2) and qurey all");
                os.RemoveOrder(2);
                orders = os.Orders;
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("Import from ./orders.xml");
                OrderService os2 = new OrderService();
                os2.Import("./orders.xml");
                os2.Orders.ForEach(order => Console.WriteLine(order));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

        }
    }
}
