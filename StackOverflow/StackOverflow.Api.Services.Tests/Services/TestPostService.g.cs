using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Post")]
	[Trait("Area", "Services")]
	public partial class PostServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostRepository>();
			var records = new List<Post>();
			records.Add(new Post());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLPostMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock);

			List<ApiPostServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostRepository>();
			var record = new Post();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLPostMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock);

			ApiPostServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLPostMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock);

			ApiPostServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPostRepository>();
			var model = new ApiPostServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Post>())).Returns(Task.FromResult(new Post()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLPostMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock);

			CreateResponse<ApiPostServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Post>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPostRepository>();
			var model = new ApiPostServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Post>())).Returns(Task.FromResult(new Post()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Post()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLPostMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock);

			UpdateResponse<ApiPostServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Post>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPostRepository>();
			var model = new ApiPostServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLPostMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByOwnerUserId_Exists()
		{
			var mock = new ServiceMockFacade<IPostRepository>();
			var records = new List<Post>();
			records.Add(new Post());
			mock.RepositoryMock.Setup(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLPostMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock);

			List<ApiPostServerResponseModel> response = await service.ByOwnerUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByOwnerUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostRepository>();
			mock.RepositoryMock.Setup(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Post>>(new List<Post>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLPostMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock);

			List<ApiPostServerResponseModel> response = await service.ByOwnerUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8f569544c64c6dd4a1adf4d5dc6880c9</Hash>
</Codenesium>*/