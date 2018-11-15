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
	public partial class ApiCountryRequirementServerRequestModelValidatorTest
	{
		public ApiCountryRequirementServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CountryId_Create_Valid_Reference()
		{
			Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
			countryRequirementRepository.Setup(x => x.CountryByCountryId(It.IsAny<int>())).Returns(Task.FromResult<Country>(new Country()));

			var validator = new ApiCountryRequirementServerRequestModelValidator(countryRequirementRepository.Object);
			await validator.ValidateCreateAsync(new ApiCountryRequirementServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
		}

		[Fact]
		public async void CountryId_Create_Invalid_Reference()
		{
			Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
			countryRequirementRepository.Setup(x => x.CountryByCountryId(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

			var validator = new ApiCountryRequirementServerRequestModelValidator(countryRequirementRepository.Object);

			await validator.ValidateCreateAsync(new ApiCountryRequirementServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
		}

		[Fact]
		public async void CountryId_Update_Valid_Reference()
		{
			Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
			countryRequirementRepository.Setup(x => x.CountryByCountryId(It.IsAny<int>())).Returns(Task.FromResult<Country>(new Country()));

			var validator = new ApiCountryRequirementServerRequestModelValidator(countryRequirementRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCountryRequirementServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
		}

		[Fact]
		public async void CountryId_Update_Invalid_Reference()
		{
			Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
			countryRequirementRepository.Setup(x => x.CountryByCountryId(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

			var validator = new ApiCountryRequirementServerRequestModelValidator(countryRequirementRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCountryRequirementServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
		}

		[Fact]
		public async void Detail_Create_null()
		{
			Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
			countryRequirementRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CountryRequirement()));

			var validator = new ApiCountryRequirementServerRequestModelValidator(countryRequirementRepository.Object);
			await validator.ValidateCreateAsync(new ApiCountryRequirementServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Detail, null as string);
		}

		[Fact]
		public async void Detail_Update_null()
		{
			Mock<ICountryRequirementRepository> countryRequirementRepository = new Mock<ICountryRequirementRepository>();
			countryRequirementRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CountryRequirement()));

			var validator = new ApiCountryRequirementServerRequestModelValidator(countryRequirementRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCountryRequirementServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Detail, null as string);
		}
	}
}

/*<Codenesium>
    <Hash>8e7de21d7f3568ecbb7847663851a42f</Hash>
</Codenesium>*/