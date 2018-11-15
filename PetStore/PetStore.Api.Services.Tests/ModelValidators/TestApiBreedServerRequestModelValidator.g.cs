using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Breed")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiBreedServerRequestModelValidatorTest
	{
		public ApiBreedServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Breed()));

			var validator = new ApiBreedServerRequestModelValidator(breedRepository.Object);
			await validator.ValidateCreateAsync(new ApiBreedServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Breed()));

			var validator = new ApiBreedServerRequestModelValidator(breedRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBreedServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Breed()));

			var validator = new ApiBreedServerRequestModelValidator(breedRepository.Object);
			await validator.ValidateCreateAsync(new ApiBreedServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Breed()));

			var validator = new ApiBreedServerRequestModelValidator(breedRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBreedServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>0c5b1b1d3360be1ff3a602f1821da2fa</Hash>
</Codenesium>*/