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
	[Trait("Table", "Pet")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPetServerRequestModelValidatorTest
	{
		public ApiPetServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void BreedId_Create_Valid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.BreedByBreedId(It.IsAny<int>())).Returns(Task.FromResult<Breed>(new Breed()));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);
			await validator.ValidateCreateAsync(new ApiPetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.BreedId, 1);
		}

		[Fact]
		public async void BreedId_Create_Invalid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.BreedByBreedId(It.IsAny<int>())).Returns(Task.FromResult<Breed>(null));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);

			await validator.ValidateCreateAsync(new ApiPetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.BreedId, 1);
		}

		[Fact]
		public async void BreedId_Update_Valid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.BreedByBreedId(It.IsAny<int>())).Returns(Task.FromResult<Breed>(new Breed()));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.BreedId, 1);
		}

		[Fact]
		public async void BreedId_Update_Invalid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.BreedByBreedId(It.IsAny<int>())).Returns(Task.FromResult<Breed>(null));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.BreedId, 1);
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);
			await validator.ValidateCreateAsync(new ApiPetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);
			await validator.ValidateCreateAsync(new ApiPetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>006706aaf3ee790b4feedb8e725408d8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/