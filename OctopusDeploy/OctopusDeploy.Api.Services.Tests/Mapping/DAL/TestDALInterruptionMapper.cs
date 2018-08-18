using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Interruption")]
	[Trait("Area", "DALMapper")]
	public class TestDALInterruptionMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALInterruptionMapper();
			var bo = new BOInterruption();
			bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A");

			Interruption response = mapper.MapBOToEF(bo);

			response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.EnvironmentId.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.ProjectId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.ResponsibleTeamIds.Should().Be("A");
			response.Status.Should().Be("A");
			response.TaskId.Should().Be("A");
			response.TenantId.Should().Be("A");
			response.Title.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALInterruptionMapper();
			Interruption entity = new Interruption();
			entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");

			BOInterruption response = mapper.MapEFToBO(entity);

			response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.EnvironmentId.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.ProjectId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.ResponsibleTeamIds.Should().Be("A");
			response.Status.Should().Be("A");
			response.TaskId.Should().Be("A");
			response.TenantId.Should().Be("A");
			response.Title.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALInterruptionMapper();
			Interruption entity = new Interruption();
			entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");

			List<BOInterruption> response = mapper.MapEFToBO(new List<Interruption>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3ecfbb086cf7a68bf195f30f33713f4f</Hash>
</Codenesium>*/