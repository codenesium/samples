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
        [Trait("Table", "LinkLog")]
        [Trait("Area", "Services")]
        public partial class LinkLogServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ILinkLogRepository>();
                        var records = new List<LinkLog>();
                        records.Add(new LinkLog());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LinkLogService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                         mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        List<ApiLinkLogResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ILinkLogRepository>();
                        var record = new LinkLog();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new LinkLogService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                         mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        ApiLinkLogResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ILinkLogRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LinkLog>(null));
                        var service = new LinkLogService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                         mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        ApiLinkLogResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ILinkLogRepository>();
                        var model = new ApiLinkLogRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkLog>())).Returns(Task.FromResult(new LinkLog()));
                        var service = new LinkLogService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                         mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        CreateResponse<ApiLinkLogResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkLogRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LinkLog>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ILinkLogRepository>();
                        var model = new ApiLinkLogRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkLog>())).Returns(Task.FromResult(new LinkLog()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkLog()));
                        var service = new LinkLogService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                         mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        UpdateResponse<ApiLinkLogResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkLogRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LinkLog>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ILinkLogRepository>();
                        var model = new ApiLinkLogRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new LinkLogService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
                                                         mock.DALMapperMockFactory.DALLinkLogMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>255216fc6cac5c2a4dac98a889f94078</Hash>
</Codenesium>*/