using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "ApiModel")]
	public class TestApiIncludedColumnTestModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiIncludedColumnTestModelMapper();
			var model = new ApiIncludedColumnTestClientRequestModel();
			model.SetProperties("A", "A");
			ApiIncludedColumnTestClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiIncludedColumnTestModelMapper();
			var model = new ApiIncludedColumnTestClientResponseModel();
			model.SetProperties(1, "A", "A");
			ApiIncludedColumnTestClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>0b2b76f00fa25a775e4dad3e099d97e8</Hash>
</Codenesium>*/