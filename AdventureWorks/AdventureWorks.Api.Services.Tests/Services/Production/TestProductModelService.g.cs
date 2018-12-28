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
	[Trait("Table", "ProductModel")]
	[Trait("Area", "Services")]
	public partial class ProductModelServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var records = new List<ProductModel>();
			records.Add(new ProductModel());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductModelServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var record = new ProductModel();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductModelServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductModel>(null));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductModelServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var model = new ApiProductModelServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductModel>())).Returns(Task.FromResult(new ProductModel()));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			CreateResponse<ApiProductModelServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductModelServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductModelCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var model = new ApiProductModelServerRequestModel();
			var validatorMock = new Mock<IApiProductModelServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductModelServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			CreateResponse<ApiProductModelServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductModelServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductModelCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var model = new ApiProductModelServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductModel>())).Returns(Task.FromResult(new ProductModel()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModel()));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			UpdateResponse<ApiProductModelServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductModelServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductModelUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var model = new ApiProductModelServerRequestModel();
			var validatorMock = new Mock<IApiProductModelServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductModelServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModel()));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			UpdateResponse<ApiProductModelServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductModelServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductModelUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var model = new ApiProductModelServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductModelDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var model = new ApiProductModelServerRequestModel();
			var validatorMock = new Mock<IApiProductModelServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductModelDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var record = new ProductModel();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductModelServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductModel>(null));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductModelServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var record = new ProductModel();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductModelServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<ProductModel>(null));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			ApiProductModelServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByCatalogDescription_Exists()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var records = new List<ProductModel>();
			records.Add(new ProductModel());
			mock.RepositoryMock.Setup(x => x.ByCatalogDescription(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductModelServerResponseModel> response = await service.ByCatalogDescription("test_value");

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCatalogDescription(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByCatalogDescription_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			mock.RepositoryMock.Setup(x => x.ByCatalogDescription(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductModel>>(new List<ProductModel>()));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductModelServerResponseModel> response = await service.ByCatalogDescription("test_value");

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCatalogDescription(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByInstruction_Exists()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var records = new List<ProductModel>();
			records.Add(new ProductModel());
			mock.RepositoryMock.Setup(x => x.ByInstruction(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductModelServerResponseModel> response = await service.ByInstruction("test_value");

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByInstruction(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByInstruction_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			mock.RepositoryMock.Setup(x => x.ByInstruction(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductModel>>(new List<ProductModel>()));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductModelServerResponseModel> response = await service.ByInstruction("test_value");

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByInstruction(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductsByProductModelID_Exists()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			var records = new List<Product>();
			records.Add(new Product());
			mock.RepositoryMock.Setup(x => x.ProductsByProductModelID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductServerResponseModel> response = await service.ProductsByProductModelID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductsByProductModelID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductsByProductModelID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductModelRepository>();
			mock.RepositoryMock.Setup(x => x.ProductsByProductModelID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Product>>(new List<Product>()));
			var service = new ProductModelService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductModelModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductModelMapperMock,
			                                      mock.DALMapperMockFactory.DALProductModelMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                      mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductServerResponseModel> response = await service.ProductsByProductModelID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductsByProductModelID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>e834bbce72377995ec98f48d5a9c5c49</Hash>
</Codenesium>*/