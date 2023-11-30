using Customer.DataLayer.Repositories;
using Customer.Import.Contracts;
using CustomerApp.DataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace customerApp.WebClient.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepositoryAsync _customerRepositoryAsync;
        private readonly ICustomerImport _customerImport;
        private readonly IOrderRepositoryAsync _orderRepositoryAsync;
        public CustomerController(ICustomerImport customerImport, ICustomerRepositoryAsync customerRepositoryAsync, IOrderRepositoryAsync orderRepositoryAsync)
        {
            _customerRepositoryAsync = customerRepositoryAsync;
            _customerImport = customerImport;
            _orderRepositoryAsync = orderRepositoryAsync;
        }

        [HttpGet]
        public ActionResult Import()
        {
            _customerImport.ImportCustomer();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Index()
        {
            var customers = await _customerRepositoryAsync.GetAll();
            return View(customers);
        }

        public async Task<ActionResult> GetCustomer(int customerId)
        {
            var customer = await _customerRepositoryAsync.GetCustomerWithOrders(customerId);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}