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
        [Trait("Table", "CountryRegionCurrency")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCountryRegionCurrencyRequestModelValidatorTest
        {
                public ApiCountryRegionCurrencyRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void CurrencyCode_Create_null()
                {
                        Mock<ICountryRegionCurrencyRepository> countryRegionCurrencyRepository = new Mock<ICountryRegionCurrencyRepository>();
                        countryRegionCurrencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegionCurrency()));

                        var validator = new ApiCountryRegionCurrencyRequestModelValidator(countryRegionCurrencyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRegionCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CurrencyCode, null as string);
                }

                [Fact]
                public async void CurrencyCode_Update_null()
                {
                        Mock<ICountryRegionCurrencyRepository> countryRegionCurrencyRepository = new Mock<ICountryRegionCurrencyRepository>();
                        countryRegionCurrencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegionCurrency()));

                        var validator = new ApiCountryRegionCurrencyRequestModelValidator(countryRegionCurrencyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCountryRegionCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CurrencyCode, null as string);
                }

                [Fact]
                public async void CurrencyCode_Create_length()
                {
                        Mock<ICountryRegionCurrencyRepository> countryRegionCurrencyRepository = new Mock<ICountryRegionCurrencyRepository>();
                        countryRegionCurrencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegionCurrency()));

                        var validator = new ApiCountryRegionCurrencyRequestModelValidator(countryRegionCurrencyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRegionCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CurrencyCode, new string('A', 4));
                }

                [Fact]
                public async void CurrencyCode_Update_length()
                {
                        Mock<ICountryRegionCurrencyRepository> countryRegionCurrencyRepository = new Mock<ICountryRegionCurrencyRepository>();
                        countryRegionCurrencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegionCurrency()));

                        var validator = new ApiCountryRegionCurrencyRequestModelValidator(countryRegionCurrencyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCountryRegionCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CurrencyCode, new string('A', 4));
                }

                [Fact]
                public async void CurrencyCode_Delete()
                {
                        Mock<ICountryRegionCurrencyRepository> countryRegionCurrencyRepository = new Mock<ICountryRegionCurrencyRepository>();
                        countryRegionCurrencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegionCurrency()));

                        var validator = new ApiCountryRegionCurrencyRequestModelValidator(countryRegionCurrencyRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void CurrencyCode_Create_Valid_Reference()
                {
                        Mock<ICountryRegionCurrencyRepository> countryRegionCurrencyRepository = new Mock<ICountryRegionCurrencyRepository>();
                        countryRegionCurrencyRepository.Setup(x => x.GetCurrency(It.IsAny<string>())).Returns(Task.FromResult<Currency>(new Currency()));

                        var validator = new ApiCountryRegionCurrencyRequestModelValidator(countryRegionCurrencyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRegionCurrencyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CurrencyCode, "A");
                }

                [Fact]
                public async void CurrencyCode_Create_Invalid_Reference()
                {
                        Mock<ICountryRegionCurrencyRepository> countryRegionCurrencyRepository = new Mock<ICountryRegionCurrencyRepository>();
                        countryRegionCurrencyRepository.Setup(x => x.GetCurrency(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));

                        var validator = new ApiCountryRegionCurrencyRequestModelValidator(countryRegionCurrencyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCountryRegionCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CurrencyCode, "A");
                }

                [Fact]
                public async void CurrencyCode_Update_Valid_Reference()
                {
                        Mock<ICountryRegionCurrencyRepository> countryRegionCurrencyRepository = new Mock<ICountryRegionCurrencyRepository>();
                        countryRegionCurrencyRepository.Setup(x => x.GetCurrency(It.IsAny<string>())).Returns(Task.FromResult<Currency>(new Currency()));

                        var validator = new ApiCountryRegionCurrencyRequestModelValidator(countryRegionCurrencyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCountryRegionCurrencyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CurrencyCode, "A");
                }

                [Fact]
                public async void CurrencyCode_Update_Invalid_Reference()
                {
                        Mock<ICountryRegionCurrencyRepository> countryRegionCurrencyRepository = new Mock<ICountryRegionCurrencyRepository>();
                        countryRegionCurrencyRepository.Setup(x => x.GetCurrency(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));

                        var validator = new ApiCountryRegionCurrencyRequestModelValidator(countryRegionCurrencyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCountryRegionCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CurrencyCode, "A");
                }
        }
}

/*<Codenesium>
    <Hash>8b515cc9da8d27d75fc42f6b3e666f4a</Hash>
</Codenesium>*/