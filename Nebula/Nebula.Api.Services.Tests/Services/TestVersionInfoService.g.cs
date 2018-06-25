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
        [Trait("Table", "VersionInfo")]
        [Trait("Area", "Services")]
        public partial class VersionInfoServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var records = new List<VersionInfo>();
                        records.Add(new VersionInfo());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        List<ApiVersionInfoResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var record = new VersionInfo();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(record));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ApiVersionInfoResponseModel response = await service.Get(default(long));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<long>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult<VersionInfo>(null));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ApiVersionInfoResponseModel response = await service.Get(default(long));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<long>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var model = new ApiVersionInfoRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VersionInfo>())).Returns(Task.FromResult(new VersionInfo()));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        CreateResponse<ApiVersionInfoResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVersionInfoRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VersionInfo>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var model = new ApiVersionInfoRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VersionInfo>())).Returns(Task.FromResult(new VersionInfo()));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ActionResponse response = await service.Update(default(long), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<long>(), It.IsAny<ApiVersionInfoRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VersionInfo>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var model = new ApiVersionInfoRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<long>())).Returns(Task.CompletedTask);
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ActionResponse response = await service.Delete(default(long));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<long>()));
                        mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<long>()));
                }

                [Fact]
                public async void ByVersion_Exists()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var record = new VersionInfo();
                        mock.RepositoryMock.Setup(x => x.ByVersion(It.IsAny<long>())).Returns(Task.FromResult(record));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ApiVersionInfoResponseModel response = await service.ByVersion(default(long));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByVersion(It.IsAny<long>()));
                }

                [Fact]
                public async void ByVersion_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        mock.RepositoryMock.Setup(x => x.ByVersion(It.IsAny<long>())).Returns(Task.FromResult<VersionInfo>(null));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ApiVersionInfoResponseModel response = await service.ByVersion(default(long));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByVersion(It.IsAny<long>()));
                }
        }
}

/*<Codenesium>
    <Hash>355cbe8a54fb16cb663fd714edae4fb2</Hash>
</Codenesium>*/