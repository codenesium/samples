using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "ApiModel")]
	public class TestApiPersonModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPersonModelMapper();
			var model = new ApiPersonClientRequestModel();
			model.SetProperties("A");
			ApiPersonClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPersonModelMapper();
			var model = new ApiPersonClientResponseModel();
			model.SetProperties(1, "A");
			ApiPersonClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.PersonName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>defb9cd343570357fd9c42e442c725a1</Hash>
</Codenesium>*/