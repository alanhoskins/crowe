using Xunit;
using CroweApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using CroweApi;

namespace Crowe.Tests
{
    public class Crowe_WritesMessages
    {
        [Fact]
        public void ShouldReturnNoContentResult()
        {
            var messageController = new MessageController();
            var message = new MessageRequest { Message = "hello world" };
            var result = messageController.Post(message) as NoContentResult;
            Assert.NotNull(result);
        }
    }
}
