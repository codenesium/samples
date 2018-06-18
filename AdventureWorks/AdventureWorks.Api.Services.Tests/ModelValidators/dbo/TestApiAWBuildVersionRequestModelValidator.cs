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
        [Trait("Table", "AWBuildVersion")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiAWBuildVersionRequestModelValidatorTest
        {
                public ApiAWBuildVersionRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Database_Version_Create_null()
                {
                        Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
                        aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

                        var validator = new ApiAWBuildVersionRequestModelValidator(aWBuildVersionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAWBuildVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Database_Version, null as string);
                }

                [Fact]
                public async void Database_Version_Update_null()
                {
                        Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
                        aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

                        var validator = new ApiAWBuildVersionRequestModelValidator(aWBuildVersionRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAWBuildVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Database_Version, null as string);
                }

                [Fact]
                public async void Database_Version_Create_length()
                {
                        Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
                        aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

                        var validator = new ApiAWBuildVersionRequestModelValidator(aWBuildVersionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAWBuildVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Database_Version, new string('A', 26));
                }

                [Fact]
                public async void Database_Version_Update_length()
                {
                        Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
                        aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

                        var validator = new ApiAWBuildVersionRequestModelValidator(aWBuildVersionRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAWBuildVersionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Database_Version, new string('A', 26));
                }

                [Fact]
                public async void Database_Version_Delete()
                {
                        Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
                        aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

                        var validator = new ApiAWBuildVersionRequestModelValidator(aWBuildVersionRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>a42ccfd7e61bb62af5d00ee9cc09dc23</Hash>
</Codenesium>*/