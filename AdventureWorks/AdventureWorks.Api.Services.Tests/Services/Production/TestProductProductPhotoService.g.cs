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
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "Services")]
	public partial class ProductProductPhotoServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
			var records = new List<ProductProductPhoto>();
			records.Add(new ProductProductPhoto());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ProductProductPhotoService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			List<ApiProductProductPhotoServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
			var record = new ProductProductPhoto();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductProductPhotoService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			ApiProductProductPhotoServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductProductPhoto>(null));
			var service = new ProductProductPhotoService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			ApiProductProductPhotoServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
			var model = new ApiProductProductPhotoServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductProductPhoto>())).Returns(Task.FromResult(new ProductProductPhoto()));
			var service = new ProductProductPhotoService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			CreateResponse<ApiProductProductPhotoServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductProductPhotoServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductProductPhoto>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductProductPhotoCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
			var model = new ApiProductProductPhotoServerRequestModel();
			var validatorMock = new Mock<IApiProductProductPhotoServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProductProductPhotoServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductProductPhotoService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			CreateResponse<ApiProductProductPhotoServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductProductPhotoServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductProductPhotoCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
			var model = new ApiProductProductPhotoServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductProductPhoto>())).Returns(Task.FromResult(new ProductProductPhoto()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductProductPhoto()));
			var service = new ProductProductPhotoService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			UpdateResponse<ApiProductProductPhotoServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductProductPhoto>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductProductPhotoUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
			var model = new ApiProductProductPhotoServerRequestModel();
			var validatorMock = new Mock<IApiProductProductPhotoServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductProductPhoto()));
			var service = new ProductProductPhotoService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			UpdateResponse<ApiProductProductPhotoServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductProductPhotoUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
			var model = new ApiProductProductPhotoServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductProductPhotoService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductProductPhotoModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductProductPhotoDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IProductProductPhotoRepository>();
			var model = new ApiProductProductPhotoServerRequestModel();
			var validatorMock = new Mock<IApiProductProductPhotoServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProductProductPhotoService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProductProductPhotoDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>dd71dbbafc53e6fcdad6e1bfe47606fb</Hash>
</Codenesium>*/