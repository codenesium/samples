using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "ApiModel")]
	public class TestApiLocationModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiLocationModelMapper();
			var model = new ApiLocationClientRequestModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiLocationClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiLocationModelMapper();
			var model = new ApiLocationClientResponseModel();
			model.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiLocationClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>295afd997e4b6932d2fdf7da1390de42</Hash>
</Codenesium>*/