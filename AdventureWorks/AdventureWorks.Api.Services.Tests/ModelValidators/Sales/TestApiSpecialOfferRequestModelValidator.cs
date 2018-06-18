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
        [Trait("Table", "SpecialOffer")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSpecialOfferRequestModelValidatorTest
        {
                public ApiSpecialOfferRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Category_Create_null()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Category, null as string);
                }

                [Fact]
                public async void Category_Update_null()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Category, null as string);
                }

                [Fact]
                public async void Category_Create_length()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Category, new string('A', 51));
                }

                [Fact]
                public async void Category_Update_length()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Category, new string('A', 51));
                }

                [Fact]
                public async void Category_Delete()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Description_Create_null()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void Description_Update_null()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void Description_Create_length()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 256));
                }

                [Fact]
                public async void Description_Update_length()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 256));
                }

                [Fact]
                public async void Description_Delete()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Type_Create_null()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
                }

                [Fact]
                public async void Type_Update_null()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
                }

                [Fact]
                public async void Type_Create_length()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
                }

                [Fact]
                public async void Type_Update_length()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSpecialOfferRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
                }

                [Fact]
                public async void Type_Delete()
                {
                        Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
                        specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

                        var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>a0b0ae4ef10ba99ba9044bd4d2792ea0</Hash>
</Codenesium>*/