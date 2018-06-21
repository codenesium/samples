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
        [Trait("Table", "Team")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTeamRequestModelValidatorTest
        {
                public ApiTeamRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void EnvironmentIds_Create_null()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentIds, null as string);
                }

                [Fact]
                public async void EnvironmentIds_Update_null()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentIds, null as string);
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void MemberUserIds_Create_null()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MemberUserIds, null as string);
                }

                [Fact]
                public async void MemberUserIds_Update_null()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MemberUserIds, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ProjectIds_Create_null()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectIds, null as string);
                }

                [Fact]
                public async void ProjectIds_Update_null()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Team()));

                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectIds, null as string);
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Team>(new Team()));
                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Team>(null));
                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTeamRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Team>(new Team()));
                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
                        teamRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Team>(null));
                        var validator = new ApiTeamRequestModelValidator(teamRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiTeamRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>cecfd3b5901a9f427df1e1b0e4a49245</Hash>
</Codenesium>*/