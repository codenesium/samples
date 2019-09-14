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
	[Trait("Table", "User")]
	[Trait("Area", "Services")]
	public partial class UserServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var records = new List<User>();
			records.Add(new User());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiUserServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var record = new User();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiUserServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<User>(null));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiUserServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();

			var model = new ApiUserServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Returns(Task.FromResult(new User()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			CreateResponse<ApiUserServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUserServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<User>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var model = new ApiUserServerRequestModel();
			var validatorMock = new Mock<IApiUserServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			CreateResponse<ApiUserServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUserServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var model = new ApiUserServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Returns(Task.FromResult(new User()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			UpdateResponse<ApiUserServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<User>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var model = new ApiUserServerRequestModel();
			var validatorMock = new Mock<IApiUserServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			UpdateResponse<ApiUserServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var model = new ApiUserServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var model = new ApiUserServerRequestModel();
			var validatorMock = new Mock<IApiUserServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UserDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void BadgesByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var records = new List<Badge>();
			records.Add(new Badge());
			mock.RepositoryMock.Setup(x => x.BadgesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiBadgeServerResponseModel> response = await service.BadgesByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BadgesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BadgesByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			mock.RepositoryMock.Setup(x => x.BadgesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Badge>>(new List<Badge>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiBadgeServerResponseModel> response = await service.BadgesByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BadgesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CommentsByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var records = new List<Comment>();
			records.Add(new Comment());
			mock.RepositoryMock.Setup(x => x.CommentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiCommentServerResponseModel> response = await service.CommentsByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CommentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CommentsByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			mock.RepositoryMock.Setup(x => x.CommentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Comment>>(new List<Comment>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiCommentServerResponseModel> response = await service.CommentsByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CommentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByLastEditorUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var records = new List<Post>();
			records.Add(new Post());
			mock.RepositoryMock.Setup(x => x.PostsByLastEditorUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostServerResponseModel> response = await service.PostsByLastEditorUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByLastEditorUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByLastEditorUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			mock.RepositoryMock.Setup(x => x.PostsByLastEditorUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Post>>(new List<Post>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostServerResponseModel> response = await service.PostsByLastEditorUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByLastEditorUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByOwnerUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var records = new List<Post>();
			records.Add(new Post());
			mock.RepositoryMock.Setup(x => x.PostsByOwnerUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostServerResponseModel> response = await service.PostsByOwnerUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByOwnerUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByOwnerUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			mock.RepositoryMock.Setup(x => x.PostsByOwnerUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Post>>(new List<Post>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostServerResponseModel> response = await service.PostsByOwnerUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByOwnerUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VotesByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var records = new List<Vote>();
			records.Add(new Vote());
			mock.RepositoryMock.Setup(x => x.VotesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiVoteServerResponseModel> response = await service.VotesByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VotesByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			mock.RepositoryMock.Setup(x => x.VotesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Vote>>(new List<Vote>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiVoteServerResponseModel> response = await service.VotesByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostHistoriesByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			var records = new List<PostHistory>();
			records.Add(new PostHistory());
			mock.RepositoryMock.Setup(x => x.PostHistoriesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoriesByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoriesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostHistoriesByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserService, IUserRepository>();
			mock.RepositoryMock.Setup(x => x.PostHistoriesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostHistory>>(new List<PostHistory>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.DALMapperMockFactory.DALBadgeMapperMock,
			                              mock.DALMapperMockFactory.DALCommentMapperMock,
			                              mock.DALMapperMockFactory.DALPostMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock,
			                              mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoriesByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoriesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>ddb110d609a8a45709420d619ac855e9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/