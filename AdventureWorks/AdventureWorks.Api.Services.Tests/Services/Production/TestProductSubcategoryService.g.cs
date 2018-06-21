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
        [Trait("Table", "ProductSubcategory")]
        [Trait("Area", "Services")]
        public partial class ProductSubcategoryServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
                        var records = new List<ProductSubcategory>();
                        records.Add(new ProductSubcategory());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductSubcategoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
                                                                    mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductMapperMock);

                        List<ApiProductSubcategoryResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
                        var record = new ProductSubcategory();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ProductSubcategoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
                                                                    mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductMapperMock);

                        ApiProductSubcategoryResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductSubcategory>(null));
                        var service = new ProductSubcategoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
                                                                    mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductMapperMock);

                        ApiProductSubcategoryResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
                        var model = new ApiProductSubcategoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductSubcategory>())).Returns(Task.FromResult(new ProductSubcategory()));
                        var service = new ProductSubcategoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
                                                                    mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductMapperMock);

                        CreateResponse<ApiProductSubcategoryResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductSubcategoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductSubcategory>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
                        var model = new ApiProductSubcategoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductSubcategory>())).Returns(Task.FromResult(new ProductSubcategory()));
                        var service = new ProductSubcategoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
                                                                    mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductSubcategory>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
                        var model = new ApiProductSubcategoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ProductSubcategoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
                                                                    mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
                        var record = new ProductSubcategory();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ProductSubcategoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
                                                                    mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductMapperMock);

                        ApiProductSubcategoryResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductSubcategory>(null));
                        var service = new ProductSubcategoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
                                                                    mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductMapperMock);

                        ApiProductSubcategoryResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void Products_Exists()
                {
                        var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
                        var records = new List<Product>();
                        records.Add(new Product());
                        mock.RepositoryMock.Setup(x => x.Products(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductSubcategoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
                                                                    mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductMapperMock);

                        List<ApiProductResponseModel> response = await service.Products(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Products(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Products_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
                        mock.RepositoryMock.Setup(x => x.Products(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Product>>(new List<Product>()));
                        var service = new ProductSubcategoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
                                                                    mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                                    mock.DALMapperMockFactory.DALProductMapperMock);

                        List<ApiProductResponseModel> response = await service.Products(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Products(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>51a344c58f5c9f987a76439e840e87f5</Hash>
</Codenesium>*/