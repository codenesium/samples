using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatus")]
	[Trait("Area", "Services")]
	public partial class EventStatusServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IEventStatusService, IEventStatusRepository>();
			var records = new List<EventStatus>();
			records.Add(new EventStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiEventStatusServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IEventStatusService, IEventStatusRepository>();
			var record = new EventStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			ApiEventStatusServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IEventStatusService, IEventStatusRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<EventStatus>(null));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			ApiEventStatusServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IEventStatusService, IEventStatusRepository>();

			var model = new ApiEventStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventStatus>())).Returns(Task.FromResult(new EventStatus()));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			CreateResponse<ApiEventStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<EventStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStatusCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IEventStatusService, IEventStatusRepository>();
			var model = new ApiEventStatusServerRequestModel();
			var validatorMock = new Mock<IApiEventStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			CreateResponse<ApiEventStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStatusCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IEventStatusService, IEventStatusRepository>();
			var model = new ApiEventStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventStatus>())).Returns(Task.FromResult(new EventStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatus()));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			UpdateResponse<ApiEventStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<EventStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStatusUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IEventStatusService, IEventStatusRepository>();
			var model = new ApiEventStatusServerRequestModel();
			var validatorMock = new Mock<IApiEventStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStatusServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatus()));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			UpdateResponse<ApiEventStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStatusUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IEventStatusService, IEventStatusRepository>();
			var model = new ApiEventStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStatusDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IEventStatusService, IEventStatusRepository>();
			var model = new ApiEventStatusServerRequestModel();
			var validatorMock = new Mock<IApiEventStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStatusDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void EventsByEventStatusId_Exists()
		{
			var mock = new ServiceMockFacade<IEventStatusService, IEventStatusRepository>();
			var records = new List<Event>();
			records.Add(new Event());
			mock.RepositoryMock.Setup(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiEventServerResponseModel> response = await service.EventsByEventStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventsByEventStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEventStatusService, IEventStatusRepository>();
			mock.RepositoryMock.Setup(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Event>>(new List<Event>()));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiEventServerResponseModel> response = await service.EventsByEventStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>7e9fab0a55d0f66d4bff740909f9a10e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/