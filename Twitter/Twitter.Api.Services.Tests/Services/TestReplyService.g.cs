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
		public async void Create()
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
			mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiReplyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Reply>()));
		}

		[Fact]
		public async void Update()
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
			mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiReplyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Reply>()));
		}

		[Fact]
		public async void Delete()
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
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ReplyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
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
    <Hash>f4e987f8c6f473f4f2ba6cf9fbd43776</Hash>
</Codenesium>*/