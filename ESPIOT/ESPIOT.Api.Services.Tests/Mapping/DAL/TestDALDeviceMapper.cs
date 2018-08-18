using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Device")]
	[Trait("Area", "DALMapper")]
	public class TestDALDeviceMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALDeviceMapper();
			var bo = new BODevice();
			bo.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			Device response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALDeviceMapper();
			Device entity = new Device();
			entity.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			BODevice response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALDeviceMapper();
			Device entity = new Device();
			entity.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			List<BODevice> response = mapper.MapEFToBO(new List<Device>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>320a9957f81dd04b4b6a8b44a602fb53</Hash>
</Codenesium>*/