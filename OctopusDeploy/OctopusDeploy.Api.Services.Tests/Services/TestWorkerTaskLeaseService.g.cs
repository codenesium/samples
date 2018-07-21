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
        [Trait("Table", "WorkerTaskLease")]
        [Trait("Area", "Services")]
        public partial class WorkerTaskLeaseServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IWorkerTaskLeaseRepository>();
                        var records = new List<WorkerTaskLease>();
                        records.Add(new WorkerTaskLease());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new WorkerTaskLeaseService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.WorkerTaskLeaseModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLWorkerTaskLeaseMapperMock,
                                                                 mock.DALMapperMockFactory.DALWorkerTaskLeaseMapperMock);

                        List<ApiWorkerTaskLeaseResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IWorkerTaskLeaseRepository>();
                        var record = new WorkerTaskLease();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new WorkerTaskLeaseService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.WorkerTaskLeaseModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLWorkerTaskLeaseMapperMock,
                                                                 mock.DALMapperMockFactory.DALWorkerTaskLeaseMapperMock);

                        ApiWorkerTaskLeaseResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IWorkerTaskLeaseRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<WorkerTaskLease>(null));
                        var service = new WorkerTaskLeaseService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.WorkerTaskLeaseModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLWorkerTaskLeaseMapperMock,
                                                                 mock.DALMapperMockFactory.DALWorkerTaskLeaseMapperMock);

                        ApiWorkerTaskLeaseResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IWorkerTaskLeaseRepository>();
                        var model = new ApiWorkerTaskLeaseRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<WorkerTaskLease>())).Returns(Task.FromResult(new WorkerTaskLease()));
                        var service = new WorkerTaskLeaseService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.WorkerTaskLeaseModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLWorkerTaskLeaseMapperMock,
                                                                 mock.DALMapperMockFactory.DALWorkerTaskLeaseMapperMock);

                        CreateResponse<ApiWorkerTaskLeaseResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.WorkerTaskLeaseModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiWorkerTaskLeaseRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<WorkerTaskLease>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IWorkerTaskLeaseRepository>();
                        var model = new ApiWorkerTaskLeaseRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<WorkerTaskLease>())).Returns(Task.FromResult(new WorkerTaskLease()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));
                        var service = new WorkerTaskLeaseService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.WorkerTaskLeaseModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLWorkerTaskLeaseMapperMock,
                                                                 mock.DALMapperMockFactory.DALWorkerTaskLeaseMapperMock);

                        UpdateResponse<ApiWorkerTaskLeaseResponseModel> response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.WorkerTaskLeaseModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiWorkerTaskLeaseRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<WorkerTaskLease>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IWorkerTaskLeaseRepository>();
                        var model = new ApiWorkerTaskLeaseRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new WorkerTaskLeaseService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.WorkerTaskLeaseModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLWorkerTaskLeaseMapperMock,
                                                                 mock.DALMapperMockFactory.DALWorkerTaskLeaseMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.WorkerTaskLeaseModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>12c65b63b7a312cc437b232d3de8c5f8</Hash>
</Codenesium>*/