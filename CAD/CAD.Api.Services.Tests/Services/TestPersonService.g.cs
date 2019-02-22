using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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

namespace CADNS.Api.Services.Tests
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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALCallPersonMapperMock);

			List<ApiPersonServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
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
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALCallPersonMapperMock);

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
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALCallPersonMapperMock);

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
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALCallPersonMapperMock);

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
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALCallPersonMapperMock);

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
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALCallPersonMapperMock);

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
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALCallPersonMapperMock);

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
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALCallPersonMapperMock);

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
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALCallPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void CallPersonsByPersonId_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var records = new List<CallPerson>();
			records.Add(new CallPerson());
			mock.RepositoryMock.Setup(x => x.CallPersonsByPersonId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALCallPersonMapperMock);

			List<ApiCallPersonServerResponseModel> response = await service.CallPersonsByPersonId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CallPersonsByPersonId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CallPersonsByPersonId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			mock.RepositoryMock.Setup(x => x.CallPersonsByPersonId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CallPerson>>(new List<CallPerson>()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALCallPersonMapperMock);

			List<ApiCallPersonServerResponseModel> response = await service.CallPersonsByPersonId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CallPersonsByPersonId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>1bcf3bdfa1d811dc34ba2ff81462b971</Hash>
</Codenesium>*/