using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Link")]
        [Trait("Area", "Services")]
        public partial class LinkServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ILinkRepository>();
                        var records = new List<Link>();
                        records.Add(new Link());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LinkService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkMapperMock,
                                                      mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        List<ApiLinkResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ILinkRepository>();
                        var record = new Link();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new LinkService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkMapperMock,
                                                      mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        ApiLinkResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ILinkRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Link>(null));
                        var service = new LinkService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkMapperMock,
                                                      mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        ApiLinkResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ILinkRepository>();
                        var model = new ApiLinkRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Link>())).Returns(Task.FromResult(new Link()));
                        var service = new LinkService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkMapperMock,
                                                      mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        CreateResponse<ApiLinkResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LinkModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Link>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ILinkRepository>();
                        var model = new ApiLinkRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Link>())).Returns(Task.FromResult(new Link()));
                        var service = new LinkService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkMapperMock,
                                                      mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LinkModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Link>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ILinkRepository>();
                        var model = new ApiLinkRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new LinkService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkMapperMock,
                                                      mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.LinkModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void LinkLogs_Exists()
                {
                        var mock = new ServiceMockFacade<ILinkRepository>();
                        var records = new List<LinkLog>();
                        records.Add(new LinkLog());
                        mock.RepositoryMock.Setup(x => x.LinkLogs(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LinkService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkMapperMock,
                                                      mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        List<ApiLinkLogResponseModel> response = await service.LinkLogs(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.LinkLogs(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void LinkLogs_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ILinkRepository>();
                        mock.RepositoryMock.Setup(x => x.LinkLogs(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<LinkLog>>(new List<LinkLog>()));
                        var service = new LinkService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkMapperMock,
                                                      mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                      mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        List<ApiLinkLogResponseModel> response = await service.LinkLogs(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.LinkLogs(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>71233bf3353754f9515feb93ff0d1beb</Hash>
</Codenesium>*/