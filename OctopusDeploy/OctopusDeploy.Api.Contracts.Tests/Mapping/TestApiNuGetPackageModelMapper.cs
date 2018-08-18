using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiNuGetPackageModelMapper();
			var model = new ApiNuGetPackageRequestModel();
			model.SetProperties("A", "A", "A", 1, 1, 1, 1, "A");

			JsonPatchDocument<ApiNuGetPackageRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiNuGetPackageRequestModel();
			patch.ApplyTo(response);
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
    <Hash>e1effe547fad5fbe1ce430ad050fc559</Hash>
</Codenesium>*/