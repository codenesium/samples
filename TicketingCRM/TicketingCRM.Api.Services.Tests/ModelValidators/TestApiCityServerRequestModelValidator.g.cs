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
	[Trait("Table", "City")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCityServerRequestModelValidatorTest
	{
		public ApiCityServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
			cityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new City()));

			var validator = new ApiCityServerRequestModelValidator(cityRepository.Object);
			await validator.ValidateCreateAsync(new ApiCityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
			cityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new City()));

			var validator = new ApiCityServerRequestModelValidator(cityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
			cityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new City()));

			var validator = new ApiCityServerRequestModelValidator(cityRepository.Object);
			await validator.ValidateCreateAsync(new ApiCityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
			cityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new City()));

			var validator = new ApiCityServerRequestModelValidator(cityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void ProvinceId_Create_Valid_Reference()
		{
			Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
			cityRepository.Setup(x => x.ProvinceByProvinceId(It.IsAny<int>())).Returns(Task.FromResult<Province>(new Province()));

			var validator = new ApiCityServerRequestModelValidator(cityRepository.Object);
			await validator.ValidateCreateAsync(new ApiCityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProvinceId, 1);
		}

		[Fact]
		public async void ProvinceId_Create_Invalid_Reference()
		{
			Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
			cityRepository.Setup(x => x.ProvinceByProvinceId(It.IsAny<int>())).Returns(Task.FromResult<Province>(null));

			var validator = new ApiCityServerRequestModelValidator(cityRepository.Object);

			await validator.ValidateCreateAsync(new ApiCityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProvinceId, 1);
		}

		[Fact]
		public async void ProvinceId_Update_Valid_Reference()
		{
			Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
			cityRepository.Setup(x => x.ProvinceByProvinceId(It.IsAny<int>())).Returns(Task.FromResult<Province>(new Province()));

			var validator = new ApiCityServerRequestModelValidator(cityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProvinceId, 1);
		}

		[Fact]
		public async void ProvinceId_Update_Invalid_Reference()
		{
			Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
			cityRepository.Setup(x => x.ProvinceByProvinceId(It.IsAny<int>())).Returns(Task.FromResult<Province>(null));

			var validator = new ApiCityServerRequestModelValidator(cityRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProvinceId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>056850382817eadbd9b09fbca715017e</Hash>
</Codenesium>*/