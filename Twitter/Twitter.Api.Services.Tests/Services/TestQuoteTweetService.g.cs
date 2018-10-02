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
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetResponseModel> response = await service.All();

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
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			ApiQuoteTweetResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<QuoteTweet>(null));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			ApiQuoteTweetResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var model = new ApiQuoteTweetRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<QuoteTweet>())).Returns(Task.FromResult(new QuoteTweet()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			CreateResponse<ApiQuoteTweetResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiQuoteTweetRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<QuoteTweet>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var model = new ApiQuoteTweetRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<QuoteTweet>())).Returns(Task.FromResult(new QuoteTweet()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new QuoteTweet()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			UpdateResponse<ApiQuoteTweetResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiQuoteTweetRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<QuoteTweet>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var model = new ApiQuoteTweetRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByRetweeterUserId_Exists()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			var records = new List<QuoteTweet>();
			records.Add(new QuoteTweet());
			mock.RepositoryMock.Setup(x => x.ByRetweeterUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetResponseModel> response = await service.ByRetweeterUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByRetweeterUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByRetweeterUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			mock.RepositoryMock.Setup(x => x.ByRetweeterUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<QuoteTweet>>(new List<QuoteTweet>()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetResponseModel> response = await service.ByRetweeterUserId(default(int));

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
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetResponseModel> response = await service.BySourceTweetId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BySourceTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BySourceTweetId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IQuoteTweetRepository>();
			mock.RepositoryMock.Setup(x => x.BySourceTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<QuoteTweet>>(new List<QuoteTweet>()));
			var service = new QuoteTweetService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.QuoteTweetModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLQuoteTweetMapperMock,
			                                    mock.DALMapperMockFactory.DALQuoteTweetMapperMock);

			List<ApiQuoteTweetResponseModel> response = await service.BySourceTweetId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BySourceTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>3ac778dec2b67ab41a7eab200ecd2263</Hash>
</Codenesium>*/