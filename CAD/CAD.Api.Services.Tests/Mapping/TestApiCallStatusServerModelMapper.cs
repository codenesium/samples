using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallStatusServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCallStatusServerModelMapper();
			var model = new ApiCallStatusServerRequestModel();
			model.SetProperties("A");
			ApiCallStatusServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCallStatusServerModelMapper();
			var model = new ApiCallStatusServerResponseModel();
			model.SetProperties(1, "A");
			ApiCallStatusServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCallStatusServerModelMapper();
			var model = new ApiCallStatusServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiCallStatusServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCallStatusServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>cd2da9ada3c860acea15fa93d06a9293</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/