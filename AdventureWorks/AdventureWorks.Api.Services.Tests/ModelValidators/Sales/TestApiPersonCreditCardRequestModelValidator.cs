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
        [Trait("Table", "PersonCreditCard")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPersonCreditCardRequestModelValidatorTest
        {
                public ApiPersonCreditCardRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void CreditCardID_Create_Valid_Reference()
                {
                        Mock<IPersonCreditCardRepository> personCreditCardRepository = new Mock<IPersonCreditCardRepository>();
                        personCreditCardRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(new CreditCard()));

                        var validator = new ApiPersonCreditCardRequestModelValidator(personCreditCardRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPersonCreditCardRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CreditCardID, 1);
                }

                [Fact]
                public async void CreditCardID_Create_Invalid_Reference()
                {
                        Mock<IPersonCreditCardRepository> personCreditCardRepository = new Mock<IPersonCreditCardRepository>();
                        personCreditCardRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(null));

                        var validator = new ApiPersonCreditCardRequestModelValidator(personCreditCardRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPersonCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CreditCardID, 1);
                }

                [Fact]
                public async void CreditCardID_Update_Valid_Reference()
                {
                        Mock<IPersonCreditCardRepository> personCreditCardRepository = new Mock<IPersonCreditCardRepository>();
                        personCreditCardRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(new CreditCard()));

                        var validator = new ApiPersonCreditCardRequestModelValidator(personCreditCardRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPersonCreditCardRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CreditCardID, 1);
                }

                [Fact]
                public async void CreditCardID_Update_Invalid_Reference()
                {
                        Mock<IPersonCreditCardRepository> personCreditCardRepository = new Mock<IPersonCreditCardRepository>();
                        personCreditCardRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(null));

                        var validator = new ApiPersonCreditCardRequestModelValidator(personCreditCardRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPersonCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CreditCardID, 1);
                }
        }
}

/*<Codenesium>
    <Hash>03c5fa226d863a9457c986bba879af5a</Hash>
</Codenesium>*/