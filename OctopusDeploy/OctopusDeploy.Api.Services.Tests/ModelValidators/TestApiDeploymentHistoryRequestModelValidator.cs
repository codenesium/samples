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
        [Trait("Table", "DeploymentHistory")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDeploymentHistoryRequestModelValidatorTest
        {
                public ApiDeploymentHistoryRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ChannelId_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelId, new string('A', 51));
                }

                [Fact]
                public async void ChannelId_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelId, new string('A', 51));
                }

                [Fact]
                public async void ChannelName_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelName, new string('A', 201));
                }

                [Fact]
                public async void ChannelName_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelName, new string('A', 201));
                }

                [Fact]
                public async void DeployedBy_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeployedBy, new string('A', 201));
                }

                [Fact]
                public async void DeployedBy_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeployedBy, new string('A', 201));
                }

                [Fact]
                public async void DeploymentName_Create_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentName, null as string);
                }

                [Fact]
                public async void DeploymentName_Update_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentName, null as string);
                }

                [Fact]
                public async void DeploymentName_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentName, new string('A', 201));
                }

                [Fact]
                public async void DeploymentName_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentName, new string('A', 201));
                }

                [Fact]
                public async void EnvironmentId_Create_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, null as string);
                }

                [Fact]
                public async void EnvironmentId_Update_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, null as string);
                }

                [Fact]
                public async void EnvironmentId_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentName_Create_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentName, null as string);
                }

                [Fact]
                public async void EnvironmentName_Update_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentName, null as string);
                }

                [Fact]
                public async void EnvironmentName_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentName, new string('A', 201));
                }

                [Fact]
                public async void EnvironmentName_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentName, new string('A', 201));
                }

                [Fact]
                public async void ProjectId_Create_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Update_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectName_Create_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectName, null as string);
                }

                [Fact]
                public async void ProjectName_Update_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectName, null as string);
                }

                [Fact]
                public async void ProjectName_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectName, new string('A', 201));
                }

                [Fact]
                public async void ProjectName_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectName, new string('A', 201));
                }

                [Fact]
                public async void ProjectSlug_Create_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectSlug, null as string);
                }

                [Fact]
                public async void ProjectSlug_Update_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectSlug, null as string);
                }

                [Fact]
                public async void ProjectSlug_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectSlug, new string('A', 211));
                }

                [Fact]
                public async void ProjectSlug_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectSlug, new string('A', 211));
                }

                [Fact]
                public async void ReleaseId_Create_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseId, null as string);
                }

                [Fact]
                public async void ReleaseId_Update_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseId, null as string);
                }

                [Fact]
                public async void ReleaseId_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseId, new string('A', 151));
                }

                [Fact]
                public async void ReleaseId_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseId, new string('A', 151));
                }

                [Fact]
                public async void ReleaseVersion_Create_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseVersion, null as string);
                }

                [Fact]
                public async void ReleaseVersion_Update_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseVersion, null as string);
                }

                [Fact]
                public async void ReleaseVersion_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseVersion, new string('A', 101));
                }

                [Fact]
                public async void ReleaseVersion_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseVersion, new string('A', 101));
                }

                [Fact]
                public async void TaskId_Create_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, null as string);
                }

                [Fact]
                public async void TaskId_Update_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, null as string);
                }

                [Fact]
                public async void TaskId_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, new string('A', 51));
                }

                [Fact]
                public async void TaskId_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, new string('A', 51));
                }

                [Fact]
                public async void TaskState_Create_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskState, null as string);
                }

                [Fact]
                public async void TaskState_Update_null()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskState, null as string);
                }

                [Fact]
                public async void TaskState_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskState, new string('A', 51));
                }

                [Fact]
                public async void TaskState_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskState, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantName_Create_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantName, new string('A', 201));
                }

                [Fact]
                public async void TenantName_Update_length()
                {
                        Mock<IDeploymentHistoryRepository> deploymentHistoryRepository = new Mock<IDeploymentHistoryRepository>();
                        deploymentHistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentHistory()));

                        var validator = new ApiDeploymentHistoryRequestModelValidator(deploymentHistoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantName, new string('A', 201));
                }
        }
}

/*<Codenesium>
    <Hash>dc98fbba05e3d5421aa6e4eef98626ee</Hash>
</Codenesium>*/