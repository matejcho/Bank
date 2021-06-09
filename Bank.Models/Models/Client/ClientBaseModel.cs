using Bank.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models.Models.Client
{
    public class ClientBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ClientType ClientTypeId { get; set; }
    }
}
