using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiChainStatuModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiChainStatuModelMapper();
			var model = new ApiChainStatuRequestModel();
			model.SetProperties("A");
			ApiChainStatuResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiChainStatuModelMapper();
			var model = new ApiChainStatuResponseModel();
			model.SetProperties(1, "A");
			ApiChainStatuRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiChainStatuModelMapper();
			var model = new ApiChainStatuRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiChainStatuRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiChainStatuRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>03abcb4597e7aa6e17af09dd69ca42a1</Hash>
</Codenesium>*/