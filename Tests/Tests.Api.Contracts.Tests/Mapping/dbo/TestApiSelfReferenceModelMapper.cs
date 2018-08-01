using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SelfReference")]
	[Trait("Area", "ApiModel")]
	public class TestApiSelfReferenceModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSelfReferenceModelMapper();
			var model = new ApiSelfReferenceRequestModel();
			model.SetProperties(1, 1);
			ApiSelfReferenceResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSelfReferenceModelMapper();
			var model = new ApiSelfReferenceResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSelfReferenceRequestModel response = mapper.MapResponseToRequest(model);

			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSelfReferenceModelMapper();
			var model = new ApiSelfReferenceRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiSelfReferenceRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSelfReferenceRequestModel();
			patch.ApplyTo(response);
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3d5bb9d30b667c96c0a820328f7a9954</Hash>
</Codenesium>*/