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
        [Trait("Table", "ProjectTrigger")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProjectTriggerRequestModelValidatorTest
        {
                public ApiProjectTriggerRequestModelValidatorTest()
                {
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
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
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
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
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
                        await validator.ValidateUpdateAsync(default(string), new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TriggerType, new string('A', 51));
                }

                [Fact]
                private async void BeUniqueByProjectIdName_Create_Exists()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.ByProjectIdName(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<ProjectTrigger>(new ProjectTrigger()));
                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByProjectIdName_Create_Not_Exists()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.ByProjectIdName(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<ProjectTrigger>(null));
                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProjectTriggerRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByProjectIdName_Update_Exists()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.ByProjectIdName(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<ProjectTrigger>(new ProjectTrigger()));
                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiProjectTriggerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByProjectIdName_Update_Not_Exists()
                {
                        Mock<IProjectTriggerRepository> projectTriggerRepository = new Mock<IProjectTriggerRepository>();
                        projectTriggerRepository.Setup(x => x.ByProjectIdName(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<ProjectTrigger>(null));
                        var validator = new ApiProjectTriggerRequestModelValidator(projectTriggerRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiProjectTriggerRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>759a31d07d20c25c8c9de2c0231f35bc</Hash>
</Codenesium>*/