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
		public async void Description_Create_null()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);
			await validator.ValidateCreateAsync(new ApiPetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void PenId_Create_Valid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.PenByPenId(It.IsAny<int>())).Returns(Task.FromResult<Pen>(new Pen()));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);
			await validator.ValidateCreateAsync(new ApiPetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PenId, 1);
		}

		[Fact]
		public async void PenId_Create_Invalid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.PenByPenId(It.IsAny<int>())).Returns(Task.FromResult<Pen>(null));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);

			await validator.ValidateCreateAsync(new ApiPetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PenId, 1);
		}

		[Fact]
		public async void PenId_Update_Valid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.PenByPenId(It.IsAny<int>())).Returns(Task.FromResult<Pen>(new Pen()));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PenId, 1);
		}

		[Fact]
		public async void PenId_Update_Invalid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.PenByPenId(It.IsAny<int>())).Returns(Task.FromResult<Pen>(null));

			var validator = new ApiPetServerRequestModelValidator(petRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PenId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>ce6f5c096e5dbc65aa036717366f1f73</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/