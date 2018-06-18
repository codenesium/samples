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
        [Trait("Table", "TeacherXTeacherSkill")]
        [Trait("Area", "Services")]
        public partial class TeacherXTeacherSkillServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ITeacherXTeacherSkillRepository>();
                        var records = new List<TeacherXTeacherSkill>();
                        records.Add(new TeacherXTeacherSkill());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TeacherXTeacherSkillService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.TeacherXTeacherSkillModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
                                                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

                        List<ApiTeacherXTeacherSkillResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ITeacherXTeacherSkillRepository>();
                        var record = new TeacherXTeacherSkill();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new TeacherXTeacherSkillService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.TeacherXTeacherSkillModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
                                                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

                        ApiTeacherXTeacherSkillResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ITeacherXTeacherSkillRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TeacherXTeacherSkill>(null));
                        var service = new TeacherXTeacherSkillService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.TeacherXTeacherSkillModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
                                                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

                        ApiTeacherXTeacherSkillResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ITeacherXTeacherSkillRepository>();
                        var model = new ApiTeacherXTeacherSkillRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TeacherXTeacherSkill>())).Returns(Task.FromResult(new TeacherXTeacherSkill()));
                        var service = new TeacherXTeacherSkillService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.TeacherXTeacherSkillModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
                                                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

                        CreateResponse<ApiTeacherXTeacherSkillResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TeacherXTeacherSkillModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherXTeacherSkillRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TeacherXTeacherSkill>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ITeacherXTeacherSkillRepository>();
                        var model = new ApiTeacherXTeacherSkillRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TeacherXTeacherSkill>())).Returns(Task.FromResult(new TeacherXTeacherSkill()));
                        var service = new TeacherXTeacherSkillService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.TeacherXTeacherSkillModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
                                                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TeacherXTeacherSkillModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherXTeacherSkillRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TeacherXTeacherSkill>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ITeacherXTeacherSkillRepository>();
                        var model = new ApiTeacherXTeacherSkillRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new TeacherXTeacherSkillService(mock.LoggerMock.Object,
                                                                      mock.RepositoryMock.Object,
                                                                      mock.ModelValidatorMockFactory.TeacherXTeacherSkillModelValidatorMock.Object,
                                                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
                                                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.TeacherXTeacherSkillModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>8861c1cd57871312489c590a6ea02bb8</Hash>
</Codenesium>*/