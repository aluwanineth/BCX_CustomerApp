using CsvHelper;
using Customer.Import.Contracts;
using Customer.Import.Dtos;
using CustomerApp.DataLayer.Contracts;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Customer.Import.Services
{
    public class CustomerImport : ICustomerImport
    {
        private readonly ICustomerRepositoryAsync _customerRepository;
        public CustomerImport(ICustomerRepositoryAsync customerRepository) 
        {
            _customerRepository = customerRepository;
        }
        public void ImportCustomer()
        {
            string filename = ConfigurationManager.AppSettings["customerCSVname"];
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var customers = csv.GetRecords<CustomerDto>().ToList();

                foreach (var customer in customers)
                {
                    _customerRepository.SaveOrUpdate(new CustomerApp.DataLayer.Models.Customer
                    {
                        Name = customer.Name,
                    });
                }
            }
        }
        public void LoadCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
