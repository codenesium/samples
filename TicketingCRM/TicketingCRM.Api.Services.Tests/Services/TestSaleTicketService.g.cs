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
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "Services")]
	public partial class SaleTicketServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var records = new List<SaleTicket>();
			records.Add(new SaleTicket());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			List<ApiSaleTicketServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var record = new SaleTicket();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			ApiSaleTicketServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SaleTicket>(null));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			ApiSaleTicketServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var model = new ApiSaleTicketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SaleTicket>())).Returns(Task.FromResult(new SaleTicket()));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			CreateResponse<ApiSaleTicketServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSaleTicketServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SaleTicket>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var model = new ApiSaleTicketServerRequestModel();
			var validatorMock = new Mock<IApiSaleTicketServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSaleTicketServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			CreateResponse<ApiSaleTicketServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSaleTicketServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var model = new ApiSaleTicketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SaleTicket>())).Returns(Task.FromResult(new SaleTicket()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SaleTicket()));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			UpdateResponse<ApiSaleTicketServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleTicketServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SaleTicket>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var model = new ApiSaleTicketServerRequestModel();
			var validatorMock = new Mock<IApiSaleTicketServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleTicketServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SaleTicket()));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			UpdateResponse<ApiSaleTicketServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleTicketServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var model = new ApiSaleTicketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var model = new ApiSaleTicketServerRequestModel();
			var validatorMock = new Mock<IApiSaleTicketServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SaleTicketDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByTicketId_Exists()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var records = new List<SaleTicket>();
			records.Add(new SaleTicket());
			mock.RepositoryMock.Setup(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			List<ApiSaleTicketServerResponseModel> response = await service.ByTicketId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTicketId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			mock.RepositoryMock.Setup(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SaleTicket>>(new List<SaleTicket>()));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			List<ApiSaleTicketServerResponseModel> response = await service.ByTicketId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>4927552a2f30cc02b13842d98a208e9c</Hash>
</Codenesium>*/