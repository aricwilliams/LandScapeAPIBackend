using LandScapeAPI.Models;
using LandScapeAPI.Repo;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace LandScapeAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMailService _mail;



        public CustomersController( ICustomerRepository CustomerRepository, IOptions<EmailMessage> settings, IMailService mail)
        {
            _customerRepository = CustomerRepository;
            _mail = mail;

        }


        [HttpGet("GetAllCustomersController")]
        public async Task<ActionResult<List<Customers>>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return Ok(customers);
        }

        [HttpPost("CustomerCreateAsync/{name}/{address}/{email}/{phone}/{status}/{nextServiceDate}/{service}")]
        public async Task<ActionResult<Customers>> CreateAsync(string name, string address, string email, string phone, string status, DateTime nextServiceDate, string service)
        {
            int serviceFrequency = GetServiceFrequency(service);

            if (serviceFrequency == 0)
            {
                throw new ArgumentException("Invalid service frequency");
            }

            nextServiceDate = DateTime.Now.AddDays(serviceFrequency);

            await SendServiceEmailAsync(service, nextServiceDate);


            Customers newCustomers = new Customers
            {
                name = name,
                address = address,
                email = email,
                phone = phone,
                status = status,
                nextServiceDate = nextServiceDate,
                service = service

            };

            var createdCustomer = await _customerRepository.CreateAsync(newCustomers);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdCustomer.id }, createdCustomer);
        }

        private int GetServiceFrequency(string service)
        {
            switch (service.ToLower())
            {
                case "weekly":
                    return 7;
                case "biweekly":
                    return 14;
                default:
                    return 0;
            }
        }

        private async Task SendServiceEmailAsync(string service, DateTime nextServiceDate)
        {
            int serviceFrequency = GetServiceFrequency(service);

            if (serviceFrequency == 0)
            {

                throw new ArgumentException("Invalid service frequency");
            }

            DateTime nextServiceDate2 = DateTime.Parse(nextServiceDate.ToString());

            while (nextServiceDate2 <= DateTime.Now)
            {
                // Send email to customer here
                // Construct the message
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Aric Williams", "aricwilliamst@gmail.com"));
                message.To.Add(new MailboxAddress("", "aricwilliamst@gmail.com"));
                message.Subject = "Your next service is due soon";
                message.Body = new TextPart("plain")
                {
                    Text = $"Your {service} service is due on {nextServiceDate2.ToString("dd/MM/yyyy")}."
                };

                // Send the message
                using var client = new SmtpClient();
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("aricwilliamst@gmail.com", "Queenstreetman12");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);


                nextServiceDate2 = nextServiceDate2.AddDays(serviceFrequency);
            }
        }

        //[HttpPost("send-email")]
        //public async Task<IActionResult> SendEmailBTNClickAsync([FromBody] EmailMessage message)
        //{
        //    try
        //    {
        //        var mimeMessage = new MimeMessage();
        //        mimeMessage.From.Add(new MailboxAddress("Sender Name", "aicwilliamst@gmail.com"));
        //        mimeMessage.To.Add(new MailboxAddress("", message.To));
        //        mimeMessage.Subject = message.Subject;
        //        mimeMessage.Body = new TextPart("html")
        //        {
        //            Text = message.Body
        //        };

        //        using var client = new SmtpClient();
        //        await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        //        await client.AuthenticateAsync("aricwilliamst@gmail.com", "Queenstreetman12");
        //        await client.SendAsync(mimeMessage);
        //        await client.DisconnectAsync(true);

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Failed to send email: {ex.Message}");
        //    }
        //}

        [HttpGet("CustomerController/{id}")]
        public async Task<ActionResult<Customers>> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpDelete("CustomerDeleteController/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _customerRepository.DeleteAsync(customer);
            return NoContent();
        }

        [HttpPut("updateCustomer/{id}/{name}/{address}/{email}/{phone}/{status}/{nextServiceDate}")]
        public async Task<ActionResult<Customers>> UpdateAsync(int id, string name, string address, string email, string phone, string status, DateTime nextServiceDate)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.name = name;
            customer.address = address;
            customer.email = email;
            customer.phone = phone;
            customer.status = status;
            customer.nextServiceDate = nextServiceDate;
            await _customerRepository.UpdateAsync(customer);

            return Ok(customer);
        }

        [HttpPost("sendmail")]
        public async Task<IActionResult> SendMailAsync(MailData mailData)
        {
            bool result = await _mail.SendAsync(mailData, new CancellationToken());

            if (result)
            {
                return StatusCode(StatusCodes.Status200OK, "Mail has successfully been sent.");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. The Mail could not be sent.");
            }
        }

    }
}
