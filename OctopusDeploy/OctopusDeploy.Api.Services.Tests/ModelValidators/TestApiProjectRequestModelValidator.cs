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
        [Trait("Table", "Project")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProjectRequestModelValidatorTest
        {
                public ApiProjectRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void DeploymentProcessId_Create_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentProcessId, new string('A', 51));
                }

                [Fact]
                public async void DeploymentProcessId_Update_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentProcessId, new string('A', 51));
                }

                [Fact]
                public async void DeploymentProcessId_Delete()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void LifecycleId_Create_null()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LifecycleId, null as string);
                }

                [Fact]
                public async void LifecycleId_Update_null()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LifecycleId, null as string);
                }

                [Fact]
                public async void LifecycleId_Create_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LifecycleId, new string('A', 51));
                }

                [Fact]
                public async void LifecycleId_Update_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LifecycleId, new string('A', 51));
                }

                [Fact]
                public async void LifecycleId_Delete()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ProjectGroupId_Create_null()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectGroupId, null as string);
                }

                [Fact]
                public async void ProjectGroupId_Update_null()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectGroupId, null as string);
                }

                [Fact]
                public async void ProjectGroupId_Create_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectGroupId, new string('A', 51));
                }

                [Fact]
                public async void ProjectGroupId_Update_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectGroupId, new string('A', 51));
                }

                [Fact]
                public async void ProjectGroupId_Delete()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Slug_Create_null()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Slug, null as string);
                }

                [Fact]
                public async void Slug_Update_null()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Slug, null as string);
                }

                [Fact]
                public async void Slug_Create_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Slug, new string('A', 211));
                }

                [Fact]
                public async void Slug_Update_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Slug, new string('A', 211));
                }

                [Fact]
                public async void Slug_Delete()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void VariableSetId_Create_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.VariableSetId, new string('A', 151));
                }

                [Fact]
                public async void VariableSetId_Update_length()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.VariableSetId, new string('A', 151));
                }

                [Fact]
                public async void VariableSetId_Delete()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));

                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Project>(new Project()));
                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Project>(null));
                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Project>(new Project()));
                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<IProjectRepository> projectRepository = new Mock<IProjectRepository>();
                        projectRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Project>(null));
                        var validator = new ApiProjectRequestModelValidator(projectRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiProjectRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>948db10398ab714cc664a215fcb4bbfc</Hash>
</Codenesium>*/