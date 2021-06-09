using Bank.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ClientType ClientTypeId { get; set; }
    }
}
