using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "NuGetPackage")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiNuGetPackageRequestModelValidatorTest
        {
                public ApiNuGetPackageRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateCreateAsync(new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void PackageId_Create_null()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateCreateAsync(new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PackageId, null as string);
                }

                [Fact]
                public async void PackageId_Update_null()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PackageId, null as string);
                }

                [Fact]
                public async void PackageId_Create_length()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateCreateAsync(new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PackageId, new string('A', 101));
                }

                [Fact]
                public async void PackageId_Update_length()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PackageId, new string('A', 101));
                }

                [Fact]
                public async void PackageId_Delete()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Version_Create_null()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateCreateAsync(new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Version, null as string);
                }

                [Fact]
                public async void Version_Update_null()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Version, null as string);
                }

                [Fact]
                public async void Version_Create_length()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateCreateAsync(new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Version, new string('A', 350));
                }

                [Fact]
                public async void Version_Update_length()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Version, new string('A', 350));
                }

                [Fact]
                public async void Version_Delete()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void VersionSpecial_Create_length()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateCreateAsync(new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.VersionSpecial, new string('A', 251));
                }

                [Fact]
                public async void VersionSpecial_Update_length()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiNuGetPackageRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.VersionSpecial, new string('A', 251));
                }

                [Fact]
                public async void VersionSpecial_Delete()
                {
                        Mock<INuGetPackageRepository> nuGetPackageRepository = new Mock<INuGetPackageRepository>();
                        nuGetPackageRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new NuGetPackage()));

                        var validator = new ApiNuGetPackageRequestModelValidator(nuGetPackageRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>830a487343cb40aa6b98b740af6176ea</Hash>
</Codenesium>*/