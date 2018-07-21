using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ShipMethod")]
        [Trait("Area", "Services")]
        public partial class ShipMethodServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IShipMethodRepository>();
                        var records = new List<ShipMethod>();
                        records.Add(new ShipMethod());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ShipMethodService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
                                                            mock.DALMapperMockFactory.DALShipMethodMapperMock,
                                                            mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
                                                            mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

                        List<ApiShipMethodResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IShipMethodRepository>();
                        var record = new ShipMethod();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ShipMethodService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
                                                            mock.DALMapperMockFactory.DALShipMethodMapperMock,
                                                            mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
                                                            mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

                        ApiShipMethodResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IShipMethodRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ShipMethod>(null));
                        var service = new ShipMethodService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
                                                            mock.DALMapperMockFactory.DALShipMethodMapperMock,
                                                            mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
                                                            mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

                        ApiShipMethodResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IShipMethodRepository>();
                        var model = new ApiShipMethodRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ShipMethod>())).Returns(Task.FromResult(new ShipMethod()));
                        var service = new ShipMethodService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
                                                            mock.DALMapperMockFactory.DALShipMethodMapperMock,
                                                            mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
                                                            mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

                        CreateResponse<ApiShipMethodResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiShipMethodRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ShipMethod>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IShipMethodRepository>();
                        var model = new ApiShipMethodRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ShipMethod>())).Returns(Task.FromResult(new ShipMethod()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));
                        var service = new ShipMethodService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
                                                            mock.DALMapperMockFactory.DALShipMethodMapperMock,
                                                            mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
                                                            mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

                        UpdateResponse<ApiShipMethodResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShipMethodRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ShipMethod>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IShipMethodRepository>();
                        var model = new ApiShipMethodRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ShipMethodService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
                                                            mock.DALMapperMockFactory.DALShipMethodMapperMock,
                                                            mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
                                                            mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IShipMethodRepository>();
                        var record = new ShipMethod();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ShipMethodService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
                                                            mock.DALMapperMockFactory.DALShipMethodMapperMock,
                                                            mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
                                                            mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

                        ApiShipMethodResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IShipMethodRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ShipMethod>(null));
                        var service = new ShipMethodService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
                                                            mock.DALMapperMockFactory.DALShipMethodMapperMock,
                                                            mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
                                                            mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

                        ApiShipMethodResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void PurchaseOrderHeaders_Exists()
                {
                        var mock = new ServiceMockFacade<IShipMethodRepository>();
                        var records = new List<PurchaseOrderHeader>();
                        records.Add(new PurchaseOrderHeader());
                        mock.RepositoryMock.Setup(x => x.PurchaseOrderHeaders(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ShipMethodService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
                                                            mock.DALMapperMockFactory.DALShipMethodMapperMock,
                                                            mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
                                                            mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

                        List<ApiPurchaseOrderHeaderResponseModel> response = await service.PurchaseOrderHeaders(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.PurchaseOrderHeaders(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void PurchaseOrderHeaders_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IShipMethodRepository>();
                        mock.RepositoryMock.Setup(x => x.PurchaseOrderHeaders(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PurchaseOrderHeader>>(new List<PurchaseOrderHeader>()));
                        var service = new ShipMethodService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
                                                            mock.DALMapperMockFactory.DALShipMethodMapperMock,
                                                            mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
                                                            mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

                        List<ApiPurchaseOrderHeaderResponseModel> response = await service.PurchaseOrderHeaders(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.PurchaseOrderHeaders(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>bd3c0e0ee83bc7c8aaf5ac0b7ad0a895</Hash>
</Codenesium>*/