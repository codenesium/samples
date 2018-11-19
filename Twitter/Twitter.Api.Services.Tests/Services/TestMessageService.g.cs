using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Message")]
	[Trait("Area", "Services")]
	public partial class MessageServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			var records = new List<Message>();
			records.Add(new Message());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MessageModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessageServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			var record = new Message();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MessageModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			ApiMessageServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Message>(null));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MessageModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			ApiMessageServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			var model = new ApiMessageServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Message>())).Returns(Task.FromResult(new Message()));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MessageModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			CreateResponse<ApiMessageServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.MessageModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMessageServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Message>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			var model = new ApiMessageServerRequestModel();
			var validatorMock = new Mock<IApiMessageServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMessageServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			CreateResponse<ApiMessageServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMessageServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			var model = new ApiMessageServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Message>())).Returns(Task.FromResult(new Message()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Message()));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MessageModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			UpdateResponse<ApiMessageServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.MessageModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMessageServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Message>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			var model = new ApiMessageServerRequestModel();
			var validatorMock = new Mock<IApiMessageServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMessageServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Message()));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			UpdateResponse<ApiMessageServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMessageServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			var model = new ApiMessageServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MessageModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.MessageModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			var model = new ApiMessageServerRequestModel();
			var validatorMock = new Mock<IApiMessageServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void BySenderUserId_Exists()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			var records = new List<Message>();
			records.Add(new Message());
			mock.RepositoryMock.Setup(x => x.BySenderUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MessageModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessageServerResponseModel> response = await service.BySenderUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BySenderUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BySenderUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			mock.RepositoryMock.Setup(x => x.BySenderUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Message>>(new List<Message>()));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MessageModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessageServerResponseModel> response = await service.BySenderUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BySenderUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void MessengersByMessageId_Exists()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.MessengersByMessageId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MessageModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.MessengersByMessageId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.MessengersByMessageId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void MessengersByMessageId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMessageRepository>();
			mock.RepositoryMock.Setup(x => x.MessengersByMessageId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Messenger>>(new List<Messenger>()));
			var service = new MessageService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MessageModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                                 mock.DALMapperMockFactory.DALMessageMapperMock,
			                                 mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                 mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.MessengersByMessageId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.MessengersByMessageId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b312c9869da7e6d13c06726804399ddb</Hash>
</Codenesium>*/