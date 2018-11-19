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
	[Trait("Table", "Reply")]
	[Trait("Area", "Services")]
	public partial class ReplyServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IReplyRepository>();
			var records = new List<Reply>();
			records.Add(new Reply());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			List<ApiReplyServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IReplyRepository>();
			var record = new Reply();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			ApiReplyServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IReplyRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Reply>(null));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			ApiReplyServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IReplyRepository>();
			var model = new ApiReplyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Reply>())).Returns(Task.FromResult(new Reply()));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			CreateResponse<ApiReplyServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiReplyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Reply>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IReplyRepository>();
			var model = new ApiReplyServerRequestModel();
			var validatorMock = new Mock<IApiReplyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiReplyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			CreateResponse<ApiReplyServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiReplyServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IReplyRepository>();
			var model = new ApiReplyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Reply>())).Returns(Task.FromResult(new Reply()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			UpdateResponse<ApiReplyServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiReplyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Reply>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IReplyRepository>();
			var model = new ApiReplyServerRequestModel();
			var validatorMock = new Mock<IApiReplyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiReplyServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			UpdateResponse<ApiReplyServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiReplyServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IReplyRepository>();
			var model = new ApiReplyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IReplyRepository>();
			var model = new ApiReplyServerRequestModel();
			var validatorMock = new Mock<IApiReplyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByReplierUserId_Exists()
		{
			var mock = new ServiceMockFacade<IReplyRepository>();
			var records = new List<Reply>();
			records.Add(new Reply());
			mock.RepositoryMock.Setup(x => x.ByReplierUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			List<ApiReplyServerResponseModel> response = await service.ByReplierUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByReplierUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByReplierUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IReplyRepository>();
			mock.RepositoryMock.Setup(x => x.ByReplierUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Reply>>(new List<Reply>()));
			var service = new ReplyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLReplyMapperMock,
			                               mock.DALMapperMockFactory.DALReplyMapperMock);

			List<ApiReplyServerResponseModel> response = await service.ByReplierUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByReplierUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>487c8988d69ce731157b67d835ab699f</Hash>
</Codenesium>*/