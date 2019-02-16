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
	[Trait("Table", "Tweet")]
	[Trait("Area", "Services")]
	public partial class TweetServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var records = new List<Tweet>();
			records.Add(new Tweet());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiTweetServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var record = new Tweet();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			ApiTweetServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(null));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			ApiTweetServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var model = new ApiTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tweet>())).Returns(Task.FromResult(new Tweet()));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			CreateResponse<ApiTweetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TweetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Tweet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TweetCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var model = new ApiTweetServerRequestModel();
			var validatorMock = new Mock<IApiTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			CreateResponse<ApiTweetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTweetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TweetCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var model = new ApiTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tweet>())).Returns(Task.FromResult(new Tweet()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tweet()));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			UpdateResponse<ApiTweetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TweetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Tweet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TweetUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var model = new ApiTweetServerRequestModel();
			var validatorMock = new Mock<IApiTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTweetServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tweet()));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			UpdateResponse<ApiTweetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTweetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TweetUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var model = new ApiTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TweetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TweetDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var model = new ApiTweetServerRequestModel();
			var validatorMock = new Mock<IApiTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TweetDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByLocationId_Exists()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var records = new List<Tweet>();
			records.Add(new Tweet());
			mock.RepositoryMock.Setup(x => x.ByLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiTweetServerResponseModel> response = await service.ByLocationId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLocationId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			mock.RepositoryMock.Setup(x => x.ByLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tweet>>(new List<Tweet>()));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiTweetServerResponseModel> response = await service.ByLocationId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLocationId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserUserId_Exists()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var records = new List<Tweet>();
			records.Add(new Tweet());
			mock.RepositoryMock.Setup(x => x.ByUserUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiTweetServerResponseModel> response = await service.ByUserUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			mock.RepositoryMock.Setup(x => x.ByUserUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tweet>>(new List<Tweet>()));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiTweetServerResponseModel> response = await service.ByUserUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void QuoteTweetsBySourceTweetId_Exists()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var records = new List<QuoteTweet>();
			records.Add(new QuoteTweet());
			mock.RepositoryMock.Setup(x => x.QuoteTweetsBySourceTweetId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.QuoteTweetsBySourceTweetId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.QuoteTweetsBySourceTweetId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void QuoteTweetsBySourceTweetId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			mock.RepositoryMock.Setup(x => x.QuoteTweetsBySourceTweetId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<QuoteTweet>>(new List<QuoteTweet>()));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.QuoteTweetsBySourceTweetId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.QuoteTweetsBySourceTweetId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RetweetsByTweetTweetId_Exists()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			var records = new List<Retweet>();
			records.Add(new Retweet());
			mock.RepositoryMock.Setup(x => x.RetweetsByTweetTweetId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiRetweetServerResponseModel> response = await service.RetweetsByTweetTweetId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.RetweetsByTweetTweetId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RetweetsByTweetTweetId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITweetRepository>();
			mock.RepositoryMock.Setup(x => x.RetweetsByTweetTweetId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Retweet>>(new List<Retweet>()));
			var service = new TweetService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TweetModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTweetMapperMock,
			                               mock.DALMapperMockFactory.DALQuoteTweetMapperMock,
			                               mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiRetweetServerResponseModel> response = await service.RetweetsByTweetTweetId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.RetweetsByTweetTweetId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>4d8489a329fa617f6d954f76d94e40aa</Hash>
</Codenesium>*/