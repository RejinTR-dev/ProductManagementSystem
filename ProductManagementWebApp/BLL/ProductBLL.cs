using ProductManagementWebApp.Models;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace ProductManagementWebApp.BLL
{
    public class ProductBLL
    {
        private readonly HttpClient _httpClient;

        public ProductBLL(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> saveProductDetailsBLL(Product product)
        {
            product.Id = 0;
            var json = JsonSerializer.Serialize(product); 
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            string url = "https://localhost:7272/api/Product";
            var response = await _httpClient.PostAsync(url, content).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) 
            { 
              return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateProductDetailsBLL(Product product)
        {
            product.Id = 0;
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            string url = "https://localhost:7272/api/Product";
            var response = await _httpClient.PostAsync(url, content).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Product>>getProductDetailsBLL()
        {
            List<Product> productResult = new List<Product>();
            try
            {

                string url = "https://localhost:7272/api/Product";
                var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    productResult = Utility.JsonResultDeserializer<List<Product>>(responseContent);
                    return productResult;
                }
                else
                {
                    return productResult;
                }

            }
            catch (Exception ex)
            {
                return productResult;
            }
        }
    }
}
