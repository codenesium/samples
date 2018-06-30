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
        [Trait("Table", "ClientCommunication")]
        [Trait("Area", "Services")]
        public partial class ClientCommunicationServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IClientCommunicationRepository>();
                        var records = new List<ClientCommunication>();
                        records.Add(new ClientCommunication());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ClientCommunicationService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ClientCommunicationModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                                     mock.DALMapperMockFactory.DALClientCommunicationMapperMock);

                        List<ApiClientCommunicationResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IClientCommunicationRepository>();
                        var record = new ClientCommunication();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ClientCommunicationService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ClientCommunicationModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                                     mock.DALMapperMockFactory.DALClientCommunicationMapperMock);

                        ApiClientCommunicationResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IClientCommunicationRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ClientCommunication>(null));
                        var service = new ClientCommunicationService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ClientCommunicationModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                                     mock.DALMapperMockFactory.DALClientCommunicationMapperMock);

                        ApiClientCommunicationResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IClientCommunicationRepository>();
                        var model = new ApiClientCommunicationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ClientCommunication>())).Returns(Task.FromResult(new ClientCommunication()));
                        var service = new ClientCommunicationService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ClientCommunicationModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                                     mock.DALMapperMockFactory.DALClientCommunicationMapperMock);

                        CreateResponse<ApiClientCommunicationResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ClientCommunicationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiClientCommunicationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ClientCommunication>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IClientCommunicationRepository>();
                        var model = new ApiClientCommunicationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ClientCommunication>())).Returns(Task.FromResult(new ClientCommunication()));
                        var service = new ClientCommunicationService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ClientCommunicationModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                                     mock.DALMapperMockFactory.DALClientCommunicationMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ClientCommunicationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiClientCommunicationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ClientCommunication>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IClientCommunicationRepository>();
                        var model = new ApiClientCommunicationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ClientCommunicationService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ClientCommunicationModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                                     mock.DALMapperMockFactory.DALClientCommunicationMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ClientCommunicationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>f76acfbb4115990df23740fbfe877dff</Hash>
</Codenesium>*/