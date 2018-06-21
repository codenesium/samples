using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PostTypes")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPostTypesRequestModelValidatorTest
        {
                public ApiPostTypesRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Type_Create_null()
                {
                        Mock<IPostTypesRepository> postTypesRepository = new Mock<IPostTypesRepository>();
                        postTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));

                        var validator = new ApiPostTypesRequestModelValidator(postTypesRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPostTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
                }

                [Fact]
                public async void Type_Update_null()
                {
                        Mock<IPostTypesRepository> postTypesRepository = new Mock<IPostTypesRepository>();
                        postTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));

                        var validator = new ApiPostTypesRequestModelValidator(postTypesRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPostTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
                }

                [Fact]
                public async void Type_Create_length()
                {
                        Mock<IPostTypesRepository> postTypesRepository = new Mock<IPostTypesRepository>();
                        postTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));

                        var validator = new ApiPostTypesRequestModelValidator(postTypesRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPostTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
                }

                [Fact]
                public async void Type_Update_length()
                {
                        Mock<IPostTypesRepository> postTypesRepository = new Mock<IPostTypesRepository>();
                        postTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));

                        var validator = new ApiPostTypesRequestModelValidator(postTypesRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPostTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
                }

                [Fact]
                public async void Type_Delete()
                {
                        Mock<IPostTypesRepository> postTypesRepository = new Mock<IPostTypesRepository>();
                        postTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));

                        var validator = new ApiPostTypesRequestModelValidator(postTypesRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>a009f5c1eafb1382418f7e2da400017e</Hash>
</Codenesium>*/