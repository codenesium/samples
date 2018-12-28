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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "Services")]
	public partial class RowVersionCheckServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var records = new List<RowVersionCheck>();
			records.Add(new RowVersionCheck());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			List<ApiRowVersionCheckServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var record = new RowVersionCheck();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			ApiRowVersionCheckServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<RowVersionCheck>(null));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			ApiRowVersionCheckServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var model = new ApiRowVersionCheckServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<RowVersionCheck>())).Returns(Task.FromResult(new RowVersionCheck()));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			CreateResponse<ApiRowVersionCheckServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiRowVersionCheckServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<RowVersionCheck>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RowVersionCheckCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var model = new ApiRowVersionCheckServerRequestModel();
			var validatorMock = new Mock<IApiRowVersionCheckServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiRowVersionCheckServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			CreateResponse<ApiRowVersionCheckServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiRowVersionCheckServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RowVersionCheckCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var model = new ApiRowVersionCheckServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<RowVersionCheck>())).Returns(Task.FromResult(new RowVersionCheck()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new RowVersionCheck()));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			UpdateResponse<ApiRowVersionCheckServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<RowVersionCheck>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RowVersionCheckUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var model = new ApiRowVersionCheckServerRequestModel();
			var validatorMock = new Mock<IApiRowVersionCheckServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new RowVersionCheck()));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			UpdateResponse<ApiRowVersionCheckServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RowVersionCheckUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var model = new ApiRowVersionCheckServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RowVersionCheckDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var model = new ApiRowVersionCheckServerRequestModel();
			var validatorMock = new Mock<IApiRowVersionCheckServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<RowVersionCheckDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>02193cc4e789d9165f045188f32058f4</Hash>
</Codenesium>*/