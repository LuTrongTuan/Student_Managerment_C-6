using System;

namespace DTO.Account
{
    public class RegisterAccount
    {
        public string Username { get; set;} = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; } = string.Empty;
      
    }
}
