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
	[Trait("Table", "Votes")]
	[Trait("Area", "Services")]
	public partial class VotesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var records = new List<Votes>();
			records.Add(new Votes());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			List<ApiVotesServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var record = new Votes();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			ApiVotesServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Votes>(null));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			ApiVotesServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var model = new ApiVotesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Votes>())).Returns(Task.FromResult(new Votes()));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			CreateResponse<ApiVotesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VotesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVotesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Votes>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VotesCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var model = new ApiVotesServerRequestModel();
			var validatorMock = new Mock<IApiVotesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVotesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			CreateResponse<ApiVotesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVotesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VotesCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var model = new ApiVotesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Votes>())).Returns(Task.FromResult(new Votes()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Votes()));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			UpdateResponse<ApiVotesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VotesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVotesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Votes>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VotesUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var model = new ApiVotesServerRequestModel();
			var validatorMock = new Mock<IApiVotesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVotesServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Votes()));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			UpdateResponse<ApiVotesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVotesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VotesUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var model = new ApiVotesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VotesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VotesDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var model = new ApiVotesServerRequestModel();
			var validatorMock = new Mock<IApiVotesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VotesDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var records = new List<Votes>();
			records.Add(new Votes());
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			List<ApiVotesServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Votes>>(new List<Votes>()));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			List<ApiVotesServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var records = new List<Votes>();
			records.Add(new Votes());
			mock.RepositoryMock.Setup(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			List<ApiVotesServerResponseModel> response = await service.ByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			mock.RepositoryMock.Setup(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Votes>>(new List<Votes>()));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			List<ApiVotesServerResponseModel> response = await service.ByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByVoteTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var records = new List<Votes>();
			records.Add(new Votes());
			mock.RepositoryMock.Setup(x => x.ByVoteTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			List<ApiVotesServerResponseModel> response = await service.ByVoteTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByVoteTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByVoteTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			mock.RepositoryMock.Setup(x => x.ByVoteTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Votes>>(new List<Votes>()));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			List<ApiVotesServerResponseModel> response = await service.ByVoteTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByVoteTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>1297db587c0922e4ab5dc563548119b5</Hash>
</Codenesium>*/