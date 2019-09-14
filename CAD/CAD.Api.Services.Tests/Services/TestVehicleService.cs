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
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();
			var records = new List<Vehicle>();
			records.Add(new Vehicle());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			List<ApiVehicleServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();
			var record = new Vehicle();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			ApiVehicleServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(null));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			ApiVehicleServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();

			var model = new ApiVehicleServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Vehicle>())).Returns(Task.FromResult(new Vehicle()));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			CreateResponse<ApiVehicleServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Vehicle>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();
			var model = new ApiVehicleServerRequestModel();
			var validatorMock = new Mock<IApiVehicleServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			CreateResponse<ApiVehicleServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();
			var model = new ApiVehicleServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Vehicle>())).Returns(Task.FromResult(new Vehicle()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vehicle()));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			UpdateResponse<ApiVehicleServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Vehicle>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();
			var model = new ApiVehicleServerRequestModel();
			var validatorMock = new Mock<IApiVehicleServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vehicle()));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			UpdateResponse<ApiVehicleServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();
			var model = new ApiVehicleServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();
			var model = new ApiVehicleServerRequestModel();
			var validatorMock = new Mock<IApiVehicleServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void VehicleCapabilitiesByVehicleId_Exists()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();
			var records = new List<VehicleCapabilities>();
			records.Add(new VehicleCapabilities());
			mock.RepositoryMock.Setup(x => x.VehicleCapabilitiesByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			List<ApiVehicleCapabilitiesServerResponseModel> response = await service.VehicleCapabilitiesByVehicleId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VehicleCapabilitiesByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VehicleCapabilitiesByVehicleId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();
			mock.RepositoryMock.Setup(x => x.VehicleCapabilitiesByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<VehicleCapabilities>>(new List<VehicleCapabilities>()));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			List<ApiVehicleCapabilitiesServerResponseModel> response = await service.VehicleCapabilitiesByVehicleId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VehicleCapabilitiesByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VehicleOfficersByVehicleId_Exists()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();
			var records = new List<VehicleOfficer>();
			records.Add(new VehicleOfficer());
			mock.RepositoryMock.Setup(x => x.VehicleOfficersByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			List<ApiVehicleOfficerServerResponseModel> response = await service.VehicleOfficersByVehicleId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VehicleOfficersByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VehicleOfficersByVehicleId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVehicleService, IVehicleRepository>();
			mock.RepositoryMock.Setup(x => x.VehicleOfficersByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<VehicleOfficer>>(new List<VehicleOfficer>()));
			var service = new VehicleService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VehicleModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALVehicleMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock,
			                                 mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			List<ApiVehicleOfficerServerResponseModel> response = await service.VehicleOfficersByVehicleId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VehicleOfficersByVehicleId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>78be9b640fbac310d6c0b2ba1426d3df</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/