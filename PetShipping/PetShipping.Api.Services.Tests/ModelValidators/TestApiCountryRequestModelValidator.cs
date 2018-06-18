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
        [Trait("Table", "Country")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCountryRequestModelValidatorTest
        {
                public ApiCountryRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
                        countryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));

                        var validator = new ApiCountryRequestModelValidator(countryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
                        countryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));

                        var validator = new ApiCountryRequestModelValidator(countryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCountryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
                        countryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));

                        var validator = new ApiCountryRequestModelValidator(countryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
                        countryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));

                        var validator = new ApiCountryRequestModelValidator(countryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCountryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
                        countryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));

                        var validator = new ApiCountryRequestModelValidator(countryRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>54f39672f00d40b7be5b417a12e8032d</Hash>
</Codenesium>*/