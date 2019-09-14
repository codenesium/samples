using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DeviceAction")]
	[Trait("Area", "DALMapper")]
	public class TestDALDeviceActionMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALDeviceActionMapper();
			ApiDeviceActionServerRequestModel model = new ApiDeviceActionServerRequestModel();
			model.SetProperties("A", 1, "A");
			DeviceAction response = mapper.MapModelToEntity(1, model);

			response.Action.Should().Be("A");
			response.DeviceId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALDeviceActionMapper();
			DeviceAction item = new DeviceAction();
			item.SetProperties(1, "A", 1, "A");
			ApiDeviceActionServerResponseModel response = mapper.MapEntityToModel(item);

			response.Action.Should().Be("A");
			response.DeviceId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALDeviceActionMapper();
			DeviceAction item = new DeviceAction();
			item.SetProperties(1, "A", 1, "A");
			List<ApiDeviceActionServerResponseModel> response = mapper.MapEntityToModel(new List<DeviceAction>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>286bd0e3b1160e9de2e5d178f34ebe30</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/