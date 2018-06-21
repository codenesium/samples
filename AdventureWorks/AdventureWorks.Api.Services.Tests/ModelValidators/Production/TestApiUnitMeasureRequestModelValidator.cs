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
        [Trait("Table", "UnitMeasure")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiUnitMeasureRequestModelValidatorTest
        {
                public ApiUnitMeasureRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
                        unitMeasureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UnitMeasure()));

                        var validator = new ApiUnitMeasureRequestModelValidator(unitMeasureRepository.Object);
                        await validator.ValidateCreateAsync(new ApiUnitMeasureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
                        unitMeasureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UnitMeasure()));

                        var validator = new ApiUnitMeasureRequestModelValidator(unitMeasureRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiUnitMeasureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
                        unitMeasureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UnitMeasure()));

                        var validator = new ApiUnitMeasureRequestModelValidator(unitMeasureRepository.Object);
                        await validator.ValidateCreateAsync(new ApiUnitMeasureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
                        unitMeasureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UnitMeasure()));

                        var validator = new ApiUnitMeasureRequestModelValidator(unitMeasureRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiUnitMeasureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
                        unitMeasureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UnitMeasure()));

                        var validator = new ApiUnitMeasureRequestModelValidator(unitMeasureRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
                        unitMeasureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(new UnitMeasure()));
                        var validator = new ApiUnitMeasureRequestModelValidator(unitMeasureRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUnitMeasureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
                        unitMeasureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(null));
                        var validator = new ApiUnitMeasureRequestModelValidator(unitMeasureRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUnitMeasureRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
                        unitMeasureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(new UnitMeasure()));
                        var validator = new ApiUnitMeasureRequestModelValidator(unitMeasureRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiUnitMeasureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
                        unitMeasureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(null));
                        var validator = new ApiUnitMeasureRequestModelValidator(unitMeasureRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiUnitMeasureRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>33a4f5c3ad3b2441f10cb5fb29830f22</Hash>
</Codenesium>*/