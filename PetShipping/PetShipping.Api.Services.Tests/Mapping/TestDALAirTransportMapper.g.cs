using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "AirTransport")]
	[Trait("Area", "DALMapper")]
	public class TestDALAirTransportMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALAirTransportMapper();
			ApiAirTransportServerRequestModel model = new ApiAirTransportServerRequestModel();
			model.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			AirTransport response = mapper.MapModelToEntity(1, model);

			response.AirlineId.Should().Be(1);
			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALAirTransportMapper();
			AirTransport item = new AirTransport();
			item.SetProperties(1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAirTransportServerResponseModel response = mapper.MapEntityToModel(item);

			response.AirlineId.Should().Be(1);
			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALAirTransportMapper();
			AirTransport item = new AirTransport();
			item.SetProperties(1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiAirTransportServerResponseModel> response = mapper.MapEntityToModel(new List<AirTransport>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7f46c7a9fac2d7aeea2877610fac941f</Hash>
</Codenesium>*/