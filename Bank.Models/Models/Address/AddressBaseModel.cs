using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models.Models.Address
{
    public class AddressBaseModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
