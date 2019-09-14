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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Country")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCountryServerRequestModelValidatorTest
	{
		public ApiCountryServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
			countryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));

			var validator = new ApiCountryServerRequestModelValidator(countryRepository.Object);
			await validator.ValidateCreateAsync(new ApiCountryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
			countryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));

			var validator = new ApiCountryServerRequestModelValidator(countryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCountryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
			countryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));

			var validator = new ApiCountryServerRequestModelValidator(countryRepository.Object);
			await validator.ValidateCreateAsync(new ApiCountryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
			countryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));

			var validator = new ApiCountryServerRequestModelValidator(countryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCountryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>b6d4b28aaac9a88a6501d038e42c8409</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/