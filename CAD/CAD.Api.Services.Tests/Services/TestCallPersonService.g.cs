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
	[Trait("Table", "CallPerson")]
	[Trait("Area", "Services")]
	public partial class CallPersonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICallPersonRepository>();
			var records = new List<CallPerson>();
			records.Add(new CallPerson());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CallPersonService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallPersonModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			List<ApiCallPersonServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICallPersonRepository>();
			var record = new CallPerson();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CallPersonService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallPersonModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			ApiCallPersonServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICallPersonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CallPerson>(null));
			var service = new CallPersonService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallPersonModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			ApiCallPersonServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallPersonRepository>();
			var model = new ApiCallPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallPerson>())).Returns(Task.FromResult(new CallPerson()));
			var service = new CallPersonService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallPersonModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			CreateResponse<ApiCallPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallPersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CallPerson>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallPersonCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICallPersonRepository>();
			var model = new ApiCallPersonServerRequestModel();
			var validatorMock = new Mock<IApiCallPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallPersonService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			CreateResponse<ApiCallPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallPersonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallPersonCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallPersonRepository>();
			var model = new ApiCallPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallPerson>())).Returns(Task.FromResult(new CallPerson()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallPerson()));
			var service = new CallPersonService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallPersonModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			UpdateResponse<ApiCallPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallPersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CallPerson>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallPersonUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICallPersonRepository>();
			var model = new ApiCallPersonServerRequestModel();
			var validatorMock = new Mock<IApiCallPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallPersonServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallPerson()));
			var service = new CallPersonService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			UpdateResponse<ApiCallPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallPersonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallPersonUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallPersonRepository>();
			var model = new ApiCallPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CallPersonService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallPersonModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CallPersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallPersonDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICallPersonRepository>();
			var model = new ApiCallPersonServerRequestModel();
			var validatorMock = new Mock<IApiCallPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallPersonService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallPersonDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>e4ceaa30077680a02f236ee27543da70</Hash>
</Codenesium>*/