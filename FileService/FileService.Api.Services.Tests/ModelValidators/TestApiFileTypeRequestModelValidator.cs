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
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "FileType")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiFileTypeRequestModelValidatorTest
        {
                public ApiFileTypeRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
                        fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

                        var validator = new ApiFileTypeRequestModelValidator(fileTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
                        fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

                        var validator = new ApiFileTypeRequestModelValidator(fileTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
                        fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

                        var validator = new ApiFileTypeRequestModelValidator(fileTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 256));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
                        fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

                        var validator = new ApiFileTypeRequestModelValidator(fileTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 256));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
                        fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

                        var validator = new ApiFileTypeRequestModelValidator(fileTypeRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>9078aae13681186315e48e3323dc8228</Hash>
</Codenesium>*/