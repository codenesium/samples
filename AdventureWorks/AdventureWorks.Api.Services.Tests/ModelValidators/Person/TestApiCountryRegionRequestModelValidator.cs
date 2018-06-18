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
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CountryRegion")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCountryRegionRequestModelValidatorTest
        {
                public ApiCountryRegionRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
                        countryRegionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegion()));

                        var validator = new ApiCountryRegionRequestModelValidator(countryRegionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRegionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
                        countryRegionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegion()));

                        var validator = new ApiCountryRegionRequestModelValidator(countryRegionRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCountryRegionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
                        countryRegionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegion()));

                        var validator = new ApiCountryRegionRequestModelValidator(countryRegionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRegionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
                        countryRegionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegion()));

                        var validator = new ApiCountryRegionRequestModelValidator(countryRegionRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCountryRegionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
                        countryRegionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegion()));

                        var validator = new ApiCountryRegionRequestModelValidator(countryRegionRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
                        countryRegionRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<CountryRegion>(new CountryRegion()));
                        var validator = new ApiCountryRegionRequestModelValidator(countryRegionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRegionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
                        countryRegionRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<CountryRegion>(null));
                        var validator = new ApiCountryRegionRequestModelValidator(countryRegionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRegionRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
                        countryRegionRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<CountryRegion>(new CountryRegion()));
                        var validator = new ApiCountryRegionRequestModelValidator(countryRegionRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCountryRegionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
                        countryRegionRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<CountryRegion>(null));
                        var validator = new ApiCountryRegionRequestModelValidator(countryRegionRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCountryRegionRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>168943cc0a64d08c13ed34ff3480e6d9</Hash>
</Codenesium>*/