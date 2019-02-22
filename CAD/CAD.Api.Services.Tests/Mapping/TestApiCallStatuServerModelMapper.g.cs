using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallStatuServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCallStatuServerModelMapper();
			var model = new ApiCallStatuServerRequestModel();
			model.SetProperties("A");
			ApiCallStatuServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCallStatuServerModelMapper();
			var model = new ApiCallStatuServerResponseModel();
			model.SetProperties(1, "A");
			ApiCallStatuServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCallStatuServerModelMapper();
			var model = new ApiCallStatuServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiCallStatuServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCallStatuServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>134a9b19ec471d0e3f9180509f2193a1</Hash>
</Codenesium>*/