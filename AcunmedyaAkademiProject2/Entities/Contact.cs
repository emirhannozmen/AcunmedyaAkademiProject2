﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunmedyaAkademiProject2.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}