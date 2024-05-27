using LionDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LionDev.Services;
using System.Threading.Tasks;
using System;

namespace LionDev.Controllers
{
    [ApiController]
    [Route("api/email_test")]
    public class EmailTestController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailTestController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            string subject = "Test Email";
            string content = "This is a test email. Please ignore...";

            try
            {
                await _emailService.SendEmailAsync("graphicgroovecustomer@gmail.com", subject, content);
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new JsonResult(new { success = false });
            }

            return new JsonResult(new { success = true });
        }
    }
}
