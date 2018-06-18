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
        [Trait("Table", "CountryRequirement")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCountryRequirementRequestModelValidatorTest
        {
                public ApiCountryRequirementRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void CountryId_Create_Valid_Reference()
                {
                        Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
                        countryRequirementRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(new Country()));

                        var validator = new ApiCountryRequirementRequestModelValidator(countryRequirementRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRequirementRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void CountryId_Create_Invalid_Reference()
                {
                        Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
                        countryRequirementRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

                        var validator = new ApiCountryRequirementRequestModelValidator(countryRequirementRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRequirementRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void CountryId_Update_Valid_Reference()
                {
                        Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
                        countryRequirementRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(new Country()));

                        var validator = new ApiCountryRequirementRequestModelValidator(countryRequirementRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCountryRequirementRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void CountryId_Update_Invalid_Reference()
                {
                        Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
                        countryRequirementRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

                        var validator = new ApiCountryRequirementRequestModelValidator(countryRequirementRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCountryRequirementRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void Details_Create_null()
                {
                        Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
                        countryRequirementRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CountryRequirement()));

                        var validator = new ApiCountryRequirementRequestModelValidator(countryRequirementRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRequirementRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Details, null as string);
                }

                [Fact]
                public async void Details_Update_null()
                {
                        Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
                        countryRequirementRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CountryRequirement()));

                        var validator = new ApiCountryRequirementRequestModelValidator(countryRequirementRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCountryRequirementRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Details, null as string);
                }
        }
}

/*<Codenesium>
    <Hash>53001dd81d48ab2532c6da5f06834485</Hash>
</Codenesium>*/