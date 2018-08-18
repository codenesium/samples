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
			await validator.ValidateUpdateAsync(default(int), new ApiShoppingCartItemRequestModel());

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
			await validator.ValidateUpdateAsync(default(int), new ApiShoppingCartItemRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ShoppingCartID, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>56ff6653d3b536af0423b195db681023</Hash>
</Codenesium>*/