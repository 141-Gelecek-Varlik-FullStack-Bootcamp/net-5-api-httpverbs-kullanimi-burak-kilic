using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model.UserAPI;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]s")] // api/Users



    //Statik kullanıcı listesi oluştur
    public class UserController : ControllerBase
    {
        private static List<User> UserList = new List<User>()
        {
            new User{
                Id = 1,
                Username = "burakkilic",
                Password = "password",
                FullName = "Burak Kılıç"
            },
            new User{
                Id = 2,
                Username = "johndoe",
                Password = "p@55w0rd",
                FullName = "John Doe"
            }
        };
        
        //Kullanıcı listesini id'ye göre sıralı şekilde listele
        [HttpGet] // https:localhost:5001/api/Users
        public List<User> GetUsers()
        {
            var userList = UserList.OrderBy( user => user.Id).ToList();
            return userList;
        }
        //Sadece girilen id'ye ait kullanıcı bilgisini yolla
        [HttpGet("{id}")] // https:localhost:5001/api/Users/1 
        public User GetUserById(int id)
        {
            var userInfo = UserList.Where( user => user.Id == id).SingleOrDefault();
            return userInfo;
        }

        //Girilen kullanıcı adı bilgisi statik kullanıcı listesinde yok ise ekle
        [HttpPost]
        public IActionResult AddUser([FromBody] User newUser)
        {
            var user = UserList.SingleOrDefault( user => user.Username == newUser.Username);
            if(user != null)
            {
                return BadRequest();
            }
            UserList.Add(newUser);
            return Ok();
        }
        
        
        //Girilen id'ye göre kullanıcı bilgilerini güncelle
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = UserList.SingleOrDefault(x => x.Id == id);
            if (user is null)
            {
                return BadRequest();
            }
            
            user.Username = updatedUser.Username != default ? updatedUser.Username : user.Username;
            user.Password = updatedUser.Password != default ? updatedUser.Password : user.Password;
            user.FullName = updatedUser.FullName != default ? updatedUser.FullName : user.FullName;
            user.Id = updatedUser.Id != default ? updatedUser.Id : user.Id;

            return Ok();
        }
        //Girilen id'ye göre kullanıcı bilgilerini sil
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = UserList.SingleOrDefault(x => x.Id == id);

            if (user is null) 
            {
                return BadRequest();
            }

            UserList.Remove(user);
            return Ok();
        }

    }

}
