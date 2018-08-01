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
			await validator.ValidateUpdateAsync(default(int), new ApiProductSubcategoryRequestModel());

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
			await validator.ValidateUpdateAsync(default(int), new ApiProductSubcategoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
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

			await validator.ValidateUpdateAsync(default(int), new ApiProductSubcategoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IProductSubcategoryRepository> productSubcategoryRepository = new Mock<IProductSubcategoryRepository>();
			productSubcategoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductSubcategory>(null));
			var validator = new ApiProductSubcategoryRequestModelValidator(productSubcategoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductSubcategoryRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>920030d9b1d7b8f557d19f7256e35585</Hash>
</Codenesium>*/