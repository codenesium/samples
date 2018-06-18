using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "NuGetPackage")]
        [Trait("Area", "DALMapper")]
        public class TestDALNuGetPackageActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALNuGetPackageMapper();

                        var bo = new BONuGetPackage();

                        bo.SetProperties("A", "A", "A", "A", 1, 1, 1, 1, "A");

                        NuGetPackage response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALNuGetPackageMapper();

                        NuGetPackage entity = new NuGetPackage();

                        entity.SetProperties("A", "A", "A", "A", 1, 1, 1, 1, "A");

                        BONuGetPackage  response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALNuGetPackageMapper();

                        NuGetPackage entity = new NuGetPackage();

                        entity.SetProperties("A", "A", "A", "A", 1, 1, 1, 1, "A");

                        List<BONuGetPackage> response = mapper.MapEFToBO(new List<NuGetPackage>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>d0812d7d9b25f7a502e714c0d22b1ad7</Hash>
</Codenesium>*/