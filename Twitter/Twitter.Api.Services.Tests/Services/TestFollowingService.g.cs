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
	[Trait("Table", "Following")]
	[Trait("Area", "Services")]
	public partial class FollowingServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var records = new List<Following>();
			records.Add(new Following());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			List<ApiFollowingResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var record = new Following();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			ApiFollowingResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Following>(null));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			ApiFollowingResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var model = new ApiFollowingRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Following>())).Returns(Task.FromResult(new Following()));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			CreateResponse<ApiFollowingResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFollowingRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Following>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var model = new ApiFollowingRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Following>())).Returns(Task.FromResult(new Following()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Following()));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			UpdateResponse<ApiFollowingResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiFollowingRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Following>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var model = new ApiFollowingRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>24e45e0b2281e57ba79f9e63398e729e</Hash>
</Codenesium>*/