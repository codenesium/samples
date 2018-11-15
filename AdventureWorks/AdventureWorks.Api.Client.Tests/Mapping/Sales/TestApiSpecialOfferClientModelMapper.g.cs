using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpecialOffer")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpecialOfferModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSpecialOfferModelMapper();
			var model = new ApiSpecialOfferClientRequestModel();
			model.SetProperties("A", "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiSpecialOfferClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Category.Should().Be("A");
			response.Description.Should().Be("A");
			response.DiscountPct.Should().Be(1m);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.MaxQty.Should().Be(1);
			response.MinQty.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSpecialOfferModelMapper();
			var model = new ApiSpecialOfferClientResponseModel();
			model.SetProperties(1, "A", "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiSpecialOfferClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Category.Should().Be("A");
			response.Description.Should().Be("A");
			response.DiscountPct.Should().Be(1m);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.MaxQty.Should().Be(1);
			response.MinQty.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Type.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>1fe3965f0200df5ecdba16118ba6f0c5</Hash>
</Codenesium>*/