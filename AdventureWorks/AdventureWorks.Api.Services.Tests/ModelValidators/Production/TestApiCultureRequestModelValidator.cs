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
        [Trait("Table", "Culture")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCultureRequestModelValidatorTest
        {
                public ApiCultureRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
                        cultureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Culture()));

                        var validator = new ApiCultureRequestModelValidator(cultureRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCultureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
                        cultureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Culture()));

                        var validator = new ApiCultureRequestModelValidator(cultureRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCultureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
                        cultureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Culture()));

                        var validator = new ApiCultureRequestModelValidator(cultureRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCultureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
                        cultureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Culture()));

                        var validator = new ApiCultureRequestModelValidator(cultureRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCultureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
                        cultureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Culture()));

                        var validator = new ApiCultureRequestModelValidator(cultureRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
                        cultureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Culture>(new Culture()));
                        var validator = new ApiCultureRequestModelValidator(cultureRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCultureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
                        cultureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Culture>(null));
                        var validator = new ApiCultureRequestModelValidator(cultureRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCultureRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
                        cultureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Culture>(new Culture()));
                        var validator = new ApiCultureRequestModelValidator(cultureRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCultureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
                        cultureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Culture>(null));
                        var validator = new ApiCultureRequestModelValidator(cultureRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCultureRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>129f0da7db97b2a364c1374109be6f03</Hash>
</Codenesium>*/