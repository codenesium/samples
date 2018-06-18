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
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "VersionInfo")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiVersionInfoRequestModelValidatorTest
        {
                public ApiVersionInfoRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Description_Create_length()
                {
                        Mock<IVersionInfoRepository> versionInfoRepository = new Mock<IVersionInfoRepository>();
                        versionInfoRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new VersionInfo()));

                        var validator = new ApiVersionInfoRequestModelValidator(versionInfoRepository.Object);

                        await validator.ValidateCreateAsync(new ApiVersionInfoRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 1025));
                }

                [Fact]
                public async void Description_Update_length()
                {
                        Mock<IVersionInfoRepository> versionInfoRepository = new Mock<IVersionInfoRepository>();
                        versionInfoRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new VersionInfo()));

                        var validator = new ApiVersionInfoRequestModelValidator(versionInfoRepository.Object);

                        await validator.ValidateUpdateAsync(default (long), new ApiVersionInfoRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 1025));
                }

                [Fact]
                public async void Description_Delete()
                {
                        Mock<IVersionInfoRepository> versionInfoRepository = new Mock<IVersionInfoRepository>();
                        versionInfoRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new VersionInfo()));

                        var validator = new ApiVersionInfoRequestModelValidator(versionInfoRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (long));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>408638ede114d55543d1aeda740207d0</Hash>
</Codenesium>*/