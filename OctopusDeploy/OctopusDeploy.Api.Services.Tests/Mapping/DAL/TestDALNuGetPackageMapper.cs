using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "NuGetPackage")]
	[Trait("Area", "DALMapper")]
	public class TestDALNuGetPackageMapper
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

			BONuGetPackage response = mapper.MapEFToBO(entity);

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
    <Hash>632a15ff8f7f5fa05c98655272db3dd2</Hash>
</Codenesium>*/