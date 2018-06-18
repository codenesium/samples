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
        [Trait("Table", "ShoppingCartItem")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiShoppingCartItemRequestModelValidatorTest
        {
                public ApiShoppingCartItemRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ShoppingCartID_Create_null()
                {
                        Mock<IShoppingCartItemRepository> shoppingCartItemRepository = new Mock<IShoppingCartItemRepository>();
                        shoppingCartItemRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShoppingCartItem()));

                        var validator = new ApiShoppingCartItemRequestModelValidator(shoppingCartItemRepository.Object);

                        await validator.ValidateCreateAsync(new ApiShoppingCartItemRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ShoppingCartID, null as string);
                }

                [Fact]
                public async void ShoppingCartID_Update_null()
                {
                        Mock<IShoppingCartItemRepository> shoppingCartItemRepository = new Mock<IShoppingCartItemRepository>();
                        shoppingCartItemRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShoppingCartItem()));

                        var validator = new ApiShoppingCartItemRequestModelValidator(shoppingCartItemRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiShoppingCartItemRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ShoppingCartID, null as string);
                }

                [Fact]
                public async void ShoppingCartID_Create_length()
                {
                        Mock<IShoppingCartItemRepository> shoppingCartItemRepository = new Mock<IShoppingCartItemRepository>();
                        shoppingCartItemRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShoppingCartItem()));

                        var validator = new ApiShoppingCartItemRequestModelValidator(shoppingCartItemRepository.Object);

                        await validator.ValidateCreateAsync(new ApiShoppingCartItemRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ShoppingCartID, new string('A', 51));
                }

                [Fact]
                public async void ShoppingCartID_Update_length()
                {
                        Mock<IShoppingCartItemRepository> shoppingCartItemRepository = new Mock<IShoppingCartItemRepository>();
                        shoppingCartItemRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShoppingCartItem()));

                        var validator = new ApiShoppingCartItemRequestModelValidator(shoppingCartItemRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiShoppingCartItemRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ShoppingCartID, new string('A', 51));
                }

                [Fact]
                public async void ShoppingCartID_Delete()
                {
                        Mock<IShoppingCartItemRepository> shoppingCartItemRepository = new Mock<IShoppingCartItemRepository>();
                        shoppingCartItemRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShoppingCartItem()));

                        var validator = new ApiShoppingCartItemRequestModelValidator(shoppingCartItemRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>0941ea87cb7a6ea41453e94aaf72aa31</Hash>
</Codenesium>*/