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
        [Trait("Table", "ProductVendor")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProductVendorRequestModelValidatorTest
        {
                public ApiProductVendorRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void UnitMeasureCode_Create_null()
                {
                        Mock<IProductVendorRepository> productVendorRepository = new Mock<IProductVendorRepository>();
                        productVendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductVendor()));

                        var validator = new ApiProductVendorRequestModelValidator(productVendorRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProductVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, null as string);
                }

                [Fact]
                public async void UnitMeasureCode_Update_null()
                {
                        Mock<IProductVendorRepository> productVendorRepository = new Mock<IProductVendorRepository>();
                        productVendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductVendor()));

                        var validator = new ApiProductVendorRequestModelValidator(productVendorRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiProductVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, null as string);
                }

                [Fact]
                public async void UnitMeasureCode_Create_length()
                {
                        Mock<IProductVendorRepository> productVendorRepository = new Mock<IProductVendorRepository>();
                        productVendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductVendor()));

                        var validator = new ApiProductVendorRequestModelValidator(productVendorRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProductVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, new string('A', 4));
                }

                [Fact]
                public async void UnitMeasureCode_Update_length()
                {
                        Mock<IProductVendorRepository> productVendorRepository = new Mock<IProductVendorRepository>();
                        productVendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductVendor()));

                        var validator = new ApiProductVendorRequestModelValidator(productVendorRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiProductVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, new string('A', 4));
                }

                [Fact]
                public async void UnitMeasureCode_Delete()
                {
                        Mock<IProductVendorRepository> productVendorRepository = new Mock<IProductVendorRepository>();
                        productVendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductVendor()));

                        var validator = new ApiProductVendorRequestModelValidator(productVendorRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>18f954d77b550b79d604215d53659405</Hash>
</Codenesium>*/