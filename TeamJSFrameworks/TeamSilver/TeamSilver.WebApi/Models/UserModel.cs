using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TeamSilver.WebApi.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
        [DataMember(Name = "password")]
        public string Password { get; set; }
        [DataMember(Name = "role")]
        public string Role { get; set; }
        [DataMember(Name = "products")]
        public virtual IEnumerable<ProductModel> Products { get; set; }

        public UserModel()
        {
            this.Products = new HashSet<ProductModel>();
        }
    }
}