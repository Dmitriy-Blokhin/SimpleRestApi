using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using SimpleRestApi.Models;

namespace SimpleRestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly User[] _users = {
            new User {Id = 1, Login = "Ivan1", Name = "Ivan", SurName = "Bobrov", Email = "Ivan.Bobrov@mail.net"},
            new User {Id = 2, Login = "Petr1", Name = "Petr", SurName = "Ivanov", Email = "Petr.Ivanov@mail.net"},
            new User {Id = 3, Login = "Roman1", Name = "Roman", SurName = "Sidorov", Email = "Roman.Sidorov@mail.net"}
        };

        // GET: api/Users
        [Route("")]
        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        // GET: api/Users/5
        [Route("{id:int}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
