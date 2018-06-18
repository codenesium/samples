using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductReview")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProductReviewRequestModelValidatorTest
        {
                public ApiProductReviewRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Comments_Create_length()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductReviewRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Comments, new string('A', 3851));
                }

                [Fact]
                public async void Comments_Update_length()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductReviewRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Comments, new string('A', 3851));
                }

                [Fact]
                public async void Comments_Delete()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void EmailAddress_Create_null()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductReviewRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, null as string);
                }

                [Fact]
                public async void EmailAddress_Update_null()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductReviewRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, null as string);
                }

                [Fact]
                public async void EmailAddress_Create_length()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductReviewRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, new string('A', 51));
                }

                [Fact]
                public async void EmailAddress_Update_length()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductReviewRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, new string('A', 51));
                }

                [Fact]
                public async void EmailAddress_Delete()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ReviewerName_Create_null()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductReviewRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReviewerName, null as string);
                }

                [Fact]
                public async void ReviewerName_Update_null()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductReviewRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReviewerName, null as string);
                }

                [Fact]
                public async void ReviewerName_Create_length()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductReviewRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReviewerName, new string('A', 51));
                }

                [Fact]
                public async void ReviewerName_Update_length()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductReviewRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReviewerName, new string('A', 51));
                }

                [Fact]
                public async void ReviewerName_Delete()
                {
                        Mock<IProductReviewRepository> productReviewRepository = new Mock<IProductReviewRepository>();
                        productReviewRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));

                        var validator = new ApiProductReviewRequestModelValidator(productReviewRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>e813cce08fe5d85daea74893ec9e7283</Hash>
</Codenesium>*/