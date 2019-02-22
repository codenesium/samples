using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PersonType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPersonTypeServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPersonTypeServerModelMapper();
			var model = new ApiPersonTypeServerRequestModel();
			model.SetProperties("A");
			ApiPersonTypeServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPersonTypeServerModelMapper();
			var model = new ApiPersonTypeServerResponseModel();
			model.SetProperties(1, "A");
			ApiPersonTypeServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPersonTypeServerModelMapper();
			var model = new ApiPersonTypeServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPersonTypeServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPersonTypeServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>2274b4b1eb10fe5fa264932f98143a0d</Hash>
</Codenesium>*/