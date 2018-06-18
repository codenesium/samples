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
        [Trait("Table", "SpecialOfferProduct")]
        [Trait("Area", "Services")]
        public partial class SpecialOfferProductServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
                        var records = new List<SpecialOfferProduct>();
                        records.Add(new SpecialOfferProduct());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SpecialOfferProductService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
                                                                     mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock,
                                                                     mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        List<ApiSpecialOfferProductResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
                        var record = new SpecialOfferProduct();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new SpecialOfferProductService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
                                                                     mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock,
                                                                     mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        ApiSpecialOfferProductResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SpecialOfferProduct>(null));
                        var service = new SpecialOfferProductService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
                                                                     mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock,
                                                                     mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        ApiSpecialOfferProductResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
                        var model = new ApiSpecialOfferProductRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpecialOfferProduct>())).Returns(Task.FromResult(new SpecialOfferProduct()));
                        var service = new SpecialOfferProductService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
                                                                     mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock,
                                                                     mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        CreateResponse<ApiSpecialOfferProductResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpecialOfferProductRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SpecialOfferProduct>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
                        var model = new ApiSpecialOfferProductRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpecialOfferProduct>())).Returns(Task.FromResult(new SpecialOfferProduct()));
                        var service = new SpecialOfferProductService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
                                                                     mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock,
                                                                     mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpecialOfferProductRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SpecialOfferProduct>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
                        var model = new ApiSpecialOfferProductRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new SpecialOfferProductService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
                                                                     mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock,
                                                                     mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductID_Exists()
                {
                        var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
                        var records = new List<SpecialOfferProduct>();
                        records.Add(new SpecialOfferProduct());
                        mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SpecialOfferProductService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
                                                                     mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock,
                                                                     mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        List<ApiSpecialOfferProductResponseModel> response = await service.ByProductID(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
                        mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult<List<SpecialOfferProduct>>(new List<SpecialOfferProduct>()));
                        var service = new SpecialOfferProductService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
                                                                     mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock,
                                                                     mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        List<ApiSpecialOfferProductResponseModel> response = await service.ByProductID(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
                }

                [Fact]
                public async void SalesOrderDetails_Exists()
                {
                        var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
                        var records = new List<SalesOrderDetail>();
                        records.Add(new SalesOrderDetail());
                        mock.RepositoryMock.Setup(x => x.SalesOrderDetails(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SpecialOfferProductService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
                                                                     mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock,
                                                                     mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        List<ApiSalesOrderDetailResponseModel> response = await service.SalesOrderDetails(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesOrderDetails(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SalesOrderDetails_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
                        mock.RepositoryMock.Setup(x => x.SalesOrderDetails(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderDetail>>(new List<SalesOrderDetail>()));
                        var service = new SpecialOfferProductService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
                                                                     mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock,
                                                                     mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                     mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        List<ApiSalesOrderDetailResponseModel> response = await service.SalesOrderDetails(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesOrderDetails(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>de1ddc8c61d17c536b9ce45d0f3bb8bc</Hash>
</Codenesium>*/