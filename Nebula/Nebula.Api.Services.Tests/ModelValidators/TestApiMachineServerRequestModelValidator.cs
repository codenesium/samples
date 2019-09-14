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
	public partial class ApiMachineServerRequestModelValidatorTest
	{
		public ApiMachineServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Description_Create_null()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void JwtKey_Create_null()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.JwtKey, null as string);
		}

		[Fact]
		public async void JwtKey_Update_null()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.JwtKey, null as string);
		}

		[Fact]
		public async void JwtKey_Create_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.JwtKey, new string('A', 129));
		}

		[Fact]
		public async void JwtKey_Update_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.JwtKey, new string('A', 129));
		}

		[Fact]
		public async void LastIpAddress_Create_null()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastIpAddress, null as string);
		}

		[Fact]
		public async void LastIpAddress_Update_null()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastIpAddress, null as string);
		}

		[Fact]
		public async void LastIpAddress_Create_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastIpAddress, new string('A', 129));
		}

		[Fact]
		public async void LastIpAddress_Update_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastIpAddress, new string('A', 129));
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateCreateAsync(new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		private async void BeUniqueByMachineGuid_Create_Exists()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.ByMachineGuid(It.IsAny<Guid>())).Returns(Task.FromResult<Machine>(new Machine()));
			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);

			await validator.ValidateCreateAsync(new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MachineGuid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByMachineGuid_Create_Not_Exists()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.ByMachineGuid(It.IsAny<Guid>())).Returns(Task.FromResult<Machine>(null));
			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);

			await validator.ValidateCreateAsync(new ApiMachineServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.MachineGuid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByMachineGuid_Update_Exists()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.ByMachineGuid(It.IsAny<Guid>())).Returns(Task.FromResult<Machine>(new Machine()));
			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiMachineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MachineGuid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByMachineGuid_Update_Not_Exists()
		{
			Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
			machineRepository.Setup(x => x.ByMachineGuid(It.IsAny<Guid>())).Returns(Task.FromResult<Machine>(null));
			var validator = new ApiMachineServerRequestModelValidator(machineRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiMachineServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.MachineGuid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>942a0bf69226ce164a63de22b5adf36b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/