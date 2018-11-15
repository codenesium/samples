using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Bucket")]
	[Trait("Area", "ApiModel")]
	public class TestApiBucketServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiBucketServerModelMapper();
			var model = new ApiBucketServerRequestModel();
			model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiBucketServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiBucketServerModelMapper();
			var model = new ApiBucketServerResponseModel();
			model.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiBucketServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiBucketServerModelMapper();
			var model = new ApiBucketServerRequestModel();
			model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");

			JsonPatchDocument<ApiBucketServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiBucketServerRequestModel();
			patch.ApplyTo(response);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>dbe996fb6b7b2e528dfa9c4af621e3ca</Hash>
</Codenesium>*/