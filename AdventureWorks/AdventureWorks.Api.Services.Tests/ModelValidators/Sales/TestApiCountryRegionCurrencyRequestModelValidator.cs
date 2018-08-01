using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

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
			await validator.ValidateUpdateAsync(default(string), new ApiCountryRegionCurrencyRequestModel());

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
			await validator.ValidateUpdateAsync(default(string), new ApiCountryRegionCurrencyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CurrencyCode, new string('A', 4));
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
			await validator.ValidateUpdateAsync(default(string), new ApiCountryRegionCurrencyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CurrencyCode, "A");
		}

		[Fact]
		public async void CurrencyCode_Update_Invalid_Reference()
		{
			Mock<ICountryRegionCurrencyRepository> countryRegionCurrencyRepository = new Mock<ICountryRegionCurrencyRepository>();
			countryRegionCurrencyRepository.Setup(x => x.GetCurrency(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));

			var validator = new ApiCountryRegionCurrencyRequestModelValidator(countryRegionCurrencyRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiCountryRegionCurrencyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CurrencyCode, "A");
		}
	}
}

/*<Codenesium>
    <Hash>361926a2b7e3bc71865025ecc7dbb066</Hash>
</Codenesium>*/