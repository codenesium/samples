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
        [Trait("Table", "ProductModelProductDescriptionCulture")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProductModelProductDescriptionCultureRequestModelValidatorTest
        {
                public ApiProductModelProductDescriptionCultureRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void CultureID_Create_null()
                {
                        Mock<IProductModelProductDescriptionCultureRepository> productModelProductDescriptionCultureRepository = new Mock<IProductModelProductDescriptionCultureRepository>();
                        productModelProductDescriptionCultureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));

                        var validator = new ApiProductModelProductDescriptionCultureRequestModelValidator(productModelProductDescriptionCultureRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductModelProductDescriptionCultureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CultureID, null as string);
                }

                [Fact]
                public async void CultureID_Update_null()
                {
                        Mock<IProductModelProductDescriptionCultureRepository> productModelProductDescriptionCultureRepository = new Mock<IProductModelProductDescriptionCultureRepository>();
                        productModelProductDescriptionCultureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));

                        var validator = new ApiProductModelProductDescriptionCultureRequestModelValidator(productModelProductDescriptionCultureRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductModelProductDescriptionCultureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CultureID, null as string);
                }

                [Fact]
                public async void CultureID_Create_length()
                {
                        Mock<IProductModelProductDescriptionCultureRepository> productModelProductDescriptionCultureRepository = new Mock<IProductModelProductDescriptionCultureRepository>();
                        productModelProductDescriptionCultureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));

                        var validator = new ApiProductModelProductDescriptionCultureRequestModelValidator(productModelProductDescriptionCultureRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProductModelProductDescriptionCultureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CultureID, new string('A', 7));
                }

                [Fact]
                public async void CultureID_Update_length()
                {
                        Mock<IProductModelProductDescriptionCultureRepository> productModelProductDescriptionCultureRepository = new Mock<IProductModelProductDescriptionCultureRepository>();
                        productModelProductDescriptionCultureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));

                        var validator = new ApiProductModelProductDescriptionCultureRequestModelValidator(productModelProductDescriptionCultureRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiProductModelProductDescriptionCultureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CultureID, new string('A', 7));
                }

                [Fact]
                public async void CultureID_Delete()
                {
                        Mock<IProductModelProductDescriptionCultureRepository> productModelProductDescriptionCultureRepository = new Mock<IProductModelProductDescriptionCultureRepository>();
                        productModelProductDescriptionCultureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));

                        var validator = new ApiProductModelProductDescriptionCultureRequestModelValidator(productModelProductDescriptionCultureRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>be8af1c393127d8c01d1957706d3d198</Hash>
</Codenesium>*/