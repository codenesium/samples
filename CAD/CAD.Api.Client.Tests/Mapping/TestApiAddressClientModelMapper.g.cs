using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Address")]
	[Trait("Area", "ApiModel")]
	public class TestApiAddressModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiAddressModelMapper();
			var model = new ApiAddressClientRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			ApiAddressClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.State.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiAddressModelMapper();
			var model = new ApiAddressClientResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A");
			ApiAddressClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.State.Should().Be("A");
			response.Zip.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d4aa0ac6c229b62fbef1c2e69d381906</Hash>
</Codenesium>*/