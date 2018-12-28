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
	[Trait("Table", "Comment")]
	[Trait("Area", "Services")]
	public partial class CommentServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var records = new List<Comment>();
			records.Add(new Comment());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			List<ApiCommentServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var record = new Comment();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			ApiCommentServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Comment>(null));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			ApiCommentServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var model = new ApiCommentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Comment>())).Returns(Task.FromResult(new Comment()));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			CreateResponse<ApiCommentServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CommentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCommentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Comment>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var model = new ApiCommentServerRequestModel();
			var validatorMock = new Mock<IApiCommentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCommentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			CreateResponse<ApiCommentServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCommentServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var model = new ApiCommentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Comment>())).Returns(Task.FromResult(new Comment()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			UpdateResponse<ApiCommentServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CommentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Comment>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var model = new ApiCommentServerRequestModel();
			var validatorMock = new Mock<IApiCommentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			UpdateResponse<ApiCommentServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var model = new ApiCommentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CommentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var model = new ApiCommentServerRequestModel();
			var validatorMock = new Mock<IApiCommentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>3db12aa6fb0cf47fcf1f0042b2925a88</Hash>
</Codenesium>*/