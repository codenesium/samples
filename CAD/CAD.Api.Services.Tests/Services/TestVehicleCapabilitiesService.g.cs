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
	[Trait("Table", "VehicleCapabilities")]
	[Trait("Area", "Services")]
	public partial class VehicleCapabilitiesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilitiesRepository>();
			var records = new List<VehicleCapabilities>();
			records.Add(new VehicleCapabilities());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VehicleCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.VehicleCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			List<ApiVehicleCapabilitiesServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilitiesRepository>();
			var record = new VehicleCapabilities();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VehicleCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.VehicleCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			ApiVehicleCapabilitiesServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilitiesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VehicleCapabilities>(null));
			var service = new VehicleCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.VehicleCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			ApiVehicleCapabilitiesServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilitiesRepository>();
			var model = new ApiVehicleCapabilitiesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehicleCapabilities>())).Returns(Task.FromResult(new VehicleCapabilities()));
			var service = new VehicleCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.VehicleCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			CreateResponse<ApiVehicleCapabilitiesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleCapabilitiesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VehicleCapabilities>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilitiesCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilitiesRepository>();
			var model = new ApiVehicleCapabilitiesServerRequestModel();
			var validatorMock = new Mock<IApiVehicleCapabilitiesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleCapabilitiesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			CreateResponse<ApiVehicleCapabilitiesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilitiesCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilitiesRepository>();
			var model = new ApiVehicleCapabilitiesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehicleCapabilities>())).Returns(Task.FromResult(new VehicleCapabilities()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleCapabilities()));
			var service = new VehicleCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.VehicleCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			UpdateResponse<ApiVehicleCapabilitiesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleCapabilitiesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VehicleCapabilities>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilitiesUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilitiesRepository>();
			var model = new ApiVehicleCapabilitiesServerRequestModel();
			var validatorMock = new Mock<IApiVehicleCapabilitiesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilitiesServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleCapabilities()));
			var service = new VehicleCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			UpdateResponse<ApiVehicleCapabilitiesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilitiesUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilitiesRepository>();
			var model = new ApiVehicleCapabilitiesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VehicleCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.VehicleCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VehicleCapabilitiesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilitiesDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilitiesRepository>();
			var model = new ApiVehicleCapabilitiesServerRequestModel();
			var validatorMock = new Mock<IApiVehicleCapabilitiesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALVehicleCapabilitiesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilitiesDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>086b6090c8ab6cf3eac9f2622aef8417</Hash>
</Codenesium>*/