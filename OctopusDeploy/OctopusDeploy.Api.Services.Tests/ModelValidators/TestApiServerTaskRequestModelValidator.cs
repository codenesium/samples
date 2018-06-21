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
        [Trait("Table", "ServerTask")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiServerTaskRequestModelValidatorTest
        {
                public ApiServerTaskRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ConcurrencyTag_Create_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateCreateAsync(new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ConcurrencyTag, new string('A', 101));
                }

                [Fact]
                public async void ConcurrencyTag_Update_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ConcurrencyTag, new string('A', 101));
                }

                [Fact]
                public async void ConcurrencyTag_Delete()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Description_Create_null()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateCreateAsync(new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void Description_Update_null()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void EnvironmentId_Create_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateCreateAsync(new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Update_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Delete()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateCreateAsync(new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateCreateAsync(new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateCreateAsync(new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ProjectId_Create_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateCreateAsync(new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Update_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Delete()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ServerNodeId_Create_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateCreateAsync(new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ServerNodeId, new string('A', 251));
                }

                [Fact]
                public async void ServerNodeId_Update_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ServerNodeId, new string('A', 251));
                }

                [Fact]
                public async void ServerNodeId_Delete()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void State_Create_null()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateCreateAsync(new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.State, null as string);
                }

                [Fact]
                public async void State_Update_null()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.State, null as string);
                }

                [Fact]
                public async void State_Create_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateCreateAsync(new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.State, new string('A', 51));
                }

                [Fact]
                public async void State_Update_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.State, new string('A', 51));
                }

                [Fact]
                public async void State_Delete()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void TenantId_Create_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateCreateAsync(new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Update_length()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiServerTaskRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Delete()
                {
                        Mock<IServerTaskRepository> serverTaskRepository = new Mock<IServerTaskRepository>();
                        serverTaskRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));

                        var validator = new ApiServerTaskRequestModelValidator(serverTaskRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>b3a7d72be0f4bdd9c315347622a976ba</Hash>
</Codenesium>*/