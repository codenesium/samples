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
        [Trait("Table", "PhoneNumberType")]
        [Trait("Area", "Services")]
        public partial class PhoneNumberTypeServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
                        var records = new List<PhoneNumberType>();
                        records.Add(new PhoneNumberType());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
                                                                 mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock,
                                                                 mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                                 mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPhoneNumberTypeResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
                        var record = new PhoneNumberType();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
                                                                 mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock,
                                                                 mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                                 mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        ApiPhoneNumberTypeResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PhoneNumberType>(null));
                        var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
                                                                 mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock,
                                                                 mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                                 mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        ApiPhoneNumberTypeResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
                        var model = new ApiPhoneNumberTypeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PhoneNumberType>())).Returns(Task.FromResult(new PhoneNumberType()));
                        var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
                                                                 mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock,
                                                                 mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                                 mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        CreateResponse<ApiPhoneNumberTypeResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPhoneNumberTypeRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PhoneNumberType>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
                        var model = new ApiPhoneNumberTypeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PhoneNumberType>())).Returns(Task.FromResult(new PhoneNumberType()));
                        var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
                                                                 mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock,
                                                                 mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                                 mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PhoneNumberType>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
                        var model = new ApiPhoneNumberTypeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
                                                                 mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock,
                                                                 mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                                 mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void PersonPhones_Exists()
                {
                        var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
                        var records = new List<PersonPhone>();
                        records.Add(new PersonPhone());
                        mock.RepositoryMock.Setup(x => x.PersonPhones(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
                                                                 mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock,
                                                                 mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                                 mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonPhoneResponseModel> response = await service.PersonPhones(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.PersonPhones(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void PersonPhones_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IPhoneNumberTypeRepository>();
                        mock.RepositoryMock.Setup(x => x.PersonPhones(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PersonPhone>>(new List<PersonPhone>()));
                        var service = new PhoneNumberTypeService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.PhoneNumberTypeModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLPhoneNumberTypeMapperMock,
                                                                 mock.DALMapperMockFactory.DALPhoneNumberTypeMapperMock,
                                                                 mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                                 mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonPhoneResponseModel> response = await service.PersonPhones(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.PersonPhones(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>c6d22f22d2fecc646423e6cadefd3f94</Hash>
</Codenesium>*/