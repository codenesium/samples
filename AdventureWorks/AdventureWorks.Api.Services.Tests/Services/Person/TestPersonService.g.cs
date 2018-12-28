using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
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
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			List<ApiPersonServerResponseModel> response = await service.All();

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
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			ApiPersonServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Person>(null));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			ApiPersonServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var model = new ApiPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Person>())).Returns(Task.FromResult(new Person()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			CreateResponse<ApiPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Person>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var model = new ApiPersonServerRequestModel();
			var validatorMock = new Mock<IApiPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			CreateResponse<ApiPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var model = new ApiPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Person>())).Returns(Task.FromResult(new Person()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			UpdateResponse<ApiPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Person>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var model = new ApiPersonServerRequestModel();
			var validatorMock = new Mock<IApiPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			UpdateResponse<ApiPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var model = new ApiPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var model = new ApiPersonServerRequestModel();
			var validatorMock = new Mock<IApiPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var record = new Person();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			ApiPersonServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Person>(null));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			ApiPersonServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByLastNameFirstNameMiddleName_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var records = new List<Person>();
			records.Add(new Person());
			mock.RepositoryMock.Setup(x => x.ByLastNameFirstNameMiddleName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			List<ApiPersonServerResponseModel> response = await service.ByLastNameFirstNameMiddleName("test_value", "test_value", "test_value");

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLastNameFirstNameMiddleName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLastNameFirstNameMiddleName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			mock.RepositoryMock.Setup(x => x.ByLastNameFirstNameMiddleName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Person>>(new List<Person>()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			List<ApiPersonServerResponseModel> response = await service.ByLastNameFirstNameMiddleName("test_value", "test_value", "test_value");

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLastNameFirstNameMiddleName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByAdditionalContactInfo_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var records = new List<Person>();
			records.Add(new Person());
			mock.RepositoryMock.Setup(x => x.ByAdditionalContactInfo(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			List<ApiPersonServerResponseModel> response = await service.ByAdditionalContactInfo("test_value");

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByAdditionalContactInfo(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByAdditionalContactInfo_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			mock.RepositoryMock.Setup(x => x.ByAdditionalContactInfo(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Person>>(new List<Person>()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			List<ApiPersonServerResponseModel> response = await service.ByAdditionalContactInfo("test_value");

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByAdditionalContactInfo(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByDemographic_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var records = new List<Person>();
			records.Add(new Person());
			mock.RepositoryMock.Setup(x => x.ByDemographic(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			List<ApiPersonServerResponseModel> response = await service.ByDemographic("test_value");

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDemographic(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByDemographic_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			mock.RepositoryMock.Setup(x => x.ByDemographic(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Person>>(new List<Person>()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			List<ApiPersonServerResponseModel> response = await service.ByDemographic("test_value");

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDemographic(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PasswordsByBusinessEntityID_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var records = new List<Password>();
			records.Add(new Password());
			mock.RepositoryMock.Setup(x => x.PasswordsByBusinessEntityID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			List<ApiPasswordServerResponseModel> response = await service.PasswordsByBusinessEntityID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PasswordsByBusinessEntityID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PasswordsByBusinessEntityID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			mock.RepositoryMock.Setup(x => x.PasswordsByBusinessEntityID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Password>>(new List<Password>()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                mock.DALMapperMockFactory.DALPasswordMapperMock);

			List<ApiPasswordServerResponseModel> response = await service.PasswordsByBusinessEntityID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PasswordsByBusinessEntityID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>95e74663d3d0b08d919aeb8241b5798a</Hash>
</Codenesium>*/