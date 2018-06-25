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
                        await validator.ValidateUpdateAsync(default(int), new ApiStateProvinceRequestModel());

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
                        await validator.ValidateUpdateAsync(default(int), new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, new string('A', 4));
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
                        await validator.ValidateUpdateAsync(default(int), new ApiStateProvinceRequestModel());

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
                        await validator.ValidateUpdateAsync(default(int), new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
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
                        await validator.ValidateUpdateAsync(default(int), new ApiStateProvinceRequestModel());

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
                        await validator.ValidateUpdateAsync(default(int), new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StateProvinceCode, new string('A', 4));
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

                        await validator.ValidateUpdateAsync(default(int), new ApiStateProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, "A");
                }

                [Fact]
                private async void BeUniqueByStateProvinceCodeCountryRegionCode_Update_Not_Exists()
                {
                        Mock<IStateProvinceRepository> stateProvinceRepository = new Mock<IStateProvinceRepository>();
                        stateProvinceRepository.Setup(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<StateProvince>(null));
                        var validator = new ApiStateProvinceRequestModelValidator(stateProvinceRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiStateProvinceRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CountryRegionCode, "A");
                }
        }
}

/*<Codenesium>
    <Hash>a572afbdb13bfbdda783a4f9219d03ca</Hash>
</Codenesium>*/