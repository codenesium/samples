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
	[Trait("Table", "OfficerCapability")]
	[Trait("Area", "Services")]
	public partial class OfficerCapabilityServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilityRepository>();
			var records = new List<OfficerCapability>();
			records.Add(new OfficerCapability());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new OfficerCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.OfficerCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			List<ApiOfficerCapabilityServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilityRepository>();
			var record = new OfficerCapability();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new OfficerCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.OfficerCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			ApiOfficerCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilityRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<OfficerCapability>(null));
			var service = new OfficerCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.OfficerCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			ApiOfficerCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilityRepository>();
			var model = new ApiOfficerCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OfficerCapability>())).Returns(Task.FromResult(new OfficerCapability()));
			var service = new OfficerCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.OfficerCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			CreateResponse<ApiOfficerCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OfficerCapabilityModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<OfficerCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilityRepository>();
			var model = new ApiOfficerCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiOfficerCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerCapabilityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OfficerCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			CreateResponse<ApiOfficerCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOfficerCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilityRepository>();
			var model = new ApiOfficerCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OfficerCapability>())).Returns(Task.FromResult(new OfficerCapability()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OfficerCapability()));
			var service = new OfficerCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.OfficerCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			UpdateResponse<ApiOfficerCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OfficerCapabilityModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<OfficerCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilityRepository>();
			var model = new ApiOfficerCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiOfficerCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilityServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OfficerCapability()));
			var service = new OfficerCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			UpdateResponse<ApiOfficerCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilityRepository>();
			var model = new ApiOfficerCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new OfficerCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.OfficerCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.OfficerCapabilityModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilityRepository>();
			var model = new ApiOfficerCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiOfficerCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OfficerCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OfficerCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void OfficerRefCapabilitiesByCapabilityId_Exists()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilityRepository>();
			var records = new List<OfficerRefCapability>();
			records.Add(new OfficerRefCapability());
			mock.RepositoryMock.Setup(x => x.OfficerRefCapabilitiesByCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new OfficerCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.OfficerCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			List<ApiOfficerRefCapabilityServerResponseModel> response = await service.OfficerRefCapabilitiesByCapabilityId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.OfficerRefCapabilitiesByCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void OfficerRefCapabilitiesByCapabilityId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IOfficerCapabilityRepository>();
			mock.RepositoryMock.Setup(x => x.OfficerRefCapabilitiesByCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<OfficerRefCapability>>(new List<OfficerRefCapability>()));
			var service = new OfficerCapabilityService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.OfficerCapabilityModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALOfficerCapabilityMapperMock,
			                                           mock.DALMapperMockFactory.DALOfficerRefCapabilityMapperMock);

			List<ApiOfficerRefCapabilityServerResponseModel> response = await service.OfficerRefCapabilitiesByCapabilityId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.OfficerRefCapabilitiesByCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>987fa3ea81838a60053828e7ff279e1d</Hash>
</Codenesium>*/