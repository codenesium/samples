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
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "Services")]
	public partial class LocationServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();
			var records = new List<Location>();
			records.Add(new Location());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiLocationServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();
			var record = new Location();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			ApiLocationServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Location>(null));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			ApiLocationServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();

			var model = new ApiLocationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Location>())).Returns(Task.FromResult(new Location()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			CreateResponse<ApiLocationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLocationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Location>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			var validatorMock = new Mock<IApiLocationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			CreateResponse<ApiLocationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLocationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Location>())).Returns(Task.FromResult(new Location()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Location()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			UpdateResponse<ApiLocationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLocationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Location>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			var validatorMock = new Mock<IApiLocationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Location()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			UpdateResponse<ApiLocationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLocationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			var validatorMock = new Mock<IApiLocationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LocationDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void TweetsByLocationId_Exists()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();
			var records = new List<Tweet>();
			records.Add(new Tweet());
			mock.RepositoryMock.Setup(x => x.TweetsByLocationId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTweetServerResponseModel> response = await service.TweetsByLocationId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TweetsByLocationId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TweetsByLocationId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();
			mock.RepositoryMock.Setup(x => x.TweetsByLocationId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tweet>>(new List<Tweet>()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTweetServerResponseModel> response = await service.TweetsByLocationId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TweetsByLocationId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void UsersByLocationLocationId_Exists()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();
			var records = new List<User>();
			records.Add(new User());
			mock.RepositoryMock.Setup(x => x.UsersByLocationLocationId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiUserServerResponseModel> response = await service.UsersByLocationLocationId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.UsersByLocationLocationId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void UsersByLocationLocationId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILocationService, ILocationRepository>();
			mock.RepositoryMock.Setup(x => x.UsersByLocationLocationId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<User>>(new List<User>()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiUserServerResponseModel> response = await service.UsersByLocationLocationId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.UsersByLocationLocationId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>210824c02ba2daa2bd240dcab7789740</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/