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
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "JobCandidate")]
        [Trait("Area", "Services")]
        public partial class JobCandidateServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IJobCandidateRepository>();
                        var records = new List<JobCandidate>();
                        records.Add(new JobCandidate());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new JobCandidateService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.JobCandidateModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                              mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        List<ApiJobCandidateResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IJobCandidateRepository>();
                        var record = new JobCandidate();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new JobCandidateService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.JobCandidateModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                              mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ApiJobCandidateResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IJobCandidateRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<JobCandidate>(null));
                        var service = new JobCandidateService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.JobCandidateModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                              mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ApiJobCandidateResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IJobCandidateRepository>();
                        var model = new ApiJobCandidateRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<JobCandidate>())).Returns(Task.FromResult(new JobCandidate()));
                        var service = new JobCandidateService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.JobCandidateModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                              mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        CreateResponse<ApiJobCandidateResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.JobCandidateModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiJobCandidateRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<JobCandidate>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IJobCandidateRepository>();
                        var model = new ApiJobCandidateRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<JobCandidate>())).Returns(Task.FromResult(new JobCandidate()));
                        var service = new JobCandidateService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.JobCandidateModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                              mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.JobCandidateModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiJobCandidateRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<JobCandidate>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IJobCandidateRepository>();
                        var model = new ApiJobCandidateRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new JobCandidateService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.JobCandidateModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                              mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.JobCandidateModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByBusinessEntityID_Exists()
                {
                        var mock = new ServiceMockFacade<IJobCandidateRepository>();
                        var records = new List<JobCandidate>();
                        records.Add(new JobCandidate());
                        mock.RepositoryMock.Setup(x => x.ByBusinessEntityID(It.IsAny<Nullable<int>>())).Returns(Task.FromResult(records));
                        var service = new JobCandidateService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.JobCandidateModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                              mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        List<ApiJobCandidateResponseModel> response = await service.ByBusinessEntityID(default (Nullable<int>));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByBusinessEntityID(It.IsAny<Nullable<int>>()));
                }

                [Fact]
                public async void ByBusinessEntityID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IJobCandidateRepository>();
                        mock.RepositoryMock.Setup(x => x.ByBusinessEntityID(It.IsAny<Nullable<int>>())).Returns(Task.FromResult<List<JobCandidate>>(new List<JobCandidate>()));
                        var service = new JobCandidateService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.JobCandidateModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                              mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        List<ApiJobCandidateResponseModel> response = await service.ByBusinessEntityID(default (Nullable<int>));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByBusinessEntityID(It.IsAny<Nullable<int>>()));
                }
        }
}

/*<Codenesium>
    <Hash>6123fd80678b0ec30ffe83f6eaf6247a</Hash>
</Codenesium>*/