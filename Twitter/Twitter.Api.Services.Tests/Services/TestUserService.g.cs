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
	[Trait("Table", "User")]
	[Trait("Area", "Services")]
	public partial class UserServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<User>();
			records.Add(new User());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiUserServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var record = new User();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			ApiUserServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<User>(null));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			ApiUserServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Returns(Task.FromResult(new User()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			CreateResponse<ApiUserServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUserServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<User>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserServerRequestModel();
			var validatorMock = new Mock<IApiUserServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			CreateResponse<ApiUserServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUserServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Returns(Task.FromResult(new User()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			UpdateResponse<ApiUserServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<User>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserServerRequestModel();
			var validatorMock = new Mock<IApiUserServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			UpdateResponse<ApiUserServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserServerRequestModel();
			var validatorMock = new Mock<IApiUserServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByLocationLocationId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<User>();
			records.Add(new User());
			mock.RepositoryMock.Setup(x => x.ByLocationLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiUserServerResponseModel> response = await service.ByLocationLocationId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLocationLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLocationLocationId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.ByLocationLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<User>>(new List<User>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiUserServerResponseModel> response = await service.ByLocationLocationId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLocationLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void DirectTweetsByTaggedUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<DirectTweet>();
			records.Add(new DirectTweet());
			mock.RepositoryMock.Setup(x => x.DirectTweetsByTaggedUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiDirectTweetServerResponseModel> response = await service.DirectTweetsByTaggedUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.DirectTweetsByTaggedUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void DirectTweetsByTaggedUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.DirectTweetsByTaggedUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<DirectTweet>>(new List<DirectTweet>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiDirectTweetServerResponseModel> response = await service.DirectTweetsByTaggedUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.DirectTweetsByTaggedUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void FollowersByFollowedUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Follower>();
			records.Add(new Follower());
			mock.RepositoryMock.Setup(x => x.FollowersByFollowedUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.FollowersByFollowedUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.FollowersByFollowedUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void FollowersByFollowedUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.FollowersByFollowedUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Follower>>(new List<Follower>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.FollowersByFollowedUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.FollowersByFollowedUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void FollowersByFollowingUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Follower>();
			records.Add(new Follower());
			mock.RepositoryMock.Setup(x => x.FollowersByFollowingUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.FollowersByFollowingUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.FollowersByFollowingUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void FollowersByFollowingUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.FollowersByFollowingUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Follower>>(new List<Follower>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.FollowersByFollowingUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.FollowersByFollowingUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void MessagesBySenderUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Message>();
			records.Add(new Message());
			mock.RepositoryMock.Setup(x => x.MessagesBySenderUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiMessageServerResponseModel> response = await service.MessagesBySenderUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.MessagesBySenderUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void MessagesBySenderUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.MessagesBySenderUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Message>>(new List<Message>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiMessageServerResponseModel> response = await service.MessagesBySenderUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.MessagesBySenderUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void MessengersByToUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.MessengersByToUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.MessengersByToUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.MessengersByToUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void MessengersByToUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.MessengersByToUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Messenger>>(new List<Messenger>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.MessengersByToUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.MessengersByToUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void MessengersByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.MessengersByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.MessengersByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.MessengersByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void MessengersByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.MessengersByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Messenger>>(new List<Messenger>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiMessengerServerResponseModel> response = await service.MessengersByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.MessengersByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void QuoteTweetsByRetweeterUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<QuoteTweet>();
			records.Add(new QuoteTweet());
			mock.RepositoryMock.Setup(x => x.QuoteTweetsByRetweeterUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.QuoteTweetsByRetweeterUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.QuoteTweetsByRetweeterUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void QuoteTweetsByRetweeterUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.QuoteTweetsByRetweeterUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<QuoteTweet>>(new List<QuoteTweet>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.QuoteTweetsByRetweeterUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.QuoteTweetsByRetweeterUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RepliesByReplierUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Reply>();
			records.Add(new Reply());
			mock.RepositoryMock.Setup(x => x.RepliesByReplierUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiReplyServerResponseModel> response = await service.RepliesByReplierUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.RepliesByReplierUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RepliesByReplierUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.RepliesByReplierUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Reply>>(new List<Reply>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiReplyServerResponseModel> response = await service.RepliesByReplierUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.RepliesByReplierUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RetweetsByRetwitterUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Retweet>();
			records.Add(new Retweet());
			mock.RepositoryMock.Setup(x => x.RetweetsByRetwitterUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiRetweetServerResponseModel> response = await service.RetweetsByRetwitterUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.RetweetsByRetwitterUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RetweetsByRetwitterUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.RetweetsByRetwitterUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Retweet>>(new List<Retweet>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiRetweetServerResponseModel> response = await service.RetweetsByRetwitterUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.RetweetsByRetwitterUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TweetsByUserUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Tweet>();
			records.Add(new Tweet());
			mock.RepositoryMock.Setup(x => x.TweetsByUserUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiTweetServerResponseModel> response = await service.TweetsByUserUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TweetsByUserUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TweetsByUserUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.TweetsByUserUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tweet>>(new List<Tweet>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                              mock.DALMapperMockFactory.DALDirectTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLFollowerMapperMock,
			                              mock.DALMapperMockFactory.DALFollowerMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessageMapperMock,
			                              mock.DALMapperMockFactory.DALMessageMapperMock,
			                              mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                              mock.DALMapperMockFactory.DALMessengerMapperMock,
			                              mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                              mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                              mock.DALMapperMockFactory.DALReplyMapperMock,
			                              mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                              mock.DALMapperMockFactory.DALRetweetMapperMock,
			                              mock.BOLMapperMockFactory.BOLTweetMapperMock,
			                              mock.DALMapperMockFactory.DALTweetMapperMock);

			List<ApiTweetServerResponseModel> response = await service.TweetsByUserUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TweetsByUserUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>a3a18853363dbec49a6cdc78b05b7d8c</Hash>
</Codenesium>*/