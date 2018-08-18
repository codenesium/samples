using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductInventory")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProductInventoryMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProductInventoryMapper();
			ApiProductInventoryRequestModel model = new ApiProductInventoryRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			BOProductInventory response = mapper.MapModelToBO(1, model);

			response.Bin.Should().Be(1);
			response.LocationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Quantity.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Shelf.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProductInventoryMapper();
			BOProductInventory bo = new BOProductInventory();
			bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiProductInventoryResponseModel response = mapper.MapBOToModel(bo);

			response.Bin.Should().Be(1);
			response.LocationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Shelf.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProductInventoryMapper();
			BOProductInventory bo = new BOProductInventory();
			bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			List<ApiProductInventoryResponseModel> response = mapper.MapBOToModel(new List<BOProductInventory>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b0d10e292eafa23d26e1632dce3a52bc</Hash>
</Codenesium>*/