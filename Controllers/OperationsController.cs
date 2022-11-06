using Microsoft.AspNetCore.Mvc;
using Stage_Twos.Models;
using Flurl.Http;

namespace Stage_Twos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController: ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpPost(Name = "postOperation")]
        public async Task<string> operation(string operation_type)
        {
            int x = 20;
            int y = 30;
            operation_type = operation_type.ToLower();
            string addition = OperationType.addition.ToString();
            string subtraction = OperationType.subtraction.ToString();
            string multiplication = OperationType.multiplication.ToString();

            if(operation_type == addition)
            {

               var output =  new OutputData()
                {
                    result = x + y,
                    operations = addition
                    
                };
                var content = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)output);

                var response = await client.PostAsync("https://localhost:7076/Operation?operation_type=addition", content);

                var responseString = await response.Content.ReadAsStringAsync();
               return responseString;
            }
            else if (operation_type == subtraction)
            {
                var output = new OutputData()
                {
                    result = x - y,
                    operations = subtraction

                };
                var content = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)output);

                var response = await client.PostAsync("https://localhost:7076/Operation?operation_type=subtraction", content);

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
            else if (operation_type == multiplication)
            {
                var output = new OutputData()
                {
                    result = x * y,
                    operations = multiplication

                };
                var content = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)output);

                var response = await client.PostAsync("https://localhost:7076/Operation?operation_type=multiplication", content);

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
            return new OutputData().ToString();
        }
        
    }
}
