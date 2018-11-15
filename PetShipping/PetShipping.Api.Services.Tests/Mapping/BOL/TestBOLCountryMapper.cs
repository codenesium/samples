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
	[Trait("Table", "Country")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLCountryMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCountryMapper();
			ApiCountryServerRequestModel model = new ApiCountryServerRequestModel();
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
			ApiCountryServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCountryMapper();
			BOCountry bo = new BOCountry();
			bo.SetProperties(1, "A");
			List<ApiCountryServerResponseModel> response = mapper.MapBOToModel(new List<BOCountry>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fbb78fc2aa9c9f07784522e5683f1d89</Hash>
</Codenesium>*/