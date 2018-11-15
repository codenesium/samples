using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "ApiModel")]
	public class TestApiRowVersionCheckServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiRowVersionCheckServerModelMapper();
			var model = new ApiRowVersionCheckServerRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiRowVersionCheckServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiRowVersionCheckServerModelMapper();
			var model = new ApiRowVersionCheckServerResponseModel();
			model.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiRowVersionCheckServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiRowVersionCheckServerModelMapper();
			var model = new ApiRowVersionCheckServerRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			JsonPatchDocument<ApiRowVersionCheckServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiRowVersionCheckServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>4a42374f8020e1cecc5dd500058b7992</Hash>
</Codenesium>*/