using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PaymentType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPaymentTypeModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPaymentTypeModelMapper();
			var model = new ApiPaymentTypeRequestModel();
			model.SetProperties("A");
			ApiPaymentTypeResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPaymentTypeModelMapper();
			var model = new ApiPaymentTypeResponseModel();
			model.SetProperties(1, "A");
			ApiPaymentTypeRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPaymentTypeModelMapper();
			var model = new ApiPaymentTypeRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPaymentTypeRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPaymentTypeRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>e691613ea9f90a3619219e14f347dcf8</Hash>
</Codenesium>*/