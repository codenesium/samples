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
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "MachineRefTeam")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiMachineRefTeamRequestModelValidatorTest
        {
                public ApiMachineRefTeamRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void MachineId_Create_Valid_Reference()
                {
                        Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
                        machineRefTeamRepository.Setup(x => x.GetMachine(It.IsAny<int>())).Returns(Task.FromResult<Machine>(new Machine()));

                        var validator = new ApiMachineRefTeamRequestModelValidator(machineRefTeamRepository.Object);

                        await validator.ValidateCreateAsync(new ApiMachineRefTeamRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.MachineId, 1);
                }

                [Fact]
                public async void MachineId_Create_Invalid_Reference()
                {
                        Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
                        machineRefTeamRepository.Setup(x => x.GetMachine(It.IsAny<int>())).Returns(Task.FromResult<Machine>(null));

                        var validator = new ApiMachineRefTeamRequestModelValidator(machineRefTeamRepository.Object);

                        await validator.ValidateCreateAsync(new ApiMachineRefTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MachineId, 1);
                }

                [Fact]
                public async void MachineId_Update_Valid_Reference()
                {
                        Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
                        machineRefTeamRepository.Setup(x => x.GetMachine(It.IsAny<int>())).Returns(Task.FromResult<Machine>(new Machine()));

                        var validator = new ApiMachineRefTeamRequestModelValidator(machineRefTeamRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiMachineRefTeamRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.MachineId, 1);
                }

                [Fact]
                public async void MachineId_Update_Invalid_Reference()
                {
                        Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
                        machineRefTeamRepository.Setup(x => x.GetMachine(It.IsAny<int>())).Returns(Task.FromResult<Machine>(null));

                        var validator = new ApiMachineRefTeamRequestModelValidator(machineRefTeamRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiMachineRefTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MachineId, 1);
                }

                [Fact]
                public async void TeamId_Create_Valid_Reference()
                {
                        Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
                        machineRefTeamRepository.Setup(x => x.GetTeam(It.IsAny<int>())).Returns(Task.FromResult<Team>(new Team()));

                        var validator = new ApiMachineRefTeamRequestModelValidator(machineRefTeamRepository.Object);

                        await validator.ValidateCreateAsync(new ApiMachineRefTeamRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TeamId, 1);
                }

                [Fact]
                public async void TeamId_Create_Invalid_Reference()
                {
                        Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
                        machineRefTeamRepository.Setup(x => x.GetTeam(It.IsAny<int>())).Returns(Task.FromResult<Team>(null));

                        var validator = new ApiMachineRefTeamRequestModelValidator(machineRefTeamRepository.Object);

                        await validator.ValidateCreateAsync(new ApiMachineRefTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TeamId, 1);
                }

                [Fact]
                public async void TeamId_Update_Valid_Reference()
                {
                        Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
                        machineRefTeamRepository.Setup(x => x.GetTeam(It.IsAny<int>())).Returns(Task.FromResult<Team>(new Team()));

                        var validator = new ApiMachineRefTeamRequestModelValidator(machineRefTeamRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiMachineRefTeamRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TeamId, 1);
                }

                [Fact]
                public async void TeamId_Update_Invalid_Reference()
                {
                        Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
                        machineRefTeamRepository.Setup(x => x.GetTeam(It.IsAny<int>())).Returns(Task.FromResult<Team>(null));

                        var validator = new ApiMachineRefTeamRequestModelValidator(machineRefTeamRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiMachineRefTeamRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TeamId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>eda2c9970f88f827257ed4c9e2fdeb44</Hash>
</Codenesium>*/