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
        [Trait("Table", "ProductInventory")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProductInventoryRequestModelValidatorTest
        {
                public ApiProductInventoryRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Shelf_Create_null()
                {
                        Mock<IProductInventoryRepository> productInventoryRepository = new Mock<IProductInventoryRepository>();
                        productInventoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductInventory()));

                        var validator = new ApiProductInventoryRequestModelValidator(productInventoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProductInventoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Shelf, null as string);
                }

                [Fact]
                public async void Shelf_Update_null()
                {
                        Mock<IProductInventoryRepository> productInventoryRepository = new Mock<IProductInventoryRepository>();
                        productInventoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductInventory()));

                        var validator = new ApiProductInventoryRequestModelValidator(productInventoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiProductInventoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Shelf, null as string);
                }

                [Fact]
                public async void Shelf_Create_length()
                {
                        Mock<IProductInventoryRepository> productInventoryRepository = new Mock<IProductInventoryRepository>();
                        productInventoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductInventory()));

                        var validator = new ApiProductInventoryRequestModelValidator(productInventoryRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProductInventoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Shelf, new string('A', 11));
                }

                [Fact]
                public async void Shelf_Update_length()
                {
                        Mock<IProductInventoryRepository> productInventoryRepository = new Mock<IProductInventoryRepository>();
                        productInventoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductInventory()));

                        var validator = new ApiProductInventoryRequestModelValidator(productInventoryRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiProductInventoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Shelf, new string('A', 11));
                }

                [Fact]
                public async void Shelf_Delete()
                {
                        Mock<IProductInventoryRepository> productInventoryRepository = new Mock<IProductInventoryRepository>();
                        productInventoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductInventory()));

                        var validator = new ApiProductInventoryRequestModelValidator(productInventoryRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>d6ca7e01d5650b0f91e165cab3b1c92a</Hash>
</Codenesium>*/