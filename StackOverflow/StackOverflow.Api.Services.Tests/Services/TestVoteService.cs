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
	[Trait("Table", "Vote")]
	[Trait("Area", "Services")]
	public partial class VoteServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			var records = new List<Vote>();
			records.Add(new Vote());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			var record = new Vote();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			ApiVoteServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Vote>(null));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			ApiVoteServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();

			var model = new ApiVoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Vote>())).Returns(Task.FromResult(new Vote()));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			CreateResponse<ApiVoteServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VoteModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVoteServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Vote>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			var model = new ApiVoteServerRequestModel();
			var validatorMock = new Mock<IApiVoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			CreateResponse<ApiVoteServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVoteServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			var model = new ApiVoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Vote>())).Returns(Task.FromResult(new Vote()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vote()));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			UpdateResponse<ApiVoteServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VoteModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Vote>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			var model = new ApiVoteServerRequestModel();
			var validatorMock = new Mock<IApiVoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vote()));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			UpdateResponse<ApiVoteServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			var model = new ApiVoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VoteModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			var model = new ApiVoteServerRequestModel();
			var validatorMock = new Mock<IApiVoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			var records = new List<Vote>();
			records.Add(new Vote());
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Vote>>(new List<Vote>()));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			var records = new List<Vote>();
			records.Add(new Vote());
			mock.RepositoryMock.Setup(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.ByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			mock.RepositoryMock.Setup(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Vote>>(new List<Vote>()));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.ByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByVoteTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			var records = new List<Vote>();
			records.Add(new Vote());
			mock.RepositoryMock.Setup(x => x.ByVoteTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.ByVoteTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByVoteTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByVoteTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVoteService, IVoteRepository>();
			mock.RepositoryMock.Setup(x => x.ByVoteTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Vote>>(new List<Vote>()));
			var service = new VoteService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.VoteModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.ByVoteTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByVoteTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8af341d3e6d18a8244e9289bc53cdda6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/