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
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PaymentType")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPaymentTypeRequestModelValidatorTest
        {
                public ApiPaymentTypeRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IPaymentTypeRepository> paymentTypeRepository = new Mock<IPaymentTypeRepository>();
                        paymentTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));

                        var validator = new ApiPaymentTypeRequestModelValidator(paymentTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPaymentTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IPaymentTypeRepository> paymentTypeRepository = new Mock<IPaymentTypeRepository>();
                        paymentTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));

                        var validator = new ApiPaymentTypeRequestModelValidator(paymentTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPaymentTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IPaymentTypeRepository> paymentTypeRepository = new Mock<IPaymentTypeRepository>();
                        paymentTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));

                        var validator = new ApiPaymentTypeRequestModelValidator(paymentTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPaymentTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IPaymentTypeRepository> paymentTypeRepository = new Mock<IPaymentTypeRepository>();
                        paymentTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));

                        var validator = new ApiPaymentTypeRequestModelValidator(paymentTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPaymentTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IPaymentTypeRepository> paymentTypeRepository = new Mock<IPaymentTypeRepository>();
                        paymentTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));

                        var validator = new ApiPaymentTypeRequestModelValidator(paymentTypeRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>841779d8cee2e9ce16604be37f680303</Hash>
</Codenesium>*/