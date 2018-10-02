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
	[Trait("Table", "Like")]
	[Trait("Area", "Services")]
	public partial class LikeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ILikeRepository>();
			var records = new List<Like>();
			records.Add(new Like());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LikeService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LikeModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLikeMapperMock,
			                              mock.DALMapperMockFactory.DALLikeMapperMock);

			List<ApiLikeResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILikeRepository>();
			var record = new Like();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LikeService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LikeModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLikeMapperMock,
			                              mock.DALMapperMockFactory.DALLikeMapperMock);

			ApiLikeResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILikeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Like>(null));
			var service = new LikeService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LikeModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLikeMapperMock,
			                              mock.DALMapperMockFactory.DALLikeMapperMock);

			ApiLikeResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ILikeRepository>();
			var model = new ApiLikeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Like>())).Returns(Task.FromResult(new Like()));
			var service = new LikeService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LikeModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLikeMapperMock,
			                              mock.DALMapperMockFactory.DALLikeMapperMock);

			CreateResponse<ApiLikeResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LikeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLikeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Like>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ILikeRepository>();
			var model = new ApiLikeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Like>())).Returns(Task.FromResult(new Like()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Like()));
			var service = new LikeService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LikeModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLikeMapperMock,
			                              mock.DALMapperMockFactory.DALLikeMapperMock);

			UpdateResponse<ApiLikeResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LikeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLikeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Like>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ILikeRepository>();
			var model = new ApiLikeRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LikeService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LikeModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLikeMapperMock,
			                              mock.DALMapperMockFactory.DALLikeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LikeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByLikerUserId_Exists()
		{
			var mock = new ServiceMockFacade<ILikeRepository>();
			var records = new List<Like>();
			records.Add(new Like());
			mock.RepositoryMock.Setup(x => x.ByLikerUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LikeService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LikeModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLikeMapperMock,
			                              mock.DALMapperMockFactory.DALLikeMapperMock);

			List<ApiLikeResponseModel> response = await service.ByLikerUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLikerUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLikerUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILikeRepository>();
			mock.RepositoryMock.Setup(x => x.ByLikerUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Like>>(new List<Like>()));
			var service = new LikeService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LikeModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLikeMapperMock,
			                              mock.DALMapperMockFactory.DALLikeMapperMock);

			List<ApiLikeResponseModel> response = await service.ByLikerUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLikerUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTweetId_Exists()
		{
			var mock = new ServiceMockFacade<ILikeRepository>();
			var records = new List<Like>();
			records.Add(new Like());
			mock.RepositoryMock.Setup(x => x.ByTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LikeService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LikeModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLikeMapperMock,
			                              mock.DALMapperMockFactory.DALLikeMapperMock);

			List<ApiLikeResponseModel> response = await service.ByTweetId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTweetId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILikeRepository>();
			mock.RepositoryMock.Setup(x => x.ByTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Like>>(new List<Like>()));
			var service = new LikeService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LikeModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLikeMapperMock,
			                              mock.DALMapperMockFactory.DALLikeMapperMock);

			List<ApiLikeResponseModel> response = await service.ByTweetId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>55152a85ab49a3249123691d455bb848</Hash>
</Codenesium>*/