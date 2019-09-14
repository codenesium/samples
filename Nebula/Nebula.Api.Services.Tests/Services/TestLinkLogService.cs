using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkLog")]
	[Trait("Area", "Services")]
	public partial class LinkLogServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ILinkLogService, ILinkLogRepository>();
			var records = new List<LinkLog>();
			records.Add(new LinkLog());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new LinkLogService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALLinkLogMapperMock);

			List<ApiLinkLogServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ILinkLogService, ILinkLogRepository>();
			var record = new LinkLog();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LinkLogService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALLinkLogMapperMock);

			ApiLinkLogServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ILinkLogService, ILinkLogRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LinkLog>(null));
			var service = new LinkLogService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALLinkLogMapperMock);

			ApiLinkLogServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ILinkLogService, ILinkLogRepository>();

			var model = new ApiLinkLogServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkLog>())).Returns(Task.FromResult(new LinkLog()));
			var service = new LinkLogService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALLinkLogMapperMock);

			CreateResponse<ApiLinkLogServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkLogServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LinkLog>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkLogCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ILinkLogService, ILinkLogRepository>();
			var model = new ApiLinkLogServerRequestModel();
			var validatorMock = new Mock<IApiLinkLogServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkLogServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkLogService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALLinkLogMapperMock);

			CreateResponse<ApiLinkLogServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkLogServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkLogCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ILinkLogService, ILinkLogRepository>();
			var model = new ApiLinkLogServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkLog>())).Returns(Task.FromResult(new LinkLog()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkLog()));
			var service = new LinkLogService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALLinkLogMapperMock);

			UpdateResponse<ApiLinkLogServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkLogServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LinkLog>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkLogUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ILinkLogService, ILinkLogRepository>();
			var model = new ApiLinkLogServerRequestModel();
			var validatorMock = new Mock<IApiLinkLogServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkLogServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkLog()));
			var service = new LinkLogService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALLinkLogMapperMock);

			UpdateResponse<ApiLinkLogServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkLogServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkLogUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ILinkLogService, ILinkLogRepository>();
			var model = new ApiLinkLogServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LinkLogService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALLinkLogMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LinkLogModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkLogDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ILinkLogService, ILinkLogRepository>();
			var model = new ApiLinkLogServerRequestModel();
			var validatorMock = new Mock<IApiLinkLogServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkLogService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALLinkLogMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkLogDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>d6c2e818500d72e6de1b3750278e0fd5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/