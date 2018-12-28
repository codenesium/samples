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
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "Services")]
	public partial class QuoteTweetServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var records = new List<QuoteTweet>();
			records.Add(new QuoteTweet());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var record = new QuoteTweet();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			ApiQuoteTweetServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<QuoteTweet>(null));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			ApiQuoteTweetServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var model = new ApiQuoteTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<QuoteTweet>())).Returns(Task.FromResult(new QuoteTweet()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			CreateResponse<ApiQuoteTweetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiQuoteTweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<QuoteTweet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<QuoteTweetCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var model = new ApiQuoteTweetServerRequestModel();
			var validatorMock = new Mock<IApiQuoteTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			CreateResponse<ApiQuoteTweetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiQuoteTweetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<QuoteTweetCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var model = new ApiQuoteTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<QuoteTweet>())).Returns(Task.FromResult(new QuoteTweet()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new QuoteTweet()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			UpdateResponse<ApiQuoteTweetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<QuoteTweet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<QuoteTweetUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var model = new ApiQuoteTweetServerRequestModel();
			var validatorMock = new Mock<IApiQuoteTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new QuoteTweet()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			UpdateResponse<ApiQuoteTweetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<QuoteTweetUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var model = new ApiQuoteTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<QuoteTweetDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var model = new ApiQuoteTweetServerRequestModel();
			var validatorMock = new Mock<IApiQuoteTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<QuoteTweetDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByRetweeterUserId_Exists()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var records = new List<QuoteTweet>();
			records.Add(new QuoteTweet());
			mock.RepositoryMock.Setup(x => x.ByRetweeterUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.ByRetweeterUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByRetweeterUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByRetweeterUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			mock.RepositoryMock.Setup(x => x.ByRetweeterUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<QuoteTweet>>(new List<QuoteTweet>()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.ByRetweeterUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByRetweeterUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BySourceTweetId_Exists()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var records = new List<QuoteTweet>();
			records.Add(new QuoteTweet());
			mock.RepositoryMock.Setup(x => x.BySourceTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.BySourceTweetId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BySourceTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BySourceTweetId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			mock.RepositoryMock.Setup(x => x.BySourceTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<QuoteTweet>>(new List<QuoteTweet>()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.BySourceTweetId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BySourceTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>bf5b3d6d776aba74c9d16905149a5ba8</Hash>
</Codenesium>*/