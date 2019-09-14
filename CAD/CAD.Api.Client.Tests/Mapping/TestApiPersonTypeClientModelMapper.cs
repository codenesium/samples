using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PersonType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPersonTypeModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPersonTypeModelMapper();
			var model = new ApiPersonTypeClientRequestModel();
			model.SetProperties("A");
			ApiPersonTypeClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPersonTypeModelMapper();
			var model = new ApiPersonTypeClientResponseModel();
			model.SetProperties(1, "A");
			ApiPersonTypeClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>7803d99a89c8aa4cd326936659a60286</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/