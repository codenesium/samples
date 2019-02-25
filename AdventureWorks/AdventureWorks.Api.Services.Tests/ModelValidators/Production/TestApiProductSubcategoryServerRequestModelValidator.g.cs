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
	[Trait("Table", "ProductSubcategory")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductSubcategoryServerRequestModelValidatorTest
	{
		public ApiProductSubcategoryServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductSubcategory()));

			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductSubcategoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductSubcategory()));

			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductSubcategoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductSubcategory()));

			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductSubcategoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductSubcategory()));

			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductSubcategoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void ProductCategoryID_Create_Valid_Reference()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.ProductCategoryByProductCategoryID(It.IsAny<int>())).Returns(Task.FromResult<ProductCategory>(new ProductCategory()));

			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductSubcategoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductCategoryID, 1);
		}

		[Fact]
		public async void ProductCategoryID_Create_Invalid_Reference()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.ProductCategoryByProductCategoryID(It.IsAny<int>())).Returns(Task.FromResult<ProductCategory>(null));

			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductSubcategoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductCategoryID, 1);
		}

		[Fact]
		public async void ProductCategoryID_Update_Valid_Reference()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.ProductCategoryByProductCategoryID(It.IsAny<int>())).Returns(Task.FromResult<ProductCategory>(new ProductCategory()));

			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductSubcategoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductCategoryID, 1);
		}

		[Fact]
		public async void ProductCategoryID_Update_Invalid_Reference()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.ProductCategoryByProductCategoryID(It.IsAny<int>())).Returns(Task.FromResult<ProductCategory>(null));

			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductSubcategoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductCategoryID, 1);
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductSubcategory>(new ProductSubcategory()));
			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductSubcategoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductSubcategory>(null));
			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductSubcategoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductSubcategory>(new ProductSubcategory()));
			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductSubcategoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductSubcategory>(null));
			var validator = new ApiProductSubcategoryServerRequestModelValidator(productSubcategoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductSubcategoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>9b8dd965e1b5524c0d03cec4b9490d32</Hash>
</Codenesium>*/