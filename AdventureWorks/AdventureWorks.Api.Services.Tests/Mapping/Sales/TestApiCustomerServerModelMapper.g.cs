using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Customer")]
	[Trait("Area", "ApiModel")]
	public class TestApiCustomerServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCustomerServerModelMapper();
			var model = new ApiCustomerServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
			ApiCustomerServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AccountNumber.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PersonID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StoreID.Should().Be(1);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCustomerServerModelMapper();
			var model = new ApiCustomerServerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
			ApiCustomerServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.AccountNumber.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PersonID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StoreID.Should().Be(1);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCustomerServerModelMapper();
			var model = new ApiCustomerServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);

			JsonPatchDocument<ApiCustomerServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCustomerServerRequestModel();
			patch.ApplyTo(response);
			response.AccountNumber.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PersonID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StoreID.Should().Be(1);
			response.TerritoryID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b3408ec81021629fd8b91beb7c9c8cbd</Hash>
</Codenesium>*/