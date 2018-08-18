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
	[Trait("Table", "Machine")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiMachineRequestModelValidatorTest
	{
		public ApiMachineRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CommunicationStyle_Create_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CommunicationStyle, new string('A', 51));
		}

		[Fact]
		public async void CommunicationStyle_Update_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CommunicationStyle, new string('A', 51));
		}

		[Fact]
		public async void Fingerprint_Create_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Fingerprint, new string('A', 51));
		}

		[Fact]
		public async void Fingerprint_Update_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Fingerprint, new string('A', 51));
		}

		[Fact]
		public async void MachinePolicyId_Create_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MachinePolicyId, new string('A', 51));
		}

		[Fact]
		public async void MachinePolicyId_Update_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MachinePolicyId, new string('A', 51));
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Thumbprint_Create_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Thumbprint, new string('A', 51));
		}

		[Fact]
		public async void Thumbprint_Update_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Thumbprint, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Machine>(new Machine()));
			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);

			await validator.ValidateCreateAsync(new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Machine>(null));
			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);

			await validator.ValidateCreateAsync(new ApiMachineRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Machine>(new Machine()));
			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiMachineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Machine>(null));
			var validator = new ApiMachineRequestModelValidator(machineRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiMachineRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>4c92b65181ec0589f990c209db2472bc</Hash>
</Codenesium>*/