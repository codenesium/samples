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
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "EmailAddress")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiEmailAddressRequestModelValidatorTest
        {
                public ApiEmailAddressRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void EmailAddress1_Create_length()
                {
                        Mock<IEmailAddressRepository> emailAddressRepository = new Mock<IEmailAddressRepository>();
                        emailAddressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EmailAddress()));

                        var validator = new ApiEmailAddressRequestModelValidator(emailAddressRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEmailAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmailAddress1, new string('A', 51));
                }

                [Fact]
                public async void EmailAddress1_Update_length()
                {
                        Mock<IEmailAddressRepository> emailAddressRepository = new Mock<IEmailAddressRepository>();
                        emailAddressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EmailAddress()));

                        var validator = new ApiEmailAddressRequestModelValidator(emailAddressRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEmailAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmailAddress1, new string('A', 51));
                }

                [Fact]
                public async void EmailAddress1_Delete()
                {
                        Mock<IEmailAddressRepository> emailAddressRepository = new Mock<IEmailAddressRepository>();
                        emailAddressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EmailAddress()));

                        var validator = new ApiEmailAddressRequestModelValidator(emailAddressRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>dd06b60c445307b1b113a999a28f59e3</Hash>
</Codenesium>*/