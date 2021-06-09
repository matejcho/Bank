using Bank.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank.Models.Models.Account
{
    public class AccountCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public AccountType AccountTypeId { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
