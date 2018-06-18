using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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

                        await validator.ValidateUpdateAsync(default (int), new ApiAirTransportRequestModel());

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

                        await validator.ValidateUpdateAsync(default (int), new ApiAirTransportRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FlightNumber, new string('A', 13));
                }

                [Fact]
                public async void FlightNumber_Delete()
                {
                        Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
                        airTransportRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));

                        var validator = new ApiAirTransportRequestModelValidator(airTransportRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
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

                        await validator.ValidateUpdateAsync(default (int), new ApiAirTransportRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
                }

                [Fact]
                public async void HandlerId_Update_Invalid_Reference()
                {
                        Mock<IAirTransportRepository> airTransportRepository = new Mock<IAirTransportRepository>();
                        airTransportRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

                        var validator = new ApiAirTransportRequestModelValidator(airTransportRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAirTransportRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>1069119c213f97d4a61630317fd84683</Hash>
</Codenesium>*/