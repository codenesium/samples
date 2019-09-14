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
	[Trait("Table", "OffCapability")]
	[Trait("Area", "Services")]
	public partial class OffCapabilityServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IOffCapabilityService, IOffCapabilityRepository>();
			var records = new List<OffCapability>();
			records.Add(new OffCapability());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new OffCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.OffCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALOffCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			List<ApiOffCapabilityServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IOffCapabilityService, IOffCapabilityRepository>();
			var record = new OffCapability();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new OffCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.OffCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALOffCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			ApiOffCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IOffCapabilityService, IOffCapabilityRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<OffCapability>(null));
			var service = new OffCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.OffCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALOffCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			ApiOffCapabilityServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IOffCapabilityService, IOffCapabilityRepository>();

			var model = new ApiOffCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OffCapability>())).Returns(Task.FromResult(new OffCapability()));
			var service = new OffCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.OffCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALOffCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			CreateResponse<ApiOffCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OffCapabilityModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOffCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<OffCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OffCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IOffCapabilityService, IOffCapabilityRepository>();
			var model = new ApiOffCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiOffCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOffCapabilityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OffCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALOffCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			CreateResponse<ApiOffCapabilityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOffCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OffCapabilityCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IOffCapabilityService, IOffCapabilityRepository>();
			var model = new ApiOffCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OffCapability>())).Returns(Task.FromResult(new OffCapability()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OffCapability()));
			var service = new OffCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.OffCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALOffCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			UpdateResponse<ApiOffCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OffCapabilityModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOffCapabilityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<OffCapability>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OffCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IOffCapabilityService, IOffCapabilityRepository>();
			var model = new ApiOffCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiOffCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOffCapabilityServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OffCapability()));
			var service = new OffCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALOffCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			UpdateResponse<ApiOffCapabilityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOffCapabilityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OffCapabilityUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IOffCapabilityService, IOffCapabilityRepository>();
			var model = new ApiOffCapabilityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new OffCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.OffCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALOffCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.OffCapabilityModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OffCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IOffCapabilityService, IOffCapabilityRepository>();
			var model = new ApiOffCapabilityServerRequestModel();
			var validatorMock = new Mock<IApiOffCapabilityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OffCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALOffCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OffCapabilityDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void OfficerCapabilitiesByCapabilityId_Exists()
		{
			var mock = new ServiceMockFacade<IOffCapabilityService, IOffCapabilityRepository>();
			var records = new List<OfficerCapabilities>();
			records.Add(new OfficerCapabilities());
			mock.RepositoryMock.Setup(x => x.OfficerCapabilitiesByCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new OffCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.OffCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALOffCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			List<ApiOfficerCapabilitiesServerResponseModel> response = await service.OfficerCapabilitiesByCapabilityId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.OfficerCapabilitiesByCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void OfficerCapabilitiesByCapabilityId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IOffCapabilityService, IOffCapabilityRepository>();
			mock.RepositoryMock.Setup(x => x.OfficerCapabilitiesByCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<OfficerCapabilities>>(new List<OfficerCapabilities>()));
			var service = new OffCapabilityService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.OffCapabilityModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALOffCapabilityMapperMock,
			                                       mock.DALMapperMockFactory.DALOfficerCapabilitiesMapperMock);

			List<ApiOfficerCapabilitiesServerResponseModel> response = await service.OfficerCapabilitiesByCapabilityId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.OfficerCapabilitiesByCapabilityId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>d77a3df6c4675ede6b0e664b11a8b0e2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/