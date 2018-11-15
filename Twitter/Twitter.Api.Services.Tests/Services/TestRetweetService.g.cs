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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiRetweetServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var record = new Retweet();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLRetweetMapperMock,
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
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			ApiRetweetServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var model = new ApiRetweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Retweet>())).Returns(Task.FromResult(new Retweet()));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			CreateResponse<ApiRetweetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiRetweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Retweet>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var model = new ApiRetweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Retweet>())).Returns(Task.FromResult(new Retweet()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Retweet()));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			UpdateResponse<ApiRetweetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRetweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Retweet>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var model = new ApiRetweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByRetwitterUserId_Exists()
		{
			var mock = new ServiceMockFacade<IRetweetRepository>();
			var records = new List<Retweet>();
			records.Add(new Retweet());
			mock.RepositoryMock.Setup(x => x.ByRetwitterUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new RetweetService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLRetweetMapperMock,
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
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLRetweetMapperMock,
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
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLRetweetMapperMock,
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
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.RetweetModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLRetweetMapperMock,
			                                 mock.DALMapperMockFactory.DALRetweetMapperMock);

			List<ApiRetweetServerResponseModel> response = await service.ByTweetTweetId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTweetTweetId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>d64f566ac900959755a2d6456e22a767</Hash>
</Codenesium>*/