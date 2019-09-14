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
	[Trait("Table", "CallType")]
	[Trait("Area", "Services")]
	public partial class CallTypeServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICallTypeService, ICallTypeRepository>();
			var records = new List<CallType>();
			records.Add(new CallType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CallTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CallTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCallTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICallTypeService, ICallTypeRepository>();
			var record = new CallType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CallTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CallTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCallTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALCallMapperMock);

			ApiCallTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ICallTypeService, ICallTypeRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CallType>(null));
			var service = new CallTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CallTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCallTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALCallMapperMock);

			ApiCallTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICallTypeService, ICallTypeRepository>();

			var model = new ApiCallTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallType>())).Returns(Task.FromResult(new CallType()));
			var service = new CallTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CallTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCallTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALCallMapperMock);

			CreateResponse<ApiCallTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CallType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallTypeCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICallTypeService, ICallTypeRepository>();
			var model = new ApiCallTypeServerRequestModel();
			var validatorMock = new Mock<IApiCallTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCallTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALCallMapperMock);

			CreateResponse<ApiCallTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallTypeCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICallTypeService, ICallTypeRepository>();
			var model = new ApiCallTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallType>())).Returns(Task.FromResult(new CallType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallType()));
			var service = new CallTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CallTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCallTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALCallMapperMock);

			UpdateResponse<ApiCallTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CallType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallTypeUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICallTypeService, ICallTypeRepository>();
			var model = new ApiCallTypeServerRequestModel();
			var validatorMock = new Mock<IApiCallTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallType()));
			var service = new CallTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCallTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALCallMapperMock);

			UpdateResponse<ApiCallTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallTypeUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICallTypeService, ICallTypeRepository>();
			var model = new ApiCallTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CallTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CallTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCallTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALCallMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CallTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallTypeDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICallTypeService, ICallTypeRepository>();
			var model = new ApiCallTypeServerRequestModel();
			var validatorMock = new Mock<IApiCallTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCallTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALCallMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallTypeDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void CallsByCallTypeId_Exists()
		{
			var mock = new ServiceMockFacade<ICallTypeService, ICallTypeRepository>();
			var records = new List<Call>();
			records.Add(new Call());
			mock.RepositoryMock.Setup(x => x.CallsByCallTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CallTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CallTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCallTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallServerResponseModel> response = await service.CallsByCallTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CallsByCallTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CallsByCallTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICallTypeService, ICallTypeRepository>();
			mock.RepositoryMock.Setup(x => x.CallsByCallTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Call>>(new List<Call>()));
			var service = new CallTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CallTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCallTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallServerResponseModel> response = await service.CallsByCallTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CallsByCallTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>d2684196bc99286fd7c63f910a174822</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/