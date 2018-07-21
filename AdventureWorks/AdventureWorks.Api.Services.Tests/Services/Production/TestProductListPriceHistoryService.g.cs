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
        [Trait("Table", "ProductListPriceHistory")]
        [Trait("Area", "Services")]
        public partial class ProductListPriceHistoryServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IProductListPriceHistoryRepository>();
                        var records = new List<ProductListPriceHistory>();
                        records.Add(new ProductListPriceHistory());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductListPriceHistoryService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.ProductListPriceHistoryModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
                                                                         mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock);

                        List<ApiProductListPriceHistoryResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IProductListPriceHistoryRepository>();
                        var record = new ProductListPriceHistory();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ProductListPriceHistoryService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.ProductListPriceHistoryModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
                                                                         mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock);

                        ApiProductListPriceHistoryResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IProductListPriceHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductListPriceHistory>(null));
                        var service = new ProductListPriceHistoryService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.ProductListPriceHistoryModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
                                                                         mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock);

                        ApiProductListPriceHistoryResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IProductListPriceHistoryRepository>();
                        var model = new ApiProductListPriceHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductListPriceHistory>())).Returns(Task.FromResult(new ProductListPriceHistory()));
                        var service = new ProductListPriceHistoryService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.ProductListPriceHistoryModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
                                                                         mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock);

                        CreateResponse<ApiProductListPriceHistoryResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductListPriceHistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductListPriceHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductListPriceHistory>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IProductListPriceHistoryRepository>();
                        var model = new ApiProductListPriceHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductListPriceHistory>())).Returns(Task.FromResult(new ProductListPriceHistory()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductListPriceHistory()));
                        var service = new ProductListPriceHistoryService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.ProductListPriceHistoryModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
                                                                         mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock);

                        UpdateResponse<ApiProductListPriceHistoryResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductListPriceHistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductListPriceHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductListPriceHistory>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IProductListPriceHistoryRepository>();
                        var model = new ApiProductListPriceHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ProductListPriceHistoryService(mock.LoggerMock.Object,
                                                                         mock.RepositoryMock.Object,
                                                                         mock.ModelValidatorMockFactory.ProductListPriceHistoryModelValidatorMock.Object,
                                                                         mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
                                                                         mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ProductListPriceHistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>899a26d9353bba433ba01dc1a8163de6</Hash>
</Codenesium>*/