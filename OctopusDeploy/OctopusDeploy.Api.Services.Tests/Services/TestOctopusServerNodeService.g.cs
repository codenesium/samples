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
        [Trait("Table", "OctopusServerNode")]
        [Trait("Area", "Services")]
        public partial class OctopusServerNodeServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IOctopusServerNodeRepository>();
                        var records = new List<OctopusServerNode>();
                        records.Add(new OctopusServerNode());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new OctopusServerNodeService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.OctopusServerNodeModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLOctopusServerNodeMapperMock,
                                                                   mock.DALMapperMockFactory.DALOctopusServerNodeMapperMock);

                        List<ApiOctopusServerNodeResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IOctopusServerNodeRepository>();
                        var record = new OctopusServerNode();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new OctopusServerNodeService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.OctopusServerNodeModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLOctopusServerNodeMapperMock,
                                                                   mock.DALMapperMockFactory.DALOctopusServerNodeMapperMock);

                        ApiOctopusServerNodeResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IOctopusServerNodeRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<OctopusServerNode>(null));
                        var service = new OctopusServerNodeService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.OctopusServerNodeModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLOctopusServerNodeMapperMock,
                                                                   mock.DALMapperMockFactory.DALOctopusServerNodeMapperMock);

                        ApiOctopusServerNodeResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IOctopusServerNodeRepository>();
                        var model = new ApiOctopusServerNodeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OctopusServerNode>())).Returns(Task.FromResult(new OctopusServerNode()));
                        var service = new OctopusServerNodeService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.OctopusServerNodeModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLOctopusServerNodeMapperMock,
                                                                   mock.DALMapperMockFactory.DALOctopusServerNodeMapperMock);

                        CreateResponse<ApiOctopusServerNodeResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.OctopusServerNodeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOctopusServerNodeRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<OctopusServerNode>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IOctopusServerNodeRepository>();
                        var model = new ApiOctopusServerNodeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OctopusServerNode>())).Returns(Task.FromResult(new OctopusServerNode()));
                        var service = new OctopusServerNodeService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.OctopusServerNodeModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLOctopusServerNodeMapperMock,
                                                                   mock.DALMapperMockFactory.DALOctopusServerNodeMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.OctopusServerNodeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiOctopusServerNodeRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<OctopusServerNode>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IOctopusServerNodeRepository>();
                        var model = new ApiOctopusServerNodeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new OctopusServerNodeService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.OctopusServerNodeModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLOctopusServerNodeMapperMock,
                                                                   mock.DALMapperMockFactory.DALOctopusServerNodeMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.OctopusServerNodeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>4f6eade17fb612249d5015231165d9c7</Hash>
</Codenesium>*/