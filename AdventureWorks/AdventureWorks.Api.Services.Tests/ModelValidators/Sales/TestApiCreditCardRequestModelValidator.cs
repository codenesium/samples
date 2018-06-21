using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CreditCard")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCreditCardRequestModelValidatorTest
        {
                public ApiCreditCardRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void CardNumber_Create_null()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));

                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);
                        await validator.ValidateCreateAsync(new ApiCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CardNumber, null as string);
                }

                [Fact]
                public async void CardNumber_Update_null()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));

                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CardNumber, null as string);
                }

                [Fact]
                public async void CardNumber_Create_length()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));

                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);
                        await validator.ValidateCreateAsync(new ApiCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CardNumber, new string('A', 26));
                }

                [Fact]
                public async void CardNumber_Update_length()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));

                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CardNumber, new string('A', 26));
                }

                [Fact]
                public async void CardNumber_Delete()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));

                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void CardType_Create_null()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));

                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);
                        await validator.ValidateCreateAsync(new ApiCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CardType, null as string);
                }

                [Fact]
                public async void CardType_Update_null()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));

                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CardType, null as string);
                }

                [Fact]
                public async void CardType_Create_length()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));

                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);
                        await validator.ValidateCreateAsync(new ApiCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CardType, new string('A', 51));
                }

                [Fact]
                public async void CardType_Update_length()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));

                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CardType, new string('A', 51));
                }

                [Fact]
                public async void CardType_Delete()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));

                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByCardNumber_Create_Exists()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.ByCardNumber(It.IsAny<string>())).Returns(Task.FromResult<CreditCard>(new CreditCard()));
                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CardNumber, "A");
                }

                [Fact]
                private async void BeUniqueByCardNumber_Create_Not_Exists()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.ByCardNumber(It.IsAny<string>())).Returns(Task.FromResult<CreditCard>(null));
                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCreditCardRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CardNumber, "A");
                }

                [Fact]
                private async void BeUniqueByCardNumber_Update_Exists()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.ByCardNumber(It.IsAny<string>())).Returns(Task.FromResult<CreditCard>(new CreditCard()));
                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiCreditCardRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CardNumber, "A");
                }

                [Fact]
                private async void BeUniqueByCardNumber_Update_Not_Exists()
                {
                        Mock<ICreditCardRepository> creditCardRepository = new Mock<ICreditCardRepository>();
                        creditCardRepository.Setup(x => x.ByCardNumber(It.IsAny<string>())).Returns(Task.FromResult<CreditCard>(null));
                        var validator = new ApiCreditCardRequestModelValidator(creditCardRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiCreditCardRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CardNumber, "A");
                }
        }
}

/*<Codenesium>
    <Hash>f09346f5d4b9e1e144202a749af21b7d</Hash>
</Codenesium>*/