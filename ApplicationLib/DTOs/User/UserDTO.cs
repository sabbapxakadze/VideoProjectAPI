﻿namespace ApplicationLib.DTOs.User
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }
}
