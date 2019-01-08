using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiVPersonServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVPersonServerModelMapper();
			var model = new ApiVPersonServerRequestModel();
			model.SetProperties("A");
			ApiVPersonServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVPersonServerModelMapper();
			var model = new ApiVPersonServerResponseModel();
			model.SetProperties(1, "A");
			ApiVPersonServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVPersonServerModelMapper();
			var model = new ApiVPersonServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiVPersonServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVPersonServerRequestModel();
			patch.ApplyTo(response);
			response.PersonName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>8d6b39a21ec3bbe0ad5aa48fef308c75</Hash>
</Codenesium>*/