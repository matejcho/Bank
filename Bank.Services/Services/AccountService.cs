using AutoMapper;
using Bank.Data;
using Bank.Data.Entities;
using Bank.Models.Models.Account;
using Bank.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly BankDbContext _context;
        private readonly IMapper _mapper;
        public AccountService(BankDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AccountBaseModel> GetById(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            return _mapper.Map<AccountBaseModel>(account);
        }
        public async Task<IEnumerable<AccountBaseModel>> Get()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return _mapper.Map<IEnumerable<AccountBaseModel>>(accounts);
        }

        public async Task<AccountBaseModel> Insert(AccountCreateModel model)
        {
            var entity = _mapper.Map<Account>(model);

            await _context.Accounts.AddAsync(entity);
            await SaveAsync();

            return _mapper.Map<AccountBaseModel>(entity);
        }

        public async Task<AccountBaseModel> Update(AccountUpdateModel model)
        {
            var entity = await _context.Accounts.FindAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Account not found");
            }
            _mapper.Map(model, entity);

            _context.Accounts.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();

            return _mapper.Map<AccountBaseModel>(entity);
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(entity);
            return await SaveAsync() > 0;
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
