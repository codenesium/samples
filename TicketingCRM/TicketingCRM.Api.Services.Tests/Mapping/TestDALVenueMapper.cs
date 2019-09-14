using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Venue")]
	[Trait("Area", "DALMapper")]
	public class TestDALVenueMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVenueMapper();
			ApiVenueServerRequestModel model = new ApiVenueServerRequestModel();
			model.SetProperties("A", "A", 1, "A", "A", "A", "A", 1, "A");
			Venue response = mapper.MapModelToEntity(1, model);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.AdminId.Should().Be(1);
			response.Email.Should().Be("A");
			response.Facebook.Should().Be("A");
			response.Name.Should().Be("A");
			response.Phone.Should().Be("A");
			response.ProvinceId.Should().Be(1);
			response.Website.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVenueMapper();
			Venue item = new Venue();
			item.SetProperties(1, "A", "A", 1, "A", "A", "A", "A", 1, "A");
			ApiVenueServerResponseModel response = mapper.MapEntityToModel(item);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.AdminId.Should().Be(1);
			response.Email.Should().Be("A");
			response.Facebook.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Phone.Should().Be("A");
			response.ProvinceId.Should().Be(1);
			response.Website.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVenueMapper();
			Venue item = new Venue();
			item.SetProperties(1, "A", "A", 1, "A", "A", "A", "A", 1, "A");
			List<ApiVenueServerResponseModel> response = mapper.MapEntityToModel(new List<Venue>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>bd4b082e31292571097c60dfdc31755d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/