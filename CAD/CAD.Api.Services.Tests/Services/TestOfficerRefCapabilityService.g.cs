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
	[Trait("Table", "OfficerRefCapability")]
	[Trait("Area", "Services")]
	public partial class OfficerRefCapabilityServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IOfficerRefCapabilityRepository>();
			var records = new List<OfficerRefCapability>();
			records.Add(new OfficerRefCapability());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new OfficerRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.OfficerRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			List<ApiOfficerRefCapabilityServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IOfficerRefCapabilityRepository>();
			var record = new OfficerRefCapability();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new OfficerRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.OfficerRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			ApiOfficerRefCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IOfficerRefCapabilityRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<OfficerRefCapability>(null));
			var service = new OfficerRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.OfficerRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			ApiOfficerRefCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerRefCapabilityRepository>();
			var model = new ApiOfficerRefCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OfficerRefCapability>())).Returns(Task.FromResult(new OfficerRefCapability()));
			var service = new OfficerRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.OfficerRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			CreateResponse<ApiOfficerRefCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OfficerRefCapabilityModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<OfficerRefCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerRefCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerRefCapabilityRepository>();
			var model = new ApiOfficerRefCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiOfficerRefCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerRefCapabilityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OfficerRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              validatorMock.Object,
			                                              mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			CreateResponse<ApiOfficerRefCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerRefCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerRefCapabilityRepository>();
			var model = new ApiOfficerRefCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OfficerRefCapability>())).Returns(Task.FromResult(new OfficerRefCapability()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OfficerRefCapability()));
			var service = new OfficerRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.OfficerRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			UpdateResponse<ApiOfficerRefCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OfficerRefCapabilityModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<OfficerRefCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerRefCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerRefCapabilityRepository>();
			var model = new ApiOfficerRefCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiOfficerRefCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerRefCapabilityServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OfficerRefCapability()));
			var service = new OfficerRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              validatorMock.Object,
			                                              mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			UpdateResponse<ApiOfficerRefCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerRefCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerRefCapabilityRepository>();
			var model = new ApiOfficerRefCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new OfficerRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              mock.ModelValidatorMockFactory.OfficerRefCapabilityModelValidatorMock.Object,
			                                              mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.OfficerRefCapabilityModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerRefCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerRefCapabilityRepository>();
			var model = new ApiOfficerRefCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiOfficerRefCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OfficerRefCapabilityService(mock.LoggerMock.Object,
			                                              mock.MediatorMock.Object,
			                                              mock.RepositoryMock.Object,
			                                              validatorMock.Object,
			                                              mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerRefCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>bd08d06579bf5e0e0d88bc0790a7cb5f</Hash>
</Codenesium>*/