using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALEventStatusMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALEventStatusMapper();
			var bo = new BOEventStatus();
			bo.SetProperties(1, "A", true);

			EventStatus response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALEventStatusMapper();
			EventStatus entity = new EventStatus();
			entity.SetProperties(1, "A", true);

			BOEventStatus response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALEventStatusMapper();
			EventStatus entity = new EventStatus();
			entity.SetProperties(1, "A", true);

			List<BOEventStatus> response = mapper.MapEFToBO(new List<EventStatus>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>05d749a6a58d433771663115010353ac</Hash>
</Codenesium>*/