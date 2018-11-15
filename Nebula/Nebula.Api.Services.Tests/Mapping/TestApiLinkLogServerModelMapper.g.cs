using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkLog")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkLogServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiLinkLogServerModelMapper();
			var model = new ApiLinkLogServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiLinkLogServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiLinkLogServerModelMapper();
			var model = new ApiLinkLogServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiLinkLogServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLinkLogServerModelMapper();
			var model = new ApiLinkLogServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

			JsonPatchDocument<ApiLinkLogServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLinkLogServerRequestModel();
			patch.ApplyTo(response);
			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>711e50d3a8dee290b98793238e85ad45</Hash>
</Codenesium>*/