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
	[Trait("Table", "CreditCard")]
	[Trait("Area", "Services")]
	public partial class CreditCardServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var records = new List<CreditCard>();
			records.Add(new CreditCard());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiCreditCardServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var record = new CreditCard();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCreditCardServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(null));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCreditCardServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var model = new ApiCreditCardServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CreditCard>())).Returns(Task.FromResult(new CreditCard()));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			CreateResponse<ApiCreditCardServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCreditCardServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CreditCard>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CreditCardCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var model = new ApiCreditCardServerRequestModel();
			var validatorMock = new Mock<IApiCreditCardServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCreditCardServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			CreateResponse<ApiCreditCardServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCreditCardServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CreditCardCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var model = new ApiCreditCardServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CreditCard>())).Returns(Task.FromResult(new CreditCard()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			UpdateResponse<ApiCreditCardServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCreditCardServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CreditCard>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CreditCardUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var model = new ApiCreditCardServerRequestModel();
			var validatorMock = new Mock<IApiCreditCardServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCreditCardServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			UpdateResponse<ApiCreditCardServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCreditCardServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CreditCardUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var model = new ApiCreditCardServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CreditCardDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var model = new ApiCreditCardServerRequestModel();
			var validatorMock = new Mock<IApiCreditCardServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CreditCardDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByCardNumber_Exists()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var record = new CreditCard();
			mock.RepositoryMock.Setup(x => x.ByCardNumber(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCreditCardServerResponseModel response = await service.ByCardNumber("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByCardNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void ByCardNumber_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			mock.RepositoryMock.Setup(x => x.ByCardNumber(It.IsAny<string>())).Returns(Task.FromResult<CreditCard>(null));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCreditCardServerResponseModel response = await service.ByCardNumber("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByCardNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void SalesOrderHeadersByCreditCardID_Exists()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var records = new List<SalesOrderHeader>();
			records.Add(new SalesOrderHeader());
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersByCreditCardID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersByCreditCardID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersByCreditCardID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesOrderHeadersByCreditCardID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersByCreditCardID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderHeader>>(new List<SalesOrderHeader>()));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersByCreditCardID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersByCreditCardID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>7a319849cddf6596aed349b0f909c458</Hash>
</Codenesium>*/