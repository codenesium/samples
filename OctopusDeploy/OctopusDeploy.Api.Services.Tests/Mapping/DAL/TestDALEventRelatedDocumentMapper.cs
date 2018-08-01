using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventRelatedDocument")]
	[Trait("Area", "DALMapper")]
	public class TestDALEventRelatedDocumentMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALEventRelatedDocumentMapper();
			var bo = new BOEventRelatedDocument();
			bo.SetProperties(1, "A", "A");

			EventRelatedDocument response = mapper.MapBOToEF(bo);

			response.EventId.Should().Be("A");
			response.Id.Should().Be(1);
			response.RelatedDocumentId.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALEventRelatedDocumentMapper();
			EventRelatedDocument entity = new EventRelatedDocument();
			entity.SetProperties("A", 1, "A");

			BOEventRelatedDocument response = mapper.MapEFToBO(entity);

			response.EventId.Should().Be("A");
			response.Id.Should().Be(1);
			response.RelatedDocumentId.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALEventRelatedDocumentMapper();
			EventRelatedDocument entity = new EventRelatedDocument();
			entity.SetProperties("A", 1, "A");

			List<BOEventRelatedDocument> response = mapper.MapEFToBO(new List<EventRelatedDocument>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9a9b5b73a76026ad93c798fd13af8838</Hash>
</Codenesium>*/