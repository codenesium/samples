using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Address")]
	[Trait("Area", "ApiModel")]
	public class TestApiAddressModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiAddressModelMapper();
			var model = new ApiAddressClientRequestModel();
			model.SetProperties("A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			ApiAddressClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiAddressModelMapper();
			var model = new ApiAddressClientResponseModel();
			model.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			ApiAddressClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6a682d229e165b9dfc1de20787e735f5</Hash>
</Codenesium>*/