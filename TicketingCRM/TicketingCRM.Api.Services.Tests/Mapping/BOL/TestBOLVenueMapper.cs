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
	[Trait("Table", "Venue")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLVenueMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLVenueMapper();
			ApiVenueRequestModel model = new ApiVenueRequestModel();
			model.SetProperties("A", "A", 1, "A", "A", "A", "A", 1, "A");
			BOVenue response = mapper.MapModelToBO(1, model);

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
		public void MapBOToModel()
		{
			var mapper = new BOLVenueMapper();
			BOVenue bo = new BOVenue();
			bo.SetProperties(1, "A", "A", 1, "A", "A", "A", "A", 1, "A");
			ApiVenueResponseModel response = mapper.MapBOToModel(bo);

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
		public void MapBOToModelList()
		{
			var mapper = new BOLVenueMapper();
			BOVenue bo = new BOVenue();
			bo.SetProperties(1, "A", "A", 1, "A", "A", "A", "A", 1, "A");
			List<ApiVenueResponseModel> response = mapper.MapBOToModel(new List<BOVenue>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3783246fed2d49040263d27399c10ef4</Hash>
</Codenesium>*/