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
	[Trait("Table", "Product")]
	[Trait("Area", "Services")]
	public partial class ProductServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<Product>();
			records.Add(new Product());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var record = new Product();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Product>())).Returns(Task.FromResult(new Product()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			CreateResponse<ApiProductResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Product>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Product>())).Returns(Task.FromResult(new Product()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			UpdateResponse<ApiProductResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Product>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var record = new Product();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductResponseModel response = await service.ByName(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Product>(null));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByProductNumber_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var record = new Product();
			mock.RepositoryMock.Setup(x => x.ByProductNumber(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductResponseModel response = await service.ByProductNumber(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByProductNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void ByProductNumber_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.ByProductNumber(It.IsAny<string>())).Returns(Task.FromResult<Product>(null));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductResponseModel response = await service.ByProductNumber(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByProductNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void BillOfMaterials_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<BillOfMaterial>();
			records.Add(new BillOfMaterial());
			mock.RepositoryMock.Setup(x => x.BillOfMaterials(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiBillOfMaterialResponseModel> response = await service.BillOfMaterials(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterials(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BillOfMaterials_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.BillOfMaterials(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BillOfMaterial>>(new List<BillOfMaterial>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiBillOfMaterialResponseModel> response = await service.BillOfMaterials(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterials(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductCostHistories_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<ProductCostHistory>();
			records.Add(new ProductCostHistory());
			mock.RepositoryMock.Setup(x => x.ProductCostHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductCostHistoryResponseModel> response = await service.ProductCostHistories(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductCostHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductCostHistories_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.ProductCostHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductCostHistory>>(new List<ProductCostHistory>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductCostHistoryResponseModel> response = await service.ProductCostHistories(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductCostHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductInventories_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<ProductInventory>();
			records.Add(new ProductInventory());
			mock.RepositoryMock.Setup(x => x.ProductInventories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductInventoryResponseModel> response = await service.ProductInventories(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductInventories(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductInventories_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.ProductInventories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductInventory>>(new List<ProductInventory>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductInventoryResponseModel> response = await service.ProductInventories(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductInventories(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductListPriceHistories_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<ProductListPriceHistory>();
			records.Add(new ProductListPriceHistory());
			mock.RepositoryMock.Setup(x => x.ProductListPriceHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductListPriceHistoryResponseModel> response = await service.ProductListPriceHistories(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductListPriceHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductListPriceHistories_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.ProductListPriceHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductListPriceHistory>>(new List<ProductListPriceHistory>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductListPriceHistoryResponseModel> response = await service.ProductListPriceHistories(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductListPriceHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductProductPhotoes_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<ProductProductPhoto>();
			records.Add(new ProductProductPhoto());
			mock.RepositoryMock.Setup(x => x.ProductProductPhotoes(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductProductPhotoResponseModel> response = await service.ProductProductPhotoes(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductProductPhotoes(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductProductPhotoes_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.ProductProductPhotoes(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductProductPhoto>>(new List<ProductProductPhoto>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductProductPhotoResponseModel> response = await service.ProductProductPhotoes(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductProductPhotoes(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductReviews_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<ProductReview>();
			records.Add(new ProductReview());
			mock.RepositoryMock.Setup(x => x.ProductReviews(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductReviewResponseModel> response = await service.ProductReviews(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductReviews(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductReviews_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.ProductReviews(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductReview>>(new List<ProductReview>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductReviewResponseModel> response = await service.ProductReviews(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductReviews(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TransactionHistories_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<TransactionHistory>();
			records.Add(new TransactionHistory());
			mock.RepositoryMock.Setup(x => x.TransactionHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiTransactionHistoryResponseModel> response = await service.TransactionHistories(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TransactionHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TransactionHistories_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.TransactionHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TransactionHistory>>(new List<TransactionHistory>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiTransactionHistoryResponseModel> response = await service.TransactionHistories(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TransactionHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void WorkOrders_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<WorkOrder>();
			records.Add(new WorkOrder());
			mock.RepositoryMock.Setup(x => x.WorkOrders(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderResponseModel> response = await service.WorkOrders(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.WorkOrders(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void WorkOrders_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.WorkOrders(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<WorkOrder>>(new List<WorkOrder>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductCostHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductCostHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductInventoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductListPriceHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALProductListPriceHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderResponseModel> response = await service.WorkOrders(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.WorkOrders(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>f77582f26260fb36e412e9cc02b393e9</Hash>
</Codenesium>*/