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
        [Trait("Table", "ProductModelProductDescriptionCulture")]
        [Trait("Area", "Services")]
        public partial class ProductModelProductDescriptionCultureServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IProductModelProductDescriptionCultureRepository>();
                        var records = new List<ProductModelProductDescriptionCulture>();
                        records.Add(new ProductModelProductDescriptionCulture());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductModelProductDescriptionCultureService(mock.LoggerMock.Object,
                                                                                       mock.RepositoryMock.Object,
                                                                                       mock.ModelValidatorMockFactory.ProductModelProductDescriptionCultureModelValidatorMock.Object,
                                                                                       mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                                                       mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        List<ApiProductModelProductDescriptionCultureResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IProductModelProductDescriptionCultureRepository>();
                        var record = new ProductModelProductDescriptionCulture();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ProductModelProductDescriptionCultureService(mock.LoggerMock.Object,
                                                                                       mock.RepositoryMock.Object,
                                                                                       mock.ModelValidatorMockFactory.ProductModelProductDescriptionCultureModelValidatorMock.Object,
                                                                                       mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                                                       mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        ApiProductModelProductDescriptionCultureResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IProductModelProductDescriptionCultureRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductModelProductDescriptionCulture>(null));
                        var service = new ProductModelProductDescriptionCultureService(mock.LoggerMock.Object,
                                                                                       mock.RepositoryMock.Object,
                                                                                       mock.ModelValidatorMockFactory.ProductModelProductDescriptionCultureModelValidatorMock.Object,
                                                                                       mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                                                       mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        ApiProductModelProductDescriptionCultureResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IProductModelProductDescriptionCultureRepository>();
                        var model = new ApiProductModelProductDescriptionCultureRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductModelProductDescriptionCulture>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));
                        var service = new ProductModelProductDescriptionCultureService(mock.LoggerMock.Object,
                                                                                       mock.RepositoryMock.Object,
                                                                                       mock.ModelValidatorMockFactory.ProductModelProductDescriptionCultureModelValidatorMock.Object,
                                                                                       mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                                                       mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        CreateResponse<ApiProductModelProductDescriptionCultureResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductModelProductDescriptionCultureModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductModelProductDescriptionCulture>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IProductModelProductDescriptionCultureRepository>();
                        var model = new ApiProductModelProductDescriptionCultureRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductModelProductDescriptionCulture>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));
                        var service = new ProductModelProductDescriptionCultureService(mock.LoggerMock.Object,
                                                                                       mock.RepositoryMock.Object,
                                                                                       mock.ModelValidatorMockFactory.ProductModelProductDescriptionCultureModelValidatorMock.Object,
                                                                                       mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                                                       mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductModelProductDescriptionCultureModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductModelProductDescriptionCulture>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IProductModelProductDescriptionCultureRepository>();
                        var model = new ApiProductModelProductDescriptionCultureRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ProductModelProductDescriptionCultureService(mock.LoggerMock.Object,
                                                                                       mock.RepositoryMock.Object,
                                                                                       mock.ModelValidatorMockFactory.ProductModelProductDescriptionCultureModelValidatorMock.Object,
                                                                                       mock.BOLMapperMockFactory.BOLProductModelProductDescriptionCultureMapperMock,
                                                                                       mock.DALMapperMockFactory.DALProductModelProductDescriptionCultureMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ProductModelProductDescriptionCultureModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>48acb59cd265b8776c5c242cdf24d7f2</Hash>
</Codenesium>*/