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
        [Trait("Table", "ProjectGroup")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProjectGroupRequestModelValidatorTest
        {
                public ApiProjectGroupRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
                        projectGroupRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectGroup()));

                        var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectGroupRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
                        projectGroupRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectGroup()));

                        var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectGroupRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
                        projectGroupRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectGroup()));

                        var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectGroupRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
                        projectGroupRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectGroup()));

                        var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectGroupRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
                        projectGroupRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectGroup()));

                        var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectGroupRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
                        projectGroupRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectGroup()));

                        var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectGroupRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
                        projectGroupRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectGroup()));

                        var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
                        projectGroupRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<ProjectGroup>(new ProjectGroup()));
                        var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectGroupRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
                        projectGroupRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<ProjectGroup>(null));
                        var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectGroupRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
                        projectGroupRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<ProjectGroup>(new ProjectGroup()));
                        var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiProjectGroupRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
                        projectGroupRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<ProjectGroup>(null));
                        var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiProjectGroupRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>03c90044546410ef67d5fae12fd76027</Hash>
</Codenesium>*/