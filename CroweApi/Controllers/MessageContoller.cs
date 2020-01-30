using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CroweApi.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessageController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MessageController()
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        [HttpPost]
        public ActionResult Post(MessageRequest request)
        {
            try
            {
                MessageWriter writer;
                var output = _configuration.GetSection("Settings").GetSection("Output").Value;
                switch (output)
                {
                    case "Console":
                    default:
                        writer = new ConsoleWriter();
                        break;
                }
                writer.WriteMessage(request.Message);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
