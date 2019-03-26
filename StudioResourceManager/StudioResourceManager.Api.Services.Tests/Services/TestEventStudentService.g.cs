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
	[Trait("Table", "EventStudent")]
	[Trait("Area", "Services")]
	public partial class EventStudentServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
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
		public async void Get()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
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
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
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
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
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
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
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
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
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
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
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
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
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
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
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

		[Fact]
		public async void ByEventId_Exists()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
			var records = new List<EventStudent>();
			records.Add(new EventStudent());
			mock.RepositoryMock.Setup(x => x.ByEventId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			List<ApiEventStudentServerResponseModel> response = await service.ByEventId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEventId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByEventId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
			mock.RepositoryMock.Setup(x => x.ByEventId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventStudent>>(new List<EventStudent>()));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			List<ApiEventStudentServerResponseModel> response = await service.ByEventId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEventId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByStudentId_Exists()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
			var records = new List<EventStudent>();
			records.Add(new EventStudent());
			mock.RepositoryMock.Setup(x => x.ByStudentId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			List<ApiEventStudentServerResponseModel> response = await service.ByStudentId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByStudentId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByStudentId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
			mock.RepositoryMock.Setup(x => x.ByStudentId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventStudent>>(new List<EventStudent>()));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			List<ApiEventStudentServerResponseModel> response = await service.ByStudentId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByStudentId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>23b710942c19232c061e4a5e07709703</Hash>
</Codenesium>*/