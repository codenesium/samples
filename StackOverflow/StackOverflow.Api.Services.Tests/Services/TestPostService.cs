using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Post")]
	[Trait("Area", "Services")]
	public partial class PostServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<Post>();
			records.Add(new Post());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var record = new Post();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ApiPostServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ApiPostServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();

			var model = new ApiPostServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Post>())).Returns(Task.FromResult(new Post()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			CreateResponse<ApiPostServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Post>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var model = new ApiPostServerRequestModel();
			var validatorMock = new Mock<IApiPostServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			CreateResponse<ApiPostServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var model = new ApiPostServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Post>())).Returns(Task.FromResult(new Post()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Post()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			UpdateResponse<ApiPostServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Post>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var model = new ApiPostServerRequestModel();
			var validatorMock = new Mock<IApiPostServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Post()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			UpdateResponse<ApiPostServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var model = new ApiPostServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var model = new ApiPostServerRequestModel();
			var validatorMock = new Mock<IApiPostServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByOwnerUserId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<Post>();
			records.Add(new Post());
			mock.RepositoryMock.Setup(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostServerResponseModel> response = await service.ByOwnerUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByOwnerUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Post>>(new List<Post>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostServerResponseModel> response = await service.ByOwnerUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLastEditorUserId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<Post>();
			records.Add(new Post());
			mock.RepositoryMock.Setup(x => x.ByLastEditorUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostServerResponseModel> response = await service.ByLastEditorUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLastEditorUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLastEditorUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.ByLastEditorUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Post>>(new List<Post>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostServerResponseModel> response = await service.ByLastEditorUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLastEditorUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<Post>();
			records.Add(new Post());
			mock.RepositoryMock.Setup(x => x.ByPostTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostServerResponseModel> response = await service.ByPostTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.ByPostTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Post>>(new List<Post>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostServerResponseModel> response = await service.ByPostTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByParentId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<Post>();
			records.Add(new Post());
			mock.RepositoryMock.Setup(x => x.ByParentId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostServerResponseModel> response = await service.ByParentId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByParentId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByParentId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.ByParentId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Post>>(new List<Post>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostServerResponseModel> response = await service.ByParentId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByParentId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CommentsByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<Comment>();
			records.Add(new Comment());
			mock.RepositoryMock.Setup(x => x.CommentsByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiCommentServerResponseModel> response = await service.CommentsByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CommentsByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CommentsByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.CommentsByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Comment>>(new List<Comment>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiCommentServerResponseModel> response = await service.CommentsByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CommentsByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByParentId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<Post>();
			records.Add(new Post());
			mock.RepositoryMock.Setup(x => x.PostsByParentId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostServerResponseModel> response = await service.PostsByParentId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByParentId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByParentId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.PostsByParentId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Post>>(new List<Post>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostServerResponseModel> response = await service.PostsByParentId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByParentId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TagsByExcerptPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<Tag>();
			records.Add(new Tag());
			mock.RepositoryMock.Setup(x => x.TagsByExcerptPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiTagServerResponseModel> response = await service.TagsByExcerptPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TagsByExcerptPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TagsByExcerptPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.TagsByExcerptPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tag>>(new List<Tag>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiTagServerResponseModel> response = await service.TagsByExcerptPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TagsByExcerptPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TagsByWikiPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<Tag>();
			records.Add(new Tag());
			mock.RepositoryMock.Setup(x => x.TagsByWikiPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiTagServerResponseModel> response = await service.TagsByWikiPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TagsByWikiPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TagsByWikiPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.TagsByWikiPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tag>>(new List<Tag>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiTagServerResponseModel> response = await service.TagsByWikiPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TagsByWikiPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VotesByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<Vote>();
			records.Add(new Vote());
			mock.RepositoryMock.Setup(x => x.VotesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiVoteServerResponseModel> response = await service.VotesByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VotesByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.VotesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Vote>>(new List<Vote>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiVoteServerResponseModel> response = await service.VotesByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostHistoriesByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<PostHistory>();
			records.Add(new PostHistory());
			mock.RepositoryMock.Setup(x => x.PostHistoriesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoriesByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoriesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostHistoriesByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.PostHistoriesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostHistory>>(new List<PostHistory>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoriesByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoriesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostLinksByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<PostLink>();
			records.Add(new PostLink());
			mock.RepositoryMock.Setup(x => x.PostLinksByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.PostLinksByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostLinksByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.PostLinksByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLink>>(new List<PostLink>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.PostLinksByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostLinksByRelatedPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			var records = new List<PostLink>();
			records.Add(new PostLink());
			mock.RepositoryMock.Setup(x => x.PostLinksByRelatedPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.PostLinksByRelatedPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByRelatedPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostLinksByRelatedPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostService, IPostRepository>();
			mock.RepositoryMock.Setup(x => x.PostLinksByRelatedPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLink>>(new List<PostLink>()));
			var service = new PostService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.PostModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALTagMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                              mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.PostLinksByRelatedPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByRelatedPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>4805f66bd43063979b3488cce65048f2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/