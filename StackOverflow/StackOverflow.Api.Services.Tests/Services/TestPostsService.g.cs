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
	[Trait("Table", "Posts")]
	[Trait("Area", "Services")]
	public partial class PostsServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<Posts>();
			records.Add(new Posts());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostsServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var record = new Posts();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ApiPostsServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ApiPostsServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var model = new ApiPostsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Posts>())).Returns(Task.FromResult(new Posts()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			CreateResponse<ApiPostsServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostsModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostsServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Posts>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostsCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var model = new ApiPostsServerRequestModel();
			var validatorMock = new Mock<IApiPostsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostsServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			CreateResponse<ApiPostsServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostsServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostsCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var model = new ApiPostsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Posts>())).Returns(Task.FromResult(new Posts()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			UpdateResponse<ApiPostsServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostsModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostsServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Posts>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostsUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var model = new ApiPostsServerRequestModel();
			var validatorMock = new Mock<IApiPostsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostsServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			UpdateResponse<ApiPostsServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostsServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostsUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var model = new ApiPostsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostsModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostsDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var model = new ApiPostsServerRequestModel();
			var validatorMock = new Mock<IApiPostsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostsDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByOwnerUserId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<Posts>();
			records.Add(new Posts());
			mock.RepositoryMock.Setup(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostsServerResponseModel> response = await service.ByOwnerUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByOwnerUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Posts>>(new List<Posts>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostsServerResponseModel> response = await service.ByOwnerUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByOwnerUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLastEditorUserId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<Posts>();
			records.Add(new Posts());
			mock.RepositoryMock.Setup(x => x.ByLastEditorUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostsServerResponseModel> response = await service.ByLastEditorUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLastEditorUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLastEditorUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.ByLastEditorUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Posts>>(new List<Posts>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostsServerResponseModel> response = await service.ByLastEditorUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLastEditorUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<Posts>();
			records.Add(new Posts());
			mock.RepositoryMock.Setup(x => x.ByPostTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostsServerResponseModel> response = await service.ByPostTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.ByPostTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Posts>>(new List<Posts>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostsServerResponseModel> response = await service.ByPostTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByParentId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<Posts>();
			records.Add(new Posts());
			mock.RepositoryMock.Setup(x => x.ByParentId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostsServerResponseModel> response = await service.ByParentId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByParentId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByParentId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.ByParentId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Posts>>(new List<Posts>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostsServerResponseModel> response = await service.ByParentId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByParentId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CommentsByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<Comments>();
			records.Add(new Comments());
			mock.RepositoryMock.Setup(x => x.CommentsByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiCommentsServerResponseModel> response = await service.CommentsByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CommentsByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CommentsByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.CommentsByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Comments>>(new List<Comments>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiCommentsServerResponseModel> response = await service.CommentsByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CommentsByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByParentId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<Posts>();
			records.Add(new Posts());
			mock.RepositoryMock.Setup(x => x.PostsByParentId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostsServerResponseModel> response = await service.PostsByParentId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByParentId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByParentId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.PostsByParentId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Posts>>(new List<Posts>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostsServerResponseModel> response = await service.PostsByParentId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByParentId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TagsByExcerptPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<Tags>();
			records.Add(new Tags());
			mock.RepositoryMock.Setup(x => x.TagsByExcerptPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiTagsServerResponseModel> response = await service.TagsByExcerptPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TagsByExcerptPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TagsByExcerptPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.TagsByExcerptPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tags>>(new List<Tags>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiTagsServerResponseModel> response = await service.TagsByExcerptPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TagsByExcerptPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TagsByWikiPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<Tags>();
			records.Add(new Tags());
			mock.RepositoryMock.Setup(x => x.TagsByWikiPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiTagsServerResponseModel> response = await service.TagsByWikiPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TagsByWikiPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TagsByWikiPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.TagsByWikiPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tags>>(new List<Tags>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiTagsServerResponseModel> response = await service.TagsByWikiPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TagsByWikiPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VotesByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<Votes>();
			records.Add(new Votes());
			mock.RepositoryMock.Setup(x => x.VotesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiVotesServerResponseModel> response = await service.VotesByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VotesByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.VotesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Votes>>(new List<Votes>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiVotesServerResponseModel> response = await service.VotesByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostHistoryByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<PostHistory>();
			records.Add(new PostHistory());
			mock.RepositoryMock.Setup(x => x.PostHistoryByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoryByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoryByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostHistoryByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.PostHistoryByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostHistory>>(new List<PostHistory>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoryByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoryByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostLinksByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<PostLinks>();
			records.Add(new PostLinks());
			mock.RepositoryMock.Setup(x => x.PostLinksByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.PostLinksByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostLinksByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.PostLinksByPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLinks>>(new List<PostLinks>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.PostLinksByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostLinksByRelatedPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			var records = new List<PostLinks>();
			records.Add(new PostLinks());
			mock.RepositoryMock.Setup(x => x.PostLinksByRelatedPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.PostLinksByRelatedPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByRelatedPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostLinksByRelatedPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostsRepository>();
			mock.RepositoryMock.Setup(x => x.PostLinksByRelatedPostId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLinks>>(new List<PostLinks>()));
			var service = new PostsService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.PostsModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALTagsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock,
			                               mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.PostLinksByRelatedPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByRelatedPostId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6a488690002e9fc418210b352e42e9f9</Hash>
</Codenesium>*/