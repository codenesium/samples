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
        [Trait("Table", "Client")]
        [Trait("Area", "Services")]
        public partial class ClientServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        var records = new List<Client>();
                        records.Add(new Client());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        List<ApiClientResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        var record = new Client();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        ApiClientResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Client>(null));
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        ApiClientResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        var model = new ApiClientRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Client>())).Returns(Task.FromResult(new Client()));
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        CreateResponse<ApiClientResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiClientRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Client>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        var model = new ApiClientRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Client>())).Returns(Task.FromResult(new Client()));
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiClientRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Client>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        var model = new ApiClientRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ClientCommunications_Exists()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        var records = new List<ClientCommunication>();
                        records.Add(new ClientCommunication());
                        mock.RepositoryMock.Setup(x => x.ClientCommunications(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        List<ApiClientCommunicationResponseModel> response = await service.ClientCommunications(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ClientCommunications(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void ClientCommunications_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        mock.RepositoryMock.Setup(x => x.ClientCommunications(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ClientCommunication>>(new List<ClientCommunication>()));
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        List<ApiClientCommunicationResponseModel> response = await service.ClientCommunications(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ClientCommunications(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Pets_Exists()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        var records = new List<Pet>();
                        records.Add(new Pet());
                        mock.RepositoryMock.Setup(x => x.Pets(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        List<ApiPetResponseModel> response = await service.Pets(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Pets(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Pets_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        mock.RepositoryMock.Setup(x => x.Pets(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Pet>>(new List<Pet>()));
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        List<ApiPetResponseModel> response = await service.Pets(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Pets(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Sales_Exists()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        var records = new List<Sale>();
                        records.Add(new Sale());
                        mock.RepositoryMock.Setup(x => x.Sales(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        List<ApiSaleResponseModel> response = await service.Sales(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Sales(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Sales_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IClientRepository>();
                        mock.RepositoryMock.Setup(x => x.Sales(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Sale>>(new List<Sale>()));
                        var service = new ClientService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.ClientModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLClientMapperMock,
                                                        mock.DALMapperMockFactory.DALClientMapperMock,
                                                        mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
                                                        mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
                                                        mock.BOLMapperMockFactory.BOLPetMapperMock,
                                                        mock.DALMapperMockFactory.DALPetMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleMapperMock);

                        List<ApiSaleResponseModel> response = await service.Sales(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Sales(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>d64796c7bcd29cb0533d23da96e3e2be</Hash>
</Codenesium>*/