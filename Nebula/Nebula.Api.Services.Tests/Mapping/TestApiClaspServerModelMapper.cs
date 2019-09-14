using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Clasp")]
	[Trait("Area", "ApiModel")]
	public class TestApiClaspServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiClaspServerModelMapper();
			var model = new ApiClaspServerRequestModel();
			model.SetProperties(1, 1);
			ApiClaspServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.NextChainId.Should().Be(1);
			response.PreviousChainId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiClaspServerModelMapper();
			var model = new ApiClaspServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiClaspServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.NextChainId.Should().Be(1);
			response.PreviousChainId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiClaspServerModelMapper();
			var model = new ApiClaspServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiClaspServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiClaspServerRequestModel();
			patch.ApplyTo(response);
			response.NextChainId.Should().Be(1);
			response.PreviousChainId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>02335423432aa9a3081c1c72eece421b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/