using sql_raw_queries_ef.Models;
using sql_raw_queries_ef.Repositories;

CustomerRepository customerRepository = new();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Create Customer");
Console.WriteLine("---------------");

var createCustomerPeterParker = new Customer { Name = "Peter Parker", Email = "peter.parker@marvel.com" };
var createCustomerBenParker = new Customer { Name = "Ben Parker", Email = "ben.parker@marvel.com" };
var createCustomerMaryJane = new Customer { Name = "Mary Jane", Email = "mary.jane@marvel.com" };

var createdCustomerPeterParker = customerRepository.CreateCustomer(createCustomerPeterParker);
var createdCustomerBenParker = customerRepository.CreateCustomer(createCustomerBenParker);
var createdCustomerMaryJane = customerRepository.CreateCustomer(createCustomerMaryJane);

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"Customer created - { createdCustomerPeterParker.Id } - { createdCustomerPeterParker.Name } - { createdCustomerPeterParker.Email }");
Console.WriteLine($"Customer created - { createdCustomerBenParker.Id } - { createdCustomerBenParker. Name } - { createdCustomerBenParker.Email }");
Console.WriteLine($"Customer created - { createdCustomerMaryJane.Id } - { createdCustomerMaryJane.Name } - { createdCustomerMaryJane.Email }");
Console.WriteLine("");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Update Customer");
Console.WriteLine("---------------");

var updateCustomerMaryJane = new Customer {Id = createdCustomerMaryJane.Id, Name = "Mary Jane Watson", Email = createdCustomerMaryJane.Email};
var updatedCustomerMaryJane = customerRepository.UpdateCustomer(updateCustomerMaryJane);

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"Customer updated - { updatedCustomerMaryJane.Id } - { updatedCustomerMaryJane.Name } - { updatedCustomerMaryJane.Email }");
Console.WriteLine("");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Delete Customer");
Console.WriteLine("---------------");

if (customerRepository.DeleteCustomer(createdCustomerBenParker.Id))
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"Customer deleted - { createdCustomerBenParker.Id } - { createdCustomerBenParker.Name } - { createdCustomerBenParker.Email }");
    Console.WriteLine("");
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Get Customer");
Console.WriteLine("------------");
Console.ForegroundColor = ConsoleColor.Magenta;

var returnedCustomer = customerRepository.GetCustomerById(createdCustomerPeterParker.Id);
if (returnedCustomer is not null) Console.WriteLine($"Returned customer - { returnedCustomer.Id } - { returnedCustomer.Name } - { returnedCustomer.Email }");
Console.WriteLine("");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Get All Customers");
Console.WriteLine("-----------------");
Console.ForegroundColor = ConsoleColor.Magenta;

var returnedCustomers = customerRepository.GetAllCustomers().ToList();

foreach (var currentCustomer in returnedCustomers)
{
    Console.WriteLine($"{ currentCustomer.Id } - { currentCustomer.Name } - { currentCustomer.Email }");
}