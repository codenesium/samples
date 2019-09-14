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
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "Services")]
	public partial class SaleTicketsServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISaleTicketsService, ISaleTicketsRepository>();
			var records = new List<SaleTickets>();
			records.Add(new SaleTickets());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISaleTicketsService, ISaleTicketsRepository>();
			var record = new SaleTickets();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ApiSaleTicketsServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ISaleTicketsService, ISaleTicketsRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SaleTickets>(null));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ApiSaleTicketsServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISaleTicketsService, ISaleTicketsRepository>();

			var model = new ApiSaleTicketsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SaleTickets>())).Returns(Task.FromResult(new SaleTickets()));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			CreateResponse<ApiSaleTicketsServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSaleTicketsServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SaleTickets>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketsCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISaleTicketsService, ISaleTicketsRepository>();
			var model = new ApiSaleTicketsServerRequestModel();
			var validatorMock = new Mock<IApiSaleTicketsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSaleTicketsServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			CreateResponse<ApiSaleTicketsServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSaleTicketsServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketsCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISaleTicketsService, ISaleTicketsRepository>();
			var model = new ApiSaleTicketsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SaleTickets>())).Returns(Task.FromResult(new SaleTickets()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SaleTickets()));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			UpdateResponse<ApiSaleTicketsServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleTicketsServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SaleTickets>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketsUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISaleTicketsService, ISaleTicketsRepository>();
			var model = new ApiSaleTicketsServerRequestModel();
			var validatorMock = new Mock<IApiSaleTicketsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleTicketsServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SaleTickets()));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			UpdateResponse<ApiSaleTicketsServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleTicketsServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketsUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISaleTicketsService, ISaleTicketsRepository>();
			var model = new ApiSaleTicketsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketsDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISaleTicketsService, ISaleTicketsRepository>();
			var model = new ApiSaleTicketsServerRequestModel();
			var validatorMock = new Mock<IApiSaleTicketsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketsDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByTicketId_Exists()
		{
			var mock = new ServiceMockFacade<ISaleTicketsService, ISaleTicketsRepository>();
			var records = new List<SaleTickets>();
			records.Add(new SaleTickets());
			mock.RepositoryMock.Setup(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsServerResponseModel> response = await service.ByTicketId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTicketId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISaleTicketsService, ISaleTicketsRepository>();
			mock.RepositoryMock.Setup(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SaleTickets>>(new List<SaleTickets>()));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsServerResponseModel> response = await service.ByTicketId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b8b13dc6f89989a5559d8d49c9113d13</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/