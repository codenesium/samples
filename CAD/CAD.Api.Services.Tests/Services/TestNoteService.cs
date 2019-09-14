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
	[Trait("Table", "Note")]
	[Trait("Area", "Services")]
	public partial class NoteServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<INoteService, INoteRepository>();
			var records = new List<Note>();
			records.Add(new Note());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new NoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.NoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			List<ApiNoteServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<INoteService, INoteRepository>();
			var record = new Note();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new NoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.NoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			ApiNoteServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<INoteService, INoteRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Note>(null));
			var service = new NoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.NoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			ApiNoteServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<INoteService, INoteRepository>();

			var model = new ApiNoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Note>())).Returns(Task.FromResult(new Note()));
			var service = new NoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.NoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			CreateResponse<ApiNoteServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.NoteModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiNoteServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Note>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<NoteCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<INoteService, INoteRepository>();
			var model = new ApiNoteServerRequestModel();
			var validatorMock = new Mock<IApiNoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiNoteServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new NoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			CreateResponse<ApiNoteServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiNoteServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<NoteCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<INoteService, INoteRepository>();
			var model = new ApiNoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Note>())).Returns(Task.FromResult(new Note()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Note()));
			var service = new NoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.NoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			UpdateResponse<ApiNoteServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.NoteModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiNoteServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Note>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<NoteUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<INoteService, INoteRepository>();
			var model = new ApiNoteServerRequestModel();
			var validatorMock = new Mock<IApiNoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiNoteServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Note()));
			var service = new NoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			UpdateResponse<ApiNoteServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiNoteServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<NoteUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<INoteService, INoteRepository>();
			var model = new ApiNoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new NoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.NoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.NoteModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<NoteDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<INoteService, INoteRepository>();
			var model = new ApiNoteServerRequestModel();
			var validatorMock = new Mock<IApiNoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new NoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALNoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<NoteDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>f4c07418e3651533a2650dbf2d76b569</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/