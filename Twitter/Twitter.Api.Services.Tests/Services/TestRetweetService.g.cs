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
	[Trait("Table", "Retweet")]
	[Trait("Area", "Services")]
	public partial class RetweetServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var records = new List<Retweet>();
			records.Add(new Retweet());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiRetweetServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var record = new Retweet();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			ApiRetweetServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Retweet>(null));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			ApiRetweetServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var model = new ApiRetweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Retweet>())).Returns(Task.FromResult(new Retweet()));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			CreateResponse<ApiRetweetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiRetweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Retweet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RetweetCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var model = new ApiRetweetServerRequestModel();
			var validatorMock = new Mock<IApiRetweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiRetweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			CreateResponse<ApiRetweetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiRetweetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RetweetCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var model = new ApiRetweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Retweet>())).Returns(Task.FromResult(new Retweet()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Retweet()));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			UpdateResponse<ApiRetweetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRetweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Retweet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RetweetUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var model = new ApiRetweetServerRequestModel();
			var validatorMock = new Mock<IApiRetweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRetweetServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Retweet()));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			UpdateResponse<ApiRetweetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRetweetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RetweetUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var model = new ApiRetweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RetweetDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var model = new ApiRetweetServerRequestModel();
			var validatorMock = new Mock<IApiRetweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RetweetDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByRetwitterUserId_Exists()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var records = new List<Retweet>();
			records.Add(new Retweet());
			mock.RepositoryMock.Setup(x => x.ByRetwitterUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiRetweetServerResponseModel> response = await service.ByRetwitterUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByRetwitterUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByRetwitterUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			mock.RepositoryMock.Setup(x => x.ByRetwitterUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Retweet>>(new List<Retweet>()));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiRetweetServerResponseModel> response = await service.ByRetwitterUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByRetwitterUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTweetTweetId_Exists()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var records = new List<Retweet>();
			records.Add(new Retweet());
			mock.RepositoryMock.Setup(x => x.ByTweetTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiRetweetServerResponseModel> response = await service.ByTweetTweetId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTweetTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTweetTweetId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			mock.RepositoryMock.Setup(x => x.ByTweetTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Retweet>>(new List<Retweet>()));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiRetweetServerResponseModel> response = await service.ByTweetTweetId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTweetTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>9e1a2d8abee2a9db75c9e16ae69a8e65</Hash>
</Codenesium>*/