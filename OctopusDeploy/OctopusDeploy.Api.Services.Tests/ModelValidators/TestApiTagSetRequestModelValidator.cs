using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TagSet")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTagSetRequestModelValidatorTest
        {
                public ApiTagSetRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
                        tagSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TagSet()));

                        var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTagSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
                        tagSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TagSet()));

                        var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTagSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
                        tagSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TagSet()));

                        var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTagSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
                        tagSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TagSet()));

                        var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTagSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
                        tagSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TagSet()));

                        var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTagSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
                        tagSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TagSet()));

                        var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTagSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
                        tagSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TagSet()));

                        var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
                        tagSetRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<TagSet>(new TagSet()));
                        var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTagSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
                        tagSetRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<TagSet>(null));
                        var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTagSetRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
                        tagSetRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<TagSet>(new TagSet()));
                        var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiTagSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
                        tagSetRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<TagSet>(null));
                        var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiTagSetRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>c441b605493c4ffb55458cbafe7f0751</Hash>
</Codenesium>*/