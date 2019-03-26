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
	[Trait("Table", "CountryRegion")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCountryRegionServerRequestModelValidatorTest
	{
		public ApiCountryRegionServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
			countryRegionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegion()));

			var validator = new ApiCountryRegionServerRequestModelValidator(countryRegionRepository.Object);
			await validator.ValidateCreateAsync(new ApiCountryRegionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
			countryRegionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegion()));

			var validator = new ApiCountryRegionServerRequestModelValidator(countryRegionRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiCountryRegionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
			countryRegionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegion()));

			var validator = new ApiCountryRegionServerRequestModelValidator(countryRegionRepository.Object);
			await validator.ValidateCreateAsync(new ApiCountryRegionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
			countryRegionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegion()));

			var validator = new ApiCountryRegionServerRequestModelValidator(countryRegionRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiCountryRegionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
			countryRegionRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<CountryRegion>(new CountryRegion()));
			var validator = new ApiCountryRegionServerRequestModelValidator(countryRegionRepository.Object);

			await validator.ValidateCreateAsync(new ApiCountryRegionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
			countryRegionRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<CountryRegion>(null));
			var validator = new ApiCountryRegionServerRequestModelValidator(countryRegionRepository.Object);

			await validator.ValidateCreateAsync(new ApiCountryRegionServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
			countryRegionRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<CountryRegion>(new CountryRegion()));
			var validator = new ApiCountryRegionServerRequestModelValidator(countryRegionRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiCountryRegionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<ICountryRegionRepository> countryRegionRepository = new Mock<ICountryRegionRepository>();
			countryRegionRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<CountryRegion>(null));
			var validator = new ApiCountryRegionServerRequestModelValidator(countryRegionRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiCountryRegionServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>19927f9020600ee8bb43d05a50261d08</Hash>
</Codenesium>*/