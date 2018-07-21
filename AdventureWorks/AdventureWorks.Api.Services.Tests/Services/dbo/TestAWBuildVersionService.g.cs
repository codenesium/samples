using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "AWBuildVersion")]
        [Trait("Area", "Services")]
        public partial class AWBuildVersionServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
                        var records = new List<AWBuildVersion>();
                        records.Add(new AWBuildVersion());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new AWBuildVersionService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLAWBuildVersionMapperMock,
                                                                mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

                        List<ApiAWBuildVersionResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
                        var record = new AWBuildVersion();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new AWBuildVersionService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLAWBuildVersionMapperMock,
                                                                mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

                        ApiAWBuildVersionResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<AWBuildVersion>(null));
                        var service = new AWBuildVersionService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLAWBuildVersionMapperMock,
                                                                mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

                        ApiAWBuildVersionResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
                        var model = new ApiAWBuildVersionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AWBuildVersion>())).Returns(Task.FromResult(new AWBuildVersion()));
                        var service = new AWBuildVersionService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLAWBuildVersionMapperMock,
                                                                mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

                        CreateResponse<ApiAWBuildVersionResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAWBuildVersionRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<AWBuildVersion>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
                        var model = new ApiAWBuildVersionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AWBuildVersion>())).Returns(Task.FromResult(new AWBuildVersion()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));
                        var service = new AWBuildVersionService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLAWBuildVersionMapperMock,
                                                                mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

                        UpdateResponse<ApiAWBuildVersionResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<AWBuildVersion>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
                        var model = new ApiAWBuildVersionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new AWBuildVersionService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLAWBuildVersionMapperMock,
                                                                mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>ceaa206f7c473bcd4ca034bfeac82eca</Hash>
</Codenesium>*/