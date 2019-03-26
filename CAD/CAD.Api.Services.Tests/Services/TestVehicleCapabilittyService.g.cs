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
	[Trait("Table", "VehicleCapabilitty")]
	[Trait("Area", "Services")]
	public partial class VehicleCapabilittyServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilittyRepository>();
			var records = new List<VehicleCapabilitty>();
			records.Add(new VehicleCapabilitty());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VehicleCapabilittyService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.VehicleCapabilittyModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			List<ApiVehicleCapabilittyServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilittyRepository>();
			var record = new VehicleCapabilitty();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VehicleCapabilittyService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.VehicleCapabilittyModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			ApiVehicleCapabilittyServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilittyRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VehicleCapabilitty>(null));
			var service = new VehicleCapabilittyService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.VehicleCapabilittyModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			ApiVehicleCapabilittyServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilittyRepository>();
			var model = new ApiVehicleCapabilittyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehicleCapabilitty>())).Returns(Task.FromResult(new VehicleCapabilitty()));
			var service = new VehicleCapabilittyService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.VehicleCapabilittyModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			CreateResponse<ApiVehicleCapabilittyServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleCapabilittyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleCapabilittyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VehicleCapabilitty>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilittyCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilittyRepository>();
			var model = new ApiVehicleCapabilittyServerRequestModel();
			var validatorMock = new Mock<IApiVehicleCapabilittyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleCapabilittyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleCapabilittyService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			CreateResponse<ApiVehicleCapabilittyServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVehicleCapabilittyServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilittyCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilittyRepository>();
			var model = new ApiVehicleCapabilittyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VehicleCapabilitty>())).Returns(Task.FromResult(new VehicleCapabilitty()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleCapabilitty()));
			var service = new VehicleCapabilittyService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.VehicleCapabilittyModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			UpdateResponse<ApiVehicleCapabilittyServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VehicleCapabilittyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilittyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VehicleCapabilitty>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilittyUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilittyRepository>();
			var model = new ApiVehicleCapabilittyServerRequestModel();
			var validatorMock = new Mock<IApiVehicleCapabilittyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilittyServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleCapabilitty()));
			var service = new VehicleCapabilittyService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			UpdateResponse<ApiVehicleCapabilittyServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilittyServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilittyUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilittyRepository>();
			var model = new ApiVehicleCapabilittyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VehicleCapabilittyService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.VehicleCapabilittyModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VehicleCapabilittyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilittyDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVehicleCapabilittyRepository>();
			var model = new ApiVehicleCapabilittyServerRequestModel();
			var validatorMock = new Mock<IApiVehicleCapabilittyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VehicleCapabilittyService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALVehicleCapabilittyMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VehicleCapabilittyDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>3354a05c77887abaad082263420d5eb8</Hash>
</Codenesium>*/