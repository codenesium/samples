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
	[Trait("Table", "ProductSubcategory")]
	[Trait("Area", "Services")]
	public partial class ProductSubcategoryServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			var records = new List<ProductSubcategory>();
			records.Add(new ProductSubcategory());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductSubcategoryServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			var record = new ProductSubcategory();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductSubcategoryServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductSubcategory>(null));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductSubcategoryServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			var model = new ApiProductSubcategoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductSubcategory>())).Returns(Task.FromResult(new ProductSubcategory()));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			CreateResponse<ApiProductSubcategoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductSubcategoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductSubcategory>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductSubcategoryCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			var model = new ApiProductSubcategoryServerRequestModel();
			var validatorMock = new Mock<IApiProductSubcategoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductSubcategoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			CreateResponse<ApiProductSubcategoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductSubcategoryServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductSubcategoryCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			var model = new ApiProductSubcategoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductSubcategory>())).Returns(Task.FromResult(new ProductSubcategory()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductSubcategory()));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			UpdateResponse<ApiProductSubcategoryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductSubcategory>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductSubcategoryUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			var model = new ApiProductSubcategoryServerRequestModel();
			var validatorMock = new Mock<IApiProductSubcategoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductSubcategory()));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			UpdateResponse<ApiProductSubcategoryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductSubcategoryUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			var model = new ApiProductSubcategoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductSubcategoryDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			var model = new ApiProductSubcategoryServerRequestModel();
			var validatorMock = new Mock<IApiProductSubcategoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductSubcategoryDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			var record = new ProductSubcategory();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductSubcategoryServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductSubcategory>(null));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductSubcategoryServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			var record = new ProductSubcategory();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductSubcategoryServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<ProductSubcategory>(null));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductSubcategoryServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ProductsByProductSubcategoryID_Exists()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			var records = new List<Product>();
			records.Add(new Product());
			mock.RepositoryMock.Setup(x => x.ProductsByProductSubcategoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductServerResponseModel> response = await service.ProductsByProductSubcategoryID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductsByProductSubcategoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductsByProductSubcategoryID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductSubcategoryRepository>();
			mock.RepositoryMock.Setup(x => x.ProductsByProductSubcategoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Product>>(new List<Product>()));
			var service = new ProductSubcategoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductSubcategoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALProductSubcategoryMapperMock,
			                                            mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductServerResponseModel> response = await service.ProductsByProductSubcategoryID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductsByProductSubcategoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>e079b7487c695cc370caf3916f629370</Hash>
</Codenesium>*/