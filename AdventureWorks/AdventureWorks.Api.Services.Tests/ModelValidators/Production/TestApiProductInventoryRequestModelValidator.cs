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

                        await validator.ValidateUpdateAsync(default (int), new ApiProductInventoryRequestModel());

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

                        await validator.ValidateUpdateAsync(default (int), new ApiProductInventoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Shelf, new string('A', 11));
                }

                [Fact]
                public async void Shelf_Delete()
                {
                        Mock<IProductInventoryRepository> productInventoryRepository = new Mock<IProductInventoryRepository>();
                        productInventoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductInventory()));

                        var validator = new ApiProductInventoryRequestModelValidator(productInventoryRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>c43527fbb303c59e47d44a659202d3d5</Hash>
</Codenesium>*/