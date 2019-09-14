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
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();
			var records = new List<QuoteTweet>();
			records.Add(new QuoteTweet());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();
			var record = new QuoteTweet();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			ApiQuoteTweetServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<QuoteTweet>(null));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			ApiQuoteTweetServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();

			var model = new ApiQuoteTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<QuoteTweet>())).Returns(Task.FromResult(new QuoteTweet()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			CreateResponse<ApiQuoteTweetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiQuoteTweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<QuoteTweet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<QuoteTweetCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();
			var model = new ApiQuoteTweetServerRequestModel();
			var validatorMock = new Mock<IApiQuoteTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			CreateResponse<ApiQuoteTweetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiQuoteTweetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<QuoteTweetCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();
			var model = new ApiQuoteTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<QuoteTweet>())).Returns(Task.FromResult(new QuoteTweet()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new QuoteTweet()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			UpdateResponse<ApiQuoteTweetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<QuoteTweet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<QuoteTweetUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();
			var model = new ApiQuoteTweetServerRequestModel();
			var validatorMock = new Mock<IApiQuoteTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new QuoteTweet()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			UpdateResponse<ApiQuoteTweetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<QuoteTweetUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();
			var model = new ApiQuoteTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<QuoteTweetDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();
			var model = new ApiQuoteTweetServerRequestModel();
			var validatorMock = new Mock<IApiQuoteTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
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
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();
			var records = new List<QuoteTweet>();
			records.Add(new QuoteTweet());
			mock.RepositoryMock.Setup(x => x.ByRetweeterUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.ByRetweeterUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByRetweeterUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByRetweeterUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();
			mock.RepositoryMock.Setup(x => x.ByRetweeterUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<QuoteTweet>>(new List<QuoteTweet>()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.ByRetweeterUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByRetweeterUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BySourceTweetId_Exists()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();
			var records = new List<QuoteTweet>();
			records.Add(new QuoteTweet());
			mock.RepositoryMock.Setup(x => x.BySourceTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.BySourceTweetId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BySourceTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BySourceTweetId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IQuoteTweetService, IQuoteTweetRepository>();
			mock.RepositoryMock.Setup(x => x.BySourceTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<QuoteTweet>>(new List<QuoteTweet>()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetServerResponseModel> response = await service.BySourceTweetId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BySourceTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>906caa770d1e7ca6caabc8f0848e0b06</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/