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
        [Trait("Table", "Interruption")]
        [Trait("Area", "Services")]
        public partial class InterruptionServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IInterruptionRepository>();
                        var records = new List<Interruption>();
                        records.Add(new Interruption());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new InterruptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.InterruptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLInterruptionMapperMock,
                                                              mock.DALMapperMockFactory.DALInterruptionMapperMock);

                        List<ApiInterruptionResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IInterruptionRepository>();
                        var record = new Interruption();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new InterruptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.InterruptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLInterruptionMapperMock,
                                                              mock.DALMapperMockFactory.DALInterruptionMapperMock);

                        ApiInterruptionResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IInterruptionRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Interruption>(null));
                        var service = new InterruptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.InterruptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLInterruptionMapperMock,
                                                              mock.DALMapperMockFactory.DALInterruptionMapperMock);

                        ApiInterruptionResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IInterruptionRepository>();
                        var model = new ApiInterruptionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Interruption>())).Returns(Task.FromResult(new Interruption()));
                        var service = new InterruptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.InterruptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLInterruptionMapperMock,
                                                              mock.DALMapperMockFactory.DALInterruptionMapperMock);

                        CreateResponse<ApiInterruptionResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.InterruptionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiInterruptionRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Interruption>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IInterruptionRepository>();
                        var model = new ApiInterruptionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Interruption>())).Returns(Task.FromResult(new Interruption()));
                        var service = new InterruptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.InterruptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLInterruptionMapperMock,
                                                              mock.DALMapperMockFactory.DALInterruptionMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.InterruptionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiInterruptionRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Interruption>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IInterruptionRepository>();
                        var model = new ApiInterruptionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new InterruptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.InterruptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLInterruptionMapperMock,
                                                              mock.DALMapperMockFactory.DALInterruptionMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.InterruptionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void ByTenantId_Exists()
                {
                        var mock = new ServiceMockFacade<IInterruptionRepository>();
                        var records = new List<Interruption>();
                        records.Add(new Interruption());
                        mock.RepositoryMock.Setup(x => x.ByTenantId(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new InterruptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.InterruptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLInterruptionMapperMock,
                                                              mock.DALMapperMockFactory.DALInterruptionMapperMock);

                        List<ApiInterruptionResponseModel> response = await service.ByTenantId(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByTenantId(It.IsAny<string>()));
                }

                [Fact]
                public async void ByTenantId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IInterruptionRepository>();
                        mock.RepositoryMock.Setup(x => x.ByTenantId(It.IsAny<string>())).Returns(Task.FromResult<List<Interruption>>(new List<Interruption>()));
                        var service = new InterruptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.InterruptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLInterruptionMapperMock,
                                                              mock.DALMapperMockFactory.DALInterruptionMapperMock);

                        List<ApiInterruptionResponseModel> response = await service.ByTenantId(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByTenantId(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>bf2f846e604c7dfe44d526d4928e441b</Hash>
</Codenesium>*/