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
        [Trait("Table", "ProductDescription")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProductDescriptionRequestModelValidatorTest
        {
                public ApiProductDescriptionRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Description_Create_null()
                {
                        Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
                        productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

                        var validator = new ApiProductDescriptionRequestModelValidator(productDescriptionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductDescriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void Description_Update_null()
                {
                        Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
                        productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

                        var validator = new ApiProductDescriptionRequestModelValidator(productDescriptionRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductDescriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void Description_Create_length()
                {
                        Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
                        productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

                        var validator = new ApiProductDescriptionRequestModelValidator(productDescriptionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductDescriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 401));
                }

                [Fact]
                public async void Description_Update_length()
                {
                        Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
                        productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

                        var validator = new ApiProductDescriptionRequestModelValidator(productDescriptionRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductDescriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 401));
                }

                [Fact]
                public async void Description_Delete()
                {
                        Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
                        productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

                        var validator = new ApiProductDescriptionRequestModelValidator(productDescriptionRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>e2d2a0326c5f5cc4fb991f7b9a1d7e41</Hash>
</Codenesium>*/