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
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Event")]
        [Trait("Area", "Services")]
        public partial class EventServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        var records = new List<Event>();
                        records.Add(new Event());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        var record = new Event();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        ApiEventResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Event>(null));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        ApiEventResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        var model = new ApiEventRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Event>())).Returns(Task.FromResult(new Event()));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        CreateResponse<ApiEventResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.EventModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Event>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        var model = new ApiEventRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Event>())).Returns(Task.FromResult(new Event()));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.EventModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiEventRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Event>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        var model = new ApiEventRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.EventModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetAutoId_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        var records = new List<Event>();
                        records.Add(new Event());
                        mock.RepositoryMock.Setup(x => x.GetAutoId(It.IsAny<long>())).Returns(Task.FromResult(records));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventResponseModel> response = await service.GetAutoId(default (long));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetAutoId(It.IsAny<long>()));
                }

                [Fact]
                public async void GetAutoId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        mock.RepositoryMock.Setup(x => x.GetAutoId(It.IsAny<long>())).Returns(Task.FromResult<List<Event>>(new List<Event>()));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventResponseModel> response = await service.GetAutoId(default (long));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetAutoId(It.IsAny<long>()));
                }

                [Fact]
                public async void GetIdRelatedDocumentIdsOccurredCategoryAutoId_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        var records = new List<Event>();
                        records.Add(new Event());
                        mock.RepositoryMock.Setup(x => x.GetIdRelatedDocumentIdsOccurredCategoryAutoId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<long>())).Returns(Task.FromResult(records));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventResponseModel> response = await service.GetIdRelatedDocumentIdsOccurredCategoryAutoId(default (string), default (string), default (DateTimeOffset), default (string), default (long));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdRelatedDocumentIdsOccurredCategoryAutoId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<long>()));
                }

                [Fact]
                public async void GetIdRelatedDocumentIdsOccurredCategoryAutoId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        mock.RepositoryMock.Setup(x => x.GetIdRelatedDocumentIdsOccurredCategoryAutoId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<long>())).Returns(Task.FromResult<List<Event>>(new List<Event>()));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventResponseModel> response = await service.GetIdRelatedDocumentIdsOccurredCategoryAutoId(default (string), default (string), default (DateTimeOffset), default (string), default (long));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdRelatedDocumentIdsOccurredCategoryAutoId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<long>()));
                }

                [Fact]
                public async void GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        var records = new List<Event>();
                        records.Add(new Event());
                        mock.RepositoryMock.Setup(x => x.GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventResponseModel> response = await service.GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(default (string), default (string), default (string), default (string), default (string), default (string), default (DateTimeOffset), default (string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        mock.RepositoryMock.Setup(x => x.GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>())).Returns(Task.FromResult<List<Event>>(new List<Event>()));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventResponseModel> response = await service.GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(default (string), default (string), default (string), default (string), default (string), default (string), default (DateTimeOffset), default (string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetIdOccurred_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        var records = new List<Event>();
                        records.Add(new Event());
                        mock.RepositoryMock.Setup(x => x.GetIdOccurred(It.IsAny<string>(), It.IsAny<DateTimeOffset>())).Returns(Task.FromResult(records));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventResponseModel> response = await service.GetIdOccurred(default (string), default (DateTimeOffset));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdOccurred(It.IsAny<string>(), It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void GetIdOccurred_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        mock.RepositoryMock.Setup(x => x.GetIdOccurred(It.IsAny<string>(), It.IsAny<DateTimeOffset>())).Returns(Task.FromResult<List<Event>>(new List<Event>()));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventResponseModel> response = await service.GetIdOccurred(default (string), default (DateTimeOffset));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdOccurred(It.IsAny<string>(), It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void EventRelatedDocuments_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        var records = new List<EventRelatedDocument>();
                        records.Add(new EventRelatedDocument());
                        mock.RepositoryMock.Setup(x => x.EventRelatedDocuments(default (string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventRelatedDocumentResponseModel> response = await service.EventRelatedDocuments(default (string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.EventRelatedDocuments(default (string), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void EventRelatedDocuments_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEventRepository>();
                        mock.RepositoryMock.Setup(x => x.EventRelatedDocuments(default (string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventRelatedDocument>>(new List<EventRelatedDocument>()));
                        var service = new EventService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                       mock.DALMapperMockFactory.DALEventMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEventRelatedDocumentMapperMock,
                                                       mock.DALMapperMockFactory.DALEventRelatedDocumentMapperMock);

                        List<ApiEventRelatedDocumentResponseModel> response = await service.EventRelatedDocuments(default (string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.EventRelatedDocuments(default (string), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>974d24427a471d2e46fe5dac49e54a32</Hash>
</Codenesium>*/