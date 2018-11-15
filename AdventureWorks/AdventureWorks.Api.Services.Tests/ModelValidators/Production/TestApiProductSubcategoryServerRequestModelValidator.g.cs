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
    <Hash>25c741ddaf4b487f994c1744f935c5f4</Hash>
</Codenesium>*/