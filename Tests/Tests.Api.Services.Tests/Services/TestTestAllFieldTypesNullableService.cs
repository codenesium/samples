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
	[Trait("Table", "TestAllFieldTypesNullable")]
	[Trait("Area", "Services")]
	public partial class TestAllFieldTypesNullableServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableService, ITestAllFieldTypesNullableRepository>();
			var records = new List<TestAllFieldTypesNullable>();
			records.Add(new TestAllFieldTypesNullable());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			List<ApiTestAllFieldTypesNullableServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableService, ITestAllFieldTypesNullableRepository>();
			var record = new TestAllFieldTypesNullable();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			ApiTestAllFieldTypesNullableServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableService, ITestAllFieldTypesNullableRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TestAllFieldTypesNullable>(null));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			ApiTestAllFieldTypesNullableServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableService, ITestAllFieldTypesNullableRepository>();

			var model = new ApiTestAllFieldTypesNullableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TestAllFieldTypesNullable>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TestAllFieldTypesNullable>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypesNullableCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableService, ITestAllFieldTypesNullableRepository>();
			var model = new ApiTestAllFieldTypesNullableServerRequestModel();
			var validatorMock = new Mock<IApiTestAllFieldTypesNullableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   validatorMock.Object,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypesNullableCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableService, ITestAllFieldTypesNullableRepository>();
			var model = new ApiTestAllFieldTypesNullableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TestAllFieldTypesNullable>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TestAllFieldTypesNullable>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypesNullableUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableService, ITestAllFieldTypesNullableRepository>();
			var model = new ApiTestAllFieldTypesNullableServerRequestModel();
			var validatorMock = new Mock<IApiTestAllFieldTypesNullableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   validatorMock.Object,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypesNullableUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableService, ITestAllFieldTypesNullableRepository>();
			var model = new ApiTestAllFieldTypesNullableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypesNullableDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableService, ITestAllFieldTypesNullableRepository>();
			var model = new ApiTestAllFieldTypesNullableServerRequestModel();
			var validatorMock = new Mock<IApiTestAllFieldTypesNullableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   validatorMock.Object,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypesNullableDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>09fd6ceb1c9185255700fce6b3f21390</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/