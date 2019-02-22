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
	[Trait("Table", "VehicleRefCapability")]
	[Trait("Area", "Services")]
	public partial class VehicleRefCapabilityServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVehicleRefCapabilityRepository>();
			var records = new List<VehicleRefCapability>();
			records.Add(new VehicleRefCapability());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VehicleRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.VehicleRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			List<ApiVehicleRefCapabilityServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVehicleRefCapabilityRepository>();
			var record = new VehicleRefCapability();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VehicleRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.VehicleRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			ApiVehicleRefCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVehicleRefCapabilityRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VehicleRefCapability>(null));
			var service = new VehicleRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.VehicleRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			ApiVehicleRefCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleRefCapabilityRepository>();
			var model = new ApiVehicleRefCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehicleRefCapability>())).Returns(Task.FromResult(new VehicleRefCapability()));
			var service = new VehicleRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.VehicleRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			CreateResponse<ApiVehicleRefCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleRefCapabilityModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleRefCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VehicleRefCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleRefCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleRefCapabilityRepository>();
			var model = new ApiVehicleRefCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiVehicleRefCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleRefCapabilityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              validatorMock.Object,
			                                              mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			CreateResponse<ApiVehicleRefCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleRefCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleRefCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleRefCapabilityRepository>();
			var model = new ApiVehicleRefCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehicleRefCapability>())).Returns(Task.FromResult(new VehicleRefCapability()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleRefCapability()));
			var service = new VehicleRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.VehicleRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			UpdateResponse<ApiVehicleRefCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleRefCapabilityModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleRefCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VehicleRefCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleRefCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleRefCapabilityRepository>();
			var model = new ApiVehicleRefCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiVehicleRefCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleRefCapabilityServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleRefCapability()));
			var service = new VehicleRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              validatorMock.Object,
			                                              mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			UpdateResponse<ApiVehicleRefCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleRefCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleRefCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleRefCapabilityRepository>();
			var model = new ApiVehicleRefCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VehicleRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.VehicleRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VehicleRefCapabilityModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleRefCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleRefCapabilityRepository>();
			var model = new ApiVehicleRefCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiVehicleRefCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              validatorMock.Object,
			                                              mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleRefCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>16986a75225b76085b2490f6ace69e3b</Hash>
</Codenesium>*/