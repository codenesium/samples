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
        [Trait("Table", "LessonStatus")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiLessonStatusRequestModelValidatorTest
        {
                public ApiLessonStatusRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ILessonStatusRepository> lessonStatusRepository = new Mock<ILessonStatusRepository>();
                        lessonStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LessonStatus()));

                        var validator = new ApiLessonStatusRequestModelValidator(lessonStatusRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLessonStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ILessonStatusRepository> lessonStatusRepository = new Mock<ILessonStatusRepository>();
                        lessonStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LessonStatus()));

                        var validator = new ApiLessonStatusRequestModelValidator(lessonStatusRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
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

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ILessonStatusRepository> lessonStatusRepository = new Mock<ILessonStatusRepository>();
                        lessonStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LessonStatus()));

                        var validator = new ApiLessonStatusRequestModelValidator(lessonStatusRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
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

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonStatusRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Update_Invalid_Reference()
                {
                        Mock<ILessonStatusRepository> lessonStatusRepository = new Mock<ILessonStatusRepository>();
                        lessonStatusRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

                        var validator = new ApiLessonStatusRequestModelValidator(lessonStatusRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiLessonStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>f32da33e1246303ea8e69c2c348fec01</Hash>
</Codenesium>*/