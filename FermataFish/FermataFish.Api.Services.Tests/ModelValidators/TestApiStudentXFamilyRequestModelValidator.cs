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
        [Trait("Table", "StudentXFamily")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiStudentXFamilyRequestModelValidatorTest
        {
                public ApiStudentXFamilyRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void FamilyId_Create_Valid_Reference()
                {
                        Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
                        studentXFamilyRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(new Family()));

                        var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStudentXFamilyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.FamilyId, 1);
                }

                [Fact]
                public async void FamilyId_Create_Invalid_Reference()
                {
                        Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
                        studentXFamilyRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(null));

                        var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStudentXFamilyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FamilyId, 1);
                }

                [Fact]
                public async void FamilyId_Update_Valid_Reference()
                {
                        Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
                        studentXFamilyRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(new Family()));

                        var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStudentXFamilyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.FamilyId, 1);
                }

                [Fact]
                public async void FamilyId_Update_Invalid_Reference()
                {
                        Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
                        studentXFamilyRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(null));

                        var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStudentXFamilyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FamilyId, 1);
                }

                [Fact]
                public async void StudentId_Create_Valid_Reference()
                {
                        Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
                        studentXFamilyRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

                        var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStudentXFamilyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
                }

                [Fact]
                public async void StudentId_Create_Invalid_Reference()
                {
                        Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
                        studentXFamilyRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

                        var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStudentXFamilyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
                }

                [Fact]
                public async void StudentId_Update_Valid_Reference()
                {
                        Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
                        studentXFamilyRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

                        var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStudentXFamilyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
                }

                [Fact]
                public async void StudentId_Update_Invalid_Reference()
                {
                        Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
                        studentXFamilyRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

                        var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStudentXFamilyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>fbd57aa4e097f9e8a00438524ee16fb1</Hash>
</Codenesium>*/