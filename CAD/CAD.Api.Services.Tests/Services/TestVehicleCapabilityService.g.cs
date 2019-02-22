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
	[Trait("Table", "VehicleCapability")]
	[Trait("Area", "Services")]
	public partial class VehicleCapabilityServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilityRepository>();
			var records = new List<VehicleCapability>();
			records.Add(new VehicleCapability());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VehicleCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.VehicleCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALVehicleCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			List<ApiVehicleCapabilityServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilityRepository>();
			var record = new VehicleCapability();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VehicleCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.VehicleCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALVehicleCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			ApiVehicleCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilityRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VehicleCapability>(null));
			var service = new VehicleCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.VehicleCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALVehicleCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			ApiVehicleCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilityRepository>();
			var model = new ApiVehicleCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehicleCapability>())).Returns(Task.FromResult(new VehicleCapability()));
			var service = new VehicleCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.VehicleCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALVehicleCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			CreateResponse<ApiVehicleCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleCapabilityModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VehicleCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilityRepository>();
			var model = new ApiVehicleCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiVehicleCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleCapabilityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALVehicleCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			CreateResponse<ApiVehicleCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilityRepository>();
			var model = new ApiVehicleCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehicleCapability>())).Returns(Task.FromResult(new VehicleCapability()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleCapability()));
			var service = new VehicleCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.VehicleCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALVehicleCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			UpdateResponse<ApiVehicleCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleCapabilityModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VehicleCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilityRepository>();
			var model = new ApiVehicleCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiVehicleCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilityServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleCapability()));
			var service = new VehicleCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALVehicleCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			UpdateResponse<ApiVehicleCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilityRepository>();
			var model = new ApiVehicleCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VehicleCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.VehicleCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALVehicleCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VehicleCapabilityModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilityRepository>();
			var model = new ApiVehicleCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiVehicleCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALVehicleCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void VehicleRefCapabilitiesByVehicleCapabilityId_Exists()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilityRepository>();
			var records = new List<VehicleRefCapability>();
			records.Add(new VehicleRefCapability());
			mock.RepositoryMock.Setup(x => x.VehicleRefCapabilitiesByVehicleCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VehicleCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.VehicleCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALVehicleCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			List<ApiVehicleRefCapabilityServerResponseModel> response = await service.VehicleRefCapabilitiesByVehicleCapabilityId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VehicleRefCapabilitiesByVehicleCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VehicleRefCapabilitiesByVehicleCapabilityId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilityRepository>();
			mock.RepositoryMock.Setup(x => x.VehicleRefCapabilitiesByVehicleCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<VehicleRefCapability>>(new List<VehicleRefCapability>()));
			var service = new VehicleCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.VehicleCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALVehicleCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALVehicleRefCapabilityMapperMock);

			List<ApiVehicleRefCapabilityServerResponseModel> response = await service.VehicleRefCapabilitiesByVehicleCapabilityId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VehicleRefCapabilitiesByVehicleCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>9cd3a6cbc749349f0503e53a051edb35</Hash>
</Codenesium>*/