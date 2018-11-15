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

		[Fact]
		public async void SpeciesId_Create_Valid_Reference()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.SpeciesBySpeciesId(It.IsAny<int>())).Returns(Task.FromResult<Species>(new Species()));

			var validator = new ApiBreedServerRequestModelValidator(breedRepository.Object);
			await validator.ValidateCreateAsync(new ApiBreedServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpeciesId, 1);
		}

		[Fact]
		public async void SpeciesId_Create_Invalid_Reference()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.SpeciesBySpeciesId(It.IsAny<int>())).Returns(Task.FromResult<Species>(null));

			var validator = new ApiBreedServerRequestModelValidator(breedRepository.Object);

			await validator.ValidateCreateAsync(new ApiBreedServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpeciesId, 1);
		}

		[Fact]
		public async void SpeciesId_Update_Valid_Reference()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.SpeciesBySpeciesId(It.IsAny<int>())).Returns(Task.FromResult<Species>(new Species()));

			var validator = new ApiBreedServerRequestModelValidator(breedRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBreedServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpeciesId, 1);
		}

		[Fact]
		public async void SpeciesId_Update_Invalid_Reference()
		{
			Mock<IBreedRepository> breedRepository = new Mock<IBreedRepository>();
			breedRepository.Setup(x => x.SpeciesBySpeciesId(It.IsAny<int>())).Returns(Task.FromResult<Species>(null));

			var validator = new ApiBreedServerRequestModelValidator(breedRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiBreedServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpeciesId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>a1a121842ed1ecfe590a3c38b47b5720</Hash>
</Codenesium>*/