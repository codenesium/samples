using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "ApiModel")]
	public class TestApiLocationModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiLocationModelMapper();
			var model = new ApiLocationRequestModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiLocationResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.LocationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiLocationModelMapper();
			var model = new ApiLocationResponseModel();
			model.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiLocationRequestModel response = mapper.MapResponseToRequest(model);

			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLocationModelMapper();
			var model = new ApiLocationRequestModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiLocationRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLocationRequestModel();
			patch.ApplyTo(response);
			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>4c8390ddf177db8e116c6c1cec0f1884</Hash>
</Codenesium>*/