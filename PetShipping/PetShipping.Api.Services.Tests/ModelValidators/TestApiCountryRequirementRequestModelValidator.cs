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
			await validator.ValidateUpdateAsync(default(int), new ApiCountryRequirementRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
		}

		[Fact]
		public async void CountryId_Update_Invalid_Reference()
		{
			Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
			countryRequirementRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

			var validator = new ApiCountryRequirementRequestModelValidator(countryRequirementRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCountryRequirementRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>d7a2fa7ba93daaf79d24db78e291d3e7</Hash>
</Codenesium>*/