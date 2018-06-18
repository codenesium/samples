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
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStepNote")]
        [Trait("Area", "Services")]
        public partial class PipelineStepNoteServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
                        var records = new List<PipelineStepNote>();
                        records.Add(new PipelineStepNote());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PipelineStepNoteService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
                                                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

                        List<ApiPipelineStepNoteResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
                        var record = new PipelineStepNote();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new PipelineStepNoteService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
                                                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

                        ApiPipelineStepNoteResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepNote>(null));
                        var service = new PipelineStepNoteService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
                                                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

                        ApiPipelineStepNoteResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
                        var model = new ApiPipelineStepNoteRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepNote>())).Returns(Task.FromResult(new PipelineStepNote()));
                        var service = new PipelineStepNoteService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
                                                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

                        CreateResponse<ApiPipelineStepNoteResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepNoteRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStepNote>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
                        var model = new ApiPipelineStepNoteRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepNote>())).Returns(Task.FromResult(new PipelineStepNote()));
                        var service = new PipelineStepNoteService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
                                                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStepNote>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
                        var model = new ApiPipelineStepNoteRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new PipelineStepNoteService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
                                                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>e2089745058366e2a6937937a9682d26</Hash>
</Codenesium>*/