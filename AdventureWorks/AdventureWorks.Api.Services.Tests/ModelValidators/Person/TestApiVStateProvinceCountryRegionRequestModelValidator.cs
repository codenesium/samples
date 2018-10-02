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
	[Trait("Table", "VStateProvinceCountryRegion")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVStateProvinceCountryRegionRequestModelValidatorTest
	{
		public ApiVStateProvinceCountryRegionRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CountryRegionCode_Create_null()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, null as string);
		}

		[Fact]
		public async void CountryRegionCode_Update_null()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, null as string);
		}

		[Fact]
		public async void CountryRegionCode_Create_length()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, new string('A', 4));
		}

		[Fact]
		public async void CountryRegionCode_Update_length()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, new string('A', 4));
		}

		[Fact]
		public async void CountryRegionName_Create_null()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionName, null as string);
		}

		[Fact]
		public async void CountryRegionName_Update_null()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionName, null as string);
		}

		[Fact]
		public async void CountryRegionName_Create_length()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionName, new string('A', 51));
		}

		[Fact]
		public async void CountryRegionName_Update_length()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionName, new string('A', 51));
		}

		[Fact]
		public async void StateProvinceCode_Create_null()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StateProvinceCode, null as string);
		}

		[Fact]
		public async void StateProvinceCode_Update_null()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StateProvinceCode, null as string);
		}

		[Fact]
		public async void StateProvinceCode_Create_length()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StateProvinceCode, new string('A', 4));
		}

		[Fact]
		public async void StateProvinceCode_Update_length()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StateProvinceCode, new string('A', 4));
		}

		[Fact]
		public async void StateProvinceName_Create_null()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StateProvinceName, null as string);
		}

		[Fact]
		public async void StateProvinceName_Update_null()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StateProvinceName, null as string);
		}

		[Fact]
		public async void StateProvinceName_Create_length()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StateProvinceName, new string('A', 51));
		}

		[Fact]
		public async void StateProvinceName_Update_length()
		{
			Mock<IVStateProvinceCountryRegionRepository> vStateProvinceCountryRegionRepository = new Mock<IVStateProvinceCountryRegionRepository>();
			vStateProvinceCountryRegionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));

			var validator = new ApiVStateProvinceCountryRegionRequestModelValidator(vStateProvinceCountryRegionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVStateProvinceCountryRegionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StateProvinceName, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>52d8721eacb3f4cb4a05453f2c29b484</Hash>
</Codenesium>*/