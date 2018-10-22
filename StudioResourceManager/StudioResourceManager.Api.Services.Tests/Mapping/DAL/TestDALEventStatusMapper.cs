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
			bo.SetProperties(1, "A");

			EventStatus response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALEventStatusMapper();
			EventStatus entity = new EventStatus();
			entity.SetProperties(1, "A");

			BOEventStatus response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALEventStatusMapper();
			EventStatus entity = new EventStatus();
			entity.SetProperties(1, "A");

			List<BOEventStatus> response = mapper.MapEFToBO(new List<EventStatus>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d12ee8881a762b1d98d0aa726dd01aa4</Hash>
</Codenesium>*/