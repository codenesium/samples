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
        [Trait("Table", "Sale")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSaleRequestModelValidatorTest
        {
                public ApiSaleRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void FirstName_Create_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Update_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Create_length()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 91));
                }

                [Fact]
                public async void FirstName_Update_length()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 91));
                }

                [Fact]
                public async void FirstName_Delete()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void LastName_Create_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Update_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Create_length()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 91));
                }

                [Fact]
                public async void LastName_Update_length()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 91));
                }

                [Fact]
                public async void LastName_Delete()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void PaymentTypeId_Create_Valid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPaymentType(It.IsAny<int>())).Returns(Task.FromResult<PaymentType>(new PaymentType()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PaymentTypeId, 1);
                }

                [Fact]
                public async void PaymentTypeId_Create_Invalid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPaymentType(It.IsAny<int>())).Returns(Task.FromResult<PaymentType>(null));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PaymentTypeId, 1);
                }

                [Fact]
                public async void PaymentTypeId_Update_Valid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPaymentType(It.IsAny<int>())).Returns(Task.FromResult<PaymentType>(new PaymentType()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PaymentTypeId, 1);
                }

                [Fact]
                public async void PaymentTypeId_Update_Invalid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPaymentType(It.IsAny<int>())).Returns(Task.FromResult<PaymentType>(null));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PaymentTypeId, 1);
                }

                [Fact]
                public async void PetId_Create_Valid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPet(It.IsAny<int>())).Returns(Task.FromResult<Pet>(new Pet()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PetId, 1);
                }

                [Fact]
                public async void PetId_Create_Invalid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPet(It.IsAny<int>())).Returns(Task.FromResult<Pet>(null));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PetId, 1);
                }

                [Fact]
                public async void PetId_Update_Valid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPet(It.IsAny<int>())).Returns(Task.FromResult<Pet>(new Pet()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PetId, 1);
                }

                [Fact]
                public async void PetId_Update_Invalid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPet(It.IsAny<int>())).Returns(Task.FromResult<Pet>(null));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PetId, 1);
                }

                [Fact]
                public async void Phone_Create_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
                }

                [Fact]
                public async void Phone_Update_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
                }

                [Fact]
                public async void Phone_Create_length()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 11));
                }

                [Fact]
                public async void Phone_Update_length()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 11));
                }

                [Fact]
                public async void Phone_Delete()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>1a261f0d1c50903b0fd489b1251857d4</Hash>
</Codenesium>*/