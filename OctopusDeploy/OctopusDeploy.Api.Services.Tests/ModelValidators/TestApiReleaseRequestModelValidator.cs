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
        [Trait("Table", "Release")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiReleaseRequestModelValidatorTest
        {
                public ApiReleaseRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ChannelId_Create_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelId, null as string);
                }

                [Fact]
                public async void ChannelId_Update_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelId, null as string);
                }

                [Fact]
                public async void ChannelId_Create_length()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelId, new string('A', 51));
                }

                [Fact]
                public async void ChannelId_Update_length()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelId, new string('A', 51));
                }

                [Fact]
                public async void ChannelId_Delete()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void ProjectDeploymentProcessSnapshotId_Create_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectDeploymentProcessSnapshotId, null as string);
                }

                [Fact]
                public async void ProjectDeploymentProcessSnapshotId_Update_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectDeploymentProcessSnapshotId, null as string);
                }

                [Fact]
                public async void ProjectDeploymentProcessSnapshotId_Create_length()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectDeploymentProcessSnapshotId, new string('A', 151));
                }

                [Fact]
                public async void ProjectDeploymentProcessSnapshotId_Update_length()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectDeploymentProcessSnapshotId, new string('A', 151));
                }

                [Fact]
                public async void ProjectDeploymentProcessSnapshotId_Delete()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ProjectId_Create_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Update_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Create_length()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 151));
                }

                [Fact]
                public async void ProjectId_Update_length()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 151));
                }

                [Fact]
                public async void ProjectId_Delete()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ProjectVariableSetSnapshotId_Create_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectVariableSetSnapshotId, null as string);
                }

                [Fact]
                public async void ProjectVariableSetSnapshotId_Update_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectVariableSetSnapshotId, null as string);
                }

                [Fact]
                public async void ProjectVariableSetSnapshotId_Create_length()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectVariableSetSnapshotId, new string('A', 151));
                }

                [Fact]
                public async void ProjectVariableSetSnapshotId_Update_length()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectVariableSetSnapshotId, new string('A', 151));
                }

                [Fact]
                public async void ProjectVariableSetSnapshotId_Delete()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Version_Create_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Version, null as string);
                }

                [Fact]
                public async void Version_Update_null()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Version, null as string);
                }

                [Fact]
                public async void Version_Create_length()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Version, new string('A', 101));
                }

                [Fact]
                public async void Version_Update_length()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Version, new string('A', 101));
                }

                [Fact]
                public async void Version_Delete()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));

                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetVersionProjectId_Create_Exists()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.GetVersionProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Release>(new Release()));
                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, "A");
                }

                [Fact]
                private async void BeUniqueGetVersionProjectId_Create_Not_Exists()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.GetVersionProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Release>(null));
                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateCreateAsync(new ApiReleaseRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ProjectId, "A");
                }

                [Fact]
                private async void BeUniqueGetVersionProjectId_Update_Exists()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.GetVersionProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Release>(new Release()));
                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, "A");
                }

                [Fact]
                private async void BeUniqueGetVersionProjectId_Update_Not_Exists()
                {
                        Mock<IReleaseRepository> releaseRepository = new Mock<IReleaseRepository>();
                        releaseRepository.Setup(x => x.GetVersionProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Release>(null));
                        var validator = new ApiReleaseRequestModelValidator(releaseRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiReleaseRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ProjectId, "A");
                }
        }
}

/*<Codenesium>
    <Hash>aaae03caee1a43c08b97e8dc7cba3033</Hash>
</Codenesium>*/