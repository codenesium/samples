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
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLocationRequestModelValidatorTest
	{
		public ApiLocationRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void LocationName_Create_null()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);
			await validator.ValidateCreateAsync(new ApiLocationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationName, null as string);
		}

		[Fact]
		public async void LocationName_Update_null()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLocationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationName, null as string);
		}

		[Fact]
		public async void LocationName_Create_length()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);
			await validator.ValidateCreateAsync(new ApiLocationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationName, new string('A', 65));
		}

		[Fact]
		public async void LocationName_Update_length()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLocationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationName, new string('A', 65));
		}
	}
}

/*<Codenesium>
    <Hash>0b8e5b808c3c7a664b216f9c1420cf53</Hash>
</Codenesium>*/