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
	[Trait("Table", "Users")]
	[Trait("Area", "Services")]
	public partial class UsersServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var records = new List<Users>();
			records.Add(new Users());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiUsersServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var record = new Users();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiUsersServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiUsersServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var model = new ApiUsersServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Users>())).Returns(Task.FromResult(new Users()));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			CreateResponse<ApiUsersServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UsersModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUsersServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Users>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UsersCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var model = new ApiUsersServerRequestModel();
			var validatorMock = new Mock<IApiUsersServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUsersServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			CreateResponse<ApiUsersServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUsersServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UsersCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var model = new ApiUsersServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Users>())).Returns(Task.FromResult(new Users()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			UpdateResponse<ApiUsersServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UsersModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUsersServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Users>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UsersUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var model = new ApiUsersServerRequestModel();
			var validatorMock = new Mock<IApiUsersServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUsersServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			UpdateResponse<ApiUsersServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUsersServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UsersUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var model = new ApiUsersServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.UsersModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UsersDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var model = new ApiUsersServerRequestModel();
			var validatorMock = new Mock<IApiUsersServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UsersDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void BadgesByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var records = new List<Badges>();
			records.Add(new Badges());
			mock.RepositoryMock.Setup(x => x.BadgesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiBadgesServerResponseModel> response = await service.BadgesByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BadgesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BadgesByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			mock.RepositoryMock.Setup(x => x.BadgesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Badges>>(new List<Badges>()));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiBadgesServerResponseModel> response = await service.BadgesByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BadgesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CommentsByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var records = new List<Comments>();
			records.Add(new Comments());
			mock.RepositoryMock.Setup(x => x.CommentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiCommentsServerResponseModel> response = await service.CommentsByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CommentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CommentsByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			mock.RepositoryMock.Setup(x => x.CommentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Comments>>(new List<Comments>()));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiCommentsServerResponseModel> response = await service.CommentsByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CommentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByLastEditorUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var records = new List<Posts>();
			records.Add(new Posts());
			mock.RepositoryMock.Setup(x => x.PostsByLastEditorUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostsServerResponseModel> response = await service.PostsByLastEditorUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByLastEditorUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByLastEditorUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			mock.RepositoryMock.Setup(x => x.PostsByLastEditorUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Posts>>(new List<Posts>()));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostsServerResponseModel> response = await service.PostsByLastEditorUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByLastEditorUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByOwnerUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var records = new List<Posts>();
			records.Add(new Posts());
			mock.RepositoryMock.Setup(x => x.PostsByOwnerUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostsServerResponseModel> response = await service.PostsByOwnerUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByOwnerUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByOwnerUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			mock.RepositoryMock.Setup(x => x.PostsByOwnerUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Posts>>(new List<Posts>()));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostsServerResponseModel> response = await service.PostsByOwnerUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByOwnerUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VotesByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var records = new List<Votes>();
			records.Add(new Votes());
			mock.RepositoryMock.Setup(x => x.VotesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiVotesServerResponseModel> response = await service.VotesByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VotesByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			mock.RepositoryMock.Setup(x => x.VotesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Votes>>(new List<Votes>()));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiVotesServerResponseModel> response = await service.VotesByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostHistoryByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			var records = new List<PostHistory>();
			records.Add(new PostHistory());
			mock.RepositoryMock.Setup(x => x.PostHistoryByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoryByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoryByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostHistoryByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUsersRepository>();
			mock.RepositoryMock.Setup(x => x.PostHistoryByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostHistory>>(new List<PostHistory>()));
			var service = new UsersService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALUsersMapperMock,
			                               mock.DALMapperMockFactory.DALBadgesMapperMock,
			                               mock.DALMapperMockFactory.DALCommentsMapperMock,
			                               mock.DALMapperMockFactory.DALPostsMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock,
			                               mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoryByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoryByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8fd3add6db13b2a3c1919a3bc1caa2ae</Hash>
</Codenesium>*/