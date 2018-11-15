using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PaymentType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPaymentTypeServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPaymentTypeServerModelMapper();
			var model = new ApiPaymentTypeServerRequestModel();
			model.SetProperties("A");
			ApiPaymentTypeServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPaymentTypeServerModelMapper();
			var model = new ApiPaymentTypeServerResponseModel();
			model.SetProperties(1, "A");
			ApiPaymentTypeServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPaymentTypeServerModelMapper();
			var model = new ApiPaymentTypeServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPaymentTypeServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPaymentTypeServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5a6fc850fabf15c40e860a454d5050e4</Hash>
</Codenesium>*/