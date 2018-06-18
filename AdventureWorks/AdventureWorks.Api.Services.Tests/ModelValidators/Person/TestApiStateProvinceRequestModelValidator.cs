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
        [Trait("Table", "StateProvince")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiStateProvinceRequestModelValidatorTest
        {
                public ApiStateProvinceRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void CountryRegionCode_Create_null()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, null as string);
                }

                [Fact]
                public async void CountryRegionCode_Update_null()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, null as string);
                }

                [Fact]
                public async void CountryRegionCode_Create_length()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, new string('A', 4));
                }

                [Fact]
                public async void CountryRegionCode_Update_length()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, new string('A', 4));
                }

                [Fact]
                public async void CountryRegionCode_Delete()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void StateProvinceCode_Create_null()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StateProvinceCode, null as string);
                }

                [Fact]
                public async void StateProvinceCode_Update_null()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StateProvinceCode, null as string);
                }

                [Fact]
                public async void StateProvinceCode_Create_length()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StateProvinceCode, new string('A', 4));
                }

                [Fact]
                public async void StateProvinceCode_Update_length()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StateProvinceCode, new string('A', 4));
                }

                [Fact]
                public async void StateProvinceCode_Delete()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));

                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByStateProvinceCodeCountryRegionCode_Create_Exists()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<StateProvince>(new StateProvince()));
                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, "A");
                }

                [Fact]
                private async void BeUniqueByStateProvinceCodeCountryRegionCode_Create_Not_Exists()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<StateProvince>(null));
                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStateProvinceRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CountryRegionCode, "A");
                }

                [Fact]
                private async void BeUniqueByStateProvinceCodeCountryRegionCode_Update_Exists()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<StateProvince>(new StateProvince()));
                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, "A");
                }

                [Fact]
                private async void BeUniqueByStateProvinceCodeCountryRegionCode_Update_Not_Exists()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<StateProvince>(null));
                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStateProvinceRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CountryRegionCode, "A");
                }
        }
}

/*<Codenesium>
    <Hash>dc590b819fcae2b853c04dba53ffe4d6</Hash>
</Codenesium>*/