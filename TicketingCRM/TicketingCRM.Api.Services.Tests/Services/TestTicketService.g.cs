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
	[Trait("Table", "Ticket")]
	[Trait("Area", "Services")]
	public partial class TicketServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var records = new List<Ticket>();
			records.Add(new Ticket());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiTicketServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var record = new Ticket();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ApiTicketServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ApiTicketServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var model = new ApiTicketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Ticket>())).Returns(Task.FromResult(new Ticket()));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			CreateResponse<ApiTicketServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TicketModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTicketServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Ticket>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var model = new ApiTicketServerRequestModel();
			var validatorMock = new Mock<IApiTicketServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTicketServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			CreateResponse<ApiTicketServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTicketServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var model = new ApiTicketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Ticket>())).Returns(Task.FromResult(new Ticket()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			UpdateResponse<ApiTicketServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TicketModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Ticket>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var model = new ApiTicketServerRequestModel();
			var validatorMock = new Mock<IApiTicketServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			UpdateResponse<ApiTicketServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var model = new ApiTicketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TicketModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var model = new ApiTicketServerRequestModel();
			var validatorMock = new Mock<IApiTicketServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByTicketStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var records = new List<Ticket>();
			records.Add(new Ticket());
			mock.RepositoryMock.Setup(x => x.ByTicketStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiTicketServerResponseModel> response = await service.ByTicketStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTicketStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			mock.RepositoryMock.Setup(x => x.ByTicketStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Ticket>>(new List<Ticket>()));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiTicketServerResponseModel> response = await service.ByTicketStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SaleTicketsByTicketId_Exists()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var records = new List<SaleTickets>();
			records.Add(new SaleTickets());
			mock.RepositoryMock.Setup(x => x.SaleTicketsByTicketId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsServerResponseModel> response = await service.SaleTicketsByTicketId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SaleTicketsByTicketId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SaleTicketsByTicketId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			mock.RepositoryMock.Setup(x => x.SaleTicketsByTicketId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SaleTickets>>(new List<SaleTickets>()));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTicketMapperMock,
			                                mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsServerResponseModel> response = await service.SaleTicketsByTicketId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SaleTicketsByTicketId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>e0a5d16ee8265764ce60ed75241d511d</Hash>
</Codenesium>*/