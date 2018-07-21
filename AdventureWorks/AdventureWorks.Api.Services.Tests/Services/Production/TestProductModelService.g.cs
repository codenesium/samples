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
        [Trait("Table", "ProductModel")]
        [Trait("Area", "Services")]
        public partial class ProductModelServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        var records = new List<ProductModel>();
                        records.Add(new ProductModel());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductModelResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        var record = new ProductModel();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        ApiProductModelResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductModel>(null));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        ApiProductModelResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        var model = new ApiProductModelRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductModel>())).Returns(Task.FromResult(new ProductModel()));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        CreateResponse<ApiProductModelResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductModelRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductModel>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        var model = new ApiProductModelRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductModel>())).Returns(Task.FromResult(new ProductModel()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModel()));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        UpdateResponse<ApiProductModelResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductModelRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductModel>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        var model = new ApiProductModelRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        var record = new ProductModel();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        ApiProductModelResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductModel>(null));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        ApiProductModelResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByCatalogDescription_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        var records = new List<ProductModel>();
                        records.Add(new ProductModel());
                        mock.RepositoryMock.Setup(x => x.ByCatalogDescription(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductModelResponseModel> response = await service.ByCatalogDescription(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByCatalogDescription(It.IsAny<string>()));
                }

                [Fact]
                public async void ByCatalogDescription_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        mock.RepositoryMock.Setup(x => x.ByCatalogDescription(It.IsAny<string>())).Returns(Task.FromResult<List<ProductModel>>(new List<ProductModel>()));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductModelResponseModel> response = await service.ByCatalogDescription(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByCatalogDescription(It.IsAny<string>()));
                }

                [Fact]
                public async void ByInstruction_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        var records = new List<ProductModel>();
                        records.Add(new ProductModel());
                        mock.RepositoryMock.Setup(x => x.ByInstruction(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductModelResponseModel> response = await service.ByInstruction(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByInstruction(It.IsAny<string>()));
                }

                [Fact]
                public async void ByInstruction_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        mock.RepositoryMock.Setup(x => x.ByInstruction(It.IsAny<string>())).Returns(Task.FromResult<List<ProductModel>>(new List<ProductModel>()));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductModelResponseModel> response = await service.ByInstruction(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByInstruction(It.IsAny<string>()));
                }

                [Fact]
                public async void Products_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        var records = new List<Product>();
                        records.Add(new Product());
                        mock.RepositoryMock.Setup(x => x.Products(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductResponseModel> response = await service.Products(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Products(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Products_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        mock.RepositoryMock.Setup(x => x.Products(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Product>>(new List<Product>()));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductResponseModel> response = await service.Products(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Products(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void ProductModelIllustrations_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        var records = new List<ProductModelIllustration>();
                        records.Add(new ProductModelIllustration());
                        mock.RepositoryMock.Setup(x => x.ProductModelIllustrations(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductModelIllustrationResponseModel> response = await service.ProductModelIllustrations(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ProductModelIllustrations(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void ProductModelIllustrations_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        mock.RepositoryMock.Setup(x => x.ProductModelIllustrations(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductModelIllustration>>(new List<ProductModelIllustration>()));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductModelIllustrationResponseModel> response = await service.ProductModelIllustrations(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ProductModelIllustrations(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void ProductModelProductDescriptionCultures_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        var records = new List<ProductModelProductDescriptionCulture>();
                        records.Add(new ProductModelProductDescriptionCulture());
                        mock.RepositoryMock.Setup(x => x.ProductModelProductDescriptionCultures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductModelProductDescriptionCultureResponseModel> response = await service.ProductModelProductDescriptionCultures(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ProductModelProductDescriptionCultures(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void ProductModelProductDescriptionCultures_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProductModelRepository>();
                        mock.RepositoryMock.Setup(x => x.ProductModelProductDescriptionCultures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductModelProductDescriptionCulture>>(new List<ProductModelProductDescriptionCulture>()));
                        var service = new ProductModelService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProductModelMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductMapperMock,
                                                              mock.DALMapperMockFactory.DALProductMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock,
                                                              mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                              mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductModelProductDescriptionCultureResponseModel> response = await service.ProductModelProductDescriptionCultures(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ProductModelProductDescriptionCultures(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>73983497ebba1de7ec9497ca533a3e4a</Hash>
</Codenesium>*/