using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStepDestination")]
        [Trait("Area", "Services")]
        public partial class PipelineStepDestinationServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IPipelineStepDestinationRepository>();
                        var records = new List<PipelineStepDestination>();
                        records.Add(new PipelineStepDestination());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLPipelineStepDestinationMapperMock,
                                                                         mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

                        List<ApiPipelineStepDestinationResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IPipelineStepDestinationRepository>();
                        var record = new PipelineStepDestination();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLPipelineStepDestinationMapperMock,
                                                                         mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

                        ApiPipelineStepDestinationResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IPipelineStepDestinationRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepDestination>(null));
                        var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLPipelineStepDestinationMapperMock,
                                                                         mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

                        ApiPipelineStepDestinationResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IPipelineStepDestinationRepository>();
                        var model = new ApiPipelineStepDestinationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepDestination>())).Returns(Task.FromResult(new PipelineStepDestination()));
                        var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLPipelineStepDestinationMapperMock,
                                                                         mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

                        CreateResponse<ApiPipelineStepDestinationResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepDestinationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStepDestination>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IPipelineStepDestinationRepository>();
                        var model = new ApiPipelineStepDestinationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepDestination>())).Returns(Task.FromResult(new PipelineStepDestination()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepDestination()));
                        var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLPipelineStepDestinationMapperMock,
                                                                         mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

                        UpdateResponse<ApiPipelineStepDestinationResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStepDestination>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IPipelineStepDestinationRepository>();
                        var model = new ApiPipelineStepDestinationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLPipelineStepDestinationMapperMock,
                                                                         mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>3fb9cbfb72636c1a823415ebe0c36a4c</Hash>
</Codenesium>*/