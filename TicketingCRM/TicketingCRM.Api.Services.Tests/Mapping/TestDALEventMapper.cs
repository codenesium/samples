using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Event")]
	[Trait("Area", "DALMapper")]
	public class TestDALEventMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALEventMapper();
			ApiEventServerRequestModel model = new ApiEventServerRequestModel();
			model.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			Event response = mapper.MapModelToEntity(1, model);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.CityId.Should().Be(1);
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Facebook.Should().Be("A");
			response.Name.Should().Be("A");
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Website.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALEventMapper();
			Event item = new Event();
			item.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiEventServerResponseModel response = mapper.MapEntityToModel(item);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.CityId.Should().Be(1);
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Facebook.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Website.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALEventMapper();
			Event item = new Event();
			item.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiEventServerResponseModel> response = mapper.MapEntityToModel(new List<Event>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5bbaee68225d8530576c22bae6429e78</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/