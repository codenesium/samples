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
	[Trait("Table", "EmailAddress")]
	[Trait("Area", "Services")]
	public partial class EmailAddressServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IEmailAddressRepository>();
			var records = new List<EmailAddress>();
			records.Add(new EmailAddress());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EmailAddressService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EmailAddressModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
			                                      mock.DALMapperMockFactory.DALEmailAddressMapperMock);

			List<ApiEmailAddressResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IEmailAddressRepository>();
			var record = new EmailAddress();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new EmailAddressService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EmailAddressModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
			                                      mock.DALMapperMockFactory.DALEmailAddressMapperMock);

			ApiEmailAddressResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IEmailAddressRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<EmailAddress>(null));
			var service = new EmailAddressService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EmailAddressModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
			                                      mock.DALMapperMockFactory.DALEmailAddressMapperMock);

			ApiEmailAddressResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IEmailAddressRepository>();
			var model = new ApiEmailAddressRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EmailAddress>())).Returns(Task.FromResult(new EmailAddress()));
			var service = new EmailAddressService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EmailAddressModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
			                                      mock.DALMapperMockFactory.DALEmailAddressMapperMock);

			CreateResponse<ApiEmailAddressResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EmailAddressModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEmailAddressRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<EmailAddress>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IEmailAddressRepository>();
			var model = new ApiEmailAddressRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EmailAddress>())).Returns(Task.FromResult(new EmailAddress()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EmailAddress()));
			var service = new EmailAddressService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EmailAddressModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
			                                      mock.DALMapperMockFactory.DALEmailAddressMapperMock);

			UpdateResponse<ApiEmailAddressResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EmailAddressModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmailAddressRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<EmailAddress>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IEmailAddressRepository>();
			var model = new ApiEmailAddressRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EmailAddressService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EmailAddressModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
			                                      mock.DALMapperMockFactory.DALEmailAddressMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EmailAddressModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByEmailAddress_Exists()
		{
			var mock = new ServiceMockFacade<IEmailAddressRepository>();
			var records = new List<EmailAddress>();
			records.Add(new EmailAddress());
			mock.RepositoryMock.Setup(x => x.ByEmailAddress(It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new EmailAddressService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EmailAddressModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
			                                      mock.DALMapperMockFactory.DALEmailAddressMapperMock);

			List<ApiEmailAddressResponseModel> response = await service.ByEmailAddress(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEmailAddress(It.IsAny<string>()));
		}

		[Fact]
		public async void ByEmailAddress_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEmailAddressRepository>();
			mock.RepositoryMock.Setup(x => x.ByEmailAddress(It.IsAny<string>())).Returns(Task.FromResult<List<EmailAddress>>(new List<EmailAddress>()));
			var service = new EmailAddressService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EmailAddressModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEmailAddressMapperMock,
			                                      mock.DALMapperMockFactory.DALEmailAddressMapperMock);

			List<ApiEmailAddressResponseModel> response = await service.ByEmailAddress(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEmailAddress(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>98889ae453743a43988cfd7418915982</Hash>
</Codenesium>*/