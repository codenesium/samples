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
	[Trait("Table", "ProductDescription")]
	[Trait("Area", "Services")]
	public partial class ProductDescriptionServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var records = new List<ProductDescription>();
			records.Add(new ProductDescription());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			List<ApiProductDescriptionServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var record = new ProductDescription();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			ApiProductDescriptionServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductDescription>(null));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			ApiProductDescriptionServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var model = new ApiProductDescriptionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductDescription>())).Returns(Task.FromResult(new ProductDescription()));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			CreateResponse<ApiProductDescriptionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductDescriptionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductDescription>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductDescriptionCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var model = new ApiProductDescriptionServerRequestModel();
			var validatorMock = new Mock<IApiProductDescriptionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductDescriptionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			CreateResponse<ApiProductDescriptionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductDescriptionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductDescriptionCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var model = new ApiProductDescriptionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductDescription>())).Returns(Task.FromResult(new ProductDescription()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			UpdateResponse<ApiProductDescriptionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductDescription>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductDescriptionUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var model = new ApiProductDescriptionServerRequestModel();
			var validatorMock = new Mock<IApiProductDescriptionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			UpdateResponse<ApiProductDescriptionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductDescriptionUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var model = new ApiProductDescriptionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductDescriptionDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var model = new ApiProductDescriptionServerRequestModel();
			var validatorMock = new Mock<IApiProductDescriptionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductDescriptionDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var record = new ProductDescription();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			ApiProductDescriptionServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<ProductDescription>(null));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			ApiProductDescriptionServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}
	}
}

/*<Codenesium>
    <Hash>44cdb54751cdb8aa28722ced7cfa820b</Hash>
</Codenesium>*/