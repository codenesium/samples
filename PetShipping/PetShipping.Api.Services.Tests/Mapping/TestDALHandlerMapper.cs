using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Handler")]
	[Trait("Area", "DALMapper")]
	public class TestDALHandlerMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALHandlerMapper();
			ApiHandlerServerRequestModel model = new ApiHandlerServerRequestModel();
			model.SetProperties(1, "A", "A", "A", "A");
			Handler response = mapper.MapModelToEntity(1, model);

			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALHandlerMapper();
			Handler item = new Handler();
			item.SetProperties(1, 1, "A", "A", "A", "A");
			ApiHandlerServerResponseModel response = mapper.MapEntityToModel(item);

			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALHandlerMapper();
			Handler item = new Handler();
			item.SetProperties(1, 1, "A", "A", "A", "A");
			List<ApiHandlerServerResponseModel> response = mapper.MapEntityToModel(new List<Handler>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c45c28f83542440ad9c70b9628b33b68</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/