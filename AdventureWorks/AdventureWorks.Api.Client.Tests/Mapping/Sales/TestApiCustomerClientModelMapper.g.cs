using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Customer")]
	[Trait("Area", "ApiModel")]
	public class TestApiCustomerModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCustomerModelMapper();
			var model = new ApiCustomerClientRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
			ApiCustomerClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AccountNumber.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PersonID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StoreID.Should().Be(1);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCustomerModelMapper();
			var model = new ApiCustomerClientResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
			ApiCustomerClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
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
    <Hash>172bb6fdd248c7075dd260a3346d1b9d</Hash>
</Codenesium>*/