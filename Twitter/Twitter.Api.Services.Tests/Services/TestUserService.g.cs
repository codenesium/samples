using FluentAssertions;
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

			List<ApiUserResponseModel> response = await service.All();

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

			ApiUserResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<User>(null));
			var service = new UserService(mock.LoggerMock.Object,
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

			ApiUserResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Returns(Task.FromResult(new User()));
			var service = new UserService(mock.LoggerMock.Object,
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

			CreateResponse<ApiUserResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUserRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<User>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Returns(Task.FromResult(new User()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));
			var service = new UserService(mock.LoggerMock.Object,
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

			UpdateResponse<ApiUserResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<User>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new UserService(mock.LoggerMock.Object,
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
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByLocationLocationId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<User>();
			records.Add(new User());
			mock.RepositoryMock.Setup(x => x.ByLocationLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiUserResponseModel> response = await service.ByLocationLocationId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLocationLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLocationLocationId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.ByLocationLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<User>>(new List<User>()));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiUserResponseModel> response = await service.ByLocationLocationId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLocationLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void DirectTweets_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<DirectTweet>();
			records.Add(new DirectTweet());
			mock.RepositoryMock.Setup(x => x.DirectTweets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiDirectTweetResponseModel> response = await service.DirectTweets(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.DirectTweets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void DirectTweets_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.DirectTweets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<DirectTweet>>(new List<DirectTweet>()));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiDirectTweetResponseModel> response = await service.DirectTweets(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.DirectTweets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Followers_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Follower>();
			records.Add(new Follower());
			mock.RepositoryMock.Setup(x => x.Followers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiFollowerResponseModel> response = await service.Followers(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Followers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Followers_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.Followers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Follower>>(new List<Follower>()));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiFollowerResponseModel> response = await service.Followers(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Followers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Messages_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Message>();
			records.Add(new Message());
			mock.RepositoryMock.Setup(x => x.Messages(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiMessageResponseModel> response = await service.Messages(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Messages(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Messages_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.Messages(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Message>>(new List<Message>()));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiMessageResponseModel> response = await service.Messages(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Messages(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Messengers_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.Messengers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiMessengerResponseModel> response = await service.Messengers(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Messengers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Messengers_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.Messengers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Messenger>>(new List<Messenger>()));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiMessengerResponseModel> response = await service.Messengers(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Messengers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void QuoteTweets_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<QuoteTweet>();
			records.Add(new QuoteTweet());
			mock.RepositoryMock.Setup(x => x.QuoteTweets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiQuoteTweetResponseModel> response = await service.QuoteTweets(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.QuoteTweets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void QuoteTweets_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.QuoteTweets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<QuoteTweet>>(new List<QuoteTweet>()));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiQuoteTweetResponseModel> response = await service.QuoteTweets(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.QuoteTweets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Replies_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Reply>();
			records.Add(new Reply());
			mock.RepositoryMock.Setup(x => x.Replies(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiReplyResponseModel> response = await service.Replies(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Replies(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Replies_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.Replies(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Reply>>(new List<Reply>()));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiReplyResponseModel> response = await service.Replies(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Replies(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Retweets_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Retweet>();
			records.Add(new Retweet());
			mock.RepositoryMock.Setup(x => x.Retweets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiRetweetResponseModel> response = await service.Retweets(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Retweets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Retweets_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.Retweets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Retweet>>(new List<Retweet>()));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiRetweetResponseModel> response = await service.Retweets(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Retweets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Tweets_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Tweet>();
			records.Add(new Tweet());
			mock.RepositoryMock.Setup(x => x.Tweets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiTweetResponseModel> response = await service.Tweets(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Tweets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Tweets_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.Tweets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tweet>>(new List<Tweet>()));
			var service = new UserService(mock.LoggerMock.Object,
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

			List<ApiTweetResponseModel> response = await service.Tweets(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Tweets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8e5af9dfb977016525629b62b75cbcf6</Hash>
</Codenesium>*/