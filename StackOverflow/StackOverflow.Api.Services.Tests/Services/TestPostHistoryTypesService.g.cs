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
        [Trait("Table", "PostHistoryTypes")]
        [Trait("Area", "Services")]
        public partial class PostHistoryTypesServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
                        var records = new List<PostHistoryTypes>();
                        records.Add(new PostHistoryTypes());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PostHistoryTypesService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPostHistoryTypesMapperMock,
                                                                  mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock);

                        List<ApiPostHistoryTypesResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
                        var record = new PostHistoryTypes();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new PostHistoryTypesService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPostHistoryTypesMapperMock,
                                                                  mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock);

                        ApiPostHistoryTypesResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostHistoryTypes>(null));
                        var service = new PostHistoryTypesService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPostHistoryTypesMapperMock,
                                                                  mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock);

                        ApiPostHistoryTypesResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
                        var model = new ApiPostHistoryTypesRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistoryTypes>())).Returns(Task.FromResult(new PostHistoryTypes()));
                        var service = new PostHistoryTypesService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPostHistoryTypesMapperMock,
                                                                  mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock);

                        CreateResponse<ApiPostHistoryTypesResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypesRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostHistoryTypes>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
                        var model = new ApiPostHistoryTypesRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistoryTypes>())).Returns(Task.FromResult(new PostHistoryTypes()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryTypes()));
                        var service = new PostHistoryTypesService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPostHistoryTypesMapperMock,
                                                                  mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock);

                        UpdateResponse<ApiPostHistoryTypesResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostHistoryTypes>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
                        var model = new ApiPostHistoryTypesRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new PostHistoryTypesService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPostHistoryTypesMapperMock,
                                                                  mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>6093b699b264981d2eeb857250498446</Hash>
</Codenesium>*/