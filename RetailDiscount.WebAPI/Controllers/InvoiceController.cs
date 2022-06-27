using Microsoft.AspNetCore.Mvc;
using RetailDiscount.Business.Abstract;
using RetailDiscount.Core.Utilities.Results;

namespace RetailDiscount.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpGet("GetInvoiceCalculate")]


        public IActionResult GetInvoiceCalculate(int id)
        {
            var lst= _invoiceService.GetInvoiceCalculate(id);

            return Ok(lst);
        }
    }
}
