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
        [Trait("Table", "Destination")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDestinationRequestModelValidatorTest
        {
                public ApiDestinationRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void CountryId_Create_Valid_Reference()
                {
                        Mock<IDestinationRepository> destinationRepository = new Mock<IDestinationRepository>();
                        destinationRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(new Country()));

                        var validator = new ApiDestinationRequestModelValidator(destinationRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDestinationRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void CountryId_Create_Invalid_Reference()
                {
                        Mock<IDestinationRepository> destinationRepository = new Mock<IDestinationRepository>();
                        destinationRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

                        var validator = new ApiDestinationRequestModelValidator(destinationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDestinationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void CountryId_Update_Valid_Reference()
                {
                        Mock<IDestinationRepository> destinationRepository = new Mock<IDestinationRepository>();
                        destinationRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(new Country()));

                        var validator = new ApiDestinationRequestModelValidator(destinationRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDestinationRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void CountryId_Update_Invalid_Reference()
                {
                        Mock<IDestinationRepository> destinationRepository = new Mock<IDestinationRepository>();
                        destinationRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

                        var validator = new ApiDestinationRequestModelValidator(destinationRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiDestinationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IDestinationRepository> destinationRepository = new Mock<IDestinationRepository>();
                        destinationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Destination()));

                        var validator = new ApiDestinationRequestModelValidator(destinationRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDestinationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IDestinationRepository> destinationRepository = new Mock<IDestinationRepository>();
                        destinationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Destination()));

                        var validator = new ApiDestinationRequestModelValidator(destinationRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDestinationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }
        }
}

/*<Codenesium>
    <Hash>12ac127e8a44e770d5acf3bf2fa43f6b</Hash>
</Codenesium>*/