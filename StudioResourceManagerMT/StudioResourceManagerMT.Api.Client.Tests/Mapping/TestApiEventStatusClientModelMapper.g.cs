using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventStatusModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiEventStatusModelMapper();
			var model = new ApiEventStatusClientRequestModel();
			model.SetProperties("A");
			ApiEventStatusClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiEventStatusModelMapper();
			var model = new ApiEventStatusClientResponseModel();
			model.SetProperties(1, "A");
			ApiEventStatusClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>4bcae892d9d5348166709f09500b509e</Hash>
</Codenesium>*/