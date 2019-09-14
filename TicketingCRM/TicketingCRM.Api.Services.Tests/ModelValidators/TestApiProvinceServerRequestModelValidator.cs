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
	[Trait("Table", "Province")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProvinceServerRequestModelValidatorTest
	{
		public ApiProvinceServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CountryId_Create_Valid_Reference()
		{
			Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
			provinceRepository.Setup(x => x.CountryByCountryId(It.IsAny<int>())).Returns(Task.FromResult<Country>(new Country()));

			var validator = new ApiProvinceServerRequestModelValidator(provinceRepository.Object);
			await validator.ValidateCreateAsync(new ApiProvinceServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
		}

		[Fact]
		public async void CountryId_Create_Invalid_Reference()
		{
			Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
			provinceRepository.Setup(x => x.CountryByCountryId(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

			var validator = new ApiProvinceServerRequestModelValidator(provinceRepository.Object);

			await validator.ValidateCreateAsync(new ApiProvinceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
		}

		[Fact]
		public async void CountryId_Update_Valid_Reference()
		{
			Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
			provinceRepository.Setup(x => x.CountryByCountryId(It.IsAny<int>())).Returns(Task.FromResult<Country>(new Country()));

			var validator = new ApiProvinceServerRequestModelValidator(provinceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProvinceServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
		}

		[Fact]
		public async void CountryId_Update_Invalid_Reference()
		{
			Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
			provinceRepository.Setup(x => x.CountryByCountryId(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

			var validator = new ApiProvinceServerRequestModelValidator(provinceRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProvinceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
			provinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));

			var validator = new ApiProvinceServerRequestModelValidator(provinceRepository.Object);
			await validator.ValidateCreateAsync(new ApiProvinceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
			provinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));

			var validator = new ApiProvinceServerRequestModelValidator(provinceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProvinceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
			provinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));

			var validator = new ApiProvinceServerRequestModelValidator(provinceRepository.Object);
			await validator.ValidateCreateAsync(new ApiProvinceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
			provinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));

			var validator = new ApiProvinceServerRequestModelValidator(provinceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProvinceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>88f2322f0dac4b07888b003e19d1f60b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/