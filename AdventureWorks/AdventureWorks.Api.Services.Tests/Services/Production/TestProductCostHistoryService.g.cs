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
        [Trait("Table", "ProductCostHistory")]
        [Trait("Area", "Services")]
        public partial class ProductCostHistoryServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IProductCostHistoryRepository>();
                        var records = new List<ProductCostHistory>();
                        records.Add(new ProductCostHistory());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductCostHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductCostHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductCostHistoryMapperMock);

                        List<ApiProductCostHistoryResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IProductCostHistoryRepository>();
                        var record = new ProductCostHistory();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ProductCostHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductCostHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductCostHistoryMapperMock);

                        ApiProductCostHistoryResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IProductCostHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductCostHistory>(null));
                        var service = new ProductCostHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductCostHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductCostHistoryMapperMock);

                        ApiProductCostHistoryResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IProductCostHistoryRepository>();
                        var model = new ApiProductCostHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductCostHistory>())).Returns(Task.FromResult(new ProductCostHistory()));
                        var service = new ProductCostHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductCostHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductCostHistoryMapperMock);

                        CreateResponse<ApiProductCostHistoryResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductCostHistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductCostHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductCostHistory>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IProductCostHistoryRepository>();
                        var model = new ApiProductCostHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductCostHistory>())).Returns(Task.FromResult(new ProductCostHistory()));
                        var service = new ProductCostHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductCostHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductCostHistoryMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductCostHistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductCostHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductCostHistory>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IProductCostHistoryRepository>();
                        var model = new ApiProductCostHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ProductCostHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductCostHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductCostHistoryMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ProductCostHistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>a8ae2edfb8e44c336f04b6143979824d</Hash>
</Codenesium>*/