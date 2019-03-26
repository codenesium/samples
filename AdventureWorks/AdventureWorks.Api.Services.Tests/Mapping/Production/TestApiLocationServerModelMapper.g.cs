using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "ApiModel")]
	public class TestApiLocationServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiLocationServerModelMapper();
			var model = new ApiLocationServerRequestModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiLocationServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiLocationServerModelMapper();
			var model = new ApiLocationServerResponseModel();
			model.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiLocationServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLocationServerModelMapper();
			var model = new ApiLocationServerRequestModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiLocationServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLocationServerRequestModel();
			patch.ApplyTo(response);
			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>2e8afcecea98bd3662fcdc1a11438a07</Hash>
</Codenesium>*/