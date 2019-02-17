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
	[Trait("Table", "TransactionStatus")]
	[Trait("Area", "Services")]
	public partial class TransactionStatusServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var records = new List<TransactionStatus>();
			records.Add(new TransactionStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionStatusServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var record = new TransactionStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			ApiTransactionStatusServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatus>(null));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			ApiTransactionStatusServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var model = new ApiTransactionStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionStatus>())).Returns(Task.FromResult(new TransactionStatus()));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			CreateResponse<ApiTransactionStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TransactionStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatusCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var model = new ApiTransactionStatusServerRequestModel();
			var validatorMock = new Mock<IApiTransactionStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			CreateResponse<ApiTransactionStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatusCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var model = new ApiTransactionStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionStatus>())).Returns(Task.FromResult(new TransactionStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			UpdateResponse<ApiTransactionStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TransactionStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatusUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var model = new ApiTransactionStatusServerRequestModel();
			var validatorMock = new Mock<IApiTransactionStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionStatusServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			UpdateResponse<ApiTransactionStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatusUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var model = new ApiTransactionStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatusDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var model = new ApiTransactionStatusServerRequestModel();
			var validatorMock = new Mock<IApiTransactionStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatusDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void TransactionsByTransactionStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var records = new List<Transaction>();
			records.Add(new Transaction());
			mock.RepositoryMock.Setup(x => x.TransactionsByTransactionStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionServerResponseModel> response = await service.TransactionsByTransactionStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TransactionsByTransactionStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TransactionsByTransactionStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			mock.RepositoryMock.Setup(x => x.TransactionsByTransactionStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Transaction>>(new List<Transaction>()));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionServerResponseModel> response = await service.TransactionsByTransactionStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TransactionsByTransactionStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6534dcf30aa5d567d1c0371b9e5a4649</Hash>
</Codenesium>*/