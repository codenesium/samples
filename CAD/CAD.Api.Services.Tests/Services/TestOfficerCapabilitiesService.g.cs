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
	[Trait("Table", "OfficerCapabilities")]
	[Trait("Area", "Services")]
	public partial class OfficerCapabilitiesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilitiesRepository>();
			var records = new List<OfficerCapabilities>();
			records.Add(new OfficerCapabilities());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new OfficerCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.OfficerCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			List<ApiOfficerCapabilitiesServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilitiesRepository>();
			var record = new OfficerCapabilities();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new OfficerCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.OfficerCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			ApiOfficerCapabilitiesServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilitiesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<OfficerCapabilities>(null));
			var service = new OfficerCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.OfficerCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			ApiOfficerCapabilitiesServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilitiesRepository>();
			var model = new ApiOfficerCapabilitiesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OfficerCapabilities>())).Returns(Task.FromResult(new OfficerCapabilities()));
			var service = new OfficerCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.OfficerCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			CreateResponse<ApiOfficerCapabilitiesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OfficerCapabilitiesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<OfficerCapabilities>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilitiesCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilitiesRepository>();
			var model = new ApiOfficerCapabilitiesServerRequestModel();
			var validatorMock = new Mock<IApiOfficerCapabilitiesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerCapabilitiesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OfficerCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			CreateResponse<ApiOfficerCapabilitiesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilitiesCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilitiesRepository>();
			var model = new ApiOfficerCapabilitiesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OfficerCapabilities>())).Returns(Task.FromResult(new OfficerCapabilities()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OfficerCapabilities()));
			var service = new OfficerCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.OfficerCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			UpdateResponse<ApiOfficerCapabilitiesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OfficerCapabilitiesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<OfficerCapabilities>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilitiesUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilitiesRepository>();
			var model = new ApiOfficerCapabilitiesServerRequestModel();
			var validatorMock = new Mock<IApiOfficerCapabilitiesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilitiesServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OfficerCapabilities()));
			var service = new OfficerCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			UpdateResponse<ApiOfficerCapabilitiesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilitiesUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilitiesRepository>();
			var model = new ApiOfficerCapabilitiesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new OfficerCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.OfficerCapabilitiesModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.OfficerCapabilitiesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilitiesDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilitiesRepository>();
			var model = new ApiOfficerCapabilitiesServerRequestModel();
			var validatorMock = new Mock<IApiOfficerCapabilitiesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OfficerCapabilitiesService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilitiesDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>6263784b3c42f119b5b9ace353acc9c8</Hash>
</Codenesium>*/