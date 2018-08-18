using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

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
			await validator.ValidateUpdateAsync(default(int), new ApiLessonXTeacherRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LessonId, 1);
		}

		[Fact]
		public async void LessonId_Update_Invalid_Reference()
		{
			Mock<ILessonXTeacherRepository> lessonXTeacherRepository = new Mock<ILessonXTeacherRepository>();
			lessonXTeacherRepository.Setup(x => x.GetLesson(It.IsAny<int>())).Returns(Task.FromResult<Lesson>(null));

			var validator = new ApiLessonXTeacherRequestModelValidator(lessonXTeacherRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLessonXTeacherRequestModel());

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
			await validator.ValidateUpdateAsync(default(int), new ApiLessonXTeacherRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudentId_Update_Invalid_Reference()
		{
			Mock<ILessonXTeacherRepository> lessonXTeacherRepository = new Mock<ILessonXTeacherRepository>();
			lessonXTeacherRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

			var validator = new ApiLessonXTeacherRequestModelValidator(lessonXTeacherRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLessonXTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>57c513e5045b1e79d7150227f5a52f2e</Hash>
</Codenesium>*/