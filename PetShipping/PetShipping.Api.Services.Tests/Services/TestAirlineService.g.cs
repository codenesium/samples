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
	[Trait("Table", "Airline")]
	[Trait("Area", "Services")]
	public partial class AirlineServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var records = new List<Airline>();
			records.Add(new Airline());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			List<ApiAirlineServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var record = new Airline();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			ApiAirlineServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Airline>(null));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			ApiAirlineServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var model = new ApiAirlineServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Airline>())).Returns(Task.FromResult(new Airline()));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			CreateResponse<ApiAirlineServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAirlineServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Airline>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirlineCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var model = new ApiAirlineServerRequestModel();
			var validatorMock = new Mock<IApiAirlineServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAirlineServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			CreateResponse<ApiAirlineServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAirlineServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirlineCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var model = new ApiAirlineServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Airline>())).Returns(Task.FromResult(new Airline()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Airline()));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			UpdateResponse<ApiAirlineServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirlineServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Airline>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirlineUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var model = new ApiAirlineServerRequestModel();
			var validatorMock = new Mock<IApiAirlineServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirlineServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Airline()));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			UpdateResponse<ApiAirlineServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirlineServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirlineUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var model = new ApiAirlineServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirlineDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var model = new ApiAirlineServerRequestModel();
			var validatorMock = new Mock<IApiAirlineServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AirlineDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>6ef4eeef0fbbec85731363c1ae449173</Hash>
</Codenesium>*/