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

			List<ApiDirectTweetServerResponseModel> response = await service.All();

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

			ApiDirectTweetServerResponseModel response = await service.Get(default(int));

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

			ApiDirectTweetServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var model = new ApiDirectTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DirectTweet>())).Returns(Task.FromResult(new DirectTweet()));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			CreateResponse<ApiDirectTweetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDirectTweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<DirectTweet>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var model = new ApiDirectTweetServerRequestModel();
			var validatorMock = new Mock<IApiDirectTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDirectTweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			CreateResponse<ApiDirectTweetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDirectTweetServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var model = new ApiDirectTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DirectTweet>())).Returns(Task.FromResult(new DirectTweet()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DirectTweet()));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			UpdateResponse<ApiDirectTweetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDirectTweetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<DirectTweet>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var model = new ApiDirectTweetServerRequestModel();
			var validatorMock = new Mock<IApiDirectTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDirectTweetServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DirectTweet()));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			UpdateResponse<ApiDirectTweetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDirectTweetServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var model = new ApiDirectTweetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.DirectTweetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IDirectTweetRepository>();
			var model = new ApiDirectTweetServerRequestModel();
			var validatorMock = new Mock<IApiDirectTweetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DirectTweetService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDirectTweetMapperMock,
			                                     mock.DALMapperMockFactory.DALDirectTweetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
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

			List<ApiDirectTweetServerResponseModel> response = await service.ByTaggedUserId(default(int));

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

			List<ApiDirectTweetServerResponseModel> response = await service.ByTaggedUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTaggedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>54cc9fcc244bb69209cf9397cab14830</Hash>
</Codenesium>*/