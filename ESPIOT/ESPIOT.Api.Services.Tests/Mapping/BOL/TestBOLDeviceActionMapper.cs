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
			ApiDeviceActionServerRequestModel model = new ApiDeviceActionServerRequestModel();
			model.SetProperties("A", 1, "A");
			BODeviceAction response = mapper.MapModelToBO(1, model);

			response.@Value.Should().Be("A");
			response.DeviceId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLDeviceActionMapper();
			BODeviceAction bo = new BODeviceAction();
			bo.SetProperties(1, "A", 1, "A");
			ApiDeviceActionServerResponseModel response = mapper.MapBOToModel(bo);

			response.@Value.Should().Be("A");
			response.DeviceId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLDeviceActionMapper();
			BODeviceAction bo = new BODeviceAction();
			bo.SetProperties(1, "A", 1, "A");
			List<ApiDeviceActionServerResponseModel> response = mapper.MapBOToModel(new List<BODeviceAction>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>cf959ce73ef2524f2132e33ed1c67f13</Hash>
</Codenesium>*/