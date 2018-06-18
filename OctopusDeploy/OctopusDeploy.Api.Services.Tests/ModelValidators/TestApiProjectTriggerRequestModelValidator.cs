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
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProjectTrigger")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProjectTriggerRequestModelValidatorTest
        {
                public ApiProjectTriggerRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ProjectId_Create_null()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Update_null()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Create_length()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Update_length()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Delete()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void TriggerType_Create_length()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TriggerType, new string('A', 51));
                }

                [Fact]
                public async void TriggerType_Update_length()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TriggerType, new string('A', 51));
                }

                [Fact]
                public async void TriggerType_Delete()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));

                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetProjectIdName_Create_Exists()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.GetProjectIdName(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<ProjectTrigger>(new ProjectTrigger()));
                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetProjectIdName_Create_Not_Exists()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.GetProjectIdName(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<ProjectTrigger>(null));
                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectTriggerRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetProjectIdName_Update_Exists()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.GetProjectIdName(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<ProjectTrigger>(new ProjectTrigger()));
                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetProjectIdName_Update_Not_Exists()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.GetProjectIdName(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<ProjectTrigger>(null));
                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProjectTriggerRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>b7e65957953cdc20e14cd01347e7bd23</Hash>
</Codenesium>*/