using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

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
                        await validator.ValidateUpdateAsync(default(int), new ApiPaymentTypeRequestModel());

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
                        await validator.ValidateUpdateAsync(default(int), new ApiPaymentTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IPaymentTypeRepository> paymentTypeRepository = new Mock<IPaymentTypeRepository>();
                        paymentTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));

                        var validator = new ApiPaymentTypeRequestModelValidator(paymentTypeRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>0841ef9e932219e082ee7ae28997279e</Hash>
</Codenesium>*/