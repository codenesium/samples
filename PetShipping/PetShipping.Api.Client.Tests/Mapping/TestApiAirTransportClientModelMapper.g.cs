using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "AirTransport")]
	[Trait("Area", "ApiModel")]
	public class TestApiAirTransportModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiAirTransportModelMapper();
			var model = new ApiAirTransportClientRequestModel();
			model.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAirTransportClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiAirTransportModelMapper();
			var model = new ApiAirTransportClientResponseModel();
			model.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAirTransportClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
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
    <Hash>4360a4970302518570f487230e9c8b52</Hash>
</Codenesium>*/