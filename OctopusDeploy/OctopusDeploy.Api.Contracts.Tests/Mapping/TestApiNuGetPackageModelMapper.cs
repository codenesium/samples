using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "NuGetPackage")]
        [Trait("Area", "ApiModel")]
        public class TestApiNuGetPackageModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiNuGetPackageModelMapper();
                        var model = new ApiNuGetPackageRequestModel();
                        model.SetProperties("A", "A", "A", 1, 1, 1, 1, "A");
                        ApiNuGetPackageResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.PackageId.Should().Be("A");
                        response.Version.Should().Be("A");
                        response.VersionBuild.Should().Be(1);
                        response.VersionMajor.Should().Be(1);
                        response.VersionMinor.Should().Be(1);
                        response.VersionRevision.Should().Be(1);
                        response.VersionSpecial.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiNuGetPackageModelMapper();
                        var model = new ApiNuGetPackageResponseModel();
                        model.SetProperties("A", "A", "A", "A", 1, 1, 1, 1, "A");
                        ApiNuGetPackageRequestModel response = mapper.MapResponseToRequest(model);

                        response.JSON.Should().Be("A");
                        response.PackageId.Should().Be("A");
                        response.Version.Should().Be("A");
                        response.VersionBuild.Should().Be(1);
                        response.VersionMajor.Should().Be(1);
                        response.VersionMinor.Should().Be(1);
                        response.VersionRevision.Should().Be(1);
                        response.VersionSpecial.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>c0e5bdefcd5495aef45b352539137dd7</Hash>
</Codenesium>*/