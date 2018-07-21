using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PersonCreditCard")]
        [Trait("Area", "Services")]
        public partial class PersonCreditCardServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IPersonCreditCardRepository>();
                        var records = new List<PersonCreditCard>();
                        records.Add(new PersonCreditCard());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PersonCreditCardService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PersonCreditCardModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPersonCreditCardMapperMock,
                                                                  mock.DALMapperMockFactory.DALPersonCreditCardMapperMock);

                        List<ApiPersonCreditCardResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IPersonCreditCardRepository>();
                        var record = new PersonCreditCard();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new PersonCreditCardService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PersonCreditCardModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPersonCreditCardMapperMock,
                                                                  mock.DALMapperMockFactory.DALPersonCreditCardMapperMock);

                        ApiPersonCreditCardResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IPersonCreditCardRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PersonCreditCard>(null));
                        var service = new PersonCreditCardService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PersonCreditCardModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPersonCreditCardMapperMock,
                                                                  mock.DALMapperMockFactory.DALPersonCreditCardMapperMock);

                        ApiPersonCreditCardResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IPersonCreditCardRepository>();
                        var model = new ApiPersonCreditCardRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PersonCreditCard>())).Returns(Task.FromResult(new PersonCreditCard()));
                        var service = new PersonCreditCardService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PersonCreditCardModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPersonCreditCardMapperMock,
                                                                  mock.DALMapperMockFactory.DALPersonCreditCardMapperMock);

                        CreateResponse<ApiPersonCreditCardResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PersonCreditCardModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonCreditCardRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PersonCreditCard>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IPersonCreditCardRepository>();
                        var model = new ApiPersonCreditCardRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PersonCreditCard>())).Returns(Task.FromResult(new PersonCreditCard()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonCreditCard()));
                        var service = new PersonCreditCardService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PersonCreditCardModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPersonCreditCardMapperMock,
                                                                  mock.DALMapperMockFactory.DALPersonCreditCardMapperMock);

                        UpdateResponse<ApiPersonCreditCardResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PersonCreditCardModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonCreditCardRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PersonCreditCard>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IPersonCreditCardRepository>();
                        var model = new ApiPersonCreditCardRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new PersonCreditCardService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PersonCreditCardModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPersonCreditCardMapperMock,
                                                                  mock.DALMapperMockFactory.DALPersonCreditCardMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.PersonCreditCardModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>6c7f44a00503659a7533a39e3d4fe75e</Hash>
</Codenesium>*/