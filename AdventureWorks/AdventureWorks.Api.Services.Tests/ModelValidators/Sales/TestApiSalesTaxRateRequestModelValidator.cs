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
        [Trait("Table", "SalesTaxRate")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSalesTaxRateRequestModelValidatorTest
        {
                public ApiSalesTaxRateRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
                        salesTaxRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));

                        var validator = new ApiSalesTaxRateRequestModelValidator(salesTaxRateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTaxRateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
                        salesTaxRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));

                        var validator = new ApiSalesTaxRateRequestModelValidator(salesTaxRateRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTaxRateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
                        salesTaxRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));

                        var validator = new ApiSalesTaxRateRequestModelValidator(salesTaxRateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTaxRateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
                        salesTaxRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));

                        var validator = new ApiSalesTaxRateRequestModelValidator(salesTaxRateRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTaxRateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
                        salesTaxRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));

                        var validator = new ApiSalesTaxRateRequestModelValidator(salesTaxRateRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByStateProvinceIDTaxType_Create_Exists()
                {
                        Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
                        salesTaxRateRepository.Setup(x => x.ByStateProvinceIDTaxType(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<SalesTaxRate>(new SalesTaxRate()));
                        var validator = new ApiSalesTaxRateRequestModelValidator(salesTaxRateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTaxRateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StateProvinceID, 1);
                }

                [Fact]
                private async void BeUniqueByStateProvinceIDTaxType_Create_Not_Exists()
                {
                        Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
                        salesTaxRateRepository.Setup(x => x.ByStateProvinceIDTaxType(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<SalesTaxRate>(null));
                        var validator = new ApiSalesTaxRateRequestModelValidator(salesTaxRateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTaxRateRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StateProvinceID, 1);
                }

                [Fact]
                private async void BeUniqueByStateProvinceIDTaxType_Update_Exists()
                {
                        Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
                        salesTaxRateRepository.Setup(x => x.ByStateProvinceIDTaxType(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<SalesTaxRate>(new SalesTaxRate()));
                        var validator = new ApiSalesTaxRateRequestModelValidator(salesTaxRateRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTaxRateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StateProvinceID, 1);
                }

                [Fact]
                private async void BeUniqueByStateProvinceIDTaxType_Update_Not_Exists()
                {
                        Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
                        salesTaxRateRepository.Setup(x => x.ByStateProvinceIDTaxType(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<SalesTaxRate>(null));
                        var validator = new ApiSalesTaxRateRequestModelValidator(salesTaxRateRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTaxRateRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StateProvinceID, 1);
                }
        }
}

/*<Codenesium>
    <Hash>0a8ea62ee48faf7b7a028a09f6dd23c7</Hash>
</Codenesium>*/