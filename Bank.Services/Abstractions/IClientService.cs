using Bank.Models.Models.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Abstractions
{
    public interface IClientService
    {
        Task<ClientBaseModel> GetById(int id);

        Task<IEnumerable<ClientBaseModel>> Get();

        Task<ClientBaseModel> Insert(ClientCreateModel model);

        Task<ClientBaseModel> Update(ClientUpdateModel model);

        Task<bool> Delete(int id);
    }
}
