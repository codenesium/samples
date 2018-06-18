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

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.LessonStatusId, 1);
                }

                [Fact]
                public async void LessonStatusId_Update_Invalid_Reference()
                {
                        Mock<ILessonRepository> lessonRepository = new Mock<ILessonRepository>();
                        lessonRepository.Setup(x => x.GetLessonStatus(It.IsAny<int>())).Returns(Task.FromResult<LessonStatus>(null));

                        var validator = new ApiLessonRequestModelValidator(lessonRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonRequestModel());

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

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Update_Invalid_Reference()
                {
                        Mock<ILessonRepository> lessonRepository = new Mock<ILessonRepository>();
                        lessonRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

                        var validator = new ApiLessonRequestModelValidator(lessonRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>2aec91e81adba6ce7bf9a353e926bc3c</Hash>
</Codenesium>*/