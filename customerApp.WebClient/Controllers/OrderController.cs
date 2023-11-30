using customerApp.WebClient.Models;
using CustomerApp.DataLayer.Contracts;
using CustomerApp.DataLayer.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace customerApp.WebClient.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepositoryAsync _orderRepositoryAsync;
        private readonly IOrderIDetailRepositoryAsync _orderItemRepositoryAsync;
        private readonly ICustomerRepositoryAsync _customerRepository;
        public OrderController(IOrderRepositoryAsync orderRepositoryAsync, ICustomerRepositoryAsync customerRepository, IOrderIDetailRepositoryAsync orderItemRepositoryAsync)
        {
            _orderRepositoryAsync = orderRepositoryAsync;
            _customerRepository = customerRepository;
            _orderItemRepositoryAsync = orderItemRepositoryAsync;
        }
        public async Task<ActionResult> Index()
        {
            var orders = await _orderRepositoryAsync.GetAll();
            return View(orders);
        }

        public async Task<ActionResult> GetOrderByCustomer(int customerId)
        {
            var customer = await _customerRepository.GetById(customerId);
            var orders = await _orderRepositoryAsync.GetOrdersForCustomer(customer);
            ViewBag.CustomerId = customerId;
            return View(orders);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteOrder(int orderId)
        {
            bool success = await DeleteOrderById(orderId);

            return Json(new { success = success });
        }

        private async Task<bool> DeleteOrderById(int orderId)
        {
            try
            {
                var order = await _orderRepositoryAsync.GetById(orderId);

                //remove orderItems
                foreach (var orderDetail in order.OrderItems.ToList())
                {
                    await _orderItemRepositoryAsync.DeleteAsync(orderDetail);
                }
                await _orderRepositoryAsync.DeleteAsync(order);
            }
            catch (Exception ex) { }
            return true; 
        }
        public async Task<ActionResult> OrderDetail(int orderId)
        {
            var order = await _orderRepositoryAsync.GetOrderWithItems(orderId);
            return View(order);
        }

        // GET: Order/AddItem
        public ActionResult AddItem(int orderId)
        {
            var viewModel = new OrderItemViewModel();
            viewModel.OrderId = orderId;
            return View(viewModel);
        }

        // POST: Order/AddItem
        [HttpPost]
        public async Task<ActionResult> AddItem(OrderItemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var item = new OrderDetail
                { 
                    ItemDescription = viewModel.ItemDescription,
                    OrderId = viewModel.OrderId,
                    Price = viewModel.Price,    
                    Quantity = viewModel.Quantity,
                    Order = await _orderRepositoryAsync.GetById(viewModel.OrderId)
                    
                };

                await _orderItemRepositoryAsync.SaveOrUpdate(item);

                return RedirectToAction("OrderDetail", new { orderId = viewModel.OrderId });
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<JsonResult> AddOrder(OrderViewModel orderVM)
        {
            var customer = await _customerRepository.GetById(orderVM.CustomerId);
            var order = new Order
            {
                OrderDate = DateTime.Now,
                Customer = customer
            };

            await _orderRepositoryAsync.SaveOrUpdate(order);

            return Json(new { success = true, orderId = order.Id });
        }
    }
}