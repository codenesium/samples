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
                public async void Description_Create_null()
                {
                        Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
                        petRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));

                        var validator = new ApiPetRequestModelValidator(petRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void Description_Update_null()
                {
                        Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
                        petRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));

                        var validator = new ApiPetRequestModelValidator(petRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void PenId_Create_Valid_Reference()
                {
                        Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
                        petRepository.Setup(x => x.GetPen(It.IsAny<int>())).Returns(Task.FromResult<Pen>(new Pen()));

                        var validator = new ApiPetRequestModelValidator(petRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPetRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PenId, 1);
                }

                [Fact]
                public async void PenId_Create_Invalid_Reference()
                {
                        Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
                        petRepository.Setup(x => x.GetPen(It.IsAny<int>())).Returns(Task.FromResult<Pen>(null));

                        var validator = new ApiPetRequestModelValidator(petRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PenId, 1);
                }

                [Fact]
                public async void PenId_Update_Valid_Reference()
                {
                        Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
                        petRepository.Setup(x => x.GetPen(It.IsAny<int>())).Returns(Task.FromResult<Pen>(new Pen()));

                        var validator = new ApiPetRequestModelValidator(petRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPetRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PenId, 1);
                }

                [Fact]
                public async void PenId_Update_Invalid_Reference()
                {
                        Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
                        petRepository.Setup(x => x.GetPen(It.IsAny<int>())).Returns(Task.FromResult<Pen>(null));

                        var validator = new ApiPetRequestModelValidator(petRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiPetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PenId, 1);
                }

                [Fact]
                public async void SpeciesId_Create_Valid_Reference()
                {
                        Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
                        petRepository.Setup(x => x.GetSpecies(It.IsAny<int>())).Returns(Task.FromResult<Species>(new Species()));

                        var validator = new ApiPetRequestModelValidator(petRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPetRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SpeciesId, 1);
                }

                [Fact]
                public async void SpeciesId_Create_Invalid_Reference()
                {
                        Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
                        petRepository.Setup(x => x.GetSpecies(It.IsAny<int>())).Returns(Task.FromResult<Species>(null));

                        var validator = new ApiPetRequestModelValidator(petRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SpeciesId, 1);
                }

                [Fact]
                public async void SpeciesId_Update_Valid_Reference()
                {
                        Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
                        petRepository.Setup(x => x.GetSpecies(It.IsAny<int>())).Returns(Task.FromResult<Species>(new Species()));

                        var validator = new ApiPetRequestModelValidator(petRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPetRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SpeciesId, 1);
                }

                [Fact]
                public async void SpeciesId_Update_Invalid_Reference()
                {
                        Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
                        petRepository.Setup(x => x.GetSpecies(It.IsAny<int>())).Returns(Task.FromResult<Species>(null));

                        var validator = new ApiPetRequestModelValidator(petRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiPetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SpeciesId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>e2280bbd8ff9bbbd9d193df07b41c81c</Hash>
</Codenesium>*/