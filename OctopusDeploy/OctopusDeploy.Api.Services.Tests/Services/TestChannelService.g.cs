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
        [Trait("Table", "Channel")]
        [Trait("Area", "Services")]
        public partial class ChannelServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        var records = new List<Channel>();
                        records.Add(new Channel());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        List<ApiChannelResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        var record = new Channel();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        ApiChannelResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Channel>(null));
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        ApiChannelResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        var model = new ApiChannelRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Channel>())).Returns(Task.FromResult(new Channel()));
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        CreateResponse<ApiChannelResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiChannelRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Channel>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        var model = new ApiChannelRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Channel>())).Returns(Task.FromResult(new Channel()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        UpdateResponse<ApiChannelResponseModel> response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiChannelRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Channel>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        var model = new ApiChannelRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void ByNameProjectId_Exists()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        var record = new Channel();
                        mock.RepositoryMock.Setup(x => x.ByNameProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        ApiChannelResponseModel response = await service.ByNameProjectId(default(string), default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByNameProjectId(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void ByNameProjectId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        mock.RepositoryMock.Setup(x => x.ByNameProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Channel>(null));
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        ApiChannelResponseModel response = await service.ByNameProjectId(default(string), default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByNameProjectId(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void ByDataVersion_Exists()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        var records = new List<Channel>();
                        records.Add(new Channel());
                        mock.RepositoryMock.Setup(x => x.ByDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult(records));
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        List<ApiChannelResponseModel> response = await service.ByDataVersion(default(byte[]));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByDataVersion(It.IsAny<byte[]>()));
                }

                [Fact]
                public async void ByDataVersion_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        mock.RepositoryMock.Setup(x => x.ByDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult<List<Channel>>(new List<Channel>()));
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        List<ApiChannelResponseModel> response = await service.ByDataVersion(default(byte[]));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByDataVersion(It.IsAny<byte[]>()));
                }

                [Fact]
                public async void ByProjectId_Exists()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        var records = new List<Channel>();
                        records.Add(new Channel());
                        mock.RepositoryMock.Setup(x => x.ByProjectId(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        List<ApiChannelResponseModel> response = await service.ByProjectId(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProjectId(It.IsAny<string>()));
                }

                [Fact]
                public async void ByProjectId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IChannelRepository>();
                        mock.RepositoryMock.Setup(x => x.ByProjectId(It.IsAny<string>())).Returns(Task.FromResult<List<Channel>>(new List<Channel>()));
                        var service = new ChannelService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ChannelModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLChannelMapperMock,
                                                         mock.DALMapperMockFactory.DALChannelMapperMock);

                        List<ApiChannelResponseModel> response = await service.ByProjectId(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProjectId(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>245c5b804f953d5fd658dee07f99a14d</Hash>
</Codenesium>*/