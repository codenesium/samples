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
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Messenger")]
	[Trait("Area", "Services")]
	public partial class MessengerServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			var record = new Messenger();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			ApiMessengerServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Messenger>(null));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			ApiMessengerServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();

			var model = new ApiMessengerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Messenger>())).Returns(Task.FromResult(new Messenger()));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			CreateResponse<ApiMessengerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMessengerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Messenger>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MessengerCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			var model = new ApiMessengerServerRequestModel();
			var validatorMock = new Mock<IApiMessengerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMessengerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			CreateResponse<ApiMessengerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMessengerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MessengerCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			var model = new ApiMessengerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Messenger>())).Returns(Task.FromResult(new Messenger()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Messenger()));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			UpdateResponse<ApiMessengerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMessengerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Messenger>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MessengerUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			var model = new ApiMessengerServerRequestModel();
			var validatorMock = new Mock<IApiMessengerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMessengerServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Messenger()));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			UpdateResponse<ApiMessengerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMessengerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MessengerUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			var model = new ApiMessengerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MessengerDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			var model = new ApiMessengerServerRequestModel();
			var validatorMock = new Mock<IApiMessengerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MessengerDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByMessageId_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.ByMessageId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.ByMessageId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByMessageId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByMessageId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			mock.RepositoryMock.Setup(x => x.ByMessageId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Messenger>>(new List<Messenger>()));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.ByMessageId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByMessageId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByToUserId_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.ByToUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.ByToUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByToUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByToUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			mock.RepositoryMock.Setup(x => x.ByToUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Messenger>>(new List<Messenger>()));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.ByToUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByToUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerService, IMessengerRepository>();
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Messenger>>(new List<Messenger>()));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6bda29b0cc22a487ed1084a8974cf0c7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/