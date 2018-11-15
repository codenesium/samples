using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkLog")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkLogModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiLinkLogModelMapper();
			var model = new ApiLinkLogClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiLinkLogClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiLinkLogModelMapper();
			var model = new ApiLinkLogClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiLinkLogClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ec17849f37212c6187fff467cd824198</Hash>
</Codenesium>*/