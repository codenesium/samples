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
        [Trait("Table", "Tags")]
        [Trait("Area", "Services")]
        public partial class TagsServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ITagsRepository>();
                        var records = new List<Tags>();
                        records.Add(new Tags());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TagsService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTagsMapperMock,
                                                      mock.DALMapperMockFactory.DALTagsMapperMock);

                        List<ApiTagsResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ITagsRepository>();
                        var record = new Tags();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new TagsService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTagsMapperMock,
                                                      mock.DALMapperMockFactory.DALTagsMapperMock);

                        ApiTagsResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ITagsRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Tags>(null));
                        var service = new TagsService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTagsMapperMock,
                                                      mock.DALMapperMockFactory.DALTagsMapperMock);

                        ApiTagsResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ITagsRepository>();
                        var model = new ApiTagsRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tags>())).Returns(Task.FromResult(new Tags()));
                        var service = new TagsService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTagsMapperMock,
                                                      mock.DALMapperMockFactory.DALTagsMapperMock);

                        CreateResponse<ApiTagsResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TagsModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTagsRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Tags>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ITagsRepository>();
                        var model = new ApiTagsRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tags>())).Returns(Task.FromResult(new Tags()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tags()));
                        var service = new TagsService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTagsMapperMock,
                                                      mock.DALMapperMockFactory.DALTagsMapperMock);

                        UpdateResponse<ApiTagsResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TagsModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTagsRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Tags>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ITagsRepository>();
                        var model = new ApiTagsRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new TagsService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTagsMapperMock,
                                                      mock.DALMapperMockFactory.DALTagsMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.TagsModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>00b68a8af8de803abfd5f32e4c6d393b</Hash>
</Codenesium>*/