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
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "Services")]
	public partial class DirectTweetServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var records = new List<DirectTweet>();
			records.Add(new DirectTweet());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			List<ApiDirectTweetResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var record = new DirectTweet();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			ApiDirectTweetResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<DirectTweet>(null));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			ApiDirectTweetResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var model = new ApiDirectTweetRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DirectTweet>())).Returns(Task.FromResult(new DirectTweet()));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			CreateResponse<ApiDirectTweetResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDirectTweetRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<DirectTweet>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var model = new ApiDirectTweetRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DirectTweet>())).Returns(Task.FromResult(new DirectTweet()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DirectTweet()));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			UpdateResponse<ApiDirectTweetResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDirectTweetRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<DirectTweet>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var model = new ApiDirectTweetRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByTaggedUserId_Exists()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var records = new List<DirectTweet>();
			records.Add(new DirectTweet());
			mock.RepositoryMock.Setup(x => x.ByTaggedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			List<ApiDirectTweetResponseModel> response = await service.ByTaggedUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTaggedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTaggedUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			mock.RepositoryMock.Setup(x => x.ByTaggedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<DirectTweet>>(new List<DirectTweet>()));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			List<ApiDirectTweetResponseModel> response = await service.ByTaggedUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTaggedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>4df20c57fa09818aa92551c91e67c2f9</Hash>
</Codenesium>*/