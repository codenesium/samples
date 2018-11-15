using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Event")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiEventServerModelMapper();
			var model = new ApiEventServerRequestModel();
			model.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiEventServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
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
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiEventServerModelMapper();
			var model = new ApiEventServerResponseModel();
			model.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiEventServerRequestModel response = mapper.MapServerResponseToRequest(model);
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
		public void CreatePatch()
		{
			var mapper = new ApiEventServerModelMapper();
			var model = new ApiEventServerRequestModel();
			model.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiEventServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventServerRequestModel();
			patch.ApplyTo(response);
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
    <Hash>db23e6481ab3443cfdd5580332ac8621</Hash>
</Codenesium>*/