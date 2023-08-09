﻿using System.ComponentModel.DataAnnotations;

namespace SimpleApi_DotNetCoreWebApi
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Place { get; set; } = string.Empty;
    }
}
