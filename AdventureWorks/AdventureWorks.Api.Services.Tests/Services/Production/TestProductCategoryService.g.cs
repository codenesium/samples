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
	[Trait("Table", "ProductCategory")]
	[Trait("Area", "Services")]
	public partial class ProductCategoryServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var records = new List<ProductCategory>();
			records.Add(new ProductCategory());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			List<ApiProductCategoryServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var record = new ProductCategory();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			ApiProductCategoryServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductCategory>(null));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			ApiProductCategoryServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var model = new ApiProductCategoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductCategory>())).Returns(Task.FromResult(new ProductCategory()));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			CreateResponse<ApiProductCategoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductCategoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductCategory>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var model = new ApiProductCategoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductCategory>())).Returns(Task.FromResult(new ProductCategory()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductCategory()));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			UpdateResponse<ApiProductCategoryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductCategory>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var model = new ApiProductCategoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var record = new ProductCategory();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			ApiProductCategoryServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductCategory>(null));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			ApiProductCategoryServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var record = new ProductCategory();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			ApiProductCategoryServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<ProductCategory>(null));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			ApiProductCategoryServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ProductSubcategoriesByProductCategoryID_Exists()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var records = new List<ProductSubcategory>();
			records.Add(new ProductSubcategory());
			mock.RepositoryMock.Setup(x => x.ProductSubcategoriesByProductCategoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			List<ApiProductSubcategoryServerResponseModel> response = await service.ProductSubcategoriesByProductCategoryID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductSubcategoriesByProductCategoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductSubcategoriesByProductCategoryID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			mock.RepositoryMock.Setup(x => x.ProductSubcategoriesByProductCategoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductSubcategory>>(new List<ProductSubcategory>()));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.BOLMapperMockFactory.BOLProductSubcategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			List<ApiProductSubcategoryServerResponseModel> response = await service.ProductSubcategoriesByProductCategoryID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductSubcategoriesByProductCategoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8e4650547c202b29d8979d380a12a4a9</Hash>
</Codenesium>*/