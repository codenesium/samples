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
	[Trait("Table", "Product")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductRequestModelValidatorTest
	{
		public ApiProductRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void @Class_Create_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.@Class, new string('A', 3));
		}

		[Fact]
		public async void @Class_Update_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.@Class, new string('A', 3));
		}

		[Fact]
		public async void Color_Create_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Color, new string('A', 16));
		}

		[Fact]
		public async void Color_Update_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Color, new string('A', 16));
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void ProductLine_Create_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductLine, new string('A', 3));
		}

		[Fact]
		public async void ProductLine_Update_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductLine, new string('A', 3));
		}

		[Fact]
		public async void ProductNumber_Create_null()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductNumber, null as string);
		}

		[Fact]
		public async void ProductNumber_Update_null()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductNumber, null as string);
		}

		[Fact]
		public async void ProductNumber_Create_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductNumber, new string('A', 26));
		}

		[Fact]
		public async void ProductNumber_Update_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductNumber, new string('A', 26));
		}

		[Fact]
		public async void Size_Create_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Size, new string('A', 6));
		}

		[Fact]
		public async void Size_Update_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Size, new string('A', 6));
		}

		[Fact]
		public async void SizeUnitMeasureCode_Create_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SizeUnitMeasureCode, new string('A', 4));
		}

		[Fact]
		public async void SizeUnitMeasureCode_Update_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SizeUnitMeasureCode, new string('A', 4));
		}

		[Fact]
		public async void Style_Create_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Style, new string('A', 3));
		}

		[Fact]
		public async void Style_Update_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Style, new string('A', 3));
		}

		[Fact]
		public async void WeightUnitMeasureCode_Create_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.WeightUnitMeasureCode, new string('A', 4));
		}

		[Fact]
		public async void WeightUnitMeasureCode_Update_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.WeightUnitMeasureCode, new string('A', 4));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Product>(new Product()));
			var validator = new ApiProductRequestModelValidator(productRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Product>(null));
			var validator = new ApiProductRequestModelValidator(productRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Product>(new Product()));
			var validator = new ApiProductRequestModelValidator(productRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Product>(null));
			var validator = new ApiProductRequestModelValidator(productRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>417f6b87dcde41c2fe5f2437a1d4b5ab</Hash>
</Codenesium>*/