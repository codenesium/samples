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
        [Trait("Table", "ShoppingCartItem")]
        [Trait("Area", "Services")]
        public partial class ShoppingCartItemServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
                        var records = new List<ShoppingCartItem>();
                        records.Add(new ShoppingCartItem());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ShoppingCartItemService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
                                                                  mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

                        List<ApiShoppingCartItemResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
                        var record = new ShoppingCartItem();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ShoppingCartItemService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
                                                                  mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

                        ApiShoppingCartItemResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ShoppingCartItem>(null));
                        var service = new ShoppingCartItemService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
                                                                  mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

                        ApiShoppingCartItemResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
                        var model = new ApiShoppingCartItemRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ShoppingCartItem>())).Returns(Task.FromResult(new ShoppingCartItem()));
                        var service = new ShoppingCartItemService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
                                                                  mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

                        CreateResponse<ApiShoppingCartItemResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiShoppingCartItemRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ShoppingCartItem>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
                        var model = new ApiShoppingCartItemRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ShoppingCartItem>())).Returns(Task.FromResult(new ShoppingCartItem()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShoppingCartItem()));
                        var service = new ShoppingCartItemService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
                                                                  mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

                        UpdateResponse<ApiShoppingCartItemResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ShoppingCartItem>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
                        var model = new ApiShoppingCartItemRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ShoppingCartItemService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
                                                                  mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByShoppingCartIDProductID_Exists()
                {
                        var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
                        var records = new List<ShoppingCartItem>();
                        records.Add(new ShoppingCartItem());
                        mock.RepositoryMock.Setup(x => x.ByShoppingCartIDProductID(It.IsAny<string>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ShoppingCartItemService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
                                                                  mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

                        List<ApiShoppingCartItemResponseModel> response = await service.ByShoppingCartIDProductID(default(string), default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByShoppingCartIDProductID(It.IsAny<string>(), It.IsAny<int>()));
                }

                [Fact]
                public async void ByShoppingCartIDProductID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
                        mock.RepositoryMock.Setup(x => x.ByShoppingCartIDProductID(It.IsAny<string>(), It.IsAny<int>())).Returns(Task.FromResult<List<ShoppingCartItem>>(new List<ShoppingCartItem>()));
                        var service = new ShoppingCartItemService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
                                                                  mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

                        List<ApiShoppingCartItemResponseModel> response = await service.ByShoppingCartIDProductID(default(string), default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByShoppingCartIDProductID(It.IsAny<string>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>5b2728dc1a190dfffeb9c3cdee8285c8</Hash>
</Codenesium>*/