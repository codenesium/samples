using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SelfReference")]
	[Trait("Area", "ApiModel")]
	public class TestApiSelfReferenceServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSelfReferenceServerModelMapper();
			var model = new ApiSelfReferenceServerRequestModel();
			model.SetProperties(1, 1);
			ApiSelfReferenceServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSelfReferenceServerModelMapper();
			var model = new ApiSelfReferenceServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSelfReferenceServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSelfReferenceServerModelMapper();
			var model = new ApiSelfReferenceServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiSelfReferenceServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSelfReferenceServerRequestModel();
			patch.ApplyTo(response);
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>27aaafea4d68f7b2fb4c828cd6b3bc22</Hash>
</Codenesium>*/