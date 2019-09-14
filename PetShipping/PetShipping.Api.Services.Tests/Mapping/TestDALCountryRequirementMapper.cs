using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CountryRequirement")]
	[Trait("Area", "DALMapper")]
	public class TestDALCountryRequirementMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCountryRequirementMapper();
			ApiCountryRequirementServerRequestModel model = new ApiCountryRequirementServerRequestModel();
			model.SetProperties(1, "A");
			CountryRequirement response = mapper.MapModelToEntity(1, model);

			response.CountryId.Should().Be(1);
			response.Details.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCountryRequirementMapper();
			CountryRequirement item = new CountryRequirement();
			item.SetProperties(1, 1, "A");
			ApiCountryRequirementServerResponseModel response = mapper.MapEntityToModel(item);

			response.CountryId.Should().Be(1);
			response.Details.Should().Be("A");
			response.Id.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCountryRequirementMapper();
			CountryRequirement item = new CountryRequirement();
			item.SetProperties(1, 1, "A");
			List<ApiCountryRequirementServerResponseModel> response = mapper.MapEntityToModel(new List<CountryRequirement>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>94df50c85e79d0429782a3ffe9fd73b5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/