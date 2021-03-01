﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.Entities;

namespace Entities.Concrete
{
    public class Member : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TcNo { get; set; }

    }
}
