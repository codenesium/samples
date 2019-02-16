using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Country")]
	[Trait("Area", "DALMapper")]
	public class TestDALCountryMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCountryMapper();
			ApiCountryServerRequestModel model = new ApiCountryServerRequestModel();
			model.SetProperties("A");
			Country response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCountryMapper();
			Country item = new Country();
			item.SetProperties(1, "A");
			ApiCountryServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCountryMapper();
			Country item = new Country();
			item.SetProperties(1, "A");
			List<ApiCountryServerResponseModel> response = mapper.MapEntityToModel(new List<Country>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7355ac0282a79a318ad0ab7daab7117c</Hash>
</Codenesium>*/