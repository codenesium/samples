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
	[Trait("Table", "SchemaBPerson")]
	[Trait("Area", "Services")]
	public partial class SchemaBPersonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var records = new List<SchemaBPerson>();
			records.Add(new SchemaBPerson());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock);

			List<ApiSchemaBPersonServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var record = new SchemaBPerson();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock);

			ApiSchemaBPersonServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SchemaBPerson>(null));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock);

			ApiSchemaBPersonServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var model = new ApiSchemaBPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SchemaBPerson>())).Returns(Task.FromResult(new SchemaBPerson()));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock);

			CreateResponse<ApiSchemaBPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaBPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SchemaBPerson>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaBPersonCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var model = new ApiSchemaBPersonServerRequestModel();
			var validatorMock = new Mock<IApiSchemaBPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaBPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock);

			CreateResponse<ApiSchemaBPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaBPersonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaBPersonCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var model = new ApiSchemaBPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SchemaBPerson>())).Returns(Task.FromResult(new SchemaBPerson()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaBPerson()));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock);

			UpdateResponse<ApiSchemaBPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SchemaBPerson>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaBPersonUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var model = new ApiSchemaBPersonServerRequestModel();
			var validatorMock = new Mock<IApiSchemaBPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaBPerson()));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock);

			UpdateResponse<ApiSchemaBPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaBPersonUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var model = new ApiSchemaBPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaBPersonDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var model = new ApiSchemaBPersonServerRequestModel();
			var validatorMock = new Mock<IApiSchemaBPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SchemaBPersonDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>672d3d7c6d02bd765122d4f6a443ed93</Hash>
</Codenesium>*/