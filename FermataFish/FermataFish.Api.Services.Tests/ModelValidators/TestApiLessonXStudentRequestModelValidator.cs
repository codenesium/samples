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
        [Trait("Table", "LessonXStudent")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiLessonXStudentRequestModelValidatorTest
        {
                public ApiLessonXStudentRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void LessonId_Create_Valid_Reference()
                {
                        Mock<ILessonXStudentRepository> lessonXStudentRepository = new Mock<ILessonXStudentRepository>();
                        lessonXStudentRepository.Setup(x => x.GetLesson(It.IsAny<int>())).Returns(Task.FromResult<Lesson>(new Lesson()));

                        var validator = new ApiLessonXStudentRequestModelValidator(lessonXStudentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLessonXStudentRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.LessonId, 1);
                }

                [Fact]
                public async void LessonId_Create_Invalid_Reference()
                {
                        Mock<ILessonXStudentRepository> lessonXStudentRepository = new Mock<ILessonXStudentRepository>();
                        lessonXStudentRepository.Setup(x => x.GetLesson(It.IsAny<int>())).Returns(Task.FromResult<Lesson>(null));

                        var validator = new ApiLessonXStudentRequestModelValidator(lessonXStudentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLessonXStudentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LessonId, 1);
                }

                [Fact]
                public async void LessonId_Update_Valid_Reference()
                {
                        Mock<ILessonXStudentRepository> lessonXStudentRepository = new Mock<ILessonXStudentRepository>();
                        lessonXStudentRepository.Setup(x => x.GetLesson(It.IsAny<int>())).Returns(Task.FromResult<Lesson>(new Lesson()));

                        var validator = new ApiLessonXStudentRequestModelValidator(lessonXStudentRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonXStudentRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.LessonId, 1);
                }

                [Fact]
                public async void LessonId_Update_Invalid_Reference()
                {
                        Mock<ILessonXStudentRepository> lessonXStudentRepository = new Mock<ILessonXStudentRepository>();
                        lessonXStudentRepository.Setup(x => x.GetLesson(It.IsAny<int>())).Returns(Task.FromResult<Lesson>(null));

                        var validator = new ApiLessonXStudentRequestModelValidator(lessonXStudentRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonXStudentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LessonId, 1);
                }

                [Fact]
                public async void StudentId_Create_Valid_Reference()
                {
                        Mock<ILessonXStudentRepository> lessonXStudentRepository = new Mock<ILessonXStudentRepository>();
                        lessonXStudentRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

                        var validator = new ApiLessonXStudentRequestModelValidator(lessonXStudentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLessonXStudentRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
                }

                [Fact]
                public async void StudentId_Create_Invalid_Reference()
                {
                        Mock<ILessonXStudentRepository> lessonXStudentRepository = new Mock<ILessonXStudentRepository>();
                        lessonXStudentRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

                        var validator = new ApiLessonXStudentRequestModelValidator(lessonXStudentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLessonXStudentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
                }

                [Fact]
                public async void StudentId_Update_Valid_Reference()
                {
                        Mock<ILessonXStudentRepository> lessonXStudentRepository = new Mock<ILessonXStudentRepository>();
                        lessonXStudentRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

                        var validator = new ApiLessonXStudentRequestModelValidator(lessonXStudentRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonXStudentRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
                }

                [Fact]
                public async void StudentId_Update_Invalid_Reference()
                {
                        Mock<ILessonXStudentRepository> lessonXStudentRepository = new Mock<ILessonXStudentRepository>();
                        lessonXStudentRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

                        var validator = new ApiLessonXStudentRequestModelValidator(lessonXStudentRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonXStudentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>0b57b2ac9c9ea2c8bdf7fd0060914a12</Hash>
</Codenesium>*/