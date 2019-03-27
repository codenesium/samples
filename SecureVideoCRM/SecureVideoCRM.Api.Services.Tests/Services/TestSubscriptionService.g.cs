using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SecureVideoCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Subscription")]
	[Trait("Area", "Services")]
	public partial class SubscriptionServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISubscriptionRepository>();
			var records = new List<Subscription>();
			records.Add(new Subscription());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new SubscriptionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSubscriptionMapperMock);

			List<ApiSubscriptionServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISubscriptionRepository>();
			var record = new Subscription();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SubscriptionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSubscriptionMapperMock);

			ApiSubscriptionServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISubscriptionRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Subscription>(null));
			var service = new SubscriptionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSubscriptionMapperMock);

			ApiSubscriptionServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ISubscriptionRepository>();
			var model = new ApiSubscriptionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Subscription>())).Returns(Task.FromResult(new Subscription()));
			var service = new SubscriptionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSubscriptionMapperMock);

			CreateResponse<ApiSubscriptionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSubscriptionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Subscription>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SubscriptionCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ISubscriptionRepository>();
			var model = new ApiSubscriptionServerRequestModel();
			var validatorMock = new Mock<IApiSubscriptionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSubscriptionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SubscriptionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSubscriptionMapperMock);

			CreateResponse<ApiSubscriptionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSubscriptionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SubscriptionCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ISubscriptionRepository>();
			var model = new ApiSubscriptionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Subscription>())).Returns(Task.FromResult(new Subscription()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Subscription()));
			var service = new SubscriptionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSubscriptionMapperMock);

			UpdateResponse<ApiSubscriptionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSubscriptionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Subscription>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SubscriptionUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ISubscriptionRepository>();
			var model = new ApiSubscriptionServerRequestModel();
			var validatorMock = new Mock<IApiSubscriptionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSubscriptionServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Subscription()));
			var service = new SubscriptionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSubscriptionMapperMock);

			UpdateResponse<ApiSubscriptionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSubscriptionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SubscriptionUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ISubscriptionRepository>();
			var model = new ApiSubscriptionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SubscriptionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSubscriptionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SubscriptionDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ISubscriptionRepository>();
			var model = new ApiSubscriptionServerRequestModel();
			var validatorMock = new Mock<IApiSubscriptionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SubscriptionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSubscriptionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SubscriptionDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>a4770d0e9b38a44157fd507b62452b14</Hash>
</Codenesium>*/