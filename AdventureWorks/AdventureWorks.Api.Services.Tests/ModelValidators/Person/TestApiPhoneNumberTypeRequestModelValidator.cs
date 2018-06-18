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
        [Trait("Table", "PhoneNumberType")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPhoneNumberTypeRequestModelValidatorTest
        {
                public ApiPhoneNumberTypeRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IPhoneNumberTypeRepository> phoneNumberTypeRepository = new Mock<IPhoneNumberTypeRepository>();
                        phoneNumberTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PhoneNumberType()));

                        var validator = new ApiPhoneNumberTypeRequestModelValidator(phoneNumberTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPhoneNumberTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IPhoneNumberTypeRepository> phoneNumberTypeRepository = new Mock<IPhoneNumberTypeRepository>();
                        phoneNumberTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PhoneNumberType()));

                        var validator = new ApiPhoneNumberTypeRequestModelValidator(phoneNumberTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPhoneNumberTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IPhoneNumberTypeRepository> phoneNumberTypeRepository = new Mock<IPhoneNumberTypeRepository>();
                        phoneNumberTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PhoneNumberType()));

                        var validator = new ApiPhoneNumberTypeRequestModelValidator(phoneNumberTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPhoneNumberTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IPhoneNumberTypeRepository> phoneNumberTypeRepository = new Mock<IPhoneNumberTypeRepository>();
                        phoneNumberTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PhoneNumberType()));

                        var validator = new ApiPhoneNumberTypeRequestModelValidator(phoneNumberTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPhoneNumberTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IPhoneNumberTypeRepository> phoneNumberTypeRepository = new Mock<IPhoneNumberTypeRepository>();
                        phoneNumberTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PhoneNumberType()));

                        var validator = new ApiPhoneNumberTypeRequestModelValidator(phoneNumberTypeRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>b8803c39b1e075ca30b82eab28eb9697</Hash>
</Codenesium>*/