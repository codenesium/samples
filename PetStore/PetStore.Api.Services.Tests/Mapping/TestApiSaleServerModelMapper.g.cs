using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "ApiModel")]
	public class TestApiSaleServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSaleServerModelMapper();
			var model = new ApiSaleServerRequestModel();
			model.SetProperties(1m, "A", "A", 1, 1, "A");
			ApiSaleServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.PaymentTypeId.Should().Be(1);
			response.PetId.Should().Be(1);
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSaleServerModelMapper();
			var model = new ApiSaleServerResponseModel();
			model.SetProperties(1, 1m, "A", "A", 1, 1, "A");
			ApiSaleServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.PaymentTypeId.Should().Be(1);
			response.PetId.Should().Be(1);
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSaleServerModelMapper();
			var model = new ApiSaleServerRequestModel();
			model.SetProperties(1m, "A", "A", 1, 1, "A");

			JsonPatchDocument<ApiSaleServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSaleServerRequestModel();
			patch.ApplyTo(response);
			response.Amount.Should().Be(1m);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.PaymentTypeId.Should().Be(1);
			response.PetId.Should().Be(1);
			response.Phone.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>bbdf98dc078828251eac911b7ba336be</Hash>
</Codenesium>*/