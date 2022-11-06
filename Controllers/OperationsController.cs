using Microsoft.AspNetCore.Mvc;
using Stage_Twos.Models;

namespace Stage_Twos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController: ControllerBase
    {

        [HttpPost(Name = "postOperation")]
        public ActionResult<OutputData> operation(string operation_type)
        {
            int x = 20;
            int y = 30;
            operation_type = operation_type.ToLower();
            string addition = OperationType.addition.ToString();
            string subtraction = OperationType.subtraction.ToString();
            string multiplication = OperationType.multiplication.ToString();

            if(operation_type == addition)
            {
                return new OutputData()
                {
                    result = x + y,
                    operations = addition
                    
                };
            }
            else if (operation_type == subtraction)
            {
                return new OutputData()
                {
                    result = x - y,
                    operations = subtraction

                };
            }
            else if (operation_type == multiplication)
            {
                return new OutputData()
                {
                    result = x * y,
                    operations = multiplication

                };
            }
            return new OutputData();
        }
        
    }
}
