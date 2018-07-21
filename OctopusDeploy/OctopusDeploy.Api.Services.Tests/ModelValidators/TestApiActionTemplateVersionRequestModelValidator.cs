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
        [Trait("Table", "ActionTemplateVersion")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiActionTemplateVersionRequestModelValidatorTest
        {
                public ApiActionTemplateVersionRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ActionType_Create_length()
                {
                        Mock<IActionTemplateVersionRepository> actionTemplateVersionRepository = new Mock<IActionTemplateVersionRepository>();
                        actionTemplateVersionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplateVersion()));

                        var validator = new ApiActionTemplateVersionRequestModelValidator(actionTemplateVersionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiActionTemplateVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ActionType, new string('A', 51));
                }

                [Fact]
                public async void ActionType_Update_length()
                {
                        Mock<IActionTemplateVersionRepository> actionTemplateVersionRepository = new Mock<IActionTemplateVersionRepository>();
                        actionTemplateVersionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplateVersion()));

                        var validator = new ApiActionTemplateVersionRequestModelValidator(actionTemplateVersionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ActionType, new string('A', 51));
                }

                [Fact]
                public async void LatestActionTemplateId_Create_length()
                {
                        Mock<IActionTemplateVersionRepository> actionTemplateVersionRepository = new Mock<IActionTemplateVersionRepository>();
                        actionTemplateVersionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplateVersion()));

                        var validator = new ApiActionTemplateVersionRequestModelValidator(actionTemplateVersionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiActionTemplateVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LatestActionTemplateId, new string('A', 51));
                }

                [Fact]
                public async void LatestActionTemplateId_Update_length()
                {
                        Mock<IActionTemplateVersionRepository> actionTemplateVersionRepository = new Mock<IActionTemplateVersionRepository>();
                        actionTemplateVersionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplateVersion()));

                        var validator = new ApiActionTemplateVersionRequestModelValidator(actionTemplateVersionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LatestActionTemplateId, new string('A', 51));
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IActionTemplateVersionRepository> actionTemplateVersionRepository = new Mock<IActionTemplateVersionRepository>();
                        actionTemplateVersionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplateVersion()));

                        var validator = new ApiActionTemplateVersionRequestModelValidator(actionTemplateVersionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiActionTemplateVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IActionTemplateVersionRepository> actionTemplateVersionRepository = new Mock<IActionTemplateVersionRepository>();
                        actionTemplateVersionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplateVersion()));

                        var validator = new ApiActionTemplateVersionRequestModelValidator(actionTemplateVersionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                private async void BeUniqueByNameVersion_Create_Exists()
                {
                        Mock<IActionTemplateVersionRepository> actionTemplateVersionRepository = new Mock<IActionTemplateVersionRepository>();
                        actionTemplateVersionRepository.Setup(x => x.ByNameVersion(It.IsAny<string>(), It.IsAny<int>())).Returns(Task.FromResult<ActionTemplateVersion>(new ActionTemplateVersion()));
                        var validator = new ApiActionTemplateVersionRequestModelValidator(actionTemplateVersionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiActionTemplateVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByNameVersion_Create_Not_Exists()
                {
                        Mock<IActionTemplateVersionRepository> actionTemplateVersionRepository = new Mock<IActionTemplateVersionRepository>();
                        actionTemplateVersionRepository.Setup(x => x.ByNameVersion(It.IsAny<string>(), It.IsAny<int>())).Returns(Task.FromResult<ActionTemplateVersion>(null));
                        var validator = new ApiActionTemplateVersionRequestModelValidator(actionTemplateVersionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiActionTemplateVersionRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByNameVersion_Update_Exists()
                {
                        Mock<IActionTemplateVersionRepository> actionTemplateVersionRepository = new Mock<IActionTemplateVersionRepository>();
                        actionTemplateVersionRepository.Setup(x => x.ByNameVersion(It.IsAny<string>(), It.IsAny<int>())).Returns(Task.FromResult<ActionTemplateVersion>(new ActionTemplateVersion()));
                        var validator = new ApiActionTemplateVersionRequestModelValidator(actionTemplateVersionRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByNameVersion_Update_Not_Exists()
                {
                        Mock<IActionTemplateVersionRepository> actionTemplateVersionRepository = new Mock<IActionTemplateVersionRepository>();
                        actionTemplateVersionRepository.Setup(x => x.ByNameVersion(It.IsAny<string>(), It.IsAny<int>())).Returns(Task.FromResult<ActionTemplateVersion>(null));
                        var validator = new ApiActionTemplateVersionRequestModelValidator(actionTemplateVersionRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateVersionRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>950432f59c283fcd69cff5d466d85066</Hash>
</Codenesium>*/