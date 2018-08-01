using ESPIOTNS.Api.Contracts;
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
	[Trait("Area", "BOLMapper")]
	public class TestBOLDeviceActionMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLDeviceActionMapper();
			ApiDeviceActionRequestModel model = new ApiDeviceActionRequestModel();
			model.SetProperties(1, "A", "A");
			BODeviceAction response = mapper.MapModelToBO(1, model);

			response.DeviceId.Should().Be(1);
			response.Name.Should().Be("A");
			response.@Value.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLDeviceActionMapper();
			BODeviceAction bo = new BODeviceAction();
			bo.SetProperties(1, 1, "A", "A");
			ApiDeviceActionResponseModel response = mapper.MapBOToModel(bo);

			response.DeviceId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.@Value.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLDeviceActionMapper();
			BODeviceAction bo = new BODeviceAction();
			bo.SetProperties(1, 1, "A", "A");
			List<ApiDeviceActionResponseModel> response = mapper.MapBOToModel(new List<BODeviceAction>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ca1bae917c88b7bd0b31482e62d56db4</Hash>
</Codenesium>*/