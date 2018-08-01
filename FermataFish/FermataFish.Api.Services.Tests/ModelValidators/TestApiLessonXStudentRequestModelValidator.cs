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
			await validator.ValidateUpdateAsync(default(int), new ApiLessonXStudentRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LessonId, 1);
		}

		[Fact]
		public async void LessonId_Update_Invalid_Reference()
		{
			Mock<ILessonXStudentRepository> lessonXStudentRepository = new Mock<ILessonXStudentRepository>();
			lessonXStudentRepository.Setup(x => x.GetLesson(It.IsAny<int>())).Returns(Task.FromResult<Lesson>(null));

			var validator = new ApiLessonXStudentRequestModelValidator(lessonXStudentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLessonXStudentRequestModel());

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
			await validator.ValidateUpdateAsync(default(int), new ApiLessonXStudentRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudentId_Update_Invalid_Reference()
		{
			Mock<ILessonXStudentRepository> lessonXStudentRepository = new Mock<ILessonXStudentRepository>();
			lessonXStudentRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

			var validator = new ApiLessonXStudentRequestModelValidator(lessonXStudentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLessonXStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>9303b6663ab04b03623194ead5369ad0</Hash>
</Codenesium>*/