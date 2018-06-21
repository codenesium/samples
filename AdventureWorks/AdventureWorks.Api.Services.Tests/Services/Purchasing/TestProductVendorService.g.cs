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
        [Trait("Table", "ProductVendor")]
        [Trait("Area", "Services")]
        public partial class ProductVendorServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IProductVendorRepository>();
                        var records = new List<ProductVendor>();
                        records.Add(new ProductVendor());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductVendorService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLProductVendorMapperMock,
                                                               mock.DALMapperMockFactory.DALProductVendorMapperMock);

                        List<ApiProductVendorResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IProductVendorRepository>();
                        var record = new ProductVendor();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ProductVendorService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLProductVendorMapperMock,
                                                               mock.DALMapperMockFactory.DALProductVendorMapperMock);

                        ApiProductVendorResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IProductVendorRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductVendor>(null));
                        var service = new ProductVendorService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLProductVendorMapperMock,
                                                               mock.DALMapperMockFactory.DALProductVendorMapperMock);

                        ApiProductVendorResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IProductVendorRepository>();
                        var model = new ApiProductVendorRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductVendor>())).Returns(Task.FromResult(new ProductVendor()));
                        var service = new ProductVendorService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLProductVendorMapperMock,
                                                               mock.DALMapperMockFactory.DALProductVendorMapperMock);

                        CreateResponse<ApiProductVendorResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductVendorRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductVendor>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IProductVendorRepository>();
                        var model = new ApiProductVendorRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductVendor>())).Returns(Task.FromResult(new ProductVendor()));
                        var service = new ProductVendorService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLProductVendorMapperMock,
                                                               mock.DALMapperMockFactory.DALProductVendorMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductVendorRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductVendor>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IProductVendorRepository>();
                        var model = new ApiProductVendorRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ProductVendorService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLProductVendorMapperMock,
                                                               mock.DALMapperMockFactory.DALProductVendorMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByBusinessEntityID_Exists()
                {
                        var mock = new ServiceMockFacade<IProductVendorRepository>();
                        var records = new List<ProductVendor>();
                        records.Add(new ProductVendor());
                        mock.RepositoryMock.Setup(x => x.ByBusinessEntityID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductVendorService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLProductVendorMapperMock,
                                                               mock.DALMapperMockFactory.DALProductVendorMapperMock);

                        List<ApiProductVendorResponseModel> response = await service.ByBusinessEntityID(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByBusinessEntityID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByBusinessEntityID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProductVendorRepository>();
                        mock.RepositoryMock.Setup(x => x.ByBusinessEntityID(It.IsAny<int>())).Returns(Task.FromResult<List<ProductVendor>>(new List<ProductVendor>()));
                        var service = new ProductVendorService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLProductVendorMapperMock,
                                                               mock.DALMapperMockFactory.DALProductVendorMapperMock);

                        List<ApiProductVendorResponseModel> response = await service.ByBusinessEntityID(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByBusinessEntityID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByUnitMeasureCode_Exists()
                {
                        var mock = new ServiceMockFacade<IProductVendorRepository>();
                        var records = new List<ProductVendor>();
                        records.Add(new ProductVendor());
                        mock.RepositoryMock.Setup(x => x.ByUnitMeasureCode(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new ProductVendorService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLProductVendorMapperMock,
                                                               mock.DALMapperMockFactory.DALProductVendorMapperMock);

                        List<ApiProductVendorResponseModel> response = await service.ByUnitMeasureCode(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByUnitMeasureCode(It.IsAny<string>()));
                }

                [Fact]
                public async void ByUnitMeasureCode_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProductVendorRepository>();
                        mock.RepositoryMock.Setup(x => x.ByUnitMeasureCode(It.IsAny<string>())).Returns(Task.FromResult<List<ProductVendor>>(new List<ProductVendor>()));
                        var service = new ProductVendorService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ProductVendorModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLProductVendorMapperMock,
                                                               mock.DALMapperMockFactory.DALProductVendorMapperMock);

                        List<ApiProductVendorResponseModel> response = await service.ByUnitMeasureCode(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByUnitMeasureCode(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>f2eabc592a22e0527f38097aeb0fda12</Hash>
</Codenesium>*/