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
	[Trait("Table", "ProductInventory")]
	[Trait("Area", "Services")]
	public partial class ProductInventoryServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductInventoryRepository>();
			var records = new List<ProductInventory>();
			records.Add(new ProductInventory());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductInventoryService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ProductInventoryModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock);

			List<ApiProductInventoryResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductInventoryRepository>();
			var record = new ProductInventory();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductInventoryService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ProductInventoryModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock);

			ApiProductInventoryResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductInventoryRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductInventory>(null));
			var service = new ProductInventoryService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ProductInventoryModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock);

			ApiProductInventoryResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IProductInventoryRepository>();
			var model = new ApiProductInventoryRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductInventory>())).Returns(Task.FromResult(new ProductInventory()));
			var service = new ProductInventoryService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ProductInventoryModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock);

			CreateResponse<ApiProductInventoryResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductInventoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductInventoryRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductInventory>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IProductInventoryRepository>();
			var model = new ApiProductInventoryRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductInventory>())).Returns(Task.FromResult(new ProductInventory()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductInventory()));
			var service = new ProductInventoryService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ProductInventoryModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock);

			UpdateResponse<ApiProductInventoryResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductInventoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductInventoryRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductInventory>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IProductInventoryRepository>();
			var model = new ApiProductInventoryRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductInventoryService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ProductInventoryModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductInventoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>5db80f957385cc52e7260e31f4aea68d</Hash>
</Codenesium>*/