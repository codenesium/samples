using FileServiceNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Bucket")]
	[Trait("Area", "ApiModel")]
	public class TestApiBucketModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiBucketModelMapper();
			var model = new ApiBucketRequestModel();
			model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiBucketResponseModel response = mapper.MapRequestToResponse(1, model);

			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiBucketModelMapper();
			var model = new ApiBucketResponseModel();
			model.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiBucketRequestModel response = mapper.MapResponseToRequest(model);

			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiBucketModelMapper();
			var model = new ApiBucketRequestModel();
			model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");

			JsonPatchDocument<ApiBucketRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiBucketRequestModel();
			patch.ApplyTo(response);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5b49cdace86af0353fe6f76e06a23cfe</Hash>
</Codenesium>*/