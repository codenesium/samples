using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Feed")]
        [Trait("Area", "Services")]
        public partial class FeedServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IFeedRepository>();
                        var records = new List<Feed>();
                        records.Add(new Feed());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new FeedService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FeedModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFeedMapperMock,
                                                      mock.DALMapperMockFactory.DALFeedMapperMock);

                        List<ApiFeedResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IFeedRepository>();
                        var record = new Feed();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new FeedService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FeedModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFeedMapperMock,
                                                      mock.DALMapperMockFactory.DALFeedMapperMock);

                        ApiFeedResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IFeedRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Feed>(null));
                        var service = new FeedService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FeedModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFeedMapperMock,
                                                      mock.DALMapperMockFactory.DALFeedMapperMock);

                        ApiFeedResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IFeedRepository>();
                        var model = new ApiFeedRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Feed>())).Returns(Task.FromResult(new Feed()));
                        var service = new FeedService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FeedModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFeedMapperMock,
                                                      mock.DALMapperMockFactory.DALFeedMapperMock);

                        CreateResponse<ApiFeedResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.FeedModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFeedRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Feed>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IFeedRepository>();
                        var model = new ApiFeedRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Feed>())).Returns(Task.FromResult(new Feed()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));
                        var service = new FeedService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FeedModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFeedMapperMock,
                                                      mock.DALMapperMockFactory.DALFeedMapperMock);

                        UpdateResponse<ApiFeedResponseModel> response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.FeedModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiFeedRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Feed>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IFeedRepository>();
                        var model = new ApiFeedRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new FeedService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FeedModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFeedMapperMock,
                                                      mock.DALMapperMockFactory.DALFeedMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.FeedModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IFeedRepository>();
                        var record = new Feed();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new FeedService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FeedModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFeedMapperMock,
                                                      mock.DALMapperMockFactory.DALFeedMapperMock);

                        ApiFeedResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IFeedRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Feed>(null));
                        var service = new FeedService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FeedModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFeedMapperMock,
                                                      mock.DALMapperMockFactory.DALFeedMapperMock);

                        ApiFeedResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>6441e3fbb2950fd2f016886bc8a94aaa</Hash>
</Codenesium>*/