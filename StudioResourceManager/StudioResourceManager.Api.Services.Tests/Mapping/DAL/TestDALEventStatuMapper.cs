using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALEventStatuMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALEventStatuMapper();
			var bo = new BOEventStatu();
			bo.SetProperties(1, "A");

			EventStatu response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALEventStatuMapper();
			EventStatu entity = new EventStatu();
			entity.SetProperties(1, "A");

			BOEventStatu response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALEventStatuMapper();
			EventStatu entity = new EventStatu();
			entity.SetProperties(1, "A");

			List<BOEventStatu> response = mapper.MapEFToBO(new List<EventStatu>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d2d3f685c821d68e7057bf2c0065e142</Hash>
</Codenesium>*/