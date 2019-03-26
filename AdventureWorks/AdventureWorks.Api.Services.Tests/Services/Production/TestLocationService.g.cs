using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "Services")]
	public partial class LocationServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var records = new List<Location>();
			records.Add(new Location());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			List<ApiLocationServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var record = new Location();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(record));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			ApiLocationServerResponseModel response = await service.Get(default(short));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<Location>(null));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			ApiLocationServerResponseModel response = await service.Get(default(short));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Location>())).Returns(Task.FromResult(new Location()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			CreateResponse<ApiLocationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLocationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Location>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			var validatorMock = new Mock<IApiLocationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			CreateResponse<ApiLocationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLocationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Location>())).Returns(Task.FromResult(new Location()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Location()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			UpdateResponse<ApiLocationServerResponseModel> response = await service.Update(default(short), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Location>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			var validatorMock = new Mock<IApiLocationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Location()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			UpdateResponse<ApiLocationServerResponseModel> response = await service.Update(default(short), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.CompletedTask);
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			ActionResponse response = await service.Delete(default(short));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<short>()));
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<short>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			var validatorMock = new Mock<IApiLocationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<short>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			ActionResponse response = await service.Delete(default(short));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<short>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var record = new Location();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			ApiLocationServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Location>(null));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			ApiLocationServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>4ae0a1bab69fcd2620750cfa2d0b0e70</Hash>
</Codenesium>*/