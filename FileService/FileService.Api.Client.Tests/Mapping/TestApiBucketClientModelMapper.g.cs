using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Bucket")]
	[Trait("Area", "ApiModel")]
	public class TestApiBucketModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiBucketModelMapper();
			var model = new ApiBucketClientRequestModel();
			model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiBucketClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiBucketModelMapper();
			var model = new ApiBucketClientResponseModel();
			model.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiBucketClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d207865866c4dcb06748277f6a78e30d</Hash>
</Codenesium>*/