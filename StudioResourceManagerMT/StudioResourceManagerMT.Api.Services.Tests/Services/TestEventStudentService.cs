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
	[Trait("Table", "EventStudent")]
	[Trait("Area", "Services")]
	public partial class EventStudentServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IEventStudentService, IEventStudentRepository>();
			var records = new List<EventStudent>();
			records.Add(new EventStudent());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			List<ApiEventStudentServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IEventStudentService, IEventStudentRepository>();
			var record = new EventStudent();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			ApiEventStudentServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IEventStudentService, IEventStudentRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<EventStudent>(null));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			ApiEventStudentServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IEventStudentService, IEventStudentRepository>();

			var model = new ApiEventStudentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventStudent>())).Returns(Task.FromResult(new EventStudent()));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			CreateResponse<ApiEventStudentServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventStudentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<EventStudent>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStudentCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IEventStudentService, IEventStudentRepository>();
			var model = new ApiEventStudentServerRequestModel();
			var validatorMock = new Mock<IApiEventStudentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventStudentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			CreateResponse<ApiEventStudentServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventStudentServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStudentCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IEventStudentService, IEventStudentRepository>();
			var model = new ApiEventStudentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventStudent>())).Returns(Task.FromResult(new EventStudent()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStudent()));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			UpdateResponse<ApiEventStudentServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStudentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<EventStudent>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStudentUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IEventStudentService, IEventStudentRepository>();
			var model = new ApiEventStudentServerRequestModel();
			var validatorMock = new Mock<IApiEventStudentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStudentServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStudent()));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			UpdateResponse<ApiEventStudentServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStudentServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStudentUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IEventStudentService, IEventStudentRepository>();
			var model = new ApiEventStudentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStudentDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IEventStudentService, IEventStudentRepository>();
			var model = new ApiEventStudentServerRequestModel();
			var validatorMock = new Mock<IApiEventStudentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventStudentDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>1399ab231abe026091760d096039278c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/