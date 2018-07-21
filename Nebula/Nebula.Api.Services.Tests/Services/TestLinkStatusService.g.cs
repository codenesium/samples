using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LinkStatus")]
        [Trait("Area", "Services")]
        public partial class LinkStatusServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ILinkStatusRepository>();
                        var records = new List<LinkStatus>();
                        records.Add(new LinkStatus());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LinkStatusService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkStatusMapperMock,
                                                            mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkMapperMock);

                        List<ApiLinkStatusResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ILinkStatusRepository>();
                        var record = new LinkStatus();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new LinkStatusService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkStatusMapperMock,
                                                            mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkMapperMock);

                        ApiLinkStatusResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ILinkStatusRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LinkStatus>(null));
                        var service = new LinkStatusService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkStatusMapperMock,
                                                            mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkMapperMock);

                        ApiLinkStatusResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ILinkStatusRepository>();
                        var model = new ApiLinkStatusRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkStatus>())).Returns(Task.FromResult(new LinkStatus()));
                        var service = new LinkStatusService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkStatusMapperMock,
                                                            mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkMapperMock);

                        CreateResponse<ApiLinkStatusResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkStatusRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LinkStatus>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ILinkStatusRepository>();
                        var model = new ApiLinkStatusRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkStatus>())).Returns(Task.FromResult(new LinkStatus()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));
                        var service = new LinkStatusService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkStatusMapperMock,
                                                            mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkMapperMock);

                        UpdateResponse<ApiLinkStatusResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkStatusRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LinkStatus>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ILinkStatusRepository>();
                        var model = new ApiLinkStatusRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new LinkStatusService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkStatusMapperMock,
                                                            mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void Links_Exists()
                {
                        var mock = new ServiceMockFacade<ILinkStatusRepository>();
                        var records = new List<Link>();
                        records.Add(new Link());
                        mock.RepositoryMock.Setup(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LinkStatusService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkStatusMapperMock,
                                                            mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkMapperMock);

                        List<ApiLinkResponseModel> response = await service.Links(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Links_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ILinkStatusRepository>();
                        mock.RepositoryMock.Setup(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Link>>(new List<Link>()));
                        var service = new LinkStatusService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkStatusMapperMock,
                                                            mock.BOLMapperMockFactory.BOLLinkMapperMock,
                                                            mock.DALMapperMockFactory.DALLinkMapperMock);

                        List<ApiLinkResponseModel> response = await service.Links(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>c3d2a15f9e8cbfd7c1fe3eb3ae002f2b</Hash>
</Codenesium>*/