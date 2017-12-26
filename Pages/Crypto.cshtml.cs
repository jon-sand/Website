using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace RazorPageWebsite.Pages
{
    public class CryptoModel : PageModel
    {
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnGetProxyAsync(string url)
        {
            try
            {
                Console.WriteLine($"Proxy request. URL: {url}");
                var client = new HttpClient();
                var stringTask = client.GetStringAsync(url);

                var msg = await stringTask;
                return new JsonResult(msg);       
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Error in proxy. Message: {e.Message}");
                return new JsonResult(e.Message);
            }
        }
    }
}
