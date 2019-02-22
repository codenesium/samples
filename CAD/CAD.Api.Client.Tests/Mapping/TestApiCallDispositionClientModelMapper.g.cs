using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallDisposition")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallDispositionModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCallDispositionModelMapper();
			var model = new ApiCallDispositionClientRequestModel();
			model.SetProperties("A");
			ApiCallDispositionClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCallDispositionModelMapper();
			var model = new ApiCallDispositionClientResponseModel();
			model.SetProperties(1, "A");
			ApiCallDispositionClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>93160a1e7cc4018a45d18bb92f15c401</Hash>
</Codenesium>*/