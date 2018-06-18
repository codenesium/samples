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
        [Trait("Table", "ProductSubcategory")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProductSubcategoryRequestModelValidatorTest
        {
                public ApiProductSubcategoryRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
                        productSubcategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductSubcategory()));

                        var validator = new ApiProductSubcategoryRequestModelValidator(productSubcategoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductSubcategoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
                        productSubcategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductSubcategory()));

                        var validator = new ApiProductSubcategoryRequestModelValidator(productSubcategoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductSubcategoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
                        productSubcategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductSubcategory()));

                        var validator = new ApiProductSubcategoryRequestModelValidator(productSubcategoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductSubcategoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
                        productSubcategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductSubcategory()));

                        var validator = new ApiProductSubcategoryRequestModelValidator(productSubcategoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductSubcategoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
                        productSubcategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductSubcategory()));

                        var validator = new ApiProductSubcategoryRequestModelValidator(productSubcategoryRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
                        productSubcategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductSubcategory>(new ProductSubcategory()));
                        var validator = new ApiProductSubcategoryRequestModelValidator(productSubcategoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductSubcategoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
                        productSubcategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductSubcategory>(null));
                        var validator = new ApiProductSubcategoryRequestModelValidator(productSubcategoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductSubcategoryRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
                        productSubcategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductSubcategory>(new ProductSubcategory()));
                        var validator = new ApiProductSubcategoryRequestModelValidator(productSubcategoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductSubcategoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
                        productSubcategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductSubcategory>(null));
                        var validator = new ApiProductSubcategoryRequestModelValidator(productSubcategoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductSubcategoryRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>7725c30c3b3c9dc5a2780551c0db6144</Hash>
</Codenesium>*/