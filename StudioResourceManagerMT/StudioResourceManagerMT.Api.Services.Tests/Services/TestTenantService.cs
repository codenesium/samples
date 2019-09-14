using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "Services")]
	public partial class TenantServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<Tenant>();
			records.Add(new Tenant());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTenantServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var record = new Tenant();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			ApiTenantServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Tenant>(null));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			ApiTenantServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();

			var model = new ApiTenantServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tenant>())).Returns(Task.FromResult(new Tenant()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			CreateResponse<ApiTenantServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TenantModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTenantServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Tenant>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TenantCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var model = new ApiTenantServerRequestModel();
			var validatorMock = new Mock<IApiTenantServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTenantServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			CreateResponse<ApiTenantServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTenantServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TenantCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var model = new ApiTenantServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tenant>())).Returns(Task.FromResult(new Tenant()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tenant()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			UpdateResponse<ApiTenantServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TenantModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTenantServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Tenant>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TenantUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var model = new ApiTenantServerRequestModel();
			var validatorMock = new Mock<IApiTenantServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTenantServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tenant()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			UpdateResponse<ApiTenantServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTenantServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TenantUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var model = new ApiTenantServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TenantModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TenantDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var model = new ApiTenantServerRequestModel();
			var validatorMock = new Mock<IApiTenantServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TenantDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void AdminsByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<Admin>();
			records.Add(new Admin());
			mock.RepositoryMock.Setup(x => x.AdminsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiAdminServerResponseModel> response = await service.AdminsByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.AdminsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void AdminsByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.AdminsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Admin>>(new List<Admin>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiAdminServerResponseModel> response = await service.AdminsByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.AdminsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventsByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<Event>();
			records.Add(new Event());
			mock.RepositoryMock.Setup(x => x.EventsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventServerResponseModel> response = await service.EventsByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventsByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.EventsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Event>>(new List<Event>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventServerResponseModel> response = await service.EventsByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventStatusByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<EventStatus>();
			records.Add(new EventStatus());
			mock.RepositoryMock.Setup(x => x.EventStatusByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventStatusServerResponseModel> response = await service.EventStatusByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStatusByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventStatusByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.EventStatusByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventStatus>>(new List<EventStatus>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventStatusServerResponseModel> response = await service.EventStatusByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStatusByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventStudentsByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<EventStudent>();
			records.Add(new EventStudent());
			mock.RepositoryMock.Setup(x => x.EventStudentsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventStudentServerResponseModel> response = await service.EventStudentsByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStudentsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventStudentsByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.EventStudentsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventStudent>>(new List<EventStudent>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventStudentServerResponseModel> response = await service.EventStudentsByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStudentsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventTeachersByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<EventTeacher>();
			records.Add(new EventTeacher());
			mock.RepositoryMock.Setup(x => x.EventTeachersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventTeacherServerResponseModel> response = await service.EventTeachersByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventTeachersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventTeachersByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.EventTeachersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventTeacher>>(new List<EventTeacher>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventTeacherServerResponseModel> response = await service.EventTeachersByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventTeachersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void FamiliesByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<Family>();
			records.Add(new Family());
			mock.RepositoryMock.Setup(x => x.FamiliesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiFamilyServerResponseModel> response = await service.FamiliesByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.FamiliesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void FamiliesByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.FamiliesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Family>>(new List<Family>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiFamilyServerResponseModel> response = await service.FamiliesByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.FamiliesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RatesByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<Rate>();
			records.Add(new Rate());
			mock.RepositoryMock.Setup(x => x.RatesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiRateServerResponseModel> response = await service.RatesByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.RatesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RatesByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.RatesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Rate>>(new List<Rate>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiRateServerResponseModel> response = await service.RatesByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.RatesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpacesByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<Space>();
			records.Add(new Space());
			mock.RepositoryMock.Setup(x => x.SpacesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceServerResponseModel> response = await service.SpacesByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SpacesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpacesByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.SpacesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Space>>(new List<Space>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceServerResponseModel> response = await service.SpacesByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SpacesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceFeaturesByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<SpaceFeature>();
			records.Add(new SpaceFeature());
			mock.RepositoryMock.Setup(x => x.SpaceFeaturesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceFeatureServerResponseModel> response = await service.SpaceFeaturesByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceFeaturesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceFeaturesByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.SpaceFeaturesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SpaceFeature>>(new List<SpaceFeature>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceFeatureServerResponseModel> response = await service.SpaceFeaturesByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceFeaturesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceSpaceFeaturesByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<SpaceSpaceFeature>();
			records.Add(new SpaceSpaceFeature());
			mock.RepositoryMock.Setup(x => x.SpaceSpaceFeaturesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceSpaceFeatureServerResponseModel> response = await service.SpaceSpaceFeaturesByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceSpaceFeaturesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceSpaceFeaturesByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.SpaceSpaceFeaturesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SpaceSpaceFeature>>(new List<SpaceSpaceFeature>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceSpaceFeatureServerResponseModel> response = await service.SpaceSpaceFeaturesByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceSpaceFeaturesByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StudentsByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<Student>();
			records.Add(new Student());
			mock.RepositoryMock.Setup(x => x.StudentsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiStudentServerResponseModel> response = await service.StudentsByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.StudentsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StudentsByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.StudentsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Student>>(new List<Student>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiStudentServerResponseModel> response = await service.StudentsByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.StudentsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StudiosByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<Studio>();
			records.Add(new Studio());
			mock.RepositoryMock.Setup(x => x.StudiosByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiStudioServerResponseModel> response = await service.StudiosByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.StudiosByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StudiosByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.StudiosByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Studio>>(new List<Studio>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiStudioServerResponseModel> response = await service.StudiosByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.StudiosByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeachersByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<Teacher>();
			records.Add(new Teacher());
			mock.RepositoryMock.Setup(x => x.TeachersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherServerResponseModel> response = await service.TeachersByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeachersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeachersByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.TeachersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Teacher>>(new List<Teacher>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherServerResponseModel> response = await service.TeachersByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeachersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherSkillsByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<TeacherSkill>();
			records.Add(new TeacherSkill());
			mock.RepositoryMock.Setup(x => x.TeacherSkillsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherSkillServerResponseModel> response = await service.TeacherSkillsByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherSkillsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherSkillsByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.TeacherSkillsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherSkill>>(new List<TeacherSkill>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherSkillServerResponseModel> response = await service.TeacherSkillsByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherSkillsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherTeacherSkillsByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<TeacherTeacherSkill>();
			records.Add(new TeacherTeacherSkill());
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkillsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherTeacherSkillServerResponseModel> response = await service.TeacherTeacherSkillsByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherTeacherSkillsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherTeacherSkillsByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkillsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherTeacherSkill>>(new List<TeacherTeacherSkill>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherTeacherSkillServerResponseModel> response = await service.TeacherTeacherSkillsByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherTeacherSkillsByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void UsersByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			var records = new List<User>();
			records.Add(new User());
			mock.RepositoryMock.Setup(x => x.UsersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiUserServerResponseModel> response = await service.UsersByTenantId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.UsersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void UsersByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantService, ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.UsersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<User>>(new List<User>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiUserServerResponseModel> response = await service.UsersByTenantId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.UsersByTenantId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>66c4e33f80a1eb87e27f646c092ec524</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/