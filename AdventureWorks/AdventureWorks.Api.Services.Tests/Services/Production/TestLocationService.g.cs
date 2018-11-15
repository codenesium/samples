using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			List<ApiLocationServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var record = new Location();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(record));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
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
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			ApiLocationServerResponseModel response = await service.Get(default(short));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Location>())).Returns(Task.FromResult(new Location()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			CreateResponse<ApiLocationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLocationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Location>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Location>())).Returns(Task.FromResult(new Location()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Location()));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			UpdateResponse<ApiLocationServerResponseModel> response = await service.Update(default(short), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Location>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var model = new ApiLocationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.CompletedTask);
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			ActionResponse response = await service.Delete(default(short));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<short>()));
			mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<short>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<ILocationRepository>();
			var record = new Location();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new LocationService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
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
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLocationMapperMock,
			                                  mock.DALMapperMockFactory.DALLocationMapperMock);

			ApiLocationServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>d9a6cd076593f7b7f5f292a996b65f8c</Hash>
</Codenesium>*/