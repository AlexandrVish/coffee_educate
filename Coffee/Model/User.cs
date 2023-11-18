﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Model
{
    public class User: IdentityUser
    {
        public DateTime Created { get; set; }
    }
}
