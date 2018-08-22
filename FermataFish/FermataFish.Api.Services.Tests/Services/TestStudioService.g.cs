using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Studio")]
	[Trait("Area", "Services")]
	public partial class StudioServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<Studio>();
			records.Add(new Studio());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiStudioResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var record = new Studio();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			ApiStudioResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			ApiStudioResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var model = new ApiStudioRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Studio>())).Returns(Task.FromResult(new Studio()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			CreateResponse<ApiStudioResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.StudioModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStudioRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Studio>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var model = new ApiStudioRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Studio>())).Returns(Task.FromResult(new Studio()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			UpdateResponse<ApiStudioResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.StudioModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudioRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Studio>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var model = new ApiStudioRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.StudioModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Families_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<Family>();
			records.Add(new Family());
			mock.RepositoryMock.Setup(x => x.Families(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiFamilyResponseModel> response = await service.Families(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Families(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Families_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.Families(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Family>>(new List<Family>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiFamilyResponseModel> response = await service.Families(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Families(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LessonStatuses_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<LessonStatus>();
			records.Add(new LessonStatus());
			mock.RepositoryMock.Setup(x => x.LessonStatuses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiLessonStatusResponseModel> response = await service.LessonStatuses(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.LessonStatuses(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LessonStatuses_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.LessonStatuses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<LessonStatus>>(new List<LessonStatus>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiLessonStatusResponseModel> response = await service.LessonStatuses(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.LessonStatuses(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Admins_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<Admin>();
			records.Add(new Admin());
			mock.RepositoryMock.Setup(x => x.Admins(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiAdminResponseModel> response = await service.Admins(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Admins(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Admins_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.Admins(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Admin>>(new List<Admin>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiAdminResponseModel> response = await service.Admins(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Admins(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Lessons_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<Lesson>();
			records.Add(new Lesson());
			mock.RepositoryMock.Setup(x => x.Lessons(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiLessonResponseModel> response = await service.Lessons(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Lessons(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Lessons_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.Lessons(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Lesson>>(new List<Lesson>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiLessonResponseModel> response = await service.Lessons(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Lessons(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LessonXStudents_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<LessonXStudent>();
			records.Add(new LessonXStudent());
			mock.RepositoryMock.Setup(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiLessonXStudentResponseModel> response = await service.LessonXStudents(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LessonXStudents_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<LessonXStudent>>(new List<LessonXStudent>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiLessonXStudentResponseModel> response = await service.LessonXStudents(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Rates_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<Rate>();
			records.Add(new Rate());
			mock.RepositoryMock.Setup(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiRateResponseModel> response = await service.Rates(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Rates_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Rate>>(new List<Rate>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiRateResponseModel> response = await service.Rates(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Spaces_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<Space>();
			records.Add(new Space());
			mock.RepositoryMock.Setup(x => x.Spaces(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiSpaceResponseModel> response = await service.Spaces(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Spaces(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Spaces_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.Spaces(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Space>>(new List<Space>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiSpaceResponseModel> response = await service.Spaces(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Spaces(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceFeatures_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<SpaceFeature>();
			records.Add(new SpaceFeature());
			mock.RepositoryMock.Setup(x => x.SpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiSpaceFeatureResponseModel> response = await service.SpaceFeatures(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceFeatures_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.SpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SpaceFeature>>(new List<SpaceFeature>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiSpaceFeatureResponseModel> response = await service.SpaceFeatures(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceXSpaceFeatures_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<SpaceXSpaceFeature>();
			records.Add(new SpaceXSpaceFeature());
			mock.RepositoryMock.Setup(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiSpaceXSpaceFeatureResponseModel> response = await service.SpaceXSpaceFeatures(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceXSpaceFeatures_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SpaceXSpaceFeature>>(new List<SpaceXSpaceFeature>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiSpaceXSpaceFeatureResponseModel> response = await service.SpaceXSpaceFeatures(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Students_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<Student>();
			records.Add(new Student());
			mock.RepositoryMock.Setup(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiStudentResponseModel> response = await service.Students(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Students_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Student>>(new List<Student>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiStudentResponseModel> response = await service.Students(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StudentXFamilies_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<StudentXFamily>();
			records.Add(new StudentXFamily());
			mock.RepositoryMock.Setup(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiStudentXFamilyResponseModel> response = await service.StudentXFamilies(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StudentXFamilies_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<StudentXFamily>>(new List<StudentXFamily>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiStudentXFamilyResponseModel> response = await service.StudentXFamilies(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Teachers_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<Teacher>();
			records.Add(new Teacher());
			mock.RepositoryMock.Setup(x => x.Teachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiTeacherResponseModel> response = await service.Teachers(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Teachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Teachers_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.Teachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Teacher>>(new List<Teacher>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiTeacherResponseModel> response = await service.Teachers(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Teachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherSkills_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<TeacherSkill>();
			records.Add(new TeacherSkill());
			mock.RepositoryMock.Setup(x => x.TeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiTeacherSkillResponseModel> response = await service.TeacherSkills(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherSkills_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.TeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherSkill>>(new List<TeacherSkill>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiTeacherSkillResponseModel> response = await service.TeacherSkills(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherXTeacherSkills_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<TeacherXTeacherSkill>();
			records.Add(new TeacherXTeacherSkill());
			mock.RepositoryMock.Setup(x => x.TeacherXTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiTeacherXTeacherSkillResponseModel> response = await service.TeacherXTeacherSkills(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherXTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherXTeacherSkills_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.TeacherXTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherXTeacherSkill>>(new List<TeacherXTeacherSkill>()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                                mock.DALMapperMockFactory.DALAdminMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                mock.DALMapperMockFactory.DALRateMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                                mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiTeacherXTeacherSkillResponseModel> response = await service.TeacherXTeacherSkills(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherXTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>a1606fa379547810c332233aa9b554d1</Hash>
</Codenesium>*/