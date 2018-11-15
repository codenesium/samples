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
	[Trait("Table", "PostLink")]
	[Trait("Area", "Services")]
	public partial class PostLinkServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostLinkRepository>();
			var records = new List<PostLink>();
			records.Add(new PostLink());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostLinkMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostLinkRepository>();
			var record = new PostLink();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostLinkMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ApiPostLinkServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostLinkRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostLink>(null));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostLinkMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ApiPostLinkServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPostLinkRepository>();
			var model = new ApiPostLinkServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostLink>())).Returns(Task.FromResult(new PostLink()));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostLinkMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			CreateResponse<ApiPostLinkServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinkServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostLink>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPostLinkRepository>();
			var model = new ApiPostLinkServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostLink>())).Returns(Task.FromResult(new PostLink()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostLink()));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostLinkMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			UpdateResponse<ApiPostLinkServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinkServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostLink>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPostLinkRepository>();
			var model = new ApiPostLinkServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostLinkMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6de52ede034a29023022ff280c073be4</Hash>
</Codenesium>*/