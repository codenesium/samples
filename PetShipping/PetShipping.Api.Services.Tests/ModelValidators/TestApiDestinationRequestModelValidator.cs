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

                        await validator.ValidateUpdateAsync(default (int), new ApiDestinationRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void CountryId_Update_Invalid_Reference()
                {
                        Mock<IDestinationRepository> destinationRepository = new Mock<IDestinationRepository>();
                        destinationRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

                        var validator = new ApiDestinationRequestModelValidator(destinationRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDestinationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IDestinationRepository> destinationRepository = new Mock<IDestinationRepository>();
                        destinationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Destination()));

                        var validator = new ApiDestinationRequestModelValidator(destinationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDestinationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IDestinationRepository> destinationRepository = new Mock<IDestinationRepository>();
                        destinationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Destination()));

                        var validator = new ApiDestinationRequestModelValidator(destinationRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDestinationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
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

                        await validator.ValidateUpdateAsync(default (int), new ApiDestinationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IDestinationRepository> destinationRepository = new Mock<IDestinationRepository>();
                        destinationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Destination()));

                        var validator = new ApiDestinationRequestModelValidator(destinationRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>aa2eb6dd738d6bf87b961cbe25240c37</Hash>
</Codenesium>*/