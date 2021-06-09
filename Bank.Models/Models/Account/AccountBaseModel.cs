using Bank.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models.Models.Account
{
    public class AccountBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
