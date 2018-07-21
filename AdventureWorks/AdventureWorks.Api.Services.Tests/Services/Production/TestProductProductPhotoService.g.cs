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
        [Trait("Table", "ProductProductPhoto")]
        [Trait("Area", "Services")]
        public partial class ProductProductPhotoServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
                        var records = new List<ProductProductPhoto>();
                        records.Add(new ProductProductPhoto());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProductProductPhotoService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
                                                                     mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

                        List<ApiProductProductPhotoResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
                        var record = new ProductProductPhoto();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ProductProductPhotoService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
                                                                     mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

                        ApiProductProductPhotoResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductProductPhoto>(null));
                        var service = new ProductProductPhotoService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
                                                                     mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

                        ApiProductProductPhotoResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
                        var model = new ApiProductProductPhotoRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductProductPhoto>())).Returns(Task.FromResult(new ProductProductPhoto()));
                        var service = new ProductProductPhotoService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
                                                                     mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

                        CreateResponse<ApiProductProductPhotoResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductProductPhotoRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductProductPhoto>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
                        var model = new ApiProductProductPhotoRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductProductPhoto>())).Returns(Task.FromResult(new ProductProductPhoto()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductProductPhoto()));
                        var service = new ProductProductPhotoService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
                                                                     mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

                        UpdateResponse<ApiProductProductPhotoResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductProductPhoto>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
                        var model = new ApiProductProductPhotoRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ProductProductPhotoService(mock.LoggerMock.Object,
                                                                     mock.RepositoryMock.Object,
                                                                     mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
                                                                     mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
                                                                     mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>2bfc473238b3206689673e84d0da38ad</Hash>
</Codenesium>*/