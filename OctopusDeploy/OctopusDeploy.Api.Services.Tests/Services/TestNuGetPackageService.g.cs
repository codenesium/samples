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
        [Trait("Table", "NuGetPackage")]
        [Trait("Area", "Services")]
        public partial class NuGetPackageServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<INuGetPackageRepository>();
                        var records = new List<NuGetPackage>();
                        records.Add(new NuGetPackage());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new NuGetPackageService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.NuGetPackageModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLNuGetPackageMapperMock,
                                                              mock.DALMapperMockFactory.DALNuGetPackageMapperMock);

                        List<ApiNuGetPackageResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<INuGetPackageRepository>();
                        var record = new NuGetPackage();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new NuGetPackageService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.NuGetPackageModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLNuGetPackageMapperMock,
                                                              mock.DALMapperMockFactory.DALNuGetPackageMapperMock);

                        ApiNuGetPackageResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<INuGetPackageRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<NuGetPackage>(null));
                        var service = new NuGetPackageService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.NuGetPackageModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLNuGetPackageMapperMock,
                                                              mock.DALMapperMockFactory.DALNuGetPackageMapperMock);

                        ApiNuGetPackageResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<INuGetPackageRepository>();
                        var model = new ApiNuGetPackageRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<NuGetPackage>())).Returns(Task.FromResult(new NuGetPackage()));
                        var service = new NuGetPackageService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.NuGetPackageModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLNuGetPackageMapperMock,
                                                              mock.DALMapperMockFactory.DALNuGetPackageMapperMock);

                        CreateResponse<ApiNuGetPackageResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.NuGetPackageModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiNuGetPackageRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<NuGetPackage>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<INuGetPackageRepository>();
                        var model = new ApiNuGetPackageRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<NuGetPackage>())).Returns(Task.FromResult(new NuGetPackage()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));
                        var service = new NuGetPackageService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.NuGetPackageModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLNuGetPackageMapperMock,
                                                              mock.DALMapperMockFactory.DALNuGetPackageMapperMock);

                        UpdateResponse<ApiNuGetPackageResponseModel> response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.NuGetPackageModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiNuGetPackageRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<NuGetPackage>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<INuGetPackageRepository>();
                        var model = new ApiNuGetPackageRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new NuGetPackageService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.NuGetPackageModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLNuGetPackageMapperMock,
                                                              mock.DALMapperMockFactory.DALNuGetPackageMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.NuGetPackageModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>95e5670cb7d7058e2950e453139274dd</Hash>
</Codenesium>*/