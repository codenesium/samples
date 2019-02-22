using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallStatu")]
	[Trait("Area", "Services")]
	public partial class CallStatuServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICallStatuRepository>();
			var records = new List<CallStatu>();
			records.Add(new CallStatu());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CallStatuService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.CallStatuModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALCallStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallStatuServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICallStatuRepository>();
			var record = new CallStatu();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CallStatuService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.CallStatuModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALCallStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALCallMapperMock);

			ApiCallStatuServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICallStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CallStatu>(null));
			var service = new CallStatuService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.CallStatuModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALCallStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALCallMapperMock);

			ApiCallStatuServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallStatuRepository>();
			var model = new ApiCallStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallStatu>())).Returns(Task.FromResult(new CallStatu()));
			var service = new CallStatuService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.CallStatuModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALCallStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALCallMapperMock);

			CreateResponse<ApiCallStatuServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallStatuModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallStatuServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CallStatu>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatuCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICallStatuRepository>();
			var model = new ApiCallStatuServerRequestModel();
			var validatorMock = new Mock<IApiCallStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallStatuServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallStatuService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALCallStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALCallMapperMock);

			CreateResponse<ApiCallStatuServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallStatuServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatuCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallStatuRepository>();
			var model = new ApiCallStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallStatu>())).Returns(Task.FromResult(new CallStatu()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatu()));
			var service = new CallStatuService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.CallStatuModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALCallStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALCallMapperMock);

			UpdateResponse<ApiCallStatuServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallStatuModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallStatuServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CallStatu>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatuUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICallStatuRepository>();
			var model = new ApiCallStatuServerRequestModel();
			var validatorMock = new Mock<IApiCallStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallStatuServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatu()));
			var service = new CallStatuService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALCallStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALCallMapperMock);

			UpdateResponse<ApiCallStatuServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallStatuServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatuUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallStatuRepository>();
			var model = new ApiCallStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CallStatuService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.CallStatuModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALCallStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALCallMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CallStatuModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatuDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICallStatuRepository>();
			var model = new ApiCallStatuServerRequestModel();
			var validatorMock = new Mock<IApiCallStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallStatuService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALCallStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALCallMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatuDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void CallsByCallStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ICallStatuRepository>();
			var records = new List<Call>();
			records.Add(new Call());
			mock.RepositoryMock.Setup(x => x.CallsByCallStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CallStatuService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.CallStatuModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALCallStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallServerResponseModel> response = await service.CallsByCallStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CallsByCallStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CallsByCallStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICallStatuRepository>();
			mock.RepositoryMock.Setup(x => x.CallsByCallStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Call>>(new List<Call>()));
			var service = new CallStatuService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.CallStatuModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALCallStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallServerResponseModel> response = await service.CallsByCallStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CallsByCallStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>ade2ee3e561aacb42fc51ff7be3f228b</Hash>
</Codenesium>*/