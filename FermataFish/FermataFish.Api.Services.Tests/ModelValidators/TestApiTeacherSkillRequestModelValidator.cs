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
        [Trait("Table", "TeacherSkill")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTeacherSkillRequestModelValidatorTest
        {
                public ApiTeacherSkillRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
                        teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

                        var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherSkillRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
                        teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

                        var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherSkillRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
                        teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

                        var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherSkillRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
                        teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

                        var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherSkillRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
                        teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

                        var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void StudioId_Create_Valid_Reference()
                {
                        Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
                        teacherSkillRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

                        var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherSkillRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Create_Invalid_Reference()
                {
                        Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
                        teacherSkillRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

                        var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherSkillRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Update_Valid_Reference()
                {
                        Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
                        teacherSkillRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

                        var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherSkillRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Update_Invalid_Reference()
                {
                        Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
                        teacherSkillRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

                        var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherSkillRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>070f2bd58a804e3970c5e01b3a0805c2</Hash>
</Codenesium>*/