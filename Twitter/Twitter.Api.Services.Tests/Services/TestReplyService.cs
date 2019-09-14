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
	[Trait("Table", "Reply")]
	[Trait("Area", "Services")]
	public partial class ReplyServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IReplyService, IReplyRepository>();
			var records = new List<Reply>();
			records.Add(new Reply());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			List<ApiReplyServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IReplyService, IReplyRepository>();
			var record = new Reply();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			ApiReplyServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IReplyService, IReplyRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Reply>(null));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			ApiReplyServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IReplyService, IReplyRepository>();

			var model = new ApiReplyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Reply>())).Returns(Task.FromResult(new Reply()));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			CreateResponse<ApiReplyServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiReplyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Reply>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ReplyCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IReplyService, IReplyRepository>();
			var model = new ApiReplyServerRequestModel();
			var validatorMock = new Mock<IApiReplyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiReplyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			CreateResponse<ApiReplyServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiReplyServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ReplyCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IReplyService, IReplyRepository>();
			var model = new ApiReplyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Reply>())).Returns(Task.FromResult(new Reply()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			UpdateResponse<ApiReplyServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiReplyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Reply>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ReplyUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IReplyService, IReplyRepository>();
			var model = new ApiReplyServerRequestModel();
			var validatorMock = new Mock<IApiReplyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiReplyServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			UpdateResponse<ApiReplyServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiReplyServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ReplyUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IReplyService, IReplyRepository>();
			var model = new ApiReplyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ReplyDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IReplyService, IReplyRepository>();
			var model = new ApiReplyServerRequestModel();
			var validatorMock = new Mock<IApiReplyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ReplyDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByReplierUserId_Exists()
		{
			var mock = new ServiceMockFacade<IReplyService, IReplyRepository>();
			var records = new List<Reply>();
			records.Add(new Reply());
			mock.RepositoryMock.Setup(x => x.ByReplierUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			List<ApiReplyServerResponseModel> response = await service.ByReplierUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByReplierUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByReplierUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IReplyService, IReplyRepository>();
			mock.RepositoryMock.Setup(x => x.ByReplierUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Reply>>(new List<Reply>()));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			List<ApiReplyServerResponseModel> response = await service.ByReplierUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByReplierUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b6096759e4b90799cfcd78e50e94737b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/