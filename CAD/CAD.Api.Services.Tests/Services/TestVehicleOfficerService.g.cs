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
	[Trait("Table", "VehicleOfficer")]
	[Trait("Area", "Services")]
	public partial class VehicleOfficerServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVehicleOfficerRepository>();
			var records = new List<VehicleOfficer>();
			records.Add(new VehicleOfficer());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VehicleOfficerService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.VehicleOfficerModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			List<ApiVehicleOfficerServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVehicleOfficerRepository>();
			var record = new VehicleOfficer();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VehicleOfficerService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.VehicleOfficerModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			ApiVehicleOfficerServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVehicleOfficerRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VehicleOfficer>(null));
			var service = new VehicleOfficerService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.VehicleOfficerModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			ApiVehicleOfficerServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleOfficerRepository>();
			var model = new ApiVehicleOfficerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehicleOfficer>())).Returns(Task.FromResult(new VehicleOfficer()));
			var service = new VehicleOfficerService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.VehicleOfficerModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			CreateResponse<ApiVehicleOfficerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleOfficerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleOfficerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VehicleOfficer>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleOfficerCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleOfficerRepository>();
			var model = new ApiVehicleOfficerServerRequestModel();
			var validatorMock = new Mock<IApiVehicleOfficerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleOfficerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleOfficerService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			CreateResponse<ApiVehicleOfficerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleOfficerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleOfficerCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleOfficerRepository>();
			var model = new ApiVehicleOfficerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehicleOfficer>())).Returns(Task.FromResult(new VehicleOfficer()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleOfficer()));
			var service = new VehicleOfficerService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.VehicleOfficerModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			UpdateResponse<ApiVehicleOfficerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleOfficerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleOfficerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VehicleOfficer>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleOfficerUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleOfficerRepository>();
			var model = new ApiVehicleOfficerServerRequestModel();
			var validatorMock = new Mock<IApiVehicleOfficerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleOfficerServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleOfficer()));
			var service = new VehicleOfficerService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			UpdateResponse<ApiVehicleOfficerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleOfficerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleOfficerUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleOfficerRepository>();
			var model = new ApiVehicleOfficerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VehicleOfficerService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.VehicleOfficerModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VehicleOfficerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleOfficerDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleOfficerRepository>();
			var model = new ApiVehicleOfficerServerRequestModel();
			var validatorMock = new Mock<IApiVehicleOfficerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleOfficerService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALVehicleOfficerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleOfficerDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>125c24c3441da5cc8e4b6573a9cd0af2</Hash>
</Codenesium>*/