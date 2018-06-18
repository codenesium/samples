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
        [Trait("Table", "Teacher")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTeacherRequestModelValidatorTest
        {
                public ApiTeacherRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Email_Create_null()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
                }

                [Fact]
                public async void Email_Update_null()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
                }

                [Fact]
                public async void Email_Create_length()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
                }

                [Fact]
                public async void Email_Update_length()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
                }

                [Fact]
                public async void Email_Delete()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void FirstName_Create_null()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Update_null()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Create_length()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
                }

                [Fact]
                public async void FirstName_Update_length()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
                }

                [Fact]
                public async void FirstName_Delete()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void LastName_Create_null()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Update_null()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Create_length()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
                }

                [Fact]
                public async void LastName_Update_length()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
                }

                [Fact]
                public async void LastName_Delete()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Phone_Create_null()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
                }

                [Fact]
                public async void Phone_Update_null()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
                }

                [Fact]
                public async void Phone_Create_length()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
                }

                [Fact]
                public async void Phone_Update_length()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
                }

                [Fact]
                public async void Phone_Delete()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void StudioId_Create_Valid_Reference()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Create_Invalid_Reference()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Update_Valid_Reference()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Update_Invalid_Reference()
                {
                        Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
                        teacherRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

                        var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>ee66e24cedceb8bd8fc4d5fef5da9089</Hash>
</Codenesium>*/