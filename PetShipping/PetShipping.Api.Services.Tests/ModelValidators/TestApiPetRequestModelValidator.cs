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
	public partial class ApiPetRequestModelValidatorTest
	{
		public ApiPetRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void BreedId_Create_Valid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.GetBreed(It.IsAny<int>())).Returns(Task.FromResult<Breed>(new Breed()));

			var validator = new ApiPetRequestModelValidator(petRepository.Object);
			await validator.ValidateCreateAsync(new ApiPetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.BreedId, 1);
		}

		[Fact]
		public async void BreedId_Create_Invalid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.GetBreed(It.IsAny<int>())).Returns(Task.FromResult<Breed>(null));

			var validator = new ApiPetRequestModelValidator(petRepository.Object);

			await validator.ValidateCreateAsync(new ApiPetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.BreedId, 1);
		}

		[Fact]
		public async void BreedId_Update_Valid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.GetBreed(It.IsAny<int>())).Returns(Task.FromResult<Breed>(new Breed()));

			var validator = new ApiPetRequestModelValidator(petRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.BreedId, 1);
		}

		[Fact]
		public async void BreedId_Update_Invalid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.GetBreed(It.IsAny<int>())).Returns(Task.FromResult<Breed>(null));

			var validator = new ApiPetRequestModelValidator(petRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.BreedId, 1);
		}

		[Fact]
		public async void ClientId_Create_Valid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(new Client()));

			var validator = new ApiPetRequestModelValidator(petRepository.Object);
			await validator.ValidateCreateAsync(new ApiPetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ClientId, 1);
		}

		[Fact]
		public async void ClientId_Create_Invalid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(null));

			var validator = new ApiPetRequestModelValidator(petRepository.Object);

			await validator.ValidateCreateAsync(new ApiPetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ClientId, 1);
		}

		[Fact]
		public async void ClientId_Update_Valid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(new Client()));

			var validator = new ApiPetRequestModelValidator(petRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ClientId, 1);
		}

		[Fact]
		public async void ClientId_Update_Invalid_Reference()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(null));

			var validator = new ApiPetRequestModelValidator(petRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ClientId, 1);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));

			var validator = new ApiPetRequestModelValidator(petRepository.Object);
			await validator.ValidateCreateAsync(new ApiPetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			petRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));

			var validator = new ApiPetRequestModelValidator(petRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>609ad298f40e6994fddeb73fc06d1b4f</Hash>
</Codenesium>*/