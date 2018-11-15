using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "City")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLCityMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCityMapper();
			ApiCityServerRequestModel model = new ApiCityServerRequestModel();
			model.SetProperties("A", 1);
			BOCity response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLCityMapper();
			BOCity bo = new BOCity();
			bo.SetProperties(1, "A", 1);
			ApiCityServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCityMapper();
			BOCity bo = new BOCity();
			bo.SetProperties(1, "A", 1);
			List<ApiCityServerResponseModel> response = mapper.MapBOToModel(new List<BOCity>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b9b84c0cb58e8d540fd0d759c207561f</Hash>
</Codenesium>*/