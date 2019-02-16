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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			List<ApiProductCategoryServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var record = new ProductCategory();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
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
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			ApiProductCategoryServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var model = new ApiProductCategoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductCategory>())).Returns(Task.FromResult(new ProductCategory()));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			CreateResponse<ApiProductCategoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductCategoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductCategory>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductCategoryCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var model = new ApiProductCategoryServerRequestModel();
			var validatorMock = new Mock<IApiProductCategoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductCategoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			CreateResponse<ApiProductCategoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductCategoryServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductCategoryCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var model = new ApiProductCategoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductCategory>())).Returns(Task.FromResult(new ProductCategory()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductCategory()));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			UpdateResponse<ApiProductCategoryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductCategory>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductCategoryUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var model = new ApiProductCategoryServerRequestModel();
			var validatorMock = new Mock<IApiProductCategoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductCategory()));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			UpdateResponse<ApiProductCategoryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductCategoryUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var model = new ApiProductCategoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductCategoryDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var model = new ApiProductCategoryServerRequestModel();
			var validatorMock = new Mock<IApiProductCategoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductCategoryDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IProductCategoryRepository>();
			var record = new ProductCategory();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProductCategoryService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
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
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
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
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
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
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
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
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
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
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.ProductCategoryModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALProductCategoryMapperMock,
			                                         mock.DALMapperMockFactory.DALProductSubcategoryMapperMock);

			List<ApiProductSubcategoryServerResponseModel> response = await service.ProductSubcategoriesByProductCategoryID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductSubcategoriesByProductCategoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>5da681cd9195ad8b5ffe28aab0890e36</Hash>
</Codenesium>*/