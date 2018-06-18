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
        [Trait("Table", "LessonXTeacher")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiLessonXTeacherRequestModelValidatorTest
        {
                public ApiLessonXTeacherRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void LessonId_Create_Valid_Reference()
                {
                        Mock<ILessonXTeacherRepository> lessonXTeacherRepository = new Mock<ILessonXTeacherRepository>();
                        lessonXTeacherRepository.Setup(x => x.GetLesson(It.IsAny<int>())).Returns(Task.FromResult<Lesson>(new Lesson()));

                        var validator = new ApiLessonXTeacherRequestModelValidator(lessonXTeacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLessonXTeacherRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.LessonId, 1);
                }

                [Fact]
                public async void LessonId_Create_Invalid_Reference()
                {
                        Mock<ILessonXTeacherRepository> lessonXTeacherRepository = new Mock<ILessonXTeacherRepository>();
                        lessonXTeacherRepository.Setup(x => x.GetLesson(It.IsAny<int>())).Returns(Task.FromResult<Lesson>(null));

                        var validator = new ApiLessonXTeacherRequestModelValidator(lessonXTeacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLessonXTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LessonId, 1);
                }

                [Fact]
                public async void LessonId_Update_Valid_Reference()
                {
                        Mock<ILessonXTeacherRepository> lessonXTeacherRepository = new Mock<ILessonXTeacherRepository>();
                        lessonXTeacherRepository.Setup(x => x.GetLesson(It.IsAny<int>())).Returns(Task.FromResult<Lesson>(new Lesson()));

                        var validator = new ApiLessonXTeacherRequestModelValidator(lessonXTeacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonXTeacherRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.LessonId, 1);
                }

                [Fact]
                public async void LessonId_Update_Invalid_Reference()
                {
                        Mock<ILessonXTeacherRepository> lessonXTeacherRepository = new Mock<ILessonXTeacherRepository>();
                        lessonXTeacherRepository.Setup(x => x.GetLesson(It.IsAny<int>())).Returns(Task.FromResult<Lesson>(null));

                        var validator = new ApiLessonXTeacherRequestModelValidator(lessonXTeacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonXTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LessonId, 1);
                }

                [Fact]
                public async void StudentId_Create_Valid_Reference()
                {
                        Mock<ILessonXTeacherRepository> lessonXTeacherRepository = new Mock<ILessonXTeacherRepository>();
                        lessonXTeacherRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

                        var validator = new ApiLessonXTeacherRequestModelValidator(lessonXTeacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLessonXTeacherRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
                }

                [Fact]
                public async void StudentId_Create_Invalid_Reference()
                {
                        Mock<ILessonXTeacherRepository> lessonXTeacherRepository = new Mock<ILessonXTeacherRepository>();
                        lessonXTeacherRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

                        var validator = new ApiLessonXTeacherRequestModelValidator(lessonXTeacherRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLessonXTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
                }

                [Fact]
                public async void StudentId_Update_Valid_Reference()
                {
                        Mock<ILessonXTeacherRepository> lessonXTeacherRepository = new Mock<ILessonXTeacherRepository>();
                        lessonXTeacherRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

                        var validator = new ApiLessonXTeacherRequestModelValidator(lessonXTeacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonXTeacherRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
                }

                [Fact]
                public async void StudentId_Update_Invalid_Reference()
                {
                        Mock<ILessonXTeacherRepository> lessonXTeacherRepository = new Mock<ILessonXTeacherRepository>();
                        lessonXTeacherRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

                        var validator = new ApiLessonXTeacherRequestModelValidator(lessonXTeacherRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonXTeacherRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>5c6bcbfbced90e5c1a505d734f555a62</Hash>
</Codenesium>*/