using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Account")]
        [Trait("Area", "Services")]
        public partial class AccountServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IAccountRepository>();
                        var records = new List<Account>();
                        records.Add(new Account());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new AccountService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.AccountModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLAccountMapperMock,
                                                         mock.DALMapperMockFactory.DALAccountMapperMock);

                        List<ApiAccountResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IAccountRepository>();
                        var record = new Account();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new AccountService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.AccountModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLAccountMapperMock,
                                                         mock.DALMapperMockFactory.DALAccountMapperMock);

                        ApiAccountResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IAccountRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Account>(null));
                        var service = new AccountService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.AccountModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLAccountMapperMock,
                                                         mock.DALMapperMockFactory.DALAccountMapperMock);

                        ApiAccountResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IAccountRepository>();
                        var model = new ApiAccountRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Account>())).Returns(Task.FromResult(new Account()));
                        var service = new AccountService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.AccountModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLAccountMapperMock,
                                                         mock.DALMapperMockFactory.DALAccountMapperMock);

                        CreateResponse<ApiAccountResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.AccountModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAccountRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Account>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IAccountRepository>();
                        var model = new ApiAccountRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Account>())).Returns(Task.FromResult(new Account()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));
                        var service = new AccountService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.AccountModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLAccountMapperMock,
                                                         mock.DALMapperMockFactory.DALAccountMapperMock);

                        UpdateResponse<ApiAccountResponseModel> response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.AccountModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiAccountRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Account>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IAccountRepository>();
                        var model = new ApiAccountRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new AccountService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.AccountModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLAccountMapperMock,
                                                         mock.DALMapperMockFactory.DALAccountMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.AccountModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IAccountRepository>();
                        var record = new Account();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new AccountService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.AccountModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLAccountMapperMock,
                                                         mock.DALMapperMockFactory.DALAccountMapperMock);

                        ApiAccountResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IAccountRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Account>(null));
                        var service = new AccountService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.AccountModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLAccountMapperMock,
                                                         mock.DALMapperMockFactory.DALAccountMapperMock);

                        ApiAccountResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>10c1efb7d5ce2a8a556116b61532a7ff</Hash>
</Codenesium>*/