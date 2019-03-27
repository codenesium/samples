using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Call")]
	[Trait("Area", "Services")]
	public partial class CallServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			var records = new List<Call>();
			records.Add(new Call());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CallModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			List<ApiCallServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			var record = new Call();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CallModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			ApiCallServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Call>(null));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CallModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			ApiCallServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			var model = new ApiCallServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Call>())).Returns(Task.FromResult(new Call()));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CallModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			CreateResponse<ApiCallServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Call>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			var model = new ApiCallServerRequestModel();
			var validatorMock = new Mock<IApiCallServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			CreateResponse<ApiCallServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			var model = new ApiCallServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Call>())).Returns(Task.FromResult(new Call()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Call()));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CallModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			UpdateResponse<ApiCallServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Call>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			var model = new ApiCallServerRequestModel();
			var validatorMock = new Mock<IApiCallServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Call()));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			UpdateResponse<ApiCallServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			var model = new ApiCallServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CallModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CallModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			var model = new ApiCallServerRequestModel();
			var validatorMock = new Mock<IApiCallServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void CallAssignmentsByCallId_Exists()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			var records = new List<CallAssignment>();
			records.Add(new CallAssignment());
			mock.RepositoryMock.Setup(x => x.CallAssignmentsByCallId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CallModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			List<ApiCallAssignmentServerResponseModel> response = await service.CallAssignmentsByCallId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CallAssignmentsByCallId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CallAssignmentsByCallId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			mock.RepositoryMock.Setup(x => x.CallAssignmentsByCallId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CallAssignment>>(new List<CallAssignment>()));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CallModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			List<ApiCallAssignmentServerResponseModel> response = await service.CallAssignmentsByCallId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CallAssignmentsByCallId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void NotesByCallId_Exists()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			var records = new List<Note>();
			records.Add(new Note());
			mock.RepositoryMock.Setup(x => x.NotesByCallId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CallModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			List<ApiNoteServerResponseModel> response = await service.NotesByCallId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.NotesByCallId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void NotesByCallId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICallRepository>();
			mock.RepositoryMock.Setup(x => x.NotesByCallId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Note>>(new List<Note>()));
			var service = new CallService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CallModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCallMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			List<ApiNoteServerResponseModel> response = await service.NotesByCallId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.NotesByCallId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c2a4615f1bd1be4c9d59eb01a22459a3</Hash>
</Codenesium>*/