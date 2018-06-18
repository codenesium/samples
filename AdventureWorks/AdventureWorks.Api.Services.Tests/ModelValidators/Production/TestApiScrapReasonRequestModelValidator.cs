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
        [Trait("Table", "ScrapReason")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiScrapReasonRequestModelValidatorTest
        {
                public ApiScrapReasonRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
                        scrapReasonRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));

                        var validator = new ApiScrapReasonRequestModelValidator(scrapReasonRepository.Object);

                        await validator.ValidateCreateAsync(new ApiScrapReasonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
                        scrapReasonRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));

                        var validator = new ApiScrapReasonRequestModelValidator(scrapReasonRepository.Object);

                        await validator.ValidateUpdateAsync(default (short), new ApiScrapReasonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
                        scrapReasonRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));

                        var validator = new ApiScrapReasonRequestModelValidator(scrapReasonRepository.Object);

                        await validator.ValidateCreateAsync(new ApiScrapReasonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
                        scrapReasonRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));

                        var validator = new ApiScrapReasonRequestModelValidator(scrapReasonRepository.Object);

                        await validator.ValidateUpdateAsync(default (short), new ApiScrapReasonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
                        scrapReasonRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));

                        var validator = new ApiScrapReasonRequestModelValidator(scrapReasonRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (short));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
                        scrapReasonRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ScrapReason>(new ScrapReason()));
                        var validator = new ApiScrapReasonRequestModelValidator(scrapReasonRepository.Object);

                        await validator.ValidateCreateAsync(new ApiScrapReasonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
                        scrapReasonRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ScrapReason>(null));
                        var validator = new ApiScrapReasonRequestModelValidator(scrapReasonRepository.Object);

                        await validator.ValidateCreateAsync(new ApiScrapReasonRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
                        scrapReasonRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ScrapReason>(new ScrapReason()));
                        var validator = new ApiScrapReasonRequestModelValidator(scrapReasonRepository.Object);

                        await validator.ValidateUpdateAsync(default (short), new ApiScrapReasonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
                        scrapReasonRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ScrapReason>(null));
                        var validator = new ApiScrapReasonRequestModelValidator(scrapReasonRepository.Object);

                        await validator.ValidateUpdateAsync(default (short), new ApiScrapReasonRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>0e00319d52964921c8e09a2fcb31ec7c</Hash>
</Codenesium>*/