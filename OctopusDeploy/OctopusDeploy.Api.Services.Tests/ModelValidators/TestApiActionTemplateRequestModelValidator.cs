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
        [Trait("Table", "ActionTemplate")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiActionTemplateRequestModelValidatorTest
        {
                public ApiActionTemplateRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ActionType_Create_null()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateCreateAsync(new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ActionType, null as string);
                }

                [Fact]
                public async void ActionType_Update_null()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ActionType, null as string);
                }

                [Fact]
                public async void ActionType_Create_length()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateCreateAsync(new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ActionType, new string('A', 51));
                }

                [Fact]
                public async void ActionType_Update_length()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ActionType, new string('A', 51));
                }

                [Fact]
                public async void ActionType_Delete()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void CommunityActionTemplateId_Create_length()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateCreateAsync(new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CommunityActionTemplateId, new string('A', 51));
                }

                [Fact]
                public async void CommunityActionTemplateId_Update_length()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CommunityActionTemplateId, new string('A', 51));
                }

                [Fact]
                public async void CommunityActionTemplateId_Delete()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateCreateAsync(new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateCreateAsync(new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateCreateAsync(new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));

                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<ActionTemplate>(new ActionTemplate()));
                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<ActionTemplate>(null));
                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiActionTemplateRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<ActionTemplate>(new ActionTemplate()));
                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<IActionTemplateRepository> actionTemplateRepository = new Mock<IActionTemplateRepository>();
                        actionTemplateRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<ActionTemplate>(null));
                        var validator = new ApiActionTemplateRequestModelValidator(actionTemplateRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiActionTemplateRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>0766caa7d909ba7e87a7bab6aff057bd</Hash>
</Codenesium>*/