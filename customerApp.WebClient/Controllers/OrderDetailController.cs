using Customer.DataLayer.Repositories;
using customerApp.WebClient.Models;
using CustomerApp.DataLayer.Contracts;
using CustomerApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace customerApp.WebClient.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IOrderIDetailRepositoryAsync _orderItemRepositoryAsync;

        public OrderDetailController(IOrderIDetailRepositoryAsync orderItemRepositoryAsync)
        {
            _orderItemRepositoryAsync = orderItemRepositoryAsync;
        }

        public async Task<ActionResult> UpdateOrderDetail(int id)
        {
            var orderDetail = await _orderItemRepositoryAsync.GetById(id);
            return View(orderDetail);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteOrderItem(int orderId)
        {
            bool success = await DeleteOrderItemById(orderId);

            return Json(new { success = success });
        }

        private async Task<bool> DeleteOrderItemById(int orderId)
        {
            try
            {
                var order = await _orderItemRepositoryAsync.GetById(orderId);
                await _orderItemRepositoryAsync.DeleteAsync(order);
            }
            catch (Exception ex) { }
            return true;
        }
        //[HttpPost]
        //public async Task<JsonResult> UpdateOrderDetail(int id, OrderDetail orderDetail)
        //{

        //    var orderDetail = await _orderItemRepositoryAsync.GetById(orderItemViewModel.Id);

        //    if (orderDetail != null)
        //    {

        //        orderDetail.Price = orderItemViewModel.Price;
        //        orderDetail.Quantity = orderItemViewModel.Quantity;
        //        orderDetail.ItemDescription = orderItemViewModel.ItemDescription;

        //        await _orderItemRepositoryAsync.SaveOrUpdate(orderDetail);

        //        return Json(new { success = true, message = "OrderDetail updated successfully." });
        //    }

        //    return Json(new { success = false, message = "OrderDetail not found." });
        //}

        [HttpPost]
        public async Task<ActionResult> UpdateOrderDetail(int id, OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _orderItemRepositoryAsync.SaveOrUpdate(orderDetail);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetail);
        }
        // GET: OrderDetail
        public ActionResult Index()
        {
            return View();
        }
    }
}