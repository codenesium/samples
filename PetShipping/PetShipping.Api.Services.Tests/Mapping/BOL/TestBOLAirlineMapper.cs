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
	[Trait("Table", "Airline")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLAirlineMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLAirlineMapper();
			ApiAirlineServerRequestModel model = new ApiAirlineServerRequestModel();
			model.SetProperties("A");
			BOAirline response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLAirlineMapper();
			BOAirline bo = new BOAirline();
			bo.SetProperties(1, "A");
			ApiAirlineServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLAirlineMapper();
			BOAirline bo = new BOAirline();
			bo.SetProperties(1, "A");
			List<ApiAirlineServerResponseModel> response = mapper.MapBOToModel(new List<BOAirline>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8435ce8f397f0aa623e5d9819b9dc7a0</Hash>
</Codenesium>*/