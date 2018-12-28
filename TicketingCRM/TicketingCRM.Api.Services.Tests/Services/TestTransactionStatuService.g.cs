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
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "Services")]
	public partial class TransactionStatuServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var records = new List<TransactionStatu>();
			records.Add(new TransactionStatu());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionStatuServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var record = new TransactionStatu();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			ApiTransactionStatuServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatu>(null));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			ApiTransactionStatuServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var model = new ApiTransactionStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionStatu>())).Returns(Task.FromResult(new TransactionStatu()));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			CreateResponse<ApiTransactionStatuServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionStatuServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TransactionStatu>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatuCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var model = new ApiTransactionStatuServerRequestModel();
			var validatorMock = new Mock<IApiTransactionStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionStatuServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			CreateResponse<ApiTransactionStatuServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionStatuServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatuCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var model = new ApiTransactionStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionStatu>())).Returns(Task.FromResult(new TransactionStatu()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatu()));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			UpdateResponse<ApiTransactionStatuServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionStatuServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TransactionStatu>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatuUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var model = new ApiTransactionStatuServerRequestModel();
			var validatorMock = new Mock<IApiTransactionStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionStatuServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatu()));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			UpdateResponse<ApiTransactionStatuServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionStatuServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatuUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var model = new ApiTransactionStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatuDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var model = new ApiTransactionStatuServerRequestModel();
			var validatorMock = new Mock<IApiTransactionStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionStatuDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void TransactionsByTransactionStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var records = new List<Transaction>();
			records.Add(new Transaction());
			mock.RepositoryMock.Setup(x => x.TransactionsByTransactionStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionServerResponseModel> response = await service.TransactionsByTransactionStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TransactionsByTransactionStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TransactionsByTransactionStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			mock.RepositoryMock.Setup(x => x.TransactionsByTransactionStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Transaction>>(new List<Transaction>()));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionServerResponseModel> response = await service.TransactionsByTransactionStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TransactionsByTransactionStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6d028cd28620a71ee8e497fb560d765a</Hash>
</Codenesium>*/