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
	[Trait("Table", "Follower")]
	[Trait("Area", "Services")]
	public partial class FollowerServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();
			var records = new List<Follower>();
			records.Add(new Follower());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();
			var record = new Follower();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			ApiFollowerServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Follower>(null));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			ApiFollowerServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();

			var model = new ApiFollowerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Follower>())).Returns(Task.FromResult(new Follower()));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			CreateResponse<ApiFollowerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFollowerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Follower>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowerCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();
			var model = new ApiFollowerServerRequestModel();
			var validatorMock = new Mock<IApiFollowerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFollowerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			CreateResponse<ApiFollowerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFollowerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowerCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();
			var model = new ApiFollowerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Follower>())).Returns(Task.FromResult(new Follower()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			UpdateResponse<ApiFollowerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFollowerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Follower>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowerUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();
			var model = new ApiFollowerServerRequestModel();
			var validatorMock = new Mock<IApiFollowerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFollowerServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			UpdateResponse<ApiFollowerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFollowerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowerUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();
			var model = new ApiFollowerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowerDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();
			var model = new ApiFollowerServerRequestModel();
			var validatorMock = new Mock<IApiFollowerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowerDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByFollowedUserId_Exists()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();
			var records = new List<Follower>();
			records.Add(new Follower());
			mock.RepositoryMock.Setup(x => x.ByFollowedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.ByFollowedUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFollowedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByFollowedUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();
			mock.RepositoryMock.Setup(x => x.ByFollowedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Follower>>(new List<Follower>()));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.ByFollowedUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFollowedUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByFollowingUserId_Exists()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();
			var records = new List<Follower>();
			records.Add(new Follower());
			mock.RepositoryMock.Setup(x => x.ByFollowingUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.ByFollowingUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFollowingUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByFollowingUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IFollowerService, IFollowerRepository>();
			mock.RepositoryMock.Setup(x => x.ByFollowingUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Follower>>(new List<Follower>()));
			var service = new FollowerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FollowerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALFollowerMapperMock);

			List<ApiFollowerServerResponseModel> response = await service.ByFollowingUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFollowingUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>193da5b4022b37b74671764ca77691aa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/