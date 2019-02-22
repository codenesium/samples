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
	[Trait("Table", "PersonType")]
	[Trait("Area", "Services")]
	public partial class PersonTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPersonTypeRepository>();
			var records = new List<PersonType>();
			records.Add(new PersonType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PersonTypeService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.PersonTypeModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALPersonTypeMapperMock,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			List<ApiPersonTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPersonTypeRepository>();
			var record = new PersonType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PersonTypeService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.PersonTypeModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALPersonTypeMapperMock,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			ApiPersonTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPersonTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PersonType>(null));
			var service = new PersonTypeService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.PersonTypeModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALPersonTypeMapperMock,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			ApiPersonTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPersonTypeRepository>();
			var model = new ApiPersonTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PersonType>())).Returns(Task.FromResult(new PersonType()));
			var service = new PersonTypeService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.PersonTypeModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALPersonTypeMapperMock,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			CreateResponse<ApiPersonTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PersonTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PersonType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonTypeCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPersonTypeRepository>();
			var model = new ApiPersonTypeServerRequestModel();
			var validatorMock = new Mock<IApiPersonTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PersonTypeService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALPersonTypeMapperMock,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			CreateResponse<ApiPersonTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonTypeCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPersonTypeRepository>();
			var model = new ApiPersonTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PersonType>())).Returns(Task.FromResult(new PersonType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonType()));
			var service = new PersonTypeService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.PersonTypeModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALPersonTypeMapperMock,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			UpdateResponse<ApiPersonTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PersonTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PersonType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonTypeUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPersonTypeRepository>();
			var model = new ApiPersonTypeServerRequestModel();
			var validatorMock = new Mock<IApiPersonTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonType()));
			var service = new PersonTypeService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALPersonTypeMapperMock,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			UpdateResponse<ApiPersonTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonTypeUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPersonTypeRepository>();
			var model = new ApiPersonTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PersonTypeService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.PersonTypeModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALPersonTypeMapperMock,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PersonTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonTypeDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPersonTypeRepository>();
			var model = new ApiPersonTypeServerRequestModel();
			var validatorMock = new Mock<IApiPersonTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PersonTypeService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALPersonTypeMapperMock,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonTypeDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void CallPersonsByPersonTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IPersonTypeRepository>();
			var records = new List<CallPerson>();
			records.Add(new CallPerson());
			mock.RepositoryMock.Setup(x => x.CallPersonsByPersonTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonTypeService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.PersonTypeModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALPersonTypeMapperMock,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			List<ApiCallPersonServerResponseModel> response = await service.CallPersonsByPersonTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CallPersonsByPersonTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CallPersonsByPersonTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPersonTypeRepository>();
			mock.RepositoryMock.Setup(x => x.CallPersonsByPersonTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CallPerson>>(new List<CallPerson>()));
			var service = new PersonTypeService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.PersonTypeModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALPersonTypeMapperMock,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			List<ApiCallPersonServerResponseModel> response = await service.CallPersonsByPersonTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CallPersonsByPersonTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>1f52b2ae1dd74e6e0464a125016a434d</Hash>
</Codenesium>*/