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
	[Trait("Table", "Following")]
	[Trait("Area", "Services")]
	public partial class FollowingServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var records = new List<Following>();
			records.Add(new Following());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			List<ApiFollowingServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var record = new Following();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			ApiFollowingServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Following>(null));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			ApiFollowingServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var model = new ApiFollowingServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Following>())).Returns(Task.FromResult(new Following()));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			CreateResponse<ApiFollowingServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFollowingServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Following>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowingCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var model = new ApiFollowingServerRequestModel();
			var validatorMock = new Mock<IApiFollowingServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFollowingServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			CreateResponse<ApiFollowingServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFollowingServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowingCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var model = new ApiFollowingServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Following>())).Returns(Task.FromResult(new Following()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Following()));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			UpdateResponse<ApiFollowingServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFollowingServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Following>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowingUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var model = new ApiFollowingServerRequestModel();
			var validatorMock = new Mock<IApiFollowingServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFollowingServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Following()));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			UpdateResponse<ApiFollowingServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFollowingServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowingUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var model = new ApiFollowingServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.FollowingModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowingDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IFollowingRepository>();
			var model = new ApiFollowingServerRequestModel();
			var validatorMock = new Mock<IApiFollowingServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new FollowingService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLFollowingMapperMock,
			                                   mock.DALMapperMockFactory.DALFollowingMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FollowingDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>2db8c696861f28cbffe1f28256965c08</Hash>
</Codenesium>*/