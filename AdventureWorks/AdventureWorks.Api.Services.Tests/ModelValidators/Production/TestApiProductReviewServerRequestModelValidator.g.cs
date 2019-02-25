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
	[Trait("Table", "ProductReview")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductReviewServerRequestModelValidatorTest
	{
		public ApiProductReviewServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Comment_Create_length()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Comment, new string('A', 3851));
		}

		[Fact]
		public async void Comment_Update_length()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Comment, new string('A', 3851));
		}

		[Fact]
		public async void EmailAddress_Create_null()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, null as string);
		}

		[Fact]
		public async void EmailAddress_Update_null()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, null as string);
		}

		[Fact]
		public async void EmailAddress_Create_length()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, new string('A', 51));
		}

		[Fact]
		public async void EmailAddress_Update_length()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, new string('A', 51));
		}

		[Fact]
		public async void ProductID_Create_Valid_Reference()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(new Product()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductReviewServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void ProductID_Create_Invalid_Reference()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void ProductID_Update_Valid_Reference()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(new Product()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductReviewServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void ProductID_Update_Invalid_Reference()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void ReviewerName_Create_null()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReviewerName, null as string);
		}

		[Fact]
		public async void ReviewerName_Update_null()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReviewerName, null as string);
		}

		[Fact]
		public async void ReviewerName_Create_length()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReviewerName, new string('A', 51));
		}

		[Fact]
		public async void ReviewerName_Update_length()
		{
			Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
			productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

			var validator = new ApiProductReviewServerRequestModelValidator(productReviewRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductReviewServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReviewerName, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>534b6d58152450bcf7c99bb7f400ecb3</Hash>
</Codenesium>*/