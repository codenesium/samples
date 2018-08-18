using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "AirTransport")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLAirTransportMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLAirTransportMapper();
			ApiAirTransportRequestModel model = new ApiAirTransportRequestModel();
			model.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			BOAirTransport response = mapper.MapModelToBO(1, model);

			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLAirTransportMapper();
			BOAirTransport bo = new BOAirTransport();
			bo.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAirTransportResponseModel response = mapper.MapBOToModel(bo);

			response.AirlineId.Should().Be(1);
			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLAirTransportMapper();
			BOAirTransport bo = new BOAirTransport();
			bo.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiAirTransportResponseModel> response = mapper.MapBOToModel(new List<BOAirTransport>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fe9cfc4ffe2d8ae3c55728f91b412e6d</Hash>
</Codenesium>*/