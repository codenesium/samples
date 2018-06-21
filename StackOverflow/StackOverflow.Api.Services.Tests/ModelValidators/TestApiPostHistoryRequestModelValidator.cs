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
        [Trait("Table", "PostHistory")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPostHistoryRequestModelValidatorTest
        {
                public ApiPostHistoryRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void RevisionGUID_Create_null()
                {
                        Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
                        postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

                        var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPostHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RevisionGUID, null as string);
                }

                [Fact]
                public async void RevisionGUID_Update_null()
                {
                        Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
                        postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

                        var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RevisionGUID, null as string);
                }

                [Fact]
                public async void RevisionGUID_Create_length()
                {
                        Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
                        postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

                        var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPostHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RevisionGUID, new string('A', 37));
                }

                [Fact]
                public async void RevisionGUID_Update_length()
                {
                        Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
                        postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

                        var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RevisionGUID, new string('A', 37));
                }

                [Fact]
                public async void RevisionGUID_Delete()
                {
                        Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
                        postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

                        var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void UserDisplayName_Create_length()
                {
                        Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
                        postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

                        var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPostHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserDisplayName, new string('A', 41));
                }

                [Fact]
                public async void UserDisplayName_Update_length()
                {
                        Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
                        postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

                        var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserDisplayName, new string('A', 41));
                }

                [Fact]
                public async void UserDisplayName_Delete()
                {
                        Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
                        postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

                        var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>6f7cfe2c91cf3daf51d3ba789433aafa</Hash>
</Codenesium>*/