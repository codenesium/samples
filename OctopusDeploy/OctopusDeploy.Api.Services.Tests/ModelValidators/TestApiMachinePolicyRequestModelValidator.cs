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
	[Trait("Table", "MachinePolicy")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiMachinePolicyRequestModelValidatorTest
	{
		public ApiMachinePolicyRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
			machinePolicyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new MachinePolicy()));

			var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachinePolicyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
			machinePolicyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new MachinePolicy()));

			var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiMachinePolicyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
			machinePolicyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<MachinePolicy>(new MachinePolicy()));
			var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);

			await validator.ValidateCreateAsync(new ApiMachinePolicyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
			machinePolicyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<MachinePolicy>(null));
			var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);

			await validator.ValidateCreateAsync(new ApiMachinePolicyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
			machinePolicyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<MachinePolicy>(new MachinePolicy()));
			var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiMachinePolicyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
			machinePolicyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<MachinePolicy>(null));
			var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiMachinePolicyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>a758e6115c3d4646a905a7cd8e861f6d</Hash>
</Codenesium>*/