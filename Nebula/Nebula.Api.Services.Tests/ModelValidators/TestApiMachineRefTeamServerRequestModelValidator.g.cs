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
	public partial class ApiMachineRefTeamServerRequestModelValidatorTest
	{
		public ApiMachineRefTeamServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void MachineId_Create_Valid_Reference()
		{
			Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
			machineRefTeamRepository.Setup(x => x.MachineByMachineId(It.IsAny<int>())).Returns(Task.FromResult<Machine>(new Machine()));

			var validator = new ApiMachineRefTeamServerRequestModelValidator(machineRefTeamRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineRefTeamServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.MachineId, 1);
		}

		[Fact]
		public async void MachineId_Create_Invalid_Reference()
		{
			Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
			machineRefTeamRepository.Setup(x => x.MachineByMachineId(It.IsAny<int>())).Returns(Task.FromResult<Machine>(null));

			var validator = new ApiMachineRefTeamServerRequestModelValidator(machineRefTeamRepository.Object);

			await validator.ValidateCreateAsync(new ApiMachineRefTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MachineId, 1);
		}

		[Fact]
		public async void MachineId_Update_Valid_Reference()
		{
			Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
			machineRefTeamRepository.Setup(x => x.MachineByMachineId(It.IsAny<int>())).Returns(Task.FromResult<Machine>(new Machine()));

			var validator = new ApiMachineRefTeamServerRequestModelValidator(machineRefTeamRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineRefTeamServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.MachineId, 1);
		}

		[Fact]
		public async void MachineId_Update_Invalid_Reference()
		{
			Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
			machineRefTeamRepository.Setup(x => x.MachineByMachineId(It.IsAny<int>())).Returns(Task.FromResult<Machine>(null));

			var validator = new ApiMachineRefTeamServerRequestModelValidator(machineRefTeamRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiMachineRefTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MachineId, 1);
		}

		[Fact]
		public async void TeamId_Create_Valid_Reference()
		{
			Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
			machineRefTeamRepository.Setup(x => x.TeamByTeamId(It.IsAny<int>())).Returns(Task.FromResult<Team>(new Team()));

			var validator = new ApiMachineRefTeamServerRequestModelValidator(machineRefTeamRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineRefTeamServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeamId, 1);
		}

		[Fact]
		public async void TeamId_Create_Invalid_Reference()
		{
			Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
			machineRefTeamRepository.Setup(x => x.TeamByTeamId(It.IsAny<int>())).Returns(Task.FromResult<Team>(null));

			var validator = new ApiMachineRefTeamServerRequestModelValidator(machineRefTeamRepository.Object);

			await validator.ValidateCreateAsync(new ApiMachineRefTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeamId, 1);
		}

		[Fact]
		public async void TeamId_Update_Valid_Reference()
		{
			Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
			machineRefTeamRepository.Setup(x => x.TeamByTeamId(It.IsAny<int>())).Returns(Task.FromResult<Team>(new Team()));

			var validator = new ApiMachineRefTeamServerRequestModelValidator(machineRefTeamRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineRefTeamServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeamId, 1);
		}

		[Fact]
		public async void TeamId_Update_Invalid_Reference()
		{
			Mock<IMachineRefTeamRepository> machineRefTeamRepository = new Mock<IMachineRefTeamRepository>();
			machineRefTeamRepository.Setup(x => x.TeamByTeamId(It.IsAny<int>())).Returns(Task.FromResult<Team>(null));

			var validator = new ApiMachineRefTeamServerRequestModelValidator(machineRefTeamRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiMachineRefTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeamId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>85e781f2ed39e7e08d9635d0ffaac4b7</Hash>
</Codenesium>*/