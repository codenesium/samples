using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		public async void All()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var records = new List<TestAllFieldType>();
			records.Add(new TestAllFieldType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			List<ApiTestAllFieldTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var record = new TestAllFieldType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			ApiTestAllFieldTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TestAllFieldType>(null));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			ApiTestAllFieldTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TestAllFieldType>())).Returns(Task.FromResult(new TestAllFieldType()));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			CreateResponse<ApiTestAllFieldTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TestAllFieldType>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeServerRequestModel();
			var validatorMock = new Mock<IApiTestAllFieldTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			CreateResponse<ApiTestAllFieldTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TestAllFieldType>())).Returns(Task.FromResult(new TestAllFieldType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			UpdateResponse<ApiTestAllFieldTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TestAllFieldType>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeServerRequestModel();
			var validatorMock = new Mock<IApiTestAllFieldTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			UpdateResponse<ApiTestAllFieldTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeServerRequestModel();
			var validatorMock = new Mock<IApiTestAllFieldTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c481a243c7c0fcb991e45bd0b34d379f</Hash>
</Codenesium>*/