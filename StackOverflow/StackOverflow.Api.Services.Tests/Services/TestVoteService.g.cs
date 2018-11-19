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
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Vote")]
	[Trait("Area", "Services")]
	public partial class VoteServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVoteRepository>();
			var records = new List<Vote>();
			records.Add(new Vote());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLVoteMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVoteRepository>();
			var record = new Vote();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLVoteMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			ApiVoteServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVoteRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Vote>(null));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLVoteMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			ApiVoteServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVoteRepository>();
			var model = new ApiVoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Vote>())).Returns(Task.FromResult(new Vote()));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLVoteMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			CreateResponse<ApiVoteServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VoteModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVoteServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Vote>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVoteRepository>();
			var model = new ApiVoteServerRequestModel();
			var validatorMock = new Mock<IApiVoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLVoteMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			CreateResponse<ApiVoteServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVoteServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVoteRepository>();
			var model = new ApiVoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Vote>())).Returns(Task.FromResult(new Vote()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vote()));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLVoteMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			UpdateResponse<ApiVoteServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VoteModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Vote>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVoteRepository>();
			var model = new ApiVoteServerRequestModel();
			var validatorMock = new Mock<IApiVoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vote()));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLVoteMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			UpdateResponse<ApiVoteServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVoteRepository>();
			var model = new ApiVoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLVoteMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VoteModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVoteRepository>();
			var model = new ApiVoteServerRequestModel();
			var validatorMock = new Mock<IApiVoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLVoteMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IVoteRepository>();
			var records = new List<Vote>();
			records.Add(new Vote());
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLVoteMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVoteRepository>();
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Vote>>(new List<Vote>()));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLVoteMapperMock,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8d34347e13d9571f5ff9fbaf825f9c32</Hash>
</Codenesium>*/