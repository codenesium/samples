using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTPostgresNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Device")]
	[Trait("Area", "DALMapper")]
	public class TestDALDeviceMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALDeviceMapper();
			ApiDeviceServerRequestModel model = new ApiDeviceServerRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			Device response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALDeviceMapper();
			Device item = new Device();
			item.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALDeviceMapper();
			Device item = new Device();
			item.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiDeviceServerResponseModel> response = mapper.MapEntityToModel(new List<Device>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>dbefc4901dc0197a372db0622bfcc0a7</Hash>
</Codenesium>*/