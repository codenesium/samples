using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Culture")]
	[Trait("Area", "ApiModel")]
	public class TestApiCultureServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCultureServerModelMapper();
			var model = new ApiCultureServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCultureServerResponseModel response = mapper.MapServerRequestToResponse("A", model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCultureServerModelMapper();
			var model = new ApiCultureServerResponseModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCultureServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCultureServerModelMapper();
			var model = new ApiCultureServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiCultureServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCultureServerRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>4750f05a84fa9fe5b6bff9b52f1a4459</Hash>
</Codenesium>*/