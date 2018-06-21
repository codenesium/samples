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
        [Trait("Table", "Currency")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCurrencyRequestModelValidatorTest
        {
                public ApiCurrencyRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
                        currencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Currency()));

                        var validator = new ApiCurrencyRequestModelValidator(currencyRepository.Object);
                        await validator.ValidateCreateAsync(new ApiCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
                        currencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Currency()));

                        var validator = new ApiCurrencyRequestModelValidator(currencyRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
                        currencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Currency()));

                        var validator = new ApiCurrencyRequestModelValidator(currencyRepository.Object);
                        await validator.ValidateCreateAsync(new ApiCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
                        currencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Currency()));

                        var validator = new ApiCurrencyRequestModelValidator(currencyRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
                        currencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Currency()));

                        var validator = new ApiCurrencyRequestModelValidator(currencyRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
                        currencyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Currency>(new Currency()));
                        var validator = new ApiCurrencyRequestModelValidator(currencyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
                        currencyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));
                        var validator = new ApiCurrencyRequestModelValidator(currencyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCurrencyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
                        currencyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Currency>(new Currency()));
                        var validator = new ApiCurrencyRequestModelValidator(currencyRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiCurrencyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
                        currencyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));
                        var validator = new ApiCurrencyRequestModelValidator(currencyRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiCurrencyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>ee4a07a0dff60da032bc2500bf742121</Hash>
</Codenesium>*/