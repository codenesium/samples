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
                public async void Name_Create_null()
                {
                        Mock<IAirlineRepository> airlineRepository = new Mock<IAirlineRepository>();
                        airlineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Airline()));

                        var validator = new ApiAirlineRequestModelValidator(airlineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiAirlineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IAirlineRepository> airlineRepository = new Mock<IAirlineRepository>();
                        airlineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Airline()));

                        var validator = new ApiAirlineRequestModelValidator(airlineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiAirlineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
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

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IAirlineRepository> airlineRepository = new Mock<IAirlineRepository>();
                        airlineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Airline()));

                        var validator = new ApiAirlineRequestModelValidator(airlineRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>317106f70fcca947cbaa65aa59e4c049</Hash>
</Codenesium>*/