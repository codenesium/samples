using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

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
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        ApiStudioResponseModel response = await service.Get(default (int));

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
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        ApiStudioResponseModel response = await service.Get(default (int));

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
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

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
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

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
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void Admins_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        var records = new List<Admin>();
                        records.Add(new Admin());
                        mock.RepositoryMock.Setup(x => x.Admins(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiAdminResponseModel> response = await service.Admins(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Admins(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Admins_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        mock.RepositoryMock.Setup(x => x.Admins(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Admin>>(new List<Admin>()));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiAdminResponseModel> response = await service.Admins(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Admins(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Families_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        var records = new List<Family>();
                        records.Add(new Family());
                        mock.RepositoryMock.Setup(x => x.Families(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiFamilyResponseModel> response = await service.Families(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Families(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Families_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        mock.RepositoryMock.Setup(x => x.Families(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Family>>(new List<Family>()));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiFamilyResponseModel> response = await service.Families(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Families(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Lessons_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        var records = new List<Lesson>();
                        records.Add(new Lesson());
                        mock.RepositoryMock.Setup(x => x.Lessons(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiLessonResponseModel> response = await service.Lessons(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Lessons(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Lessons_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        mock.RepositoryMock.Setup(x => x.Lessons(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Lesson>>(new List<Lesson>()));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiLessonResponseModel> response = await service.Lessons(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Lessons(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void LessonStatus_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        var records = new List<LessonStatus>();
                        records.Add(new LessonStatus());
                        mock.RepositoryMock.Setup(x => x.LessonStatus(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiLessonStatusResponseModel> response = await service.LessonStatus(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.LessonStatus(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void LessonStatus_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        mock.RepositoryMock.Setup(x => x.LessonStatus(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<LessonStatus>>(new List<LessonStatus>()));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiLessonStatusResponseModel> response = await service.LessonStatus(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.LessonStatus(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Spaces_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        var records = new List<Space>();
                        records.Add(new Space());
                        mock.RepositoryMock.Setup(x => x.Spaces(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiSpaceResponseModel> response = await service.Spaces(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Spaces(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Spaces_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        mock.RepositoryMock.Setup(x => x.Spaces(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Space>>(new List<Space>()));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiSpaceResponseModel> response = await service.Spaces(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Spaces(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SpaceFeatures_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        var records = new List<SpaceFeature>();
                        records.Add(new SpaceFeature());
                        mock.RepositoryMock.Setup(x => x.SpaceFeatures(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiSpaceFeatureResponseModel> response = await service.SpaceFeatures(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.SpaceFeatures(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SpaceFeatures_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        mock.RepositoryMock.Setup(x => x.SpaceFeatures(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SpaceFeature>>(new List<SpaceFeature>()));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiSpaceFeatureResponseModel> response = await service.SpaceFeatures(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.SpaceFeatures(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Students_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        var records = new List<Student>();
                        records.Add(new Student());
                        mock.RepositoryMock.Setup(x => x.Students(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiStudentResponseModel> response = await service.Students(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Students(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Students_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        mock.RepositoryMock.Setup(x => x.Students(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Student>>(new List<Student>()));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiStudentResponseModel> response = await service.Students(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Students(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Teachers_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        var records = new List<Teacher>();
                        records.Add(new Teacher());
                        mock.RepositoryMock.Setup(x => x.Teachers(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiTeacherResponseModel> response = await service.Teachers(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Teachers(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Teachers_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        mock.RepositoryMock.Setup(x => x.Teachers(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Teacher>>(new List<Teacher>()));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiTeacherResponseModel> response = await service.Teachers(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Teachers(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void TeacherSkills_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        var records = new List<TeacherSkill>();
                        records.Add(new TeacherSkill());
                        mock.RepositoryMock.Setup(x => x.TeacherSkills(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiTeacherSkillResponseModel> response = await service.TeacherSkills(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.TeacherSkills(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void TeacherSkills_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudioRepository>();
                        mock.RepositoryMock.Setup(x => x.TeacherSkills(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherSkill>>(new List<TeacherSkill>()));
                        var service = new StudioService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLStudioMapperMock,
                                                        mock.DALMapperMockFactory.DALStudioMapperMock,
                                                        mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                        mock.DALMapperMockFactory.DALAdminMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFamilyMapperMock,
                                                        mock.DALMapperMockFactory.DALFamilyMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonMapperMock,
                                                        mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
                                                        mock.DALMapperMockFactory.DALLessonStatusMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                        mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                        mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                        mock.DALMapperMockFactory.DALStudentMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherMapperMock,
                                                        mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
                                                        mock.DALMapperMockFactory.DALTeacherSkillMapperMock);

                        List<ApiTeacherSkillResponseModel> response = await service.TeacherSkills(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.TeacherSkills(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>5dbf5bb64620974679f17531a2ef601e</Hash>
</Codenesium>*/