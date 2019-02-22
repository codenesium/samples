using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UnitDisposition")]
	[Trait("Area", "ApiModel")]
	public class TestApiUnitDispositionModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiUnitDispositionModelMapper();
			var model = new ApiUnitDispositionClientRequestModel();
			model.SetProperties("A");
			ApiUnitDispositionClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiUnitDispositionModelMapper();
			var model = new ApiUnitDispositionClientResponseModel();
			model.SetProperties(1, "A");
			ApiUnitDispositionClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>b4b9e2358df64ee55b34aa34be354c21</Hash>
</Codenesium>*/