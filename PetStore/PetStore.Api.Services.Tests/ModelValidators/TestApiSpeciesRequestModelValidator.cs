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
                        await validator.ValidateUpdateAsync(default(int), new ApiSpeciesRequestModel());

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
                        await validator.ValidateUpdateAsync(default(int), new ApiSpeciesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }
        }
}

/*<Codenesium>
    <Hash>7fdb6a09a7e24b513b3daed5223c9864</Hash>
</Codenesium>*/