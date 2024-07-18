using FurnitureShopNew.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class OrdersRepo : IOrdersRepo
{
    private readonly string _connectionString;

    public OrdersRepo(string connectionString)
    {
        _connectionString = connectionString;
    }
    public IEnumerable<Orders> GetAllOrders()
    {
        var orders = new List<Orders>();
        string query = "select OrderID, CustomerID, OrderDate, TotalAmount from Orders";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var order = new Orders();
                    {
                        order.OrderId = reader.GetInt32(0);
                        order.CustomerId = reader.GetInt32(1);
                        order.OrderDate = reader.GetDateTime(2);
                        order.TotalAmount = reader.GetDecimal(3);
                    };
                    orders.Add(order);
                }
            }
        }
        return orders;
    }
}