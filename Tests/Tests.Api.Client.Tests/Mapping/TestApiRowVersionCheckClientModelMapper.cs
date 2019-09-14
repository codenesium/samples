using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "ApiModel")]
	public class TestApiRowVersionCheckModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiRowVersionCheckModelMapper();
			var model = new ApiRowVersionCheckClientRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiRowVersionCheckClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiRowVersionCheckModelMapper();
			var model = new ApiRowVersionCheckClientResponseModel();
			model.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiRowVersionCheckClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>171f3bd9c7d85afb76317a21cc34fa8d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/