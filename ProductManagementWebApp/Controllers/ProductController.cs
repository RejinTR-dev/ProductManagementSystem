using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebApp.BLL;
using ProductManagementWebApp.Models;

namespace ProductManagementWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ProductBLL _productBLL;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
             var client = _httpClientFactory.CreateClient();
            _productBLL = new ProductBLL(client);
        }

        [Authorize]
        public bool saveProductDetails(Product product)
        {
            bool val= _productBLL.saveProductDetailsBLL(product).Result;
            return val;
        }

        [Authorize]
        public async Task<PartialViewResult> getProductDetails()
        {
            List<Product> product = await _productBLL.getProductDetailsBLL();
            return await Task.Run(()=> this.PartialView("~/Views/ProductGrid.cshtml", product));
        }
    }
}
