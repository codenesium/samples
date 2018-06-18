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
        [Trait("Table", "PersonPhone")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPersonPhoneRequestModelValidatorTest
        {
                public ApiPersonPhoneRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void PhoneNumber_Create_null()
                {
                        Mock<IPersonPhoneRepository> personPhoneRepository = new Mock<IPersonPhoneRepository>();
                        personPhoneRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonPhone()));

                        var validator = new ApiPersonPhoneRequestModelValidator(personPhoneRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPersonPhoneRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, null as string);
                }

                [Fact]
                public async void PhoneNumber_Update_null()
                {
                        Mock<IPersonPhoneRepository> personPhoneRepository = new Mock<IPersonPhoneRepository>();
                        personPhoneRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonPhone()));

                        var validator = new ApiPersonPhoneRequestModelValidator(personPhoneRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPersonPhoneRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, null as string);
                }

                [Fact]
                public async void PhoneNumber_Create_length()
                {
                        Mock<IPersonPhoneRepository> personPhoneRepository = new Mock<IPersonPhoneRepository>();
                        personPhoneRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonPhone()));

                        var validator = new ApiPersonPhoneRequestModelValidator(personPhoneRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPersonPhoneRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, new string('A', 26));
                }

                [Fact]
                public async void PhoneNumber_Update_length()
                {
                        Mock<IPersonPhoneRepository> personPhoneRepository = new Mock<IPersonPhoneRepository>();
                        personPhoneRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonPhone()));

                        var validator = new ApiPersonPhoneRequestModelValidator(personPhoneRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPersonPhoneRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, new string('A', 26));
                }

                [Fact]
                public async void PhoneNumber_Delete()
                {
                        Mock<IPersonPhoneRepository> personPhoneRepository = new Mock<IPersonPhoneRepository>();
                        personPhoneRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonPhone()));

                        var validator = new ApiPersonPhoneRequestModelValidator(personPhoneRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>16e7529066f10ef0f85f3c547f11004a</Hash>
</Codenesium>*/