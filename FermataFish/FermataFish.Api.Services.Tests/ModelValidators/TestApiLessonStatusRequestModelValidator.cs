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
	[Trait("Table", "LessonStatus")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLessonStatusRequestModelValidatorTest
	{
		public ApiLessonStatusRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ILessonStatusRepository> lessonStatusRepository = new Mock<ILessonStatusRepository>();
			lessonStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LessonStatus()));

			var validator = new ApiLessonStatusRequestModelValidator(lessonStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiLessonStatusRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ILessonStatusRepository> lessonStatusRepository = new Mock<ILessonStatusRepository>();
			lessonStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LessonStatus()));

			var validator = new ApiLessonStatusRequestModelValidator(lessonStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLessonStatusRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void StudioId_Create_Valid_Reference()
		{
			Mock<ILessonStatusRepository> lessonStatusRepository = new Mock<ILessonStatusRepository>();
			lessonStatusRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiLessonStatusRequestModelValidator(lessonStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiLessonStatusRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Create_Invalid_Reference()
		{
			Mock<ILessonStatusRepository> lessonStatusRepository = new Mock<ILessonStatusRepository>();
			lessonStatusRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiLessonStatusRequestModelValidator(lessonStatusRepository.Object);

			await validator.ValidateCreateAsync(new ApiLessonStatusRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Valid_Reference()
		{
			Mock<ILessonStatusRepository> lessonStatusRepository = new Mock<ILessonStatusRepository>();
			lessonStatusRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiLessonStatusRequestModelValidator(lessonStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLessonStatusRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Invalid_Reference()
		{
			Mock<ILessonStatusRepository> lessonStatusRepository = new Mock<ILessonStatusRepository>();
			lessonStatusRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiLessonStatusRequestModelValidator(lessonStatusRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLessonStatusRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>3cfcca10fe0b2d70d9c9ef713135fc8e</Hash>
</Codenesium>*/