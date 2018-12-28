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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaAPerson")]
	[Trait("Area", "Services")]
	public partial class SchemaAPersonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var records = new List<SchemaAPerson>();
			records.Add(new SchemaAPerson());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			List<ApiSchemaAPersonServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var record = new SchemaAPerson();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			ApiSchemaAPersonServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SchemaAPerson>(null));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			ApiSchemaAPersonServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var model = new ApiSchemaAPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SchemaAPerson>())).Returns(Task.FromResult(new SchemaAPerson()));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			CreateResponse<ApiSchemaAPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaAPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SchemaAPerson>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaAPersonCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var model = new ApiSchemaAPersonServerRequestModel();
			var validatorMock = new Mock<IApiSchemaAPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaAPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			CreateResponse<ApiSchemaAPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaAPersonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaAPersonCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var model = new ApiSchemaAPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SchemaAPerson>())).Returns(Task.FromResult(new SchemaAPerson()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaAPerson()));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			UpdateResponse<ApiSchemaAPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SchemaAPerson>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaAPersonUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var model = new ApiSchemaAPersonServerRequestModel();
			var validatorMock = new Mock<IApiSchemaAPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaAPerson()));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			UpdateResponse<ApiSchemaAPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaAPersonUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var model = new ApiSchemaAPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaAPersonDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var model = new ApiSchemaAPersonServerRequestModel();
			var validatorMock = new Mock<IApiSchemaAPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaAPersonDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>3a1b71c38d0cefe1c9b77c90676a2828</Hash>
</Codenesium>*/