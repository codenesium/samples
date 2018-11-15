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
	[Trait("Table", "AirTransport")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiAirTransportServerRequestModelValidatorTest
	{
		public ApiAirTransportServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void FlightNumber_Create_null()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));

			var validator = new ApiAirTransportServerRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateCreateAsync(new ApiAirTransportServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FlightNumber, null as string);
		}

		[Fact]
		public async void FlightNumber_Update_null()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));

			var validator = new ApiAirTransportServerRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAirTransportServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FlightNumber, null as string);
		}

		[Fact]
		public async void FlightNumber_Create_length()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));

			var validator = new ApiAirTransportServerRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateCreateAsync(new ApiAirTransportServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FlightNumber, new string('A', 13));
		}

		[Fact]
		public async void FlightNumber_Update_length()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));

			var validator = new ApiAirTransportServerRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAirTransportServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FlightNumber, new string('A', 13));
		}

		[Fact]
		public async void HandlerId_Create_Valid_Reference()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

			var validator = new ApiAirTransportServerRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateCreateAsync(new ApiAirTransportServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Create_Invalid_Reference()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

			var validator = new ApiAirTransportServerRequestModelValidator(airTransportRepository.Object);

			await validator.ValidateCreateAsync(new ApiAirTransportServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Update_Valid_Reference()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

			var validator = new ApiAirTransportServerRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAirTransportServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Update_Invalid_Reference()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

			var validator = new ApiAirTransportServerRequestModelValidator(airTransportRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiAirTransportServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>ab6db648573ac154690be9e5affa6cf6</Hash>
</Codenesium>*/