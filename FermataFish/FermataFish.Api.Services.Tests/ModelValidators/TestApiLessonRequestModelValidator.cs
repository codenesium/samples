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
	[Trait("Table", "Lesson")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLessonRequestModelValidatorTest
	{
		public ApiLessonRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void LessonStatusId_Create_Valid_Reference()
		{
			Mock<ILessonRepository> lessonRepository = new Mock<ILessonRepository>();
			lessonRepository.Setup(x => x.GetLessonStatus(It.IsAny<int>())).Returns(Task.FromResult<LessonStatus>(new LessonStatus()));

			var validator = new ApiLessonRequestModelValidator(lessonRepository.Object);
			await validator.ValidateCreateAsync(new ApiLessonRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LessonStatusId, 1);
		}

		[Fact]
		public async void LessonStatusId_Create_Invalid_Reference()
		{
			Mock<ILessonRepository> lessonRepository = new Mock<ILessonRepository>();
			lessonRepository.Setup(x => x.GetLessonStatus(It.IsAny<int>())).Returns(Task.FromResult<LessonStatus>(null));

			var validator = new ApiLessonRequestModelValidator(lessonRepository.Object);

			await validator.ValidateCreateAsync(new ApiLessonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LessonStatusId, 1);
		}

		[Fact]
		public async void LessonStatusId_Update_Valid_Reference()
		{
			Mock<ILessonRepository> lessonRepository = new Mock<ILessonRepository>();
			lessonRepository.Setup(x => x.GetLessonStatus(It.IsAny<int>())).Returns(Task.FromResult<LessonStatus>(new LessonStatus()));

			var validator = new ApiLessonRequestModelValidator(lessonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLessonRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LessonStatusId, 1);
		}

		[Fact]
		public async void LessonStatusId_Update_Invalid_Reference()
		{
			Mock<ILessonRepository> lessonRepository = new Mock<ILessonRepository>();
			lessonRepository.Setup(x => x.GetLessonStatus(It.IsAny<int>())).Returns(Task.FromResult<LessonStatus>(null));

			var validator = new ApiLessonRequestModelValidator(lessonRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLessonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LessonStatusId, 1);
		}

		[Fact]
		public async void StudioId_Create_Valid_Reference()
		{
			Mock<ILessonRepository> lessonRepository = new Mock<ILessonRepository>();
			lessonRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiLessonRequestModelValidator(lessonRepository.Object);
			await validator.ValidateCreateAsync(new ApiLessonRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Create_Invalid_Reference()
		{
			Mock<ILessonRepository> lessonRepository = new Mock<ILessonRepository>();
			lessonRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiLessonRequestModelValidator(lessonRepository.Object);

			await validator.ValidateCreateAsync(new ApiLessonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Valid_Reference()
		{
			Mock<ILessonRepository> lessonRepository = new Mock<ILessonRepository>();
			lessonRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiLessonRequestModelValidator(lessonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLessonRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Invalid_Reference()
		{
			Mock<ILessonRepository> lessonRepository = new Mock<ILessonRepository>();
			lessonRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiLessonRequestModelValidator(lessonRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLessonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>65fa7b86ef0794b507206b25ea365a15</Hash>
</Codenesium>*/