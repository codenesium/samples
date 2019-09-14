using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Event")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiEventModelMapper();
			var model = new ApiEventClientRequestModel();
			model.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiEventClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
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
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiEventModelMapper();
			var model = new ApiEventClientResponseModel();
			model.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiEventClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
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
	}
}

/*<Codenesium>
    <Hash>f22d34618b59738956619916ffe702c2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/