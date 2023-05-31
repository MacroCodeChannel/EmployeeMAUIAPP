using EmployeeApp.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public class ProductService
    {
        ProductsVM products = new();

        HttpClient httpClient;

        public ProductService()
        {
            this.httpClient = new HttpClient();
        }


        public async Task<ProductsVM> GetProductsList()
        {
            //https://dummyjson.com/products

            if(products == null)
            return products;

            // Online
            var response = await httpClient.GetAsync("https://dummyjson.com/products");
            if(response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadFromJsonAsync<ProductsVM>();
            }

            return products;
        }
    }
}
