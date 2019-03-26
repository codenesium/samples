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
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductProductPhotoServerRequestModelValidatorTest
	{
		public ApiProductProductPhotoServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void ProductPhotoID_Create_Valid_Reference()
		{
			Mock<IProductProductPhotoRepository> productProductPhotoRepository = new Mock<IProductProductPhotoRepository>();
			productProductPhotoRepository.Setup(x => x.ProductPhotoByProductPhotoID(It.IsAny<int>())).Returns(Task.FromResult<ProductPhoto>(new ProductPhoto()));

			var validator = new ApiProductProductPhotoServerRequestModelValidator(productProductPhotoRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductProductPhotoServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductPhotoID, 1);
		}

		[Fact]
		public async void ProductPhotoID_Create_Invalid_Reference()
		{
			Mock<IProductProductPhotoRepository> productProductPhotoRepository = new Mock<IProductProductPhotoRepository>();
			productProductPhotoRepository.Setup(x => x.ProductPhotoByProductPhotoID(It.IsAny<int>())).Returns(Task.FromResult<ProductPhoto>(null));

			var validator = new ApiProductProductPhotoServerRequestModelValidator(productProductPhotoRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductProductPhotoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductPhotoID, 1);
		}

		[Fact]
		public async void ProductPhotoID_Update_Valid_Reference()
		{
			Mock<IProductProductPhotoRepository> productProductPhotoRepository = new Mock<IProductProductPhotoRepository>();
			productProductPhotoRepository.Setup(x => x.ProductPhotoByProductPhotoID(It.IsAny<int>())).Returns(Task.FromResult<ProductPhoto>(new ProductPhoto()));

			var validator = new ApiProductProductPhotoServerRequestModelValidator(productProductPhotoRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductProductPhotoServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductPhotoID, 1);
		}

		[Fact]
		public async void ProductPhotoID_Update_Invalid_Reference()
		{
			Mock<IProductProductPhotoRepository> productProductPhotoRepository = new Mock<IProductProductPhotoRepository>();
			productProductPhotoRepository.Setup(x => x.ProductPhotoByProductPhotoID(It.IsAny<int>())).Returns(Task.FromResult<ProductPhoto>(null));

			var validator = new ApiProductProductPhotoServerRequestModelValidator(productProductPhotoRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductProductPhotoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductPhotoID, 1);
		}
	}
}

/*<Codenesium>
    <Hash>21d75c74ddefad5b474f20481135442a</Hash>
</Codenesium>*/