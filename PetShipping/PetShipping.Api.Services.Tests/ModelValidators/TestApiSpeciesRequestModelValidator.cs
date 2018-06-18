using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Species")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSpeciesRequestModelValidatorTest
        {
                public ApiSpeciesRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ISpeciesRepository> speciesRepository = new Mock<ISpeciesRepository>();
                        speciesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));

                        var validator = new ApiSpeciesRequestModelValidator(speciesRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSpeciesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ISpeciesRepository> speciesRepository = new Mock<ISpeciesRepository>();
                        speciesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));

                        var validator = new ApiSpeciesRequestModelValidator(speciesRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSpeciesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ISpeciesRepository> speciesRepository = new Mock<ISpeciesRepository>();
                        speciesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));

                        var validator = new ApiSpeciesRequestModelValidator(speciesRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSpeciesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ISpeciesRepository> speciesRepository = new Mock<ISpeciesRepository>();
                        speciesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));

                        var validator = new ApiSpeciesRequestModelValidator(speciesRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSpeciesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ISpeciesRepository> speciesRepository = new Mock<ISpeciesRepository>();
                        speciesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));

                        var validator = new ApiSpeciesRequestModelValidator(speciesRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>e0155246c036a0784453435598a97c50</Hash>
</Codenesium>*/