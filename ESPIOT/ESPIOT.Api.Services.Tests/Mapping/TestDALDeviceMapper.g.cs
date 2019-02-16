using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Services
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
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			Device response = mapper.MapModelToEntity(1, model);

			response.DateOfLastPing.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.IsActive.Should().Be(true);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALDeviceMapper();
			Device item = new Device();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceServerResponseModel response = mapper.MapEntityToModel(item);

			response.DateOfLastPing.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.IsActive.Should().Be(true);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALDeviceMapper();
			Device item = new Device();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiDeviceServerResponseModel> response = mapper.MapEntityToModel(new List<Device>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1dc2f0028cde4bf52a5a18ee2eebe9bb</Hash>
</Codenesium>*/