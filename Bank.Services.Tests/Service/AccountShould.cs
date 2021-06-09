using AutoMapper;
using Bank.Data;
using Bank.Models.Models.Account;
using Bank.Models.Profiles;
using Bank.Services.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bank.Services.Tests.Service
{
    public class AccountShould
    {
        private readonly IMapper _mapper;
        private readonly AccountService _service;
        private readonly BankDbContext _context;
        public AccountShould()
        {
            if (_mapper == null)
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(typeof(AccountProfile));
                }).CreateMapper();
                _mapper = mapper;
            }
            _service = new AccountService(_context, _mapper);
        }
        [Fact]
        public async Task GetAccountById()
        {

            // Arrange
            var expected = 1;

            // Act
            var result = await _service.GetById(expected);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<Bank.Models.Models.Account.AccountBaseModel>();
            result.Id.Should().Be(expected);
        }
        [Fact]
        public async Task GetAccounts()
        {
            // Arrange
            var expected = 2;

            // Act
            var result = await _service.Get();

            // Assert
            result.Should().NotBeEmpty().And.HaveCount(expected);
            result.Should().BeAssignableTo<IEnumerable<Bank.Models.Models.Account.AccountBaseModel>>();
        }
        [Fact]
        public async Task InsertNewAnswer()
        {
            // Arrange
            var answers = new AccountCreateModel
            {
                Name = "Simon",
                Balance = 550,
                AccountTypeId = Data.Enums.AccountType.CreditCard,
                IsActive = true
            };

            // Act
            var result = await _service.Insert(answers);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<AccountBaseModel>();
            result.Id.Should().NotBe(0);
        }
        [Fact]
        public async Task UpdateAccount()
        {
            // Arrange
            var account = new AccountUpdateModel
            {
                Id = 1,
                Name = "Simon",
                Balance = 3000,
                AccountTypeId = Data.Enums.AccountType.CreditCard,
                IsActive = true
            };

            // Act
            var result = await _service.Update(account);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<AccountBaseModel>();
            result.Id.Should().Be(account.Id);
            result.Name.Should().Be(account.Name);
            result.Balance.Should().Be(account.Balance);
            result.AccountTypeId.Should().Be(account.AccountTypeId);
            result.IsActive.Should().Be(account.IsActive);
        }
        [Fact]
        public async Task ThrowExceptionOnUpdateAccount()
        {
            // Arrange
            var account = new AccountUpdateModel
            {
                Id = 10,
                Name = "Simon",
                Balance = 3500,
                AccountTypeId = Data.Enums.AccountType.CreditCard,
                IsActive = true
            };

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => _service.Update(account));
            Assert.Equal("Account not found", ex.Message);

        }
        [Fact]
        public async Task DeleteAccount()
        {
            // Arrange
            var expected = 1;

            // Act
            var result = await _service.Delete(expected);
            var account = await _service.GetById(expected);

            // Assert
            result.Should().Be(true);
            account.Should().BeNull();
        }
    }
}
