using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Province")]
	[Trait("Area", "DALMapper")]
	public class TestDALProvinceMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALProvinceMapper();
			ApiProvinceServerRequestModel model = new ApiProvinceServerRequestModel();
			model.SetProperties(1, "A");
			Province response = mapper.MapModelToEntity(1, model);

			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALProvinceMapper();
			Province item = new Province();
			item.SetProperties(1, 1, "A");
			ApiProvinceServerResponseModel response = mapper.MapEntityToModel(item);

			response.CountryId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALProvinceMapper();
			Province item = new Province();
			item.SetProperties(1, 1, "A");
			List<ApiProvinceServerResponseModel> response = mapper.MapEntityToModel(new List<Province>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1d81b867714488e6d11139671e891abe</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/