using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Store")]
	[Trait("Area", "ApiModel")]
	public class TestApiStoreServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiStoreServerModelMapper();
			var model = new ApiStoreServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			ApiStoreServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Demographic.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesPersonID.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiStoreServerModelMapper();
			var model = new ApiStoreServerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			ApiStoreServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Demographic.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesPersonID.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiStoreServerModelMapper();
			var model = new ApiStoreServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);

			JsonPatchDocument<ApiStoreServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiStoreServerRequestModel();
			patch.ApplyTo(response);
			response.Demographic.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesPersonID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a63d5c2ac75c792e19612bac579dbaa5</Hash>
</Codenesium>*/