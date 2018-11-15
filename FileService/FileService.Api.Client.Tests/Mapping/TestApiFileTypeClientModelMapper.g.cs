using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "FileType")]
	[Trait("Area", "ApiModel")]
	public class TestApiFileTypeModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiFileTypeModelMapper();
			var model = new ApiFileTypeClientRequestModel();
			model.SetProperties("A");
			ApiFileTypeClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiFileTypeModelMapper();
			var model = new ApiFileTypeClientResponseModel();
			model.SetProperties(1, "A");
			ApiFileTypeClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>b5d8245256f161163a9795a81e907432</Hash>
</Codenesium>*/