using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PointOfSaleNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Product")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductServerRequestModelValidatorTest
	{
		public ApiProductServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Description_Create_null()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductServerRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductServerRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Create_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductServerRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 4097));
		}

		[Fact]
		public async void Description_Update_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductServerRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 4097));
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductServerRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductServerRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductServerRequestModelValidator(productRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
			productRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Product()));

			var validator = new ApiProductServerRequestModelValidator(productRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>4a9c7e3e6e764a7ce154bae6b4aac794</Hash>
</Codenesium>*/