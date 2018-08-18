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
	[Trait("Table", "Worker")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiWorkerRequestModelValidatorTest
	{
		public ApiWorkerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CommunicationStyle_Create_length()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Worker()));

			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);
			await validator.ValidateCreateAsync(new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CommunicationStyle, new string('A', 51));
		}

		[Fact]
		public async void CommunicationStyle_Update_length()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Worker()));

			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CommunicationStyle, new string('A', 51));
		}

		[Fact]
		public async void Fingerprint_Create_length()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Worker()));

			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);
			await validator.ValidateCreateAsync(new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Fingerprint, new string('A', 51));
		}

		[Fact]
		public async void Fingerprint_Update_length()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Worker()));

			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Fingerprint, new string('A', 51));
		}

		[Fact]
		public async void MachinePolicyId_Create_length()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Worker()));

			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);
			await validator.ValidateCreateAsync(new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MachinePolicyId, new string('A', 51));
		}

		[Fact]
		public async void MachinePolicyId_Update_length()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Worker()));

			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MachinePolicyId, new string('A', 51));
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Worker()));

			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);
			await validator.ValidateCreateAsync(new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Worker()));

			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Thumbprint_Create_length()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Worker()));

			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);
			await validator.ValidateCreateAsync(new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Thumbprint, new string('A', 51));
		}

		[Fact]
		public async void Thumbprint_Update_length()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Worker()));

			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Thumbprint, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Worker>(new Worker()));
			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);

			await validator.ValidateCreateAsync(new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Worker>(null));
			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);

			await validator.ValidateCreateAsync(new ApiWorkerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Worker>(new Worker()));
			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiWorkerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
			workerRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Worker>(null));
			var validator = new ApiWorkerRequestModelValidator(workerRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiWorkerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>e2e6debdd5f971558f1187df29d265b1</Hash>
</Codenesium>*/