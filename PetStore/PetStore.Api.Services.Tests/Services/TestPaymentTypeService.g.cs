using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PaymentType")]
	[Trait("Area", "Services")]
	public partial class PaymentTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var records = new List<PaymentType>();
			records.Add(new PaymentType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiPaymentTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var record = new PaymentType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiPaymentTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PaymentType>(null));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiPaymentTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var model = new ApiPaymentTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PaymentType>())).Returns(Task.FromResult(new PaymentType()));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			CreateResponse<ApiPaymentTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPaymentTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PaymentType>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var model = new ApiPaymentTypeServerRequestModel();
			var validatorMock = new Mock<IApiPaymentTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPaymentTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			CreateResponse<ApiPaymentTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPaymentTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var model = new ApiPaymentTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PaymentType>())).Returns(Task.FromResult(new PaymentType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			UpdateResponse<ApiPaymentTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPaymentTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PaymentType>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var model = new ApiPaymentTypeServerRequestModel();
			var validatorMock = new Mock<IApiPaymentTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPaymentTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			UpdateResponse<ApiPaymentTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPaymentTypeServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var model = new ApiPaymentTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var model = new ApiPaymentTypeServerRequestModel();
			var validatorMock = new Mock<IApiPaymentTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void SalesByPaymentTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var records = new List<Sale>();
			records.Add(new Sale());
			mock.RepositoryMock.Setup(x => x.SalesByPaymentTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleServerResponseModel> response = await service.SalesByPaymentTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesByPaymentTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesByPaymentTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			mock.RepositoryMock.Setup(x => x.SalesByPaymentTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Sale>>(new List<Sale>()));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleServerResponseModel> response = await service.SalesByPaymentTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesByPaymentTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>a58b359ad4733ed8c6a7212e2d313194</Hash>
</Codenesium>*/