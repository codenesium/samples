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
	[Trait("Table", "Country")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLCountryMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCountryMapper();
			ApiCountryRequestModel model = new ApiCountryRequestModel();
			model.SetProperties("A");
			BOCountry response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLCountryMapper();
			BOCountry bo = new BOCountry();
			bo.SetProperties(1, "A");
			ApiCountryResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCountryMapper();
			BOCountry bo = new BOCountry();
			bo.SetProperties(1, "A");
			List<ApiCountryResponseModel> response = mapper.MapBOToModel(new List<BOCountry>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7b3250cc50d364f4375605c1c98a9260</Hash>
</Codenesium>*/