using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class GenericService<T> where T:class
    {
        private readonly HttpClient httpClient;

        public GenericService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<T> Get(int id)
        {
            return await httpClient.GetJsonAsync<T>($"api/{nameof(T)}/{id}");
        }

        public async Task<IEnumerable<T>> GetList()
        {
            return await httpClient.GetJsonAsync<T[]>($"api/{nameof(T)}");
        }
    }
}
