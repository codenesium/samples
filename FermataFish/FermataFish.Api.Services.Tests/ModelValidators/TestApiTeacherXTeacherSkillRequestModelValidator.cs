using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TeacherXTeacherSkill")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTeacherXTeacherSkillRequestModelValidatorTest
        {
                public ApiTeacherXTeacherSkillRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void TeacherId_Create_Valid_Reference()
                {
                        Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
                        teacherXTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

                        var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherXTeacherSkillRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
                }

                [Fact]
                public async void TeacherId_Create_Invalid_Reference()
                {
                        Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
                        teacherXTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

                        var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherXTeacherSkillRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
                }

                [Fact]
                public async void TeacherId_Update_Valid_Reference()
                {
                        Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
                        teacherXTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

                        var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherXTeacherSkillRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
                }

                [Fact]
                public async void TeacherId_Update_Invalid_Reference()
                {
                        Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
                        teacherXTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

                        var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherXTeacherSkillRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
                }

                [Fact]
                public async void TeacherSkillId_Create_Valid_Reference()
                {
                        Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
                        teacherXTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

                        var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherXTeacherSkillRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
                }

                [Fact]
                public async void TeacherSkillId_Create_Invalid_Reference()
                {
                        Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
                        teacherXTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

                        var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherXTeacherSkillRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
                }

                [Fact]
                public async void TeacherSkillId_Update_Valid_Reference()
                {
                        Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
                        teacherXTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

                        var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherXTeacherSkillRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
                }

                [Fact]
                public async void TeacherSkillId_Update_Invalid_Reference()
                {
                        Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
                        teacherXTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

                        var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherXTeacherSkillRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>bc447d7c9c62c80fa46a1f8c8e7d3495</Hash>
</Codenesium>*/