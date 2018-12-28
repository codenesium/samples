using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ErrorLog")]
	[Trait("Area", "Services")]
	public partial class ErrorLogServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IErrorLogRepository>();
			var records = new List<ErrorLog>();
			records.Add(new ErrorLog());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ErrorLogService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
			                                  mock.DALMapperMockFactory.DALErrorLogMapperMock);

			List<ApiErrorLogServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IErrorLogRepository>();
			var record = new ErrorLog();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ErrorLogService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
			                                  mock.DALMapperMockFactory.DALErrorLogMapperMock);

			ApiErrorLogServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IErrorLogRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ErrorLog>(null));
			var service = new ErrorLogService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
			                                  mock.DALMapperMockFactory.DALErrorLogMapperMock);

			ApiErrorLogServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IErrorLogRepository>();
			var model = new ApiErrorLogServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ErrorLog>())).Returns(Task.FromResult(new ErrorLog()));
			var service = new ErrorLogService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
			                                  mock.DALMapperMockFactory.DALErrorLogMapperMock);

			CreateResponse<ApiErrorLogServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiErrorLogServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ErrorLog>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ErrorLogCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IErrorLogRepository>();
			var model = new ApiErrorLogServerRequestModel();
			var validatorMock = new Mock<IApiErrorLogServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiErrorLogServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ErrorLogService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
			                                  mock.DALMapperMockFactory.DALErrorLogMapperMock);

			CreateResponse<ApiErrorLogServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiErrorLogServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ErrorLogCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IErrorLogRepository>();
			var model = new ApiErrorLogServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ErrorLog>())).Returns(Task.FromResult(new ErrorLog()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));
			var service = new ErrorLogService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
			                                  mock.DALMapperMockFactory.DALErrorLogMapperMock);

			UpdateResponse<ApiErrorLogServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiErrorLogServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ErrorLog>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ErrorLogUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IErrorLogRepository>();
			var model = new ApiErrorLogServerRequestModel();
			var validatorMock = new Mock<IApiErrorLogServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiErrorLogServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));
			var service = new ErrorLogService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
			                                  mock.DALMapperMockFactory.DALErrorLogMapperMock);

			UpdateResponse<ApiErrorLogServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiErrorLogServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ErrorLogUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IErrorLogRepository>();
			var model = new ApiErrorLogServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ErrorLogService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
			                                  mock.DALMapperMockFactory.DALErrorLogMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ErrorLogDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IErrorLogRepository>();
			var model = new ApiErrorLogServerRequestModel();
			var validatorMock = new Mock<IApiErrorLogServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ErrorLogService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
			                                  mock.DALMapperMockFactory.DALErrorLogMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ErrorLogDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>9430513ae8cade633b09f77326bcc222</Hash>
</Codenesium>*/