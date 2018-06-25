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
        [Trait("Table", "Posts")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPostsRequestModelValidatorTest
        {
                public ApiPostsRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Body_Create_null()
                {
                        Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
                        postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

                        var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPostsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Body, null as string);
                }

                [Fact]
                public async void Body_Update_null()
                {
                        Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
                        postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

                        var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPostsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Body, null as string);
                }

                [Fact]
                public async void LastEditorDisplayName_Create_length()
                {
                        Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
                        postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

                        var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPostsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastEditorDisplayName, new string('A', 41));
                }

                [Fact]
                public async void LastEditorDisplayName_Update_length()
                {
                        Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
                        postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

                        var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPostsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastEditorDisplayName, new string('A', 41));
                }

                [Fact]
                public async void Tags_Create_length()
                {
                        Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
                        postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

                        var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPostsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Tags, new string('A', 151));
                }

                [Fact]
                public async void Tags_Update_length()
                {
                        Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
                        postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

                        var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPostsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Tags, new string('A', 151));
                }

                [Fact]
                public async void Title_Create_length()
                {
                        Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
                        postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

                        var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPostsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 251));
                }

                [Fact]
                public async void Title_Update_length()
                {
                        Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
                        postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

                        var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPostsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 251));
                }
        }
}

/*<Codenesium>
    <Hash>26fe0b91a76099bb7286249e5ff020f2</Hash>
</Codenesium>*/