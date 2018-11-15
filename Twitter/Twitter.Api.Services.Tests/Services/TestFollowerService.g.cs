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
	[Trait("Table", "Follower")]
	[Trait("Area", "Services")]
	public partial class FollowerServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IFollowerRepository>();
			var records = new List<Follower>();
			records.Add(new Follower());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IFollowerRepository>();
			var record = new Follower();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			ApiFollowerServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IFollowerRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Follower>(null));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			ApiFollowerServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IFollowerRepository>();
			var model = new ApiFollowerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Follower>())).Returns(Task.FromResult(new Follower()));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			CreateResponse<ApiFollowerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFollowerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Follower>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IFollowerRepository>();
			var model = new ApiFollowerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Follower>())).Returns(Task.FromResult(new Follower()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			UpdateResponse<ApiFollowerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFollowerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Follower>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IFollowerRepository>();
			var model = new ApiFollowerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByFollowedUserId_Exists()
		{
			var mock = new ServiceMockFacade<IFollowerRepository>();
			var records = new List<Follower>();
			records.Add(new Follower());
			mock.RepositoryMock.Setup(x => x.ByFollowedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.ByFollowedUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFollowedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByFollowedUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IFollowerRepository>();
			mock.RepositoryMock.Setup(x => x.ByFollowedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Follower>>(new List<Follower>()));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.ByFollowedUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFollowedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByFollowingUserId_Exists()
		{
			var mock = new ServiceMockFacade<IFollowerRepository>();
			var records = new List<Follower>();
			records.Add(new Follower());
			mock.RepositoryMock.Setup(x => x.ByFollowingUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.ByFollowingUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFollowingUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByFollowingUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IFollowerRepository>();
			mock.RepositoryMock.Setup(x => x.ByFollowingUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Follower>>(new List<Follower>()));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.ByFollowingUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFollowingUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>d220330f56c11351fa1cdd4f1ecaec9b</Hash>
</Codenesium>*/