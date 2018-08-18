using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

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
			await validator.ValidateUpdateAsync(default(int), new ApiMachineRefTeamRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.MachineId, 1);
		}

		[Fact]
		public async void MachineId_Update_Invalid_Reference()
		{
			Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
			machineRefTeamRepository.Setup(x => x.GetMachine(It.IsAny<int>())).Returns(Task.FromResult<Machine>(null));

			var validator = new ApiMachineRefTeamRequestModelValidator(machineRefTeamRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiMachineRefTeamRequestModel());

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
			await validator.ValidateUpdateAsync(default(int), new ApiMachineRefTeamRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeamId, 1);
		}

		[Fact]
		public async void TeamId_Update_Invalid_Reference()
		{
			Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
			machineRefTeamRepository.Setup(x => x.GetTeam(It.IsAny<int>())).Returns(Task.FromResult<Team>(null));

			var validator = new ApiMachineRefTeamRequestModelValidator(machineRefTeamRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiMachineRefTeamRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeamId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>3a82f0c6508346b32a44a945fc2c6866</Hash>
</Codenesium>*/