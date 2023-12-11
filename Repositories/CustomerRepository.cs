using Microsoft.EntityFrameworkCore;

using sql_raw_queries_ef.Data;
using sql_raw_queries_ef.Models;

namespace sql_raw_queries_ef.Repositories;

public class CustomerRepository : IDisposable
{
    private readonly AppDbContext _dbContext = new();

    public Customer CreateCustomer(Customer customer)
    {
        _dbContext.Database.ExecuteSqlInterpolated($"INSERT INTO Customers (Name, Email) VALUES ({ customer.Name }, { customer.Email })");
        customer.Id = _dbContext.Database.SqlQuery<int>($"SELECT LAST_INSERT_ROWID() AS Id").AsEnumerable().FirstOrDefault();
        
        return customer;
    }

    public Customer UpdateCustomer(Customer customer)
    {
        _dbContext.Database.ExecuteSqlInterpolated($"UPDATE Customers SET Name = { customer.Name }, Email = { customer.Email } WHERE Id = { customer.Id }");
        
        return customer;
    }

    public bool DeleteCustomer(int id)
    {
        _dbContext.Database.ExecuteSqlInterpolated($"DELETE FROM Customers WHERE Id = { id }");
        
        return true;
    }

    public Customer? GetCustomerById(int id)
    {
        return _dbContext.Database.SqlQuery<Customer>($"SELECT * FROM Customers WHERE Id = { id }").FirstOrDefault();
    }

    public List<Customer> GetAllCustomers()
    {
        return [.. _dbContext.Database.SqlQuery<Customer>($"SELECT * FROM Customers")];
    }

    public void Dispose() => _dbContext.Dispose();
}