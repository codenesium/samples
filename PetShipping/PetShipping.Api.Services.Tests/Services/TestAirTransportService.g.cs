using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "AirTransport")]
	[Trait("Area", "Services")]
	public partial class AirTransportServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var records = new List<AirTransport>();
			records.Add(new AirTransport());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			List<ApiAirTransportServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var record = new AirTransport();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			ApiAirTransportServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<AirTransport>(null));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			ApiAirTransportServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var model = new ApiAirTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AirTransport>())).Returns(Task.FromResult(new AirTransport()));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			CreateResponse<ApiAirTransportServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAirTransportServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<AirTransport>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirTransportCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var model = new ApiAirTransportServerRequestModel();
			var validatorMock = new Mock<IApiAirTransportServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAirTransportServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			CreateResponse<ApiAirTransportServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAirTransportServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirTransportCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var model = new ApiAirTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AirTransport>())).Returns(Task.FromResult(new AirTransport()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			UpdateResponse<ApiAirTransportServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirTransportServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<AirTransport>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirTransportUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var model = new ApiAirTransportServerRequestModel();
			var validatorMock = new Mock<IApiAirTransportServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirTransportServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			UpdateResponse<ApiAirTransportServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirTransportServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirTransportUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var model = new ApiAirTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirTransportDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var model = new ApiAirTransportServerRequestModel();
			var validatorMock = new Mock<IApiAirTransportServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirTransportDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>b75d9d2729fb40a673079156faa27863</Hash>
</Codenesium>*/