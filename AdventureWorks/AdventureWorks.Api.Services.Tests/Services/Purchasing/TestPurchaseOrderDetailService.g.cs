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
        [Trait("Table", "PurchaseOrderDetail")]
        [Trait("Area", "Services")]
        public partial class PurchaseOrderDetailServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IPurchaseOrderDetailRepository>();
                        var records = new List<PurchaseOrderDetail>();
                        records.Add(new PurchaseOrderDetail());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PurchaseOrderDetailService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.PurchaseOrderDetailModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

                        List<ApiPurchaseOrderDetailResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IPurchaseOrderDetailRepository>();
                        var record = new PurchaseOrderDetail();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new PurchaseOrderDetailService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.PurchaseOrderDetailModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

                        ApiPurchaseOrderDetailResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IPurchaseOrderDetailRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PurchaseOrderDetail>(null));
                        var service = new PurchaseOrderDetailService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.PurchaseOrderDetailModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

                        ApiPurchaseOrderDetailResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IPurchaseOrderDetailRepository>();
                        var model = new ApiPurchaseOrderDetailRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PurchaseOrderDetail>())).Returns(Task.FromResult(new PurchaseOrderDetail()));
                        var service = new PurchaseOrderDetailService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.PurchaseOrderDetailModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

                        CreateResponse<ApiPurchaseOrderDetailResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PurchaseOrderDetailModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPurchaseOrderDetailRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PurchaseOrderDetail>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IPurchaseOrderDetailRepository>();
                        var model = new ApiPurchaseOrderDetailRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PurchaseOrderDetail>())).Returns(Task.FromResult(new PurchaseOrderDetail()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PurchaseOrderDetail()));
                        var service = new PurchaseOrderDetailService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.PurchaseOrderDetailModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

                        UpdateResponse<ApiPurchaseOrderDetailResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PurchaseOrderDetailModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderDetailRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PurchaseOrderDetail>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IPurchaseOrderDetailRepository>();
                        var model = new ApiPurchaseOrderDetailRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new PurchaseOrderDetailService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.PurchaseOrderDetailModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.PurchaseOrderDetailModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductID_Exists()
                {
                        var mock = new ServiceMockFacade<IPurchaseOrderDetailRepository>();
                        var records = new List<PurchaseOrderDetail>();
                        records.Add(new PurchaseOrderDetail());
                        mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PurchaseOrderDetailService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.PurchaseOrderDetailModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

                        List<ApiPurchaseOrderDetailResponseModel> response = await service.ByProductID(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IPurchaseOrderDetailRepository>();
                        mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult<List<PurchaseOrderDetail>>(new List<PurchaseOrderDetail>()));
                        var service = new PurchaseOrderDetailService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.PurchaseOrderDetailModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

                        List<ApiPurchaseOrderDetailResponseModel> response = await service.ByProductID(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>c9a85cc09c2ff0b3e19b59e922b336cf</Hash>
</Codenesium>*/