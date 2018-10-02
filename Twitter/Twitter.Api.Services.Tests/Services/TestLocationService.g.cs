using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		public async void All()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var records = new List<Location>();
			records.Add(new Location());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiLocationResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var record = new Location();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			ApiLocationResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Location>(null));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			ApiLocationResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Location>())).Returns(Task.FromResult(new Location()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			CreateResponse<ApiLocationResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLocationRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Location>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Location>())).Returns(Task.FromResult(new Location()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Location()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			UpdateResponse<ApiLocationResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLocationRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Location>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Tweets_Exists()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var records = new List<Tweet>();
			records.Add(new Tweet());
			mock.RepositoryMock.Setup(x => x.Tweets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTweetResponseModel> response = await service.Tweets(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Tweets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Tweets_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			mock.RepositoryMock.Setup(x => x.Tweets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tweet>>(new List<Tweet>()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTweetResponseModel> response = await service.Tweets(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Tweets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Users_Exists()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var records = new List<User>();
			records.Add(new User());
			mock.RepositoryMock.Setup(x => x.Users(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiUserResponseModel> response = await service.Users(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Users(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Users_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			mock.RepositoryMock.Setup(x => x.Users(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<User>>(new List<User>()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                                  mock.DALMapperMockFactory.DALTweetMapperMock,
			                                  mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                  mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiUserResponseModel> response = await service.Users(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Users(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c6f1f05fc5cb2d9ce1a5f1261ec7967a</Hash>
</Codenesium>*/