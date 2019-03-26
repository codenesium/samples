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
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "Services")]
	public partial class ProductPhotoServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var records = new List<ProductPhoto>();
			records.Add(new ProductPhoto());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			List<ApiProductPhotoServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var record = new ProductPhoto();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			ApiProductPhotoServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductPhoto>(null));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			ApiProductPhotoServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var model = new ApiProductPhotoServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductPhoto>())).Returns(Task.FromResult(new ProductPhoto()));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			CreateResponse<ApiProductPhotoServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductPhotoServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductPhoto>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductPhotoCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var model = new ApiProductPhotoServerRequestModel();
			var validatorMock = new Mock<IApiProductPhotoServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductPhotoServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			CreateResponse<ApiProductPhotoServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductPhotoServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductPhotoCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var model = new ApiProductPhotoServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductPhoto>())).Returns(Task.FromResult(new ProductPhoto()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductPhoto()));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			UpdateResponse<ApiProductPhotoServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductPhotoServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductPhoto>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductPhotoUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var model = new ApiProductPhotoServerRequestModel();
			var validatorMock = new Mock<IApiProductPhotoServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductPhotoServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductPhoto()));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			UpdateResponse<ApiProductPhotoServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductPhotoServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductPhotoUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var model = new ApiProductPhotoServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductPhotoDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var model = new ApiProductPhotoServerRequestModel();
			var validatorMock = new Mock<IApiProductPhotoServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductPhotoDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ProductProductPhotoesByProductPhotoID_Exists()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var records = new List<ProductProductPhoto>();
			records.Add(new ProductProductPhoto());
			mock.RepositoryMock.Setup(x => x.ProductProductPhotoesByProductPhotoID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			List<ApiProductProductPhotoServerResponseModel> response = await service.ProductProductPhotoesByProductPhotoID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductProductPhotoesByProductPhotoID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductProductPhotoesByProductPhotoID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			mock.RepositoryMock.Setup(x => x.ProductProductPhotoesByProductPhotoID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductProductPhoto>>(new List<ProductProductPhoto>()));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			List<ApiProductProductPhotoServerResponseModel> response = await service.ProductProductPhotoesByProductPhotoID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductProductPhotoesByProductPhotoID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b9d145a208f917771ba7f34689ba4359</Hash>
</Codenesium>*/