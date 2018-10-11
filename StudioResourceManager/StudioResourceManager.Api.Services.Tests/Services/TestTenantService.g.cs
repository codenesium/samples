using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "Services")]
	public partial class TenantServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<Tenant>();
			records.Add(new Tenant());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTenantResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var record = new Tenant();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			ApiTenantResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Tenant>(null));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			ApiTenantResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var model = new ApiTenantRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tenant>())).Returns(Task.FromResult(new Tenant()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			CreateResponse<ApiTenantResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TenantModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTenantRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Tenant>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var model = new ApiTenantRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tenant>())).Returns(Task.FromResult(new Tenant()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tenant()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			UpdateResponse<ApiTenantResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TenantModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTenantRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Tenant>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var model = new ApiTenantRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TenantModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Admins_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<Admin>();
			records.Add(new Admin());
			mock.RepositoryMock.Setup(x => x.Admins(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiAdminResponseModel> response = await service.Admins(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Admins(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Admins_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.Admins(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Admin>>(new List<Admin>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiAdminResponseModel> response = await service.Admins(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Admins(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Events_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<Event>();
			records.Add(new Event());
			mock.RepositoryMock.Setup(x => x.Events(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventResponseModel> response = await service.Events(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Events(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Events_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.Events(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Event>>(new List<Event>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventResponseModel> response = await service.Events(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Events(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventStatuses_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<EventStatus>();
			records.Add(new EventStatus());
			mock.RepositoryMock.Setup(x => x.EventStatuses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventStatusResponseModel> response = await service.EventStatuses(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStatuses(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventStatuses_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.EventStatuses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventStatus>>(new List<EventStatus>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventStatusResponseModel> response = await service.EventStatuses(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStatuses(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventStudents_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<EventStudent>();
			records.Add(new EventStudent());
			mock.RepositoryMock.Setup(x => x.EventStudents(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventStudentResponseModel> response = await service.EventStudents(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStudents(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventStudents_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.EventStudents(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventStudent>>(new List<EventStudent>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventStudentResponseModel> response = await service.EventStudents(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStudents(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventTeachers_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<EventTeacher>();
			records.Add(new EventTeacher());
			mock.RepositoryMock.Setup(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventTeacherResponseModel> response = await service.EventTeachers(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventTeachers_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventTeacher>>(new List<EventTeacher>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiEventTeacherResponseModel> response = await service.EventTeachers(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Families_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<Family>();
			records.Add(new Family());
			mock.RepositoryMock.Setup(x => x.Families(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiFamilyResponseModel> response = await service.Families(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Families(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Families_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.Families(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Family>>(new List<Family>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiFamilyResponseModel> response = await service.Families(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Families(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Rates_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<Rate>();
			records.Add(new Rate());
			mock.RepositoryMock.Setup(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiRateResponseModel> response = await service.Rates(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Rates_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Rate>>(new List<Rate>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiRateResponseModel> response = await service.Rates(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Spaces_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<Space>();
			records.Add(new Space());
			mock.RepositoryMock.Setup(x => x.Spaces(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceResponseModel> response = await service.Spaces(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Spaces(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Spaces_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.Spaces(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Space>>(new List<Space>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceResponseModel> response = await service.Spaces(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Spaces(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceFeatures_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<SpaceFeature>();
			records.Add(new SpaceFeature());
			mock.RepositoryMock.Setup(x => x.SpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceFeatureResponseModel> response = await service.SpaceFeatures(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceFeatures_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.SpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SpaceFeature>>(new List<SpaceFeature>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceFeatureResponseModel> response = await service.SpaceFeatures(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceSpaceFeatures_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<SpaceSpaceFeature>();
			records.Add(new SpaceSpaceFeature());
			mock.RepositoryMock.Setup(x => x.SpaceSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceSpaceFeatureResponseModel> response = await service.SpaceSpaceFeatures(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceSpaceFeatures_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.SpaceSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SpaceSpaceFeature>>(new List<SpaceSpaceFeature>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiSpaceSpaceFeatureResponseModel> response = await service.SpaceSpaceFeatures(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Students_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<Student>();
			records.Add(new Student());
			mock.RepositoryMock.Setup(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiStudentResponseModel> response = await service.Students(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Students_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Student>>(new List<Student>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiStudentResponseModel> response = await service.Students(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Studios_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<Studio>();
			records.Add(new Studio());
			mock.RepositoryMock.Setup(x => x.Studios(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiStudioResponseModel> response = await service.Studios(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Studios(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Studios_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.Studios(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Studio>>(new List<Studio>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiStudioResponseModel> response = await service.Studios(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Studios(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Teachers_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<Teacher>();
			records.Add(new Teacher());
			mock.RepositoryMock.Setup(x => x.Teachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherResponseModel> response = await service.Teachers(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Teachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Teachers_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.Teachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Teacher>>(new List<Teacher>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherResponseModel> response = await service.Teachers(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Teachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherSkills_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<TeacherSkill>();
			records.Add(new TeacherSkill());
			mock.RepositoryMock.Setup(x => x.TeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherSkillResponseModel> response = await service.TeacherSkills(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherSkills_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.TeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherSkill>>(new List<TeacherSkill>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherSkillResponseModel> response = await service.TeacherSkills(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherTeacherSkills_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<TeacherTeacherSkill>();
			records.Add(new TeacherTeacherSkill());
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherTeacherSkillResponseModel> response = await service.TeacherTeacherSkills(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherTeacherSkills_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherTeacherSkill>>(new List<TeacherTeacherSkill>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiTeacherTeacherSkillResponseModel> response = await service.TeacherTeacherSkills(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Users_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			var records = new List<User>();
			records.Add(new User());
			mock.RepositoryMock.Setup(x => x.Users(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiUserResponseModel> response = await service.Users(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Users(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Users_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantRepository>();
			mock.RepositoryMock.Setup(x => x.Users(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<User>>(new List<User>()));
			var service = new TenantService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTenantMapperMock,
			                                mock.DALMapperMockFactory.DALTenantMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                mock.DALMapperMockFactory.DALEventMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLUserMapperMock,
			                                mock.DALMapperMockFactory.DALUserMapperMock);

			List<ApiUserResponseModel> response = await service.Users(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Users(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>7a295afa743816066d476a3253cf5e47</Hash>
</Codenesium>*/