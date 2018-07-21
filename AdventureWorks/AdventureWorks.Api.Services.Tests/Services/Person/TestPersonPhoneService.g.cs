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
        [Trait("Table", "PersonPhone")]
        [Trait("Area", "Services")]
        public partial class PersonPhoneServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IPersonPhoneRepository>();
                        var records = new List<PersonPhone>();
                        records.Add(new PersonPhone());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PersonPhoneService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.PersonPhoneModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                             mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonPhoneResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IPersonPhoneRepository>();
                        var record = new PersonPhone();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new PersonPhoneService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.PersonPhoneModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                             mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        ApiPersonPhoneResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IPersonPhoneRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PersonPhone>(null));
                        var service = new PersonPhoneService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.PersonPhoneModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                             mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        ApiPersonPhoneResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IPersonPhoneRepository>();
                        var model = new ApiPersonPhoneRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PersonPhone>())).Returns(Task.FromResult(new PersonPhone()));
                        var service = new PersonPhoneService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.PersonPhoneModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                             mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        CreateResponse<ApiPersonPhoneResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PersonPhoneModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonPhoneRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PersonPhone>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IPersonPhoneRepository>();
                        var model = new ApiPersonPhoneRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PersonPhone>())).Returns(Task.FromResult(new PersonPhone()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonPhone()));
                        var service = new PersonPhoneService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.PersonPhoneModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                             mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        UpdateResponse<ApiPersonPhoneResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PersonPhoneModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonPhoneRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PersonPhone>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IPersonPhoneRepository>();
                        var model = new ApiPersonPhoneRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new PersonPhoneService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.PersonPhoneModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                             mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.PersonPhoneModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByPhoneNumber_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonPhoneRepository>();
                        var records = new List<PersonPhone>();
                        records.Add(new PersonPhone());
                        mock.RepositoryMock.Setup(x => x.ByPhoneNumber(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new PersonPhoneService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.PersonPhoneModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                             mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonPhoneResponseModel> response = await service.ByPhoneNumber(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByPhoneNumber(It.IsAny<string>()));
                }

                [Fact]
                public async void ByPhoneNumber_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonPhoneRepository>();
                        mock.RepositoryMock.Setup(x => x.ByPhoneNumber(It.IsAny<string>())).Returns(Task.FromResult<List<PersonPhone>>(new List<PersonPhone>()));
                        var service = new PersonPhoneService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.PersonPhoneModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                             mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonPhoneResponseModel> response = await service.ByPhoneNumber(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByPhoneNumber(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>99e0114685c1a57b63c1dc1ce8ee6f95</Hash>
</Codenesium>*/