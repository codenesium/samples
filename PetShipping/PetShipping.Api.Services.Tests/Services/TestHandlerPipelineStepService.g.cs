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
        [Trait("Table", "HandlerPipelineStep")]
        [Trait("Area", "Services")]
        public partial class HandlerPipelineStepServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
                        var records = new List<HandlerPipelineStep>();
                        records.Add(new HandlerPipelineStep());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
                                                                     mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

                        List<ApiHandlerPipelineStepResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
                        var record = new HandlerPipelineStep();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
                                                                     mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

                        ApiHandlerPipelineStepResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<HandlerPipelineStep>(null));
                        var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
                                                                     mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

                        ApiHandlerPipelineStepResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
                        var model = new ApiHandlerPipelineStepRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<HandlerPipelineStep>())).Returns(Task.FromResult(new HandlerPipelineStep()));
                        var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
                                                                     mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

                        CreateResponse<ApiHandlerPipelineStepResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerPipelineStepRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<HandlerPipelineStep>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
                        var model = new ApiHandlerPipelineStepRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<HandlerPipelineStep>())).Returns(Task.FromResult(new HandlerPipelineStep()));
                        var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
                                                                     mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<HandlerPipelineStep>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
                        var model = new ApiHandlerPipelineStepRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
                                                                     mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>d9c2ea7b156742385142e1df37cc3b9e</Hash>
</Codenesium>*/