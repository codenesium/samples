using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DeviceAction")]
	[Trait("Area", "DALMapper")]
	public class TestDALDeviceActionMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALDeviceActionMapper();
			var bo = new BODeviceAction();
			bo.SetProperties(1, "A", 1, "A");

			DeviceAction response = mapper.MapBOToEF(bo);

			response.@Value.Should().Be("A");
			response.DeviceId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALDeviceActionMapper();
			DeviceAction entity = new DeviceAction();
			entity.SetProperties("A", 1, 1, "A");

			BODeviceAction response = mapper.MapEFToBO(entity);

			response.@Value.Should().Be("A");
			response.DeviceId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALDeviceActionMapper();
			DeviceAction entity = new DeviceAction();
			entity.SetProperties("A", 1, 1, "A");

			List<BODeviceAction> response = mapper.MapEFToBO(new List<DeviceAction>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>536ee6de470cd032b32d4155bd27d80f</Hash>
</Codenesium>*/