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
	[Trait("Table", "ProductModel")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductModelRequestModelValidatorTest
	{
		public ApiProductModelRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
			productModelRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModel()));

			var validator = new ApiProductModelRequestModelValidator(productModelRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductModelRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
			productModelRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModel()));

			var validator = new ApiProductModelRequestModelValidator(productModelRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductModelRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
			productModelRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModel()));

			var validator = new ApiProductModelRequestModelValidator(productModelRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductModelRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
			productModelRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModel()));

			var validator = new ApiProductModelRequestModelValidator(productModelRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductModelRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
			productModelRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductModel>(new ProductModel()));
			var validator = new ApiProductModelRequestModelValidator(productModelRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductModelRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
			productModelRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductModel>(null));
			var validator = new ApiProductModelRequestModelValidator(productModelRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductModelRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
			productModelRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductModel>(new ProductModel()));
			var validator = new ApiProductModelRequestModelValidator(productModelRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductModelRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IProductModelRepository> productModelRepository = new Mock<IProductModelRepository>();
			productModelRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProductModel>(null));
			var validator = new ApiProductModelRequestModelValidator(productModelRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductModelRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>9777471c3451e036f38f4048f392c1bf</Hash>
</Codenesium>*/