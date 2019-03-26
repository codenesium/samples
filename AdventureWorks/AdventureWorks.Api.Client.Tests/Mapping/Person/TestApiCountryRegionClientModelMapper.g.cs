using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CountryRegion")]
	[Trait("Area", "ApiModel")]
	public class TestApiCountryRegionModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCountryRegionModelMapper();
			var model = new ApiCountryRegionClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCountryRegionClientResponseModel response = mapper.MapClientRequestToResponse("A", model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCountryRegionModelMapper();
			var model = new ApiCountryRegionClientResponseModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCountryRegionClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>9bad587762a24a3e9b2d4ab0f9cddbcb</Hash>
</Codenesium>*/