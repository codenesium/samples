using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var record = new Product();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Product>())).Returns(Task.FromResult(new Product()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			CreateResponse<ApiProductServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Product>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductServerRequestModel();
			var validatorMock = new Mock<IApiProductServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			CreateResponse<ApiProductServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Product>())).Returns(Task.FromResult(new Product()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			UpdateResponse<ApiProductServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Product>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductServerRequestModel();
			var validatorMock = new Mock<IApiProductServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			UpdateResponse<ApiProductServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var model = new ApiProductServerRequestModel();
			var validatorMock = new Mock<IApiProductServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var record = new Product();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiProductServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void BillOfMaterialsByComponentID_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<BillOfMaterial>();
			records.Add(new BillOfMaterial());
			mock.RepositoryMock.Setup(x => x.BillOfMaterialsByComponentID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiBillOfMaterialServerResponseModel> response = await service.BillOfMaterialsByComponentID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterialsByComponentID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BillOfMaterialsByProductAssemblyID_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<BillOfMaterial>();
			records.Add(new BillOfMaterial());
			mock.RepositoryMock.Setup(x => x.BillOfMaterialsByProductAssemblyID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiBillOfMaterialServerResponseModel> response = await service.BillOfMaterialsByProductAssemblyID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterialsByProductAssemblyID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductProductPhotoesByProductID_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<ProductProductPhoto>();
			records.Add(new ProductProductPhoto());
			mock.RepositoryMock.Setup(x => x.ProductProductPhotoesByProductID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductProductPhotoServerResponseModel> response = await service.ProductProductPhotoesByProductID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductProductPhotoesByProductID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductProductPhotoesByProductID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			mock.RepositoryMock.Setup(x => x.ProductProductPhotoesByProductID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductProductPhoto>>(new List<ProductProductPhoto>()));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiProductProductPhotoServerResponseModel> response = await service.ProductProductPhotoesByProductID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductProductPhotoesByProductID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductReviewsByProductID_Exists()
		{
			var mock = new ServiceMockFacade<IProductRepository>();
			var records = new List<ProductReview>();
			records.Add(new ProductReview());
			mock.RepositoryMock.Setup(x => x.ProductReviewsByProductID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
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
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProductModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALProductMapperMock,
			                                 mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                 mock.DALMapperMockFactory.DALProductProductPhotoMapperMock,
			                                 mock.DALMapperMockFactory.DALProductReviewMapperMock,
			                                 mock.DALMapperMockFactory.DALTransactionHistoryMapperMock,
			                                 mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderServerResponseModel> response = await service.WorkOrdersByProductID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.WorkOrdersByProductID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>0672b13f78cc1efe04e0c9293b345710</Hash>
</Codenesium>*/