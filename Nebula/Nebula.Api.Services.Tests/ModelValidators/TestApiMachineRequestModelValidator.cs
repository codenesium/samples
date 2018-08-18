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
	[Trait("Table", "Machine")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiMachineRequestModelValidatorTest
	{
		public ApiMachineRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void JwtKey_Create_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.JwtKey, new string('A', 129));
		}

		[Fact]
		public async void JwtKey_Update_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.JwtKey, new string('A', 129));
		}

		[Fact]
		public async void LastIpAddress_Create_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastIpAddress, new string('A', 129));
		}

		[Fact]
		public async void LastIpAddress_Update_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastIpAddress, new string('A', 129));
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>d5161e93b7702c4e6ec0576a28a107c2</Hash>
</Codenesium>*/