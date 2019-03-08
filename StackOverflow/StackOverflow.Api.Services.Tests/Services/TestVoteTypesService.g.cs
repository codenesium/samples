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
	[Trait("Table", "VoteTypes")]
	[Trait("Area", "Services")]
	public partial class VoteTypesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var records = new List<VoteTypes>();
			records.Add(new VoteTypes());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVotesMapperMock);

			List<ApiVoteTypesServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var record = new VoteTypes();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVotesMapperMock);

			ApiVoteTypesServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VoteTypes>(null));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVotesMapperMock);

			ApiVoteTypesServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var model = new ApiVoteTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VoteTypes>())).Returns(Task.FromResult(new VoteTypes()));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVotesMapperMock);

			CreateResponse<ApiVoteTypesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VoteTypes>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypesCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var model = new ApiVoteTypesServerRequestModel();
			var validatorMock = new Mock<IApiVoteTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVotesMapperMock);

			CreateResponse<ApiVoteTypesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypesCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var model = new ApiVoteTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VoteTypes>())).Returns(Task.FromResult(new VoteTypes()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteTypes()));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVotesMapperMock);

			UpdateResponse<ApiVoteTypesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VoteTypes>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypesUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var model = new ApiVoteTypesServerRequestModel();
			var validatorMock = new Mock<IApiVoteTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypesServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteTypes()));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVotesMapperMock);

			UpdateResponse<ApiVoteTypesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypesUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var model = new ApiVoteTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVotesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypesDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var model = new ApiVoteTypesServerRequestModel();
			var validatorMock = new Mock<IApiVoteTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVotesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypesDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void VotesByVoteTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var records = new List<Votes>();
			records.Add(new Votes());
			mock.RepositoryMock.Setup(x => x.VotesByVoteTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVotesMapperMock);

			List<ApiVotesServerResponseModel> response = await service.VotesByVoteTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByVoteTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VotesByVoteTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			mock.RepositoryMock.Setup(x => x.VotesByVoteTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Votes>>(new List<Votes>()));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVotesMapperMock);

			List<ApiVotesServerResponseModel> response = await service.VotesByVoteTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByVoteTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>24d2e557122d96fed9bfee5e616d8b2d</Hash>
</Codenesium>*/