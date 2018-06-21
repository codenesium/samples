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
        [Trait("Table", "ContactType")]
        [Trait("Area", "Services")]
        public partial class ContactTypeServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IContactTypeRepository>();
                        var records = new List<ContactType>();
                        records.Add(new ContactType());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ContactTypeService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
                                                             mock.DALMapperMockFactory.DALContactTypeMapperMock,
                                                             mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                             mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        List<ApiContactTypeResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IContactTypeRepository>();
                        var record = new ContactType();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ContactTypeService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
                                                             mock.DALMapperMockFactory.DALContactTypeMapperMock,
                                                             mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                             mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        ApiContactTypeResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IContactTypeRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ContactType>(null));
                        var service = new ContactTypeService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
                                                             mock.DALMapperMockFactory.DALContactTypeMapperMock,
                                                             mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                             mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        ApiContactTypeResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IContactTypeRepository>();
                        var model = new ApiContactTypeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ContactType>())).Returns(Task.FromResult(new ContactType()));
                        var service = new ContactTypeService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
                                                             mock.DALMapperMockFactory.DALContactTypeMapperMock,
                                                             mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                             mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        CreateResponse<ApiContactTypeResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiContactTypeRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ContactType>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IContactTypeRepository>();
                        var model = new ApiContactTypeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ContactType>())).Returns(Task.FromResult(new ContactType()));
                        var service = new ContactTypeService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
                                                             mock.DALMapperMockFactory.DALContactTypeMapperMock,
                                                             mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                             mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiContactTypeRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ContactType>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IContactTypeRepository>();
                        var model = new ApiContactTypeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ContactTypeService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
                                                             mock.DALMapperMockFactory.DALContactTypeMapperMock,
                                                             mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                             mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IContactTypeRepository>();
                        var record = new ContactType();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ContactTypeService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
                                                             mock.DALMapperMockFactory.DALContactTypeMapperMock,
                                                             mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                             mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        ApiContactTypeResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IContactTypeRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ContactType>(null));
                        var service = new ContactTypeService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
                                                             mock.DALMapperMockFactory.DALContactTypeMapperMock,
                                                             mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                             mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        ApiContactTypeResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void BusinessEntityContacts_Exists()
                {
                        var mock = new ServiceMockFacade<IContactTypeRepository>();
                        var records = new List<BusinessEntityContact>();
                        records.Add(new BusinessEntityContact());
                        mock.RepositoryMock.Setup(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ContactTypeService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
                                                             mock.DALMapperMockFactory.DALContactTypeMapperMock,
                                                             mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                             mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        List<ApiBusinessEntityContactResponseModel> response = await service.BusinessEntityContacts(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void BusinessEntityContacts_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IContactTypeRepository>();
                        mock.RepositoryMock.Setup(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BusinessEntityContact>>(new List<BusinessEntityContact>()));
                        var service = new ContactTypeService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
                                                             mock.DALMapperMockFactory.DALContactTypeMapperMock,
                                                             mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                             mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        List<ApiBusinessEntityContactResponseModel> response = await service.BusinessEntityContacts(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>311380155912bc5bf118298c26f354f8</Hash>
</Codenesium>*/