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
        [Trait("Table", "Interruption")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiInterruptionRequestModelValidatorTest
        {
                public ApiInterruptionRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void EnvironmentId_Create_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, null as string);
                }

                [Fact]
                public async void EnvironmentId_Update_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, null as string);
                }

                [Fact]
                public async void EnvironmentId_Create_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Update_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Delete()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void ProjectId_Create_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Update_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Create_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Update_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Delete()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void RelatedDocumentIds_Create_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RelatedDocumentIds, null as string);
                }

                [Fact]
                public async void RelatedDocumentIds_Update_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RelatedDocumentIds, null as string);
                }

                [Fact]
                public async void ResponsibleTeamIds_Create_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ResponsibleTeamIds, null as string);
                }

                [Fact]
                public async void ResponsibleTeamIds_Update_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ResponsibleTeamIds, null as string);
                }

                [Fact]
                public async void Status_Create_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Status, null as string);
                }

                [Fact]
                public async void Status_Update_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Status, null as string);
                }

                [Fact]
                public async void Status_Create_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Status, new string('A', 51));
                }

                [Fact]
                public async void Status_Update_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Status, new string('A', 51));
                }

                [Fact]
                public async void Status_Delete()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void TaskId_Create_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, null as string);
                }

                [Fact]
                public async void TaskId_Update_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, null as string);
                }

                [Fact]
                public async void TaskId_Create_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, new string('A', 51));
                }

                [Fact]
                public async void TaskId_Update_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, new string('A', 51));
                }

                [Fact]
                public async void TaskId_Delete()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void TenantId_Create_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Update_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Delete()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Title_Create_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, null as string);
                }

                [Fact]
                public async void Title_Update_null()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, null as string);
                }

                [Fact]
                public async void Title_Create_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 201));
                }

                [Fact]
                public async void Title_Update_length()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiInterruptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 201));
                }

                [Fact]
                public async void Title_Delete()
                {
                        Mock<IInterruptionRepository> interruptionRepository = new Mock<IInterruptionRepository>();
                        interruptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Interruption()));

                        var validator = new ApiInterruptionRequestModelValidator(interruptionRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>a17b4e3d5913a477336acb7cc2c87a6d</Hash>
</Codenesium>*/