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
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "Services")]
	public partial class TicketStatusServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var records = new List<TicketStatus>();
			records.Add(new TicketStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketStatusServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var record = new TicketStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			ApiTicketStatusServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TicketStatus>(null));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			ApiTicketStatusServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var model = new ApiTicketStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TicketStatus>())).Returns(Task.FromResult(new TicketStatus()));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			CreateResponse<ApiTicketStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTicketStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TicketStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatusCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var model = new ApiTicketStatusServerRequestModel();
			var validatorMock = new Mock<IApiTicketStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTicketStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			CreateResponse<ApiTicketStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTicketStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatusCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var model = new ApiTicketStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TicketStatus>())).Returns(Task.FromResult(new TicketStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			UpdateResponse<ApiTicketStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TicketStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatusUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var model = new ApiTicketStatusServerRequestModel();
			var validatorMock = new Mock<IApiTicketStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketStatusServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			UpdateResponse<ApiTicketStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatusUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var model = new ApiTicketStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatusDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var model = new ApiTicketStatusServerRequestModel();
			var validatorMock = new Mock<IApiTicketStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatusDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void TicketsByTicketStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var records = new List<Ticket>();
			records.Add(new Ticket());
			mock.RepositoryMock.Setup(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketServerResponseModel> response = await service.TicketsByTicketStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TicketsByTicketStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			mock.RepositoryMock.Setup(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Ticket>>(new List<Ticket>()));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketServerResponseModel> response = await service.TicketsByTicketStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>9065a26c843ead6dbeb2f2c6777fff1c</Hash>
</Codenesium>*/