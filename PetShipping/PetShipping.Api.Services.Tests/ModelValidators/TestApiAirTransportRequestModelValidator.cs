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
	public partial class ApiAirTransportRequestModelValidatorTest
	{
		public ApiAirTransportRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void FlightNumber_Create_null()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));

			var validator = new ApiAirTransportRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateCreateAsync(new ApiAirTransportRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FlightNumber, null as string);
		}

		[Fact]
		public async void FlightNumber_Update_null()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));

			var validator = new ApiAirTransportRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAirTransportRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FlightNumber, null as string);
		}

		[Fact]
		public async void FlightNumber_Create_length()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));

			var validator = new ApiAirTransportRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateCreateAsync(new ApiAirTransportRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FlightNumber, new string('A', 13));
		}

		[Fact]
		public async void FlightNumber_Update_length()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));

			var validator = new ApiAirTransportRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAirTransportRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FlightNumber, new string('A', 13));
		}

		[Fact]
		public async void HandlerId_Create_Valid_Reference()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

			var validator = new ApiAirTransportRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateCreateAsync(new ApiAirTransportRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Create_Invalid_Reference()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

			var validator = new ApiAirTransportRequestModelValidator(airTransportRepository.Object);

			await validator.ValidateCreateAsync(new ApiAirTransportRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Update_Valid_Reference()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

			var validator = new ApiAirTransportRequestModelValidator(airTransportRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAirTransportRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Update_Invalid_Reference()
		{
			Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
			airTransportRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

			var validator = new ApiAirTransportRequestModelValidator(airTransportRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiAirTransportRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>573397c8093759947583da7d697ce6e8</Hash>
</Codenesium>*/