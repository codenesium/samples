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
	[Trait("Table", "ProductCategory")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductCategoryRequestModelValidatorTest
	{
		public ApiProductCategoryRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
			productCategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductCategory()));

			var validator = new ApiProductCategoryRequestModelValidator(productCategoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductCategoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
			productCategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductCategory()));

			var validator = new ApiProductCategoryRequestModelValidator(productCategoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductCategoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
			productCategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductCategory()));

			var validator = new ApiProductCategoryRequestModelValidator(productCategoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductCategoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
			productCategoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductCategory()));

			var validator = new ApiProductCategoryRequestModelValidator(productCategoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductCategoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
			productCategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductCategory>(new ProductCategory()));
			var validator = new ApiProductCategoryRequestModelValidator(productCategoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductCategoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
			productCategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductCategory>(null));
			var validator = new ApiProductCategoryRequestModelValidator(productCategoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductCategoryRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
			productCategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductCategory>(new ProductCategory()));
			var validator = new ApiProductCategoryRequestModelValidator(productCategoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductCategoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IProductCategoryRepository> productCategoryRepository = new Mock<IProductCategoryRepository>();
			productCategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductCategory>(null));
			var validator = new ApiProductCategoryRequestModelValidator(productCategoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductCategoryRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>885190baefccb397d32ebfc2f9aba74a</Hash>
</Codenesium>*/