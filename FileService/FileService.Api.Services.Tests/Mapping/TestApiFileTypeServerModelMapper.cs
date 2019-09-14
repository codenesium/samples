using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "FileType")]
	[Trait("Area", "ApiModel")]
	public class TestApiFileTypeServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiFileTypeServerModelMapper();
			var model = new ApiFileTypeServerRequestModel();
			model.SetProperties("A");
			ApiFileTypeServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiFileTypeServerModelMapper();
			var model = new ApiFileTypeServerResponseModel();
			model.SetProperties(1, "A");
			ApiFileTypeServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiFileTypeServerModelMapper();
			var model = new ApiFileTypeServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiFileTypeServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiFileTypeServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>c329d48716cabb5c85d29a69abf3e6a7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/