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
	[Trait("Table", "Airline")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiAirlineRequestModelValidatorTest
	{
		public ApiAirlineRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IAirlineRepository> airlineRepository = new Mock<IAirlineRepository>();
			airlineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Airline()));

			var validator = new ApiAirlineRequestModelValidator(airlineRepository.Object);
			await validator.ValidateCreateAsync(new ApiAirlineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IAirlineRepository> airlineRepository = new Mock<IAirlineRepository>();
			airlineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Airline()));

			var validator = new ApiAirlineRequestModelValidator(airlineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAirlineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>1e37c7d9cee10a3eb90ce795ec9ce491</Hash>
</Codenesium>*/