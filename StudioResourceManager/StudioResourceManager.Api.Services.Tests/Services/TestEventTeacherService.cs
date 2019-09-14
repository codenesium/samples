using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "Services")]
	public partial class EventTeacherServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();
			var records = new List<EventTeacher>();
			records.Add(new EventTeacher());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			List<ApiEventTeacherServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();
			var record = new EventTeacher();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			ApiEventTeacherServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<EventTeacher>(null));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			ApiEventTeacherServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();

			var model = new ApiEventTeacherServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventTeacher>())).Returns(Task.FromResult(new EventTeacher()));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			CreateResponse<ApiEventTeacherServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventTeacherServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<EventTeacher>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventTeacherCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();
			var model = new ApiEventTeacherServerRequestModel();
			var validatorMock = new Mock<IApiEventTeacherServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventTeacherServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			CreateResponse<ApiEventTeacherServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventTeacherServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventTeacherCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();
			var model = new ApiEventTeacherServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventTeacher>())).Returns(Task.FromResult(new EventTeacher()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventTeacher()));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			UpdateResponse<ApiEventTeacherServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventTeacherServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<EventTeacher>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventTeacherUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();
			var model = new ApiEventTeacherServerRequestModel();
			var validatorMock = new Mock<IApiEventTeacherServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventTeacherServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventTeacher()));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			UpdateResponse<ApiEventTeacherServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventTeacherServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventTeacherUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();
			var model = new ApiEventTeacherServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventTeacherDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();
			var model = new ApiEventTeacherServerRequestModel();
			var validatorMock = new Mock<IApiEventTeacherServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<EventTeacherDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByTeacherId_Exists()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();
			var records = new List<EventTeacher>();
			records.Add(new EventTeacher());
			mock.RepositoryMock.Setup(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			List<ApiEventTeacherServerResponseModel> response = await service.ByTeacherId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTeacherId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();
			mock.RepositoryMock.Setup(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventTeacher>>(new List<EventTeacher>()));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			List<ApiEventTeacherServerResponseModel> response = await service.ByTeacherId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByEventId_Exists()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();
			var records = new List<EventTeacher>();
			records.Add(new EventTeacher());
			mock.RepositoryMock.Setup(x => x.ByEventId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			List<ApiEventTeacherServerResponseModel> response = await service.ByEventId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEventId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByEventId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEventTeacherService, IEventTeacherRepository>();
			mock.RepositoryMock.Setup(x => x.ByEventId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventTeacher>>(new List<EventTeacher>()));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			List<ApiEventTeacherServerResponseModel> response = await service.ByEventId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEventId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>d2b44b87c8033fa4a8f5a6b98871a641</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/