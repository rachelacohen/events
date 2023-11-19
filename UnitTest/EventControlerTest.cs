using Api_Calender.Controllers;
using Api_Calender;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class EventControlerTest
    {
      
            private readonly EventsController _controller;
            private readonly IDataContext _dataContext;


            public EventControlerTest()
            {
                _dataContext = new FakeContext();
                _controller = new EventsController(_dataContext);
            }

        [Fact]
        public void Get_ReturnsOKResult()
        {
            //Act
            var result = _controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
         

            [Fact]
            public void Post_ReturnsOkResult()
            {
                var testId = 1;
            var result = _controller.Post(new Event { Id = 5, Start = new DateTime(2023, 09, 01) });
                Assert.IsType<OkObjectResult>(result);
            }

            [Fact]
        public void gettById_ReturnsOkResult()
        {
            var testId = 5;
            var result = _controller.Get(testId);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void puttById_ReturnsOkResult()
        {
            var testId = 5;
            var result = _controller.Put(testId, new Event { Id = 5, Start = new DateTime(2023, 09, 01) });
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void deleteById_ReturnsOkResult()
        {
            var testId = 5;
            var result = _controller.Delete(testId);
            Assert.IsType<NotFoundResult>(result);
        }

    }
}
