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
	[Trait("Table", "VehCapability")]
	[Trait("Area", "Services")]
	public partial class VehCapabilityServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVehCapabilityRepository>();
			var records = new List<VehCapability>();
			records.Add(new VehCapability());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VehCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.VehCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALVehCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			List<ApiVehCapabilityServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVehCapabilityRepository>();
			var record = new VehCapability();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VehCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.VehCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALVehCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			ApiVehCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVehCapabilityRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VehCapability>(null));
			var service = new VehCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.VehCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALVehCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			ApiVehCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehCapabilityRepository>();
			var model = new ApiVehCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehCapability>())).Returns(Task.FromResult(new VehCapability()));
			var service = new VehCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.VehCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALVehCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			CreateResponse<ApiVehCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehCapabilityModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VehCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVehCapabilityRepository>();
			var model = new ApiVehCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiVehCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVehCapabilityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALVehCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			CreateResponse<ApiVehCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehCapabilityRepository>();
			var model = new ApiVehCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehCapability>())).Returns(Task.FromResult(new VehCapability()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehCapability()));
			var service = new VehCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.VehCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALVehCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			UpdateResponse<ApiVehCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehCapabilityModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VehCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVehCapabilityRepository>();
			var model = new ApiVehCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiVehCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehCapabilityServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehCapability()));
			var service = new VehCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALVehCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			UpdateResponse<ApiVehCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehCapabilityRepository>();
			var model = new ApiVehCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VehCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.VehCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALVehCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VehCapabilityModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVehCapabilityRepository>();
			var model = new ApiVehCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiVehCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALVehCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void VehicleCapabilitiesByVehicleCapabilityId_Exists()
		{
			var mock = new ServiceMockFacade<IVehCapabilityRepository>();
			var records = new List<VehicleCapabilities>();
			records.Add(new VehicleCapabilities());
			mock.RepositoryMock.Setup(x => x.VehicleCapabilitiesByVehicleCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VehCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.VehCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALVehCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			List<ApiVehicleCapabilitiesServerResponseModel> response = await service.VehicleCapabilitiesByVehicleCapabilityId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VehicleCapabilitiesByVehicleCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VehicleCapabilitiesByVehicleCapabilityId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVehCapabilityRepository>();
			mock.RepositoryMock.Setup(x => x.VehicleCapabilitiesByVehicleCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<VehicleCapabilities>>(new List<VehicleCapabilities>()));
			var service = new VehCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.VehCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALVehCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			List<ApiVehicleCapabilitiesServerResponseModel> response = await service.VehicleCapabilitiesByVehicleCapabilityId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VehicleCapabilitiesByVehicleCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>69061672ef37e080a150a3a9c900d948</Hash>
</Codenesium>*/