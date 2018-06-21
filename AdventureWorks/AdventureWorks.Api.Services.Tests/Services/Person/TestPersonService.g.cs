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
        [Trait("Table", "Person")]
        [Trait("Area", "Services")]
        public partial class PersonServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var records = new List<Person>();
                        records.Add(new Person());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var record = new Person();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        ApiPersonResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Person>(null));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        ApiPersonResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var model = new ApiPersonRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Person>())).Returns(Task.FromResult(new Person()));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        CreateResponse<ApiPersonResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Person>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var model = new ApiPersonRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Person>())).Returns(Task.FromResult(new Person()));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Person>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var model = new ApiPersonRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByLastNameFirstNameMiddleName_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var records = new List<Person>();
                        records.Add(new Person());
                        mock.RepositoryMock.Setup(x => x.ByLastNameFirstNameMiddleName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonResponseModel> response = await service.ByLastNameFirstNameMiddleName(default(string), default(string), default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByLastNameFirstNameMiddleName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void ByLastNameFirstNameMiddleName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.ByLastNameFirstNameMiddleName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<List<Person>>(new List<Person>()));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonResponseModel> response = await service.ByLastNameFirstNameMiddleName(default(string), default(string), default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByLastNameFirstNameMiddleName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void ByAdditionalContactInfo_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var records = new List<Person>();
                        records.Add(new Person());
                        mock.RepositoryMock.Setup(x => x.ByAdditionalContactInfo(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonResponseModel> response = await service.ByAdditionalContactInfo(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByAdditionalContactInfo(It.IsAny<string>()));
                }

                [Fact]
                public async void ByAdditionalContactInfo_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.ByAdditionalContactInfo(It.IsAny<string>())).Returns(Task.FromResult<List<Person>>(new List<Person>()));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonResponseModel> response = await service.ByAdditionalContactInfo(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByAdditionalContactInfo(It.IsAny<string>()));
                }

                [Fact]
                public async void ByDemographics_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var records = new List<Person>();
                        records.Add(new Person());
                        mock.RepositoryMock.Setup(x => x.ByDemographics(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonResponseModel> response = await service.ByDemographics(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByDemographics(It.IsAny<string>()));
                }

                [Fact]
                public async void ByDemographics_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.ByDemographics(It.IsAny<string>())).Returns(Task.FromResult<List<Person>>(new List<Person>()));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonResponseModel> response = await service.ByDemographics(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByDemographics(It.IsAny<string>()));
                }

                [Fact]
                public async void BusinessEntityContacts_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var records = new List<BusinessEntityContact>();
                        records.Add(new BusinessEntityContact());
                        mock.RepositoryMock.Setup(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiBusinessEntityContactResponseModel> response = await service.BusinessEntityContacts(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void BusinessEntityContacts_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BusinessEntityContact>>(new List<BusinessEntityContact>()));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiBusinessEntityContactResponseModel> response = await service.BusinessEntityContacts(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void EmailAddresses_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var records = new List<EmailAddress>();
                        records.Add(new EmailAddress());
                        mock.RepositoryMock.Setup(x => x.EmailAddresses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiEmailAddressResponseModel> response = await service.EmailAddresses(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.EmailAddresses(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void EmailAddresses_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.EmailAddresses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EmailAddress>>(new List<EmailAddress>()));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiEmailAddressResponseModel> response = await service.EmailAddresses(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.EmailAddresses(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Passwords_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var records = new List<Password>();
                        records.Add(new Password());
                        mock.RepositoryMock.Setup(x => x.Passwords(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPasswordResponseModel> response = await service.Passwords(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Passwords(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Passwords_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.Passwords(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Password>>(new List<Password>()));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPasswordResponseModel> response = await service.Passwords(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Passwords(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void PersonPhones_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        var records = new List<PersonPhone>();
                        records.Add(new PersonPhone());
                        mock.RepositoryMock.Setup(x => x.PersonPhones(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonPhoneResponseModel> response = await service.PersonPhones(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.PersonPhones(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void PersonPhones_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.PersonPhones(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PersonPhone>>(new List<PersonPhone>()));
                        var service = new PersonService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                        mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                        mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
                                                        mock.DALMapperMockFactory.DALEmailAddressMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                        mock.DALMapperMockFactory.DALPasswordMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPersonPhoneMapperMock,
                                                        mock.DALMapperMockFactory.DALPersonPhoneMapperMock);

                        List<ApiPersonPhoneResponseModel> response = await service.PersonPhones(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.PersonPhones(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>65e72fd30fa1cf07a827aa47a628cc8f</Hash>
</Codenesium>*/