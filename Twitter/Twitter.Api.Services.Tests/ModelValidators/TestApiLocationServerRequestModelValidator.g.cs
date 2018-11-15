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
	public partial class ApiLocationServerRequestModelValidatorTest
	{
		public ApiLocationServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void LocationName_Create_null()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationServerRequestModelValidator(locationRepository.Object);
			await validator.ValidateCreateAsync(new ApiLocationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationName, null as string);
		}

		[Fact]
		public async void LocationName_Update_null()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationServerRequestModelValidator(locationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLocationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationName, null as string);
		}

		[Fact]
		public async void LocationName_Create_length()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationServerRequestModelValidator(locationRepository.Object);
			await validator.ValidateCreateAsync(new ApiLocationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationName, new string('A', 65));
		}

		[Fact]
		public async void LocationName_Update_length()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationServerRequestModelValidator(locationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLocationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationName, new string('A', 65));
		}
	}
}

/*<Codenesium>
    <Hash>4f5f42826744b6d3a4b4eea7566423df</Hash>
</Codenesium>*/