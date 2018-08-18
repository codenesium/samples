using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Artifact")]
	[Trait("Area", "DALMapper")]
	public class TestDALArtifactMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALArtifactMapper();
			var bo = new BOArtifact();
			bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");

			Artifact response = mapper.MapBOToEF(bo);

			response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.EnvironmentId.Should().Be("A");
			response.Filename.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.ProjectId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.TenantId.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALArtifactMapper();
			Artifact entity = new Artifact();
			entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A");

			BOArtifact response = mapper.MapEFToBO(entity);

			response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.EnvironmentId.Should().Be("A");
			response.Filename.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.ProjectId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.TenantId.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALArtifactMapper();
			Artifact entity = new Artifact();
			entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A");

			List<BOArtifact> response = mapper.MapEFToBO(new List<Artifact>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d999bc38d9ed0a218e64f3056a2c7f83</Hash>
</Codenesium>*/