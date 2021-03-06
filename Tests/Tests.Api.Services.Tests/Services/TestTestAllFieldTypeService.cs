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
	[Trait("Table", "TestAllFieldType")]
	[Trait("Area", "Services")]
	public partial class TestAllFieldTypeServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeService, ITestAllFieldTypeRepository>();
			var records = new List<TestAllFieldType>();
			records.Add(new TestAllFieldType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			List<ApiTestAllFieldTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeService, ITestAllFieldTypeRepository>();
			var record = new TestAllFieldType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			ApiTestAllFieldTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeService, ITestAllFieldTypeRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TestAllFieldType>(null));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			ApiTestAllFieldTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeService, ITestAllFieldTypeRepository>();

			var model = new ApiTestAllFieldTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TestAllFieldType>())).Returns(Task.FromResult(new TestAllFieldType()));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			CreateResponse<ApiTestAllFieldTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TestAllFieldType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypeCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeService, ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeServerRequestModel();
			var validatorMock = new Mock<IApiTestAllFieldTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			CreateResponse<ApiTestAllFieldTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypeCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeService, ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TestAllFieldType>())).Returns(Task.FromResult(new TestAllFieldType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			UpdateResponse<ApiTestAllFieldTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TestAllFieldType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypeUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeService, ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeServerRequestModel();
			var validatorMock = new Mock<IApiTestAllFieldTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			UpdateResponse<ApiTestAllFieldTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypeUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeService, ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypeDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeService, ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeServerRequestModel();
			var validatorMock = new Mock<IApiTestAllFieldTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TestAllFieldTypeDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>f31baf169ca93bc10f03856addb13393</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/