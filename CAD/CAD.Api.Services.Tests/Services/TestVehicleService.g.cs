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
	[Trait("Table", "Vehicle")]
	[Trait("Area", "Services")]
	public partial class VehicleServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVehicleRepository>();
			var records = new List<Vehicle>();
			records.Add(new Vehicle());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			List<ApiVehicleServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVehicleRepository>();
			var record = new Vehicle();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			ApiVehicleServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVehicleRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(null));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			ApiVehicleServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleRepository>();
			var model = new ApiVehicleServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Vehicle>())).Returns(Task.FromResult(new Vehicle()));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			CreateResponse<ApiVehicleServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Vehicle>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleRepository>();
			var model = new ApiVehicleServerRequestModel();
			var validatorMock = new Mock<IApiVehicleServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			CreateResponse<ApiVehicleServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleRepository>();
			var model = new ApiVehicleServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Vehicle>())).Returns(Task.FromResult(new Vehicle()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vehicle()));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			UpdateResponse<ApiVehicleServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Vehicle>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleRepository>();
			var model = new ApiVehicleServerRequestModel();
			var validatorMock = new Mock<IApiVehicleServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vehicle()));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			UpdateResponse<ApiVehicleServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleRepository>();
			var model = new ApiVehicleServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleRepository>();
			var model = new ApiVehicleServerRequestModel();
			var validatorMock = new Mock<IApiVehicleServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void VehicleCapabilitiesByVehicleId_Exists()
		{
			var mock = new ServiceMockFacade<IVehicleRepository>();
			var records = new List<VehicleCapabilitty>();
			records.Add(new VehicleCapabilitty());
			mock.RepositoryMock.Setup(x => x.VehicleCapabilitiesByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			List<ApiVehicleCapabilittyServerResponseModel> response = await service.VehicleCapabilitiesByVehicleId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VehicleCapabilitiesByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VehicleCapabilitiesByVehicleId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVehicleRepository>();
			mock.RepositoryMock.Setup(x => x.VehicleCapabilitiesByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<VehicleCapabilitty>>(new List<VehicleCapabilitty>()));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			List<ApiVehicleCapabilittyServerResponseModel> response = await service.VehicleCapabilitiesByVehicleId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VehicleCapabilitiesByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>1018895969e7831e6bc4b230c7895a0d</Hash>
</Codenesium>*/