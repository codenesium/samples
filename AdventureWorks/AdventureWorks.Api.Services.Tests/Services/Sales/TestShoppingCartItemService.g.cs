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
	[Trait("Table", "ShoppingCartItem")]
	[Trait("Area", "Services")]
	public partial class ShoppingCartItemServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
			var records = new List<ShoppingCartItem>();
			records.Add(new ShoppingCartItem());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ShoppingCartItemService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
			                                          mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

			List<ApiShoppingCartItemServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
			var record = new ShoppingCartItem();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ShoppingCartItemService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
			                                          mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

			ApiShoppingCartItemServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ShoppingCartItem>(null));
			var service = new ShoppingCartItemService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
			                                          mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

			ApiShoppingCartItemServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
			var model = new ApiShoppingCartItemServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ShoppingCartItem>())).Returns(Task.FromResult(new ShoppingCartItem()));
			var service = new ShoppingCartItemService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
			                                          mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

			CreateResponse<ApiShoppingCartItemServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiShoppingCartItemServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ShoppingCartItem>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ShoppingCartItemCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
			var model = new ApiShoppingCartItemServerRequestModel();
			var validatorMock = new Mock<IApiShoppingCartItemServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiShoppingCartItemServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ShoppingCartItemService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
			                                          mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

			CreateResponse<ApiShoppingCartItemServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiShoppingCartItemServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ShoppingCartItemCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
			var model = new ApiShoppingCartItemServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ShoppingCartItem>())).Returns(Task.FromResult(new ShoppingCartItem()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShoppingCartItem()));
			var service = new ShoppingCartItemService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
			                                          mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

			UpdateResponse<ApiShoppingCartItemServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ShoppingCartItem>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ShoppingCartItemUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
			var model = new ApiShoppingCartItemServerRequestModel();
			var validatorMock = new Mock<IApiShoppingCartItemServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShoppingCartItem()));
			var service = new ShoppingCartItemService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
			                                          mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

			UpdateResponse<ApiShoppingCartItemServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ShoppingCartItemUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
			var model = new ApiShoppingCartItemServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ShoppingCartItemService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
			                                          mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ShoppingCartItemDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
			var model = new ApiShoppingCartItemServerRequestModel();
			var validatorMock = new Mock<IApiShoppingCartItemServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ShoppingCartItemService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
			                                          mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ShoppingCartItemDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByShoppingCartIDProductID_Exists()
		{
			var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
			var records = new List<ShoppingCartItem>();
			records.Add(new ShoppingCartItem());
			mock.RepositoryMock.Setup(x => x.ByShoppingCartIDProductID(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ShoppingCartItemService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
			                                          mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

			List<ApiShoppingCartItemServerResponseModel> response = await service.ByShoppingCartIDProductID("test_value", default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByShoppingCartIDProductID(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByShoppingCartIDProductID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IShoppingCartItemRepository>();
			mock.RepositoryMock.Setup(x => x.ByShoppingCartIDProductID(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ShoppingCartItem>>(new List<ShoppingCartItem>()));
			var service = new ShoppingCartItemService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.ShoppingCartItemModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLShoppingCartItemMapperMock,
			                                          mock.DALMapperMockFactory.DALShoppingCartItemMapperMock);

			List<ApiShoppingCartItemServerResponseModel> response = await service.ByShoppingCartIDProductID("test_value", default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByShoppingCartIDProductID(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>219dc92a1ae401e4794f454aa24b6780</Hash>
</Codenesium>*/