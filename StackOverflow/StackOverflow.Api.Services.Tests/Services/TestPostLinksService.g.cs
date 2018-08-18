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
	[Trait("Table", "PostLinks")]
	[Trait("Area", "Services")]
	public partial class PostLinksServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var records = new List<PostLinks>();
			records.Add(new PostLinks());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostLinksMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var record = new PostLinks();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostLinksMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ApiPostLinksResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostLinks>(null));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostLinksMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ApiPostLinksResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var model = new ApiPostLinksRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostLinks>())).Returns(Task.FromResult(new PostLinks()));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostLinksMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			CreateResponse<ApiPostLinksResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinksRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostLinks>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var model = new ApiPostLinksRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostLinks>())).Returns(Task.FromResult(new PostLinks()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostLinks()));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostLinksMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			UpdateResponse<ApiPostLinksResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinksRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostLinks>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var model = new ApiPostLinksRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostLinksMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>5a5cbf1925912ab6328f80cd7d915c0f</Hash>
</Codenesium>*/