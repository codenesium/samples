using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Breed")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiBreedRequestModelValidatorTest
	{
		public ApiBreedRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Breed()));

			var validator = new ApiBreedRequestModelValidator(breedRepository.Object);
			await validator.ValidateCreateAsync(new ApiBreedRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Breed()));

			var validator = new ApiBreedRequestModelValidator(breedRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBreedRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void SpeciesId_Create_Valid_Reference()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.GetSpecies(It.IsAny<int>())).Returns(Task.FromResult<Species>(new Species()));

			var validator = new ApiBreedRequestModelValidator(breedRepository.Object);
			await validator.ValidateCreateAsync(new ApiBreedRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpeciesId, 1);
		}

		[Fact]
		public async void SpeciesId_Create_Invalid_Reference()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.GetSpecies(It.IsAny<int>())).Returns(Task.FromResult<Species>(null));

			var validator = new ApiBreedRequestModelValidator(breedRepository.Object);

			await validator.ValidateCreateAsync(new ApiBreedRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpeciesId, 1);
		}

		[Fact]
		public async void SpeciesId_Update_Valid_Reference()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.GetSpecies(It.IsAny<int>())).Returns(Task.FromResult<Species>(new Species()));

			var validator = new ApiBreedRequestModelValidator(breedRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBreedRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpeciesId, 1);
		}

		[Fact]
		public async void SpeciesId_Update_Invalid_Reference()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.GetSpecies(It.IsAny<int>())).Returns(Task.FromResult<Species>(null));

			var validator = new ApiBreedRequestModelValidator(breedRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiBreedRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpeciesId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>6ab9083de6a82200688355419c53a03f</Hash>
</Codenesium>*/