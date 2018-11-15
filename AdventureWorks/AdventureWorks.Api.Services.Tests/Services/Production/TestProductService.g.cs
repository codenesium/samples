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
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductServerResponseModel> response = await service.All();

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
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductServerResponseModel response = await service.Get(default(int));

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
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Product>())).Returns(Task.FromResult(new Product()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			CreateResponse<ApiProductServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Product>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Product>())).Returns(Task.FromResult(new Product()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			UpdateResponse<ApiProductServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Product>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
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
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductServerResponseModel response = await service.ByName("test_value");

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
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductServerResponseModel response = await service.ByName("test_value");

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
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductServerResponseModel response = await service.ByProductNumber("test_value");

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
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductServerResponseModel response = await service.ByProductNumber("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByProductNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var record = new Product();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Product>(null));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void BillOfMaterialsByProductAssemblyID_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<BillOfMaterial>();
			records.Add(new BillOfMaterial());
			mock.RepositoryMock.Setup(x => x.BillOfMaterialsByProductAssemblyID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiBillOfMaterialServerResponseModel> response = await service.BillOfMaterialsByProductAssemblyID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterialsByProductAssemblyID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BillOfMaterialsByProductAssemblyID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.BillOfMaterialsByProductAssemblyID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BillOfMaterial>>(new List<BillOfMaterial>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiBillOfMaterialServerResponseModel> response = await service.BillOfMaterialsByProductAssemblyID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterialsByProductAssemblyID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BillOfMaterialsByComponentID_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<BillOfMaterial>();
			records.Add(new BillOfMaterial());
			mock.RepositoryMock.Setup(x => x.BillOfMaterialsByComponentID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiBillOfMaterialServerResponseModel> response = await service.BillOfMaterialsByComponentID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterialsByComponentID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BillOfMaterialsByComponentID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.BillOfMaterialsByComponentID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BillOfMaterial>>(new List<BillOfMaterial>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiBillOfMaterialServerResponseModel> response = await service.BillOfMaterialsByComponentID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterialsByComponentID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductReviewsByProductID_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<ProductReview>();
			records.Add(new ProductReview());
			mock.RepositoryMock.Setup(x => x.ProductReviewsByProductID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductReviewServerResponseModel> response = await service.ProductReviewsByProductID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductReviewsByProductID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductReviewsByProductID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.ProductReviewsByProductID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductReview>>(new List<ProductReview>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductReviewServerResponseModel> response = await service.ProductReviewsByProductID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductReviewsByProductID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TransactionHistoriesByProductID_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<TransactionHistory>();
			records.Add(new TransactionHistory());
			mock.RepositoryMock.Setup(x => x.TransactionHistoriesByProductID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiTransactionHistoryServerResponseModel> response = await service.TransactionHistoriesByProductID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TransactionHistoriesByProductID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TransactionHistoriesByProductID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.TransactionHistoriesByProductID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TransactionHistory>>(new List<TransactionHistory>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiTransactionHistoryServerResponseModel> response = await service.TransactionHistoriesByProductID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TransactionHistoriesByProductID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void WorkOrdersByProductID_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<WorkOrder>();
			records.Add(new WorkOrder());
			mock.RepositoryMock.Setup(x => x.WorkOrdersByProductID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderServerResponseModel> response = await service.WorkOrdersByProductID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.WorkOrdersByProductID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void WorkOrdersByProductID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.WorkOrdersByProductID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<WorkOrder>>(new List<WorkOrder>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderServerResponseModel> response = await service.WorkOrdersByProductID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.WorkOrdersByProductID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b488eda694d32bf4ee7850299fc36260</Hash>
</Codenesium>*/