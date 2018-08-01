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
	[Trait("Table", "Country")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCountryRequestModelValidatorTest
	{
		public ApiCountryRequestModelValidatorTest()
		{
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
			await validator.ValidateUpdateAsync(default(int), new ApiCountryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>81e4ac9682198fd7a187cf3959a40f6e</Hash>
</Codenesium>*/