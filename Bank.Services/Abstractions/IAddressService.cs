using Bank.Models.Models.Address;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Abstractions
{
    public interface IAddressService
    {
        Task<AddressBaseModel> GetById(int id);

        Task<IEnumerable<AddressBaseModel>> Get();

        Task<AddressBaseModel> Insert(AddressCreateModel model);

        Task<AddressBaseModel> Update(AddressUpdateModel model);

        Task<bool> Delete(int id);
    }
}
