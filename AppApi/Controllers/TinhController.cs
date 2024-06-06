using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhController : ControllerBase
    {
        [HttpGet("tinh-bmi")]
        public double BMI(double cao, double nang)
        {
            return nang / cao / cao;
        }
        [HttpPost("lon-thu-hai")]
        public string Second(int[] arr)
        {
            // Bước 1 sort (sắp xếp)
            Array.Sort(arr); 
            int second = arr[arr.Length-1];
            for (int i = arr.Length - 2; i >=0; i--)
            {
                if (arr[i] < second)
                {
                    second = arr[i]; break;
                }
            }
            if (second < arr[arr.Length - 1]) return "Phần tử lớn thứ 2 là " + second;
            else return "Không có phần tửu lớn thứ 2";
        }
    }
}
