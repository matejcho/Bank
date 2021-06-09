using AutoMapper;
using Bank.Data;
using Bank.Data.Entities;
using Bank.Models.Models.Address;
using Bank.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly BankDbContext _context;
        private readonly IMapper _mapper;
        public AddressService(BankDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AddressBaseModel> GetById(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            return _mapper.Map<AddressBaseModel>(address);
        }
        public async Task<IEnumerable<AddressBaseModel>> Get()
        {
            var addresses = await _context.Addresses.ToListAsync();
            return _mapper.Map<IEnumerable<AddressBaseModel>>(addresses);
        }

        public async Task<AddressBaseModel> Insert(AddressCreateModel model)
        {
            var entity = _mapper.Map<Address>(model);

            await _context.Addresses.AddAsync(entity);
            await SaveAsync();

            return _mapper.Map<AddressBaseModel>(entity);
        }

        public async Task<AddressBaseModel> Update(AddressUpdateModel model)
        {
            var entity = await _context.Addresses.FindAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Address not found");
            }
            _mapper.Map(model, entity);

            _context.Addresses.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();

            return _mapper.Map<AddressBaseModel>(entity);
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(entity);
            return await SaveAsync() > 0;
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
