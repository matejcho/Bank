using Bank.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank.Models.Models.Client
{
    public class ClientUpdateModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ClientType ClientTypeId { get; set; }
    }
}
