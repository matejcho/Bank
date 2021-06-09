using Bank.Models.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Abstractions
{
    public interface IAccountService
    {
        Task<AccountBaseModel> GetById(int id);

        Task<IEnumerable<AccountBaseModel>> Get();

        Task<AccountBaseModel> Insert(AccountCreateModel model);

        Task<AccountBaseModel> Update(AccountUpdateModel model);

        Task<bool> Delete(int id);
    }
}
