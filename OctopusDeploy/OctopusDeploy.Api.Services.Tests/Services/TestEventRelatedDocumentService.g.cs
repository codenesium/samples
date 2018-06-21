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
        [Trait("Table", "EventRelatedDocument")]
        [Trait("Area", "Services")]
        public partial class EventRelatedDocumentServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IEventRelatedDocumentRepository>();
                        var records = new List<EventRelatedDocument>();
                        records.Add(new EventRelatedDocument());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new EventRelatedDocumentService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                                      mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventRelatedDocumentResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IEventRelatedDocumentRepository>();
                        var record = new EventRelatedDocument();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new EventRelatedDocumentService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                                      mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        ApiEventRelatedDocumentResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IEventRelatedDocumentRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<EventRelatedDocument>(null));
                        var service = new EventRelatedDocumentService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                                      mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        ApiEventRelatedDocumentResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IEventRelatedDocumentRepository>();
                        var model = new ApiEventRelatedDocumentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventRelatedDocument>())).Returns(Task.FromResult(new EventRelatedDocument()));
                        var service = new EventRelatedDocumentService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                                      mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        CreateResponse<ApiEventRelatedDocumentResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventRelatedDocumentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<EventRelatedDocument>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IEventRelatedDocumentRepository>();
                        var model = new ApiEventRelatedDocumentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventRelatedDocument>())).Returns(Task.FromResult(new EventRelatedDocument()));
                        var service = new EventRelatedDocumentService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                                      mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventRelatedDocumentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<EventRelatedDocument>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IEventRelatedDocumentRepository>();
                        var model = new ApiEventRelatedDocumentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new EventRelatedDocumentService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                                      mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void GetEventId_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRelatedDocumentRepository>();
                        var records = new List<EventRelatedDocument>();
                        records.Add(new EventRelatedDocument());
                        mock.RepositoryMock.Setup(x => x.GetEventId(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new EventRelatedDocumentService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                                      mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventRelatedDocumentResponseModel> response = await service.GetEventId(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetEventId(It.IsAny<string>()));
                }

                [Fact]
                public async void GetEventId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRelatedDocumentRepository>();
                        mock.RepositoryMock.Setup(x => x.GetEventId(It.IsAny<string>())).Returns(Task.FromResult<List<EventRelatedDocument>>(new List<EventRelatedDocument>()));
                        var service = new EventRelatedDocumentService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                                      mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventRelatedDocumentResponseModel> response = await service.GetEventId(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetEventId(It.IsAny<string>()));
                }

                [Fact]
                public async void GetEventIdRelatedDocumentId_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRelatedDocumentRepository>();
                        var records = new List<EventRelatedDocument>();
                        records.Add(new EventRelatedDocument());
                        mock.RepositoryMock.Setup(x => x.GetEventIdRelatedDocumentId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new EventRelatedDocumentService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                                      mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventRelatedDocumentResponseModel> response = await service.GetEventIdRelatedDocumentId(default(string), default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetEventIdRelatedDocumentId(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetEventIdRelatedDocumentId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRelatedDocumentRepository>();
                        mock.RepositoryMock.Setup(x => x.GetEventIdRelatedDocumentId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<List<EventRelatedDocument>>(new List<EventRelatedDocument>()));
                        var service = new EventRelatedDocumentService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.EventRelatedDocumentModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                                      mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventRelatedDocumentResponseModel> response = await service.GetEventIdRelatedDocumentId(default(string), default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetEventIdRelatedDocumentId(It.IsAny<string>(), It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>82c5118047669dfaac6219cc9f2449a3</Hash>
</Codenesium>*/