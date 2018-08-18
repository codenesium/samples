using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CommunityActionTemplate")]
	[Trait("Area", "DALMapper")]
	public class TestDALCommunityActionTemplateMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALCommunityActionTemplateMapper();
			var bo = new BOCommunityActionTemplate();
			bo.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");

			CommunityActionTemplate response = mapper.MapBOToEF(bo);

			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALCommunityActionTemplateMapper();
			CommunityActionTemplate entity = new CommunityActionTemplate();
			entity.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A", "A");

			BOCommunityActionTemplate response = mapper.MapEFToBO(entity);

			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALCommunityActionTemplateMapper();
			CommunityActionTemplate entity = new CommunityActionTemplate();
			entity.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A", "A");

			List<BOCommunityActionTemplate> response = mapper.MapEFToBO(new List<CommunityActionTemplate>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d34010764e7951fe5fe4d76b811299ba</Hash>
</Codenesium>*/