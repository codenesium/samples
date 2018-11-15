using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "AirTransport")]
	[Trait("Area", "ApiModel")]
	public class TestApiAirTransportServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiAirTransportServerModelMapper();
			var model = new ApiAirTransportServerRequestModel();
			model.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAirTransportServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiAirTransportServerModelMapper();
			var model = new ApiAirTransportServerResponseModel();
			model.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAirTransportServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiAirTransportServerModelMapper();
			var model = new ApiAirTransportServerRequestModel();
			model.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

			JsonPatchDocument<ApiAirTransportServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiAirTransportServerRequestModel();
			patch.ApplyTo(response);
			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>f4bbdab2fc9ec49c5e2b129b9f1ddc7d</Hash>
</Codenesium>*/