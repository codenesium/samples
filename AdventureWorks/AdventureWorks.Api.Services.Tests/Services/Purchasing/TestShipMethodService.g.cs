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
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ShipMethod")]
	[Trait("Area", "Services")]
	public partial class ShipMethodServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			var records = new List<ShipMethod>();
			records.Add(new ShipMethod());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			List<ApiShipMethodServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			var record = new ShipMethod();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiShipMethodServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ShipMethod>(null));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiShipMethodServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			var model = new ApiShipMethodServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ShipMethod>())).Returns(Task.FromResult(new ShipMethod()));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			CreateResponse<ApiShipMethodServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiShipMethodServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ShipMethod>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			var model = new ApiShipMethodServerRequestModel();
			var validatorMock = new Mock<IApiShipMethodServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiShipMethodServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			CreateResponse<ApiShipMethodServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiShipMethodServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			var model = new ApiShipMethodServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ShipMethod>())).Returns(Task.FromResult(new ShipMethod()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			UpdateResponse<ApiShipMethodServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShipMethodServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ShipMethod>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			var model = new ApiShipMethodServerRequestModel();
			var validatorMock = new Mock<IApiShipMethodServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShipMethodServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			UpdateResponse<ApiShipMethodServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShipMethodServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			var model = new ApiShipMethodServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			var model = new ApiShipMethodServerRequestModel();
			var validatorMock = new Mock<IApiShipMethodServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			var record = new ShipMethod();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiShipMethodServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ShipMethod>(null));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiShipMethodServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			var record = new ShipMethod();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiShipMethodServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<ShipMethod>(null));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiShipMethodServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void PurchaseOrderHeadersByShipMethodID_Exists()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			var records = new List<PurchaseOrderHeader>();
			records.Add(new PurchaseOrderHeader());
			mock.RepositoryMock.Setup(x => x.PurchaseOrderHeadersByShipMethodID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await service.PurchaseOrderHeadersByShipMethodID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PurchaseOrderHeadersByShipMethodID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PurchaseOrderHeadersByShipMethodID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IShipMethodRepository>();
			mock.RepositoryMock.Setup(x => x.PurchaseOrderHeadersByShipMethodID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PurchaseOrderHeader>>(new List<PurchaseOrderHeader>()));
			var service = new ShipMethodService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ShipMethodModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLShipMethodMapperMock,
			                                    mock.DALMapperMockFactory.DALShipMethodMapperMock,
			                                    mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await service.PurchaseOrderHeadersByShipMethodID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PurchaseOrderHeadersByShipMethodID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>21295e4bbb5cfa4d2e356b5938b1ea5c</Hash>
</Codenesium>*/