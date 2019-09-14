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
			model.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAirTransportServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AirlineId.Should().Be(1);
			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiAirTransportServerModelMapper();
			var model = new ApiAirTransportServerResponseModel();
			model.SetProperties(1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAirTransportServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.AirlineId.Should().Be(1);
			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiAirTransportServerModelMapper();
			var model = new ApiAirTransportServerRequestModel();
			model.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

			JsonPatchDocument<ApiAirTransportServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiAirTransportServerRequestModel();
			patch.ApplyTo(response);
			response.AirlineId.Should().Be(1);
			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>10dc2f9947dd9a4e26cdda288205af26</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/