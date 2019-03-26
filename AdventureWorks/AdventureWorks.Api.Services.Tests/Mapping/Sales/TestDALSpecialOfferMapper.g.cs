using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpecialOffer")]
	[Trait("Area", "DALMapper")]
	public class TestDALSpecialOfferMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSpecialOfferMapper();
			ApiSpecialOfferServerRequestModel model = new ApiSpecialOfferServerRequestModel();
			model.SetProperties("A", "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			SpecialOffer response = mapper.MapModelToEntity(1, model);

			response.Category.Should().Be("A");
			response.Description.Should().Be("A");
			response.DiscountPct.Should().Be(1m);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.MaxQty.Should().Be(1);
			response.MinQty.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReservedType.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSpecialOfferMapper();
			SpecialOffer item = new SpecialOffer();
			item.SetProperties(1, "A", "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiSpecialOfferServerResponseModel response = mapper.MapEntityToModel(item);

			response.Category.Should().Be("A");
			response.Description.Should().Be("A");
			response.DiscountPct.Should().Be(1m);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.MaxQty.Should().Be(1);
			response.MinQty.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReservedType.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SpecialOfferID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSpecialOfferMapper();
			SpecialOffer item = new SpecialOffer();
			item.SetProperties(1, "A", "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiSpecialOfferServerResponseModel> response = mapper.MapEntityToModel(new List<SpecialOffer>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1f2f15e4099fe9bebda34de6773727ff</Hash>
</Codenesium>*/