﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoblinFreelancer.ViewModels
{
    public class UserCreateModel
    {
        [Required]
        public string Email { get; set; }
    }
}