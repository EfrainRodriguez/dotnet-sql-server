using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.NetworkInformation;
using UserAPI.Models;
using UserAPI.Resources;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public dynamic ListPersons()
        {

            DataTable persons = DBConnection.ListPerson("procedure_select_persons");

            string jsonPersons = JsonConvert.SerializeObject(persons);

            return new
            {
                status = "OK",
                message = "Persons recovered!",
                data = jsonPersons
            };
        }

        [HttpPost]
        public dynamic CreatePerson(Person person)
        {
            string token = Request.Headers.Where(t => t.Key == "Authorization").FirstOrDefault().Value;

            if (string.Compare(token, "token123") != 0)
            {
                return new
                {
                    status = "Unauthorized",
                    message = "Invalid token"
                };
            }

            Person p = new() { Id = person.Id };

            return new {
                status = "OK",
                message = "Person created!",
                data = p
            };
        }
    }
}
