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
            connection.Close();
        }
        return orders;
    }
    public Orders GetOrdersById(int ordersID) // Assumming we get only the order on the OrdersID
    {
        var order = new Orders();
        string query = "select OrderID, CustomerID, OrderDate, TotalAmount from Orders WHERE OrderID = @ordersID";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ordersID", ordersID);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                try
                {
                    while (reader.Read())
                    {
                        {
                            order.OrderId = reader.GetInt32(0);
                            order.CustomerId = reader.GetInt32(1);
                            order.OrderDate = reader.GetDateTime(2);
                            order.TotalAmount = reader.GetDecimal(3);
                        };
                    }
                }
                catch (Exception ex) { Console.WriteLine($"Order with {ordersID} not found."); return null; }
            }
            connection.Close();
        }
        return order;
    }
    public void AddOrders(Orders Orders)
    {
        string query = "insert into Orders values (`@OrderID`, `@CustomerID`, `@OrderDate`, `@TotalAmount`)";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", Orders.OrderId);
            command.Parameters.AddWithValue("@CustomerID", Orders.CustomerId);
            command.Parameters.AddWithValue("@OrderDate", Orders.OrderDate);
            command.Parameters.AddWithValue("@TotalAmount", Orders.TotalAmount);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void UpdateOrders(Orders Orders)
    {
        // what should this do?
    }
    public void DeleteOrders(int ordersID)
    {
        string query = "delete from Orders where `OrderID` = @OrderID";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", ordersID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
