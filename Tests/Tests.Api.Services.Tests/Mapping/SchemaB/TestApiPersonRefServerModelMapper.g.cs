using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PersonRef")]
	[Trait("Area", "ApiModel")]
	public class TestApiPersonRefServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPersonRefServerModelMapper();
			var model = new ApiPersonRefServerRequestModel();
			model.SetProperties(1, 1);
			ApiPersonRefServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.PersonAId.Should().Be(1);
			response.PersonBId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPersonRefServerModelMapper();
			var model = new ApiPersonRefServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiPersonRefServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.PersonAId.Should().Be(1);
			response.PersonBId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPersonRefServerModelMapper();
			var model = new ApiPersonRefServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiPersonRefServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPersonRefServerRequestModel();
			patch.ApplyTo(response);
			response.PersonAId.Should().Be(1);
			response.PersonBId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>09175bbfb0e1b7f107f42acf7eafa927</Hash>
</Codenesium>*/