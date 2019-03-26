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
	[Trait("Table", "Officer")]
	[Trait("Area", "Services")]
	public partial class OfficerServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			var records = new List<Officer>();
			records.Add(new Officer());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			List<ApiOfficerServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			var record = new Officer();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			ApiOfficerServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			ApiOfficerServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			var model = new ApiOfficerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Officer>())).Returns(Task.FromResult(new Officer()));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			CreateResponse<ApiOfficerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Officer>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			var model = new ApiOfficerServerRequestModel();
			var validatorMock = new Mock<IApiOfficerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			CreateResponse<ApiOfficerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			var model = new ApiOfficerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Officer>())).Returns(Task.FromResult(new Officer()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			UpdateResponse<ApiOfficerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Officer>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			var model = new ApiOfficerServerRequestModel();
			var validatorMock = new Mock<IApiOfficerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			UpdateResponse<ApiOfficerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			var model = new ApiOfficerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			var model = new ApiOfficerServerRequestModel();
			var validatorMock = new Mock<IApiOfficerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void NotesByOfficerId_Exists()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			var records = new List<Note>();
			records.Add(new Note());
			mock.RepositoryMock.Setup(x => x.NotesByOfficerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			List<ApiNoteServerResponseModel> response = await service.NotesByOfficerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.NotesByOfficerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void NotesByOfficerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			mock.RepositoryMock.Setup(x => x.NotesByOfficerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Note>>(new List<Note>()));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			List<ApiNoteServerResponseModel> response = await service.NotesByOfficerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.NotesByOfficerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void OfficerCapabilitiesByOfficerId_Exists()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			var records = new List<OfficerCapability>();
			records.Add(new OfficerCapability());
			mock.RepositoryMock.Setup(x => x.OfficerCapabilitiesByOfficerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			List<ApiOfficerCapabilityServerResponseModel> response = await service.OfficerCapabilitiesByOfficerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.OfficerCapabilitiesByOfficerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void OfficerCapabilitiesByOfficerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IOfficerRepository>();
			mock.RepositoryMock.Setup(x => x.OfficerCapabilitiesByOfficerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<OfficerCapability>>(new List<OfficerCapability>()));
			var service = new OfficerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.OfficerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALOfficerMapperMock,
			                                 mock.DALMapperMockFactory.DALNoteMapperMock,
			                                 mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock);

			List<ApiOfficerCapabilityServerResponseModel> response = await service.OfficerCapabilitiesByOfficerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.OfficerCapabilitiesByOfficerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>72c801be4a5c65704815803419a7d585</Hash>
</Codenesium>*/