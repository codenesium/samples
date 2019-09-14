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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "Services")]
	public partial class SaleServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();
			var records = new List<Sale>();
			records.Add(new Sale());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();
			var record = new Sale();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ApiSaleServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ApiSaleServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();

			var model = new ApiSaleServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Sale>())).Returns(Task.FromResult(new Sale()));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			CreateResponse<ApiSaleServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SaleModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSaleServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Sale>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();
			var model = new ApiSaleServerRequestModel();
			var validatorMock = new Mock<IApiSaleServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSaleServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			CreateResponse<ApiSaleServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSaleServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();
			var model = new ApiSaleServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Sale>())).Returns(Task.FromResult(new Sale()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			UpdateResponse<ApiSaleServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SaleModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Sale>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();
			var model = new ApiSaleServerRequestModel();
			var validatorMock = new Mock<IApiSaleServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			UpdateResponse<ApiSaleServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();
			var model = new ApiSaleServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SaleModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();
			var model = new ApiSaleServerRequestModel();
			var validatorMock = new Mock<IApiSaleServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByTransactionId_Exists()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();
			var records = new List<Sale>();
			records.Add(new Sale());
			mock.RepositoryMock.Setup(x => x.ByTransactionId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleServerResponseModel> response = await service.ByTransactionId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTransactionId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTransactionId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();
			mock.RepositoryMock.Setup(x => x.ByTransactionId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Sale>>(new List<Sale>()));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleServerResponseModel> response = await service.ByTransactionId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTransactionId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SaleTicketsBySaleId_Exists()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();
			var records = new List<SaleTickets>();
			records.Add(new SaleTickets());
			mock.RepositoryMock.Setup(x => x.SaleTicketsBySaleId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsServerResponseModel> response = await service.SaleTicketsBySaleId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SaleTicketsBySaleId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SaleTicketsBySaleId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISaleService, ISaleRepository>();
			mock.RepositoryMock.Setup(x => x.SaleTicketsBySaleId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SaleTickets>>(new List<SaleTickets>()));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsServerResponseModel> response = await service.SaleTicketsBySaleId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SaleTicketsBySaleId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>9081ad375f8b7ec40509f440cb76e472</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/