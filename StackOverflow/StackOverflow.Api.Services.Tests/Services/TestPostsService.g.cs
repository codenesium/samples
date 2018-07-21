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
        [Trait("Table", "Posts")]
        [Trait("Area", "Services")]
        public partial class PostsServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IPostsRepository>();
                        var records = new List<Posts>();
                        records.Add(new Posts());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PostsService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLPostsMapperMock,
                                                       mock.DALMapperMockFactory.DALPostsMapperMock);

                        List<ApiPostsResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IPostsRepository>();
                        var record = new Posts();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new PostsService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLPostsMapperMock,
                                                       mock.DALMapperMockFactory.DALPostsMapperMock);

                        ApiPostsResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IPostsRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));
                        var service = new PostsService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLPostsMapperMock,
                                                       mock.DALMapperMockFactory.DALPostsMapperMock);

                        ApiPostsResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IPostsRepository>();
                        var model = new ApiPostsRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Posts>())).Returns(Task.FromResult(new Posts()));
                        var service = new PostsService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLPostsMapperMock,
                                                       mock.DALMapperMockFactory.DALPostsMapperMock);

                        CreateResponse<ApiPostsResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PostsModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostsRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Posts>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IPostsRepository>();
                        var model = new ApiPostsRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Posts>())).Returns(Task.FromResult(new Posts()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));
                        var service = new PostsService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLPostsMapperMock,
                                                       mock.DALMapperMockFactory.DALPostsMapperMock);

                        UpdateResponse<ApiPostsResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PostsModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostsRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Posts>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IPostsRepository>();
                        var model = new ApiPostsRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new PostsService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLPostsMapperMock,
                                                       mock.DALMapperMockFactory.DALPostsMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.PostsModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>7bb916586b9d8f3f1db1a3fd227ba7c1</Hash>
</Codenesium>*/