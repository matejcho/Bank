using AutoMapper;
using Bank.Data;
using Bank.Data.Entities;
using Bank.Models.Models.Client;
using Bank.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Services
{
    public class ClientService : IClientService
    {
        private readonly BankDbContext _context;
        private readonly IMapper _mapper;
        public ClientService(BankDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ClientBaseModel> GetById(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            return _mapper.Map<ClientBaseModel>(client);
        }
        public async Task<IEnumerable<ClientBaseModel>> Get()
        {
            var clients = await _context.Clients.ToListAsync();
            return _mapper.Map<IEnumerable<ClientBaseModel>>(clients);
        }

        public async Task<ClientBaseModel> Insert(ClientCreateModel model)
        {
            var entity = _mapper.Map<Client>(model);

            await _context.Clients.AddAsync(entity);
            await SaveAsync();

            return _mapper.Map<ClientBaseModel>(entity);
        }

        public async Task<ClientBaseModel> Update(ClientUpdateModel model)
        {
            var entity = await _context.Clients.FindAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Client not found");
            }
            _mapper.Map(model, entity);

            _context.Clients.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();

            return _mapper.Map<ClientBaseModel>(entity);
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(entity);
            return await SaveAsync() > 0;
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
